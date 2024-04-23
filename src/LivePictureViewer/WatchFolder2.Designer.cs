namespace LivePictureViewer;

partial class WatchFolder2
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
        listView1 = new ListView();
        pictureBox1 = new PictureBox();
        imageList1 = new ImageList(components);
        button1 = new Button();
        textBox1 = new TextBox();
        button2 = new Button();
        button3 = new Button();
        textBox2 = new TextBox();
        label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // listView1
        // 
        listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        listView1.Location = new Point(12, 70);
        listView1.Name = "listView1";
        listView1.Size = new Size(337, 409);
        listView1.TabIndex = 0;
        listView1.UseCompatibleStateImageBehavior = false;
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBox1.BackColor = SystemColors.ControlDark;
        pictureBox1.Location = new Point(355, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(635, 496);
        pictureBox1.TabIndex = 1;
        pictureBox1.TabStop = false;
        // 
        // imageList1
        // 
        imageList1.ColorDepth = ColorDepth.Depth32Bit;
        imageList1.ImageSize = new Size(16, 16);
        imageList1.TransparentColor = Color.Transparent;
        // 
        // button1
        // 
        button1.Location = new Point(12, 12);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 2;
        button1.Text = "Refresh";
        button1.UseVisualStyleBackColor = true;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(12, 41);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(337, 23);
        textBox1.TabIndex = 3;
        // 
        // button2
        // 
        button2.Location = new Point(93, 12);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 4;
        button2.Text = "Cookbook";
        button2.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Location = new Point(174, 12);
        button3.Name = "button3";
        button3.Size = new Size(75, 23);
        button3.TabIndex = 5;
        button3.Text = "Tests";
        button3.UseVisualStyleBackColor = true;
        // 
        // textBox2
        // 
        textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        textBox2.Location = new Point(63, 485);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(286, 23);
        textBox2.TabIndex = 6;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        label1.AutoSize = true;
        label1.Location = new Point(12, 488);
        label1.Name = "label1";
        label1.Size = new Size(45, 15);
        label1.TabIndex = 7;
        label1.Text = "Search:";
        // 
        // WatchFolder2
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1002, 520);
        Controls.Add(label1);
        Controls.Add(textBox2);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Controls.Add(pictureBox1);
        Controls.Add(listView1);
        Name = "WatchFolder2";
        Text = "WatchFolder2";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListView listView1;
    private PictureBox pictureBox1;
    private ImageList imageList1;
    private Button button1;
    private TextBox textBox1;
    private Button button2;
    private Button button3;
    private TextBox textBox2;
    private Label label1;
}