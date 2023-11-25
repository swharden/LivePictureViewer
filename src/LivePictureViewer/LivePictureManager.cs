using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LivePictureViewer;

public class LivePictureManager
{
    private FileSystemWatcher? Watcher;
    public EventHandler<string> ImageFileChanged = delegate { };
    public string Watching = string.Empty;
    public string Showing = string.Empty;
    private DateTime ImageLoaded = DateTime.Now;
    public double ImageLoadedSec => (DateTime.Now - ImageLoaded).TotalSeconds;
    public bool IsImageShowing => !string.IsNullOrWhiteSpace(Showing);
    private string? WatchSingleFile = null;

    public LivePictureManager()
    {

    }

    public static void ShowError(string message)
    {
        MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void WatchFile(string filePath)
    {
        WatchSingleFile = filePath;
        Watching = filePath;
        Watcher?.Dispose();
    }

    public void WatchFolder(string folderPath)
    {
        Watcher?.Dispose();

        WatchSingleFile = null;
        Watching = folderPath;

        Watcher = new FileSystemWatcher(folderPath)
        {
            Filter = "*.*",
            IncludeSubdirectories = true,
            EnableRaisingEvents = true,
            NotifyFilter = NotifyFilters.Attributes
                             | NotifyFilters.CreationTime
                             | NotifyFilters.DirectoryName
                             | NotifyFilters.FileName
                             | NotifyFilters.LastWrite
                             | NotifyFilters.Size,
        };

        Watcher.Changed += OnWatcherNotify;
        Watcher.Created += OnWatcherNotify;
    }

    private void OnWatcherNotify(object sender, FileSystemEventArgs e)
    {
        if (!File.Exists(e.FullPath))
            return;

        string[] ImageExtensions = [".jpeg", ".jpg", ".png", ".bmp"];
        string ext = Path.GetExtension(e.FullPath);
        if (!ImageExtensions.Contains(ext))
            return;

        ShowImage(e.FullPath);
    }

    public void Watch(string path)
    {
        if (Directory.Exists(path))
        {
            WatchFolder(path);
        }
        else if (File.Exists(path))
        {
            WatchFile(path);
        }
    }

    public void ShowImage(string path)
    {
        ImageLoaded = DateTime.Now;
        Showing = path;
        ImageFileChanged.Invoke(this, path);
    }
}
