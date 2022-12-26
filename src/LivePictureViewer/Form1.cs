using System.Reflection;
using System.Windows.Forms;

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
        FormClosing += Form1_FormClosing;

        string defaultImagePath = @"../../../../../dev/data/blue-red.png";
        if (File.Exists(defaultImagePath))
            LoadImage(defaultImagePath);
    }

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show(
            text: "Are you sure you want to exit?",
            caption: "Exit",
            buttons: MessageBoxButtons.YesNo,
            icon: MessageBoxIcon.Question);

        if (dialogResult == DialogResult.No)
        {
            e.Cancel = true;
        }
    }

    public void ReloadImage()
    {
        if (!string.IsNullOrEmpty(ImagePath))
            LoadImage(ImagePath);
    }

    private void ClearImage()
    {

    }

    public void LoadImage(string path)
    {
        path = Path.GetFullPath(path);

        if (!File.Exists(path))
        {
            System.Diagnostics.Debug.WriteLine(path);
            Text = "FILE NOT FOUND";
            panel1.Visible = false;
            return;
        }

        try
        {
            var bytes = File.ReadAllBytes(path);
            MemoryStream ms = new(bytes);
            Image bmp = Bitmap.FromStream(ms);
            Image originalImage = pictureBox1.Image;
            pictureBox1.Image = bmp;
            originalImage?.Dispose();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            Text = "INVALID IMAGE";
            panel1.Visible = false;
            return;
        }

        ImagePath = path;
        Text = $"{Path.GetFileName(path)} ({pictureBox1.Image.Width}x{pictureBox1.Image.Height})";
        ImageModifiedDate = File.GetLastWriteTime(path);
        panel1.Visible = true;
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (cbActualSize.Checked)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Size = pictureBox1.Image.Size;
            pictureBox1.Dock = DockStyle.None;
            panel1.AutoScroll = true;
        }
        else
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Size = panel1.Size;
            pictureBox1.Dock = DockStyle.Fill;
            panel1.AutoScroll = false;
        }
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
        Color color = comboBox1.Text switch
        {
            "Gray" => Color.Gray,
            "Black" => Color.Black,
            "White" => Color.White,
            "Red" => Color.Red,
            "Green" => Color.Green,
            "Blue" => Color.Blue,
            _ => throw new NotImplementedException(),
        };
        pictureBox1.BackColor = color;
        panel1.BackColor = color;
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
