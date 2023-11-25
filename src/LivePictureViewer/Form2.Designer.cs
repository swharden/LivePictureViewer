namespace LivePictureViewer;

partial class Form2
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pictureBox1 = new PictureBox();
        lblWatching = new Label();
        lblViewingFile = new Label();
        lblUpdated = new Label();
        cbActualSize = new CheckBox();
        cbAlwaysOnTop = new CheckBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBox1.BackColor = SystemColors.ControlDark;
        pictureBox1.Location = new Point(12, 103);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(630, 397);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // lblWatching
        // 
        lblWatching.AutoSize = true;
        lblWatching.Location = new Point(12, 9);
        lblWatching.Name = "lblWatching";
        lblWatching.Size = new Size(322, 15);
        lblWatching.TabIndex = 3;
        lblWatching.Text = "drag/drop a file or folder onto this application to get started";
        // 
        // lblViewingFile
        // 
        lblViewingFile.AutoSize = true;
        lblViewingFile.Location = new Point(12, 31);
        lblViewingFile.Name = "lblViewingFile";
        lblViewingFile.Size = new Size(127, 15);
        lblViewingFile.TabIndex = 4;
        lblViewingFile.Text = "Viewing: no file loaded";
        // 
        // lblUpdated
        // 
        lblUpdated.AutoSize = true;
        lblUpdated.Location = new Point(12, 54);
        lblUpdated.Name = "lblUpdated";
        lblUpdated.Size = new Size(76, 15);
        lblUpdated.TabIndex = 5;
        lblUpdated.Text = "Updated: n/a";
        // 
        // cbActualSize
        // 
        cbActualSize.AutoSize = true;
        cbActualSize.Location = new Point(15, 78);
        cbActualSize.Name = "cbActualSize";
        cbActualSize.Size = new Size(83, 19);
        cbActualSize.TabIndex = 6;
        cbActualSize.Text = "Actual Size";
        cbActualSize.UseVisualStyleBackColor = true;
        // 
        // cbAlwaysOnTop
        // 
        cbAlwaysOnTop.AutoSize = true;
        cbAlwaysOnTop.Checked = true;
        cbAlwaysOnTop.CheckState = CheckState.Checked;
        cbAlwaysOnTop.Location = new Point(104, 78);
        cbAlwaysOnTop.Name = "cbAlwaysOnTop";
        cbAlwaysOnTop.Size = new Size(101, 19);
        cbAlwaysOnTop.TabIndex = 7;
        cbAlwaysOnTop.Text = "Always on top";
        cbAlwaysOnTop.UseVisualStyleBackColor = true;
        // 
        // Form2
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(654, 512);
        Controls.Add(cbAlwaysOnTop);
        Controls.Add(cbActualSize);
        Controls.Add(lblUpdated);
        Controls.Add(lblViewingFile);
        Controls.Add(lblWatching);
        Controls.Add(pictureBox1);
        Name = "Form2";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Live Picture Viewer";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private Label lblWatching;
    private Label lblViewingFile;
    private Label lblUpdated;
    private CheckBox cbActualSize;
    private CheckBox cbAlwaysOnTop;
}