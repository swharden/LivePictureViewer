namespace LivePictureViewer;

partial class WatchFile
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
        components = new System.ComponentModel.Container();
        pictureBox1 = new PictureBox();
        textBox1 = new TextBox();
        timer1 = new System.Windows.Forms.Timer(components);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBox1.BackColor = SystemColors.ControlDark;
        pictureBox1.Location = new Point(12, 46);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(550, 326);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // textBox1
        // 
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBox1.Location = new Point(12, 12);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(550, 23);
        textBox1.TabIndex = 1;
        // 
        // timer1
        // 
        timer1.Enabled = true;
        timer1.Interval = 1000;
        // 
        // WatchFile
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(574, 384);
        Controls.Add(textBox1);
        Controls.Add(pictureBox1);
        Name = "WatchFile";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Simple";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private TextBox textBox1;
    private System.Windows.Forms.Timer timer1;
}