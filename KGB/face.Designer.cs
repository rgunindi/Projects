namespace WindowsFormsApplication5
{
  partial class face
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
      this.components = new System.ComponentModel.Container();
      this.button2 = new System.Windows.Forms.Button();
      this.webBrowser1 = new System.Windows.Forms.WebBrowser();
      this.button1 = new System.Windows.Forms.Button();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label2 = new System.Windows.Forms.Label();
      this.timer2 = new System.Windows.Forms.Timer(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.button4 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      this.SuspendLayout();
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.button2.Location = new System.Drawing.Point(1, 284);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(230, 29);
      this.button2.TabIndex = 7;
      this.button2.Text = "Kayıtları Başlat";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // webBrowser1
      // 
      this.webBrowser1.Location = new System.Drawing.Point(280, 48);
      this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.ScriptErrorsSuppressed = true;
      this.webBrowser1.ScrollBarsEnabled = false;
      this.webBrowser1.Size = new System.Drawing.Size(247, 130);
      this.webBrowser1.TabIndex = 8;
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.button1.Location = new System.Drawing.Point(1, 3);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(230, 29);
      this.button1.TabIndex = 9;
      this.button1.Text = "Hesap Bölümüne Dön";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // listBox1
      // 
      this.listBox1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 20;
      this.listBox1.Location = new System.Drawing.Point(1, 48);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(227, 120);
      this.listBox1.TabIndex = 10;
      // 
      // timer1
      // 
      this.timer1.Interval = 4000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.label2.Location = new System.Drawing.Point(12, 254);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(262, 20);
      this.label2.TabIndex = 12;
      this.label2.Text = "Lütfen Bekleyin Sonuç Alınıyor..";
      this.label2.Visible = false;
      // 
      // timer2
      // 
      this.timer2.Interval = 4000;
      this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.label1.Location = new System.Drawing.Point(276, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(140, 20);
      this.label1.TabIndex = 14;
      this.label1.Text = "Capchtca \' yı Gir";
      this.label1.Visible = false;
      // 
      // button4
      // 
      this.button4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.button4.Location = new System.Drawing.Point(280, 184);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(247, 29);
      this.button4.TabIndex = 16;
      this.button4.Text = "Tamam";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Visible = false;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
      this.textBox1.Cursor = System.Windows.Forms.Cursors.No;
      this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.textBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
      this.textBox1.Location = new System.Drawing.Point(280, 148);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(247, 30);
      this.textBox1.TabIndex = 17;
      this.toolTip1.SetToolTip(this.textBox1, "Capchtca\' yı Buraya Gir !");
      // 
      // pictureBox1
      // 
      this.pictureBox1.ImageLocation = "http://t0.gstatic.com/images?q=tbn:ANd9GcQVbQeZ-AUGECdO59BvxWIt0GQz1sDh1rLBQIS05p" +
          "uJZAKgpjENRg";
      this.pictureBox1.Location = new System.Drawing.Point(486, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(41, 33);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 18;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
      // 
      // pictureBox3
      // 
      this.pictureBox3.Location = new System.Drawing.Point(280, 263);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new System.Drawing.Size(69, 50);
      this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox3.TabIndex = 13;
      this.pictureBox3.TabStop = false;
      this.pictureBox3.Visible = false;
      // 
      // pictureBox2
      // 
      this.pictureBox2.Location = new System.Drawing.Point(280, 263);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(69, 50);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 11;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Visible = false;
      // 
      // face
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.CornflowerBlue;
      this.ClientSize = new System.Drawing.Size(276, 330);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pictureBox3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.webBrowser1);
      this.Controls.Add(this.button2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "face";
      this.Text = "Facebook Kayıt Bölümü";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.face_FormClosed_1);
      this.Load += new System.EventHandler(this.face_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.WebBrowser webBrowser1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Timer timer2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}