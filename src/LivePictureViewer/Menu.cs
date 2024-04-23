namespace LivePictureViewer;

public partial class Menu : Form
{
    public Menu()
    {
        InitializeComponent();

        button1.Click += (s, e) =>
        {
            Hide();
            new WatchFolder().ShowDialog();
            Close();
        };

        button2.Click += (s, e) =>
        {
            Hide();
            new WatchFile().ShowDialog();
            Close();
        };

        button3.Click += (s, e) =>
        {
            Hide();
            new WatchFolder2().ShowDialog();
            Close();
        };
    }
}
