namespace LivePictureViewer;

public partial class Form1 : Form
{
    public string ImagePath;

    public Form1()
    {
        InitializeComponent();
        comboBox1.SelectedIndex = 0;

        string defaultImagePath = @"../../../../dev/data/blue-red.png";
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

        ImagePath = path;

        Image originalImage = pictureBox1.Image;
        pictureBox1.Image = Bitmap.FromFile(path);
        originalImage?.Dispose();

        Text = $"{Path.GetFileName(path)} ({pictureBox1.Image.Width}x{pictureBox1.Image.Height})";
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        pictureBox1.SizeMode = checkBox1.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.AutoSize;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        ReloadImage();
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
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
}
