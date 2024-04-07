namespace LivePictureViewer;

public partial class WatchFile : Form
{
    public WatchFile()
    {
        InitializeComponent();

        AllowDrop = true;
        textBox1.TextChanged += (s, e) => UpdateImage();
        timer1.Tick += (s, e) => UpdateImage();

        DragEnter += (o, e) =>
        {
            if (e.Data is null) return;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        };

        DragDrop += (o, e) =>
        {
            if (e.Data is null) return;
            if (e.Data.GetData(DataFormats.FileDrop) is not string[] paths) return;
            textBox1.Text = paths.First();
        };
    }

    private void UpdateImage()
    {
        string imagePath = textBox1.Text.Trim();

        if (!File.Exists(imagePath))
        {
            textBox1.BackColor = Color.LightCoral;
            return;
        }

        textBox1.BackColor = Color.White;

        // lock the file for the minimum amount of time
        byte[] bytes = File.ReadAllBytes(imagePath);
        using MemoryStream ms = new(bytes);
        Bitmap bmp = new(ms);

        Image oldImage = pictureBox1.Image;
        pictureBox1.Image = bmp;
        oldImage?.Dispose();
    }
}
