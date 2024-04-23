using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace LivePictureViewer;

public partial class WatchFolder2 : Form
{
    List<Image> LargeImages = [];
    string Watching => textBox1.Text;

    public WatchFolder2()
    {
        InitializeComponent();

        imageList1.ImageSize = new Size(200, 150);
        listView1.LargeImageList = imageList1;
        listView1.SelectedIndexChanged += (s, e) =>
        {
            foreach (int i in listView1.SelectedIndices)
            {
                pictureBox1.Image = LargeImages[i];
                return;
            }
            pictureBox1.Image = null;
        };

        textBox1.Text = @"C:\Users\scott\Documents\GitHub\ScottPlot\dev\www\cookbook\5.0\images";

        Shown += (s, e) =>
        {
            Application.DoEvents();
            ScanFolder();
        };

        button1.Click += (s, e) => ScanFolder();
        button2.Click += (s, e) => ScanFolder(@"C:\Users\scott\Documents\GitHub\ScottPlot\dev\www\cookbook\5.0\images");
        button3.Click += (s, e) => ScanFolder(@"C:\Users\scott\Documents\GitHub\ScottPlot\src\ScottPlot5\ScottPlot5 Tests\bin\Debug\net8.0\test-images");
    }

    private void ScanFolder(string folder)
    {
        textBox1.Text = folder;
        ScanFolder();
    }

    private void ScanFolder()
    {
        Text = "Loading...";

        LargeImages.Clear();
        imageList1.Images.Clear();
        listView1.Items.Clear();

        if (!Directory.Exists(textBox1.Text))
        {
            Text = "Directory does not exist";
            return;
        }

        string[] imageFiles = Directory.GetFiles(Watching, "*.png");

        if (textBox2.Text.Length > 0)
            imageFiles = imageFiles
                .Where(x => Path.GetFileNameWithoutExtension(x).Contains(textBox2.Text, StringComparison.InvariantCultureIgnoreCase))
                .ToArray();

        for (int i = 0; i < imageFiles.Length; i++)
        {
            Text = $"Loading {i + 1} of {imageFiles.Length}...";

            string imageFile = imageFiles[i];
            Image img = Image.FromFile(imageFile);
            LargeImages.Add(img);

            Image thumbnail = GetThumbnail(img, imageList1.ImageSize.Width, imageList1.ImageSize.Height);
            imageList1.Images.Add(thumbnail);
            ListViewItem item = new(Path.GetFileNameWithoutExtension(imageFile))
            {
                ImageIndex = imageList1.Images.Count - 1,
            };
            listView1.Items.Add(item);
        }

        Text = $"Loaded {imageFiles.Length} images";
    }

    private Image GetThumbnail(Image img, int width, int height)
    {
        double ratioX = (double)width / img.Width;
        double ratioY = (double)height / img.Height;
        double ratio = Math.Min(ratioX, ratioY);
        int newWidth = (int)(img.Width * ratio);
        int newHeight = (int)(img.Height * ratio);

        Bitmap bmp = new(width, height);
        using Graphics g = Graphics.FromImage(bmp);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        int posX = (width - newWidth) / 2;
        int posY = (height - newHeight) / 2;
        g.DrawImage(img, posX, posY, newWidth, newHeight);

        return bmp;
    }
}
