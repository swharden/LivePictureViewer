namespace LivePictureViewer;

public partial class Form1 : Form
{
    string ImagePath = string.Empty;
    DateTime ImageModifiedDate = DateTime.Now;
    TimeSpan ImageAge => DateTime.Now - ImageModifiedDate;

    public Form1()
    {
        InitializeComponent();
        comboBox1.SelectedIndex = 0;

        string defaultImagePath = @"../../../../../dev/data/blue-red.png";
        if (File.Exists(defaultImagePath))
            LoadImage(defaultImagePath);
    }

    public void ReloadImage()
    {
        if (!string.IsNullOrEmpty(ImagePath))
            LoadImage(ImagePath);
    }

    public void LoadImage(string path)
    {
        path = Path.GetFullPath(path);

        if (!File.Exists(path))
            throw new FileNotFoundException(path);

        var bytes = File.ReadAllBytes(path);
        MemoryStream ms = new(bytes);
        Image bmp = Bitmap.FromStream(ms);

        ImagePath = path;

        Image originalImage = pictureBox1.Image;
        pictureBox1.Image = bmp;
        originalImage?.Dispose();

        Text = $"{Path.GetFileName(path)} ({pictureBox1.Image.Width}x{pictureBox1.Image.Height})";
        ImageModifiedDate = File.GetLastWriteTime(path);
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        pictureBox1.SizeMode = cbActualSize.Checked
            ? PictureBoxSizeMode.AutoSize
            : PictureBoxSizeMode.Zoom;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        ReloadImage();
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data is null)
            return;

        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data is null)
            return;

        string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
        LoadImage(paths[0]);
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        pictureBox1.BackColor = comboBox1.Text switch
        {
            "Gray" => Color.Gray,
            "Black" => Color.Black,
            "White" => Color.White,
            "Red" => Color.Red,
            "Green" => Color.Green,
            "Blue" => Color.Blue,
            _ => throw new NotImplementedException(),
        };
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (ImageAge.TotalSeconds < 60)
        {
            lblImageAge.Text = $"{ImageAge.TotalSeconds:N2} sec";
        }
        else if (ImageAge.TotalMinutes < 60)
        {
            lblImageAge.Text = $"{ImageAge.TotalMinutes:N1} min";
        }
        else
        {
            lblImageAge.Text = string.Empty;
        }

        if (ImageAge.TotalSeconds < 5)
        {
            lblImageAge.BackColor = Color.Yellow;
            lblImageAge.ForeColor = Color.Magenta;
        }
        else if (ImageAge.TotalSeconds < 60)
        {
            lblImageAge.BackColor = SystemColors.Control;
            lblImageAge.ForeColor = Color.Magenta;
        }
        else
        {
            lblImageAge.BackColor = SystemColors.Control;
            lblImageAge.ForeColor = SystemColors.GrayText;
        }
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ImagePath))
            return;

        if (cbAutoRefresh.Checked && (File.GetLastWriteTime(ImagePath) != ImageModifiedDate))
        {
            ReloadImage();
        }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        ReloadImage();
    }
}
