namespace LivePictureViewer;

public partial class Form2 : Form
{
    readonly LivePictureManager Manager = new();
    readonly System.Windows.Forms.Timer ImageTimer = new() { Interval = 10 };
    string? ImageToShow = null;

    public Form2()
    {
        InitializeComponent();
        SetupDragDrop();

        ImageTimer.Start();
        ImageTimer.Tick += (s, e) => UpdateGuiState();
        Manager.ImageFileChanged += (s, e) => ImageToShow = e;
        pictureBox1.MouseClick += (s, e) => { if (e.Button == MouseButtons.Right) LaunchRightClickMenu(); };

        FormClosing += (s, e) =>
        {
            ImageTimer.Stop();

            DialogResult dialogResult = MessageBox.Show(
                text: "Are you sure you want to exit?",
                caption: "Exit",
                buttons: MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
                ImageTimer.Start();
            }
        };

        Manager.Watch(@"C:\Users\scott\Documents\GitHub\ScottPlot\src\ScottPlot4\ScottPlot.Tests\bin");
        Manager.ShowImage(@"C:\Users\scott\Documents\important\zoom-logo.jpeg");
    }

    void SetupDragDrop()
    {
        AllowDrop = true;

        DragEnter += (o, e) =>
        {
            if (e.Data is null) return;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        };

        DragDrop += (o, e) =>
        {
            if (e.Data is null) return;
            string[]? paths = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (paths is null || paths.Length == 0)
                return;
            Manager.Watch(paths.First());
        };
    }

    void UpdateGuiState()
    {
        TopMost = cbAlwaysOnTop.Checked;

        pictureBox1.SizeMode = cbActualSize.Checked ? PictureBoxSizeMode.CenterImage : PictureBoxSizeMode.Zoom;

        if (pictureBox1.ImageLocation != ImageToShow)
        {
            pictureBox1.ImageLocation = ImageToShow;
        }

        lblWatching.Text = $"Watching: {Manager.Watching}";

        if (Manager.IsImageShowing)
        {
            lblViewingFile.Text = $"Showing: {Manager.Showing}";
            lblUpdated.Text = $"Age: {Manager.ImageLoadedSec:N2} sec";
            lblUpdated.BackColor = Manager.ImageLoadedSec < 10 ? Color.Yellow : SystemColors.Control;
        }
        else
        {
            lblViewingFile.Text = string.Empty;
            lblUpdated.Text = string.Empty;
        }
    }

    void LaunchRightClickMenu()
    {
        ContextMenuStrip cm = new();
        ToolStripItem watchedPathItem = cm.Items.Add("Copy Watched Path");
        ToolStripItem displayedImagePathItem = cm.Items.Add("Copy Image Path");
        ToolStripItem displayedImageFolderPathItem = cm.Items.Add("Copy Image Folder Path");
        ToolStripItem displayedImageDataItem = cm.Items.Add("Copy Image");

        cm.ItemClicked += (s, e) =>
        {
            if (e.ClickedItem is null)
                return;

            if (e.ClickedItem == watchedPathItem)
            {
                Clipboard.SetText(Manager.Watching);
            }
            else if (e.ClickedItem == displayedImagePathItem)
            {
                Clipboard.SetText(Manager.Showing);
            }
            else if (e.ClickedItem == displayedImageFolderPathItem)
            {
                Clipboard.SetText(Path.GetDirectoryName(Manager.Showing)!);
            }
            else if (e.ClickedItem == displayedImageDataItem)
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
        };

        cm.Show(Cursor.Position);
    }
}
