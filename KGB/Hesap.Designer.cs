namespace WindowsFormsApplication5
{
  partial class Hesap
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hesap));
      this.button1 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label2 = new System.Windows.Forms.Label();
      this.timer2 = new System.Windows.Forms.Timer(this.components);
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.timer3 = new System.Windows.Forms.Timer(this.components);
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.button4 = new System.Windows.Forms.Button();
      this.timer4 = new System.Windows.Forms.Timer(this.components);
      this.webBrowser1 = new System.Windows.Forms.WebBrowser();
      this.button5 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.timer5 = new System.Windows.Forms.Timer(this.components);
      this.timer6 = new System.Windows.Forms.Timer(this.components);
      this.timer7 = new System.Windows.Forms.Timer(this.components);
      this.timer8 = new System.Windows.Forms.Timer(this.components);
      this.listBox2 = new System.Windows.Forms.ListBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.button1.Location = new System.Drawing.Point(12, 33);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(230, 29);
      this.button1.TabIndex = 0;
      this.button1.TabStop = false;
      this.button1.Text = "Kayıt İşlemini Başlatın.";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button3
      // 
      this.button3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.button3.Location = new System.Drawing.Point(248, 140);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(213, 29);
      this.button3.TabIndex = 5;
      this.button3.Text = "Kayıtlı Mail Listeniz";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.button2.Location = new System.Drawing.Point(12, 140);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(230, 29);
      this.button2.TabIndex = 6;
      this.button2.TabStop = false;
      this.button2.Text = "Saldırı Departmanı";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.label1.Location = new System.Drawing.Point(330, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(155, 20);
      this.label1.TabIndex = 7;
      this.label1.Text = "Coder:ŞehSuVaRi";
      // 
      // timer1
      // 
      this.timer1.Interval = 5000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.label2.Location = new System.Drawing.Point(148, 195);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(262, 20);
      this.label2.TabIndex = 9;
      this.label2.Text = "Lütfen Bekleyin Sonuç Alınıyor..";
      this.label2.Visible = false;
      // 
      // timer2
      // 
      this.timer2.Interval = 4000;
      this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
      // 
      // listBox1
      // 
      this.listBox1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.listBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(12, 68);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(360, 65);
      this.listBox1.TabIndex = 13;
      this.listBox1.TabStop = false;
      // 
      // timer3
      // 
      this.timer3.Interval = 10000;
      this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
      // 
      // pictureBox2
      // 
      this.pictureBox2.Image = global::KGB.Properties.Resources._14_cyrle_four_24;
      this.pictureBox2.Location = new System.Drawing.Point(416, 165);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(69, 50);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 8;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Visible = false;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(-7, 221);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(492, 76);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 2;
      this.pictureBox1.TabStop = false;
      // 
      // button4
      // 
      this.button4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.button4.Location = new System.Drawing.Point(248, 33);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(230, 29);
      this.button4.TabIndex = 14;
      this.button4.TabStop = false;
      this.button4.Text = "awsurveys Kayıt İşlemi";
      this.button4.UseVisualStyleBackColor = false;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // timer4
      // 
      this.timer4.Interval = 3000;
      this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
      // 
      // webBrowser1
      // 
      this.webBrowser1.Location = new System.Drawing.Point(484, 0);
      this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowser1.Name = "webBrowser1";
      this.webBrowser1.ScriptErrorsSuppressed = true;
      this.webBrowser1.Size = new System.Drawing.Size(444, 503);
      this.webBrowser1.TabIndex = 15;
      this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(239, 4);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(75, 23);
      this.button5.TabIndex = 16;
      this.button5.Text = "Git";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new System.EventHandler(this.button5_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(378, 68);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 17;
      // 
      // timer5
      // 
      this.timer5.Interval = 4000;
      this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
      // 
      // timer6
      // 
      this.timer6.Interval = 4000;
      this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
      // 
      // timer7
      // 
      this.timer7.Interval = 500;
      this.timer7.Tick += new System.EventHandler(this.timer7_Tick);
      // 
      // timer8
      // 
      this.timer8.Interval = 2500;
      this.timer8.Tick += new System.EventHandler(this.timer8_Tick);
      // 
      // listBox2
      // 
      this.listBox2.BackColor = System.Drawing.SystemColors.ControlDark;
      this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.listBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
      this.listBox2.FormattingEnabled = true;
      this.listBox2.Location = new System.Drawing.Point(12, 303);
      this.listBox2.Name = "listBox2";
      this.listBox2.Size = new System.Drawing.Size(466, 195);
      this.listBox2.TabIndex = 18;
      this.listBox2.TabStop = false;
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(378, 94);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(100, 20);
      this.textBox2.TabIndex = 19;
      // 
      // Hesap
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ClientSize = new System.Drawing.Size(932, 504);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.listBox2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.button5);
      this.Controls.Add(this.webBrowser1);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.button1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.Name = "Hesap";
      this.Text = "Hesap";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Hesap_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Hesap_FormClosed);
      this.Load += new System.EventHandler(this.Hesap_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hesap_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Timer timer2;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Timer timer3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Timer timer4;
    private System.Windows.Forms.WebBrowser webBrowser1;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Timer timer5;
    private System.Windows.Forms.Timer timer6;
    private System.Windows.Forms.Timer timer7;
    private System.Windows.Forms.Timer timer8;
    private System.Windows.Forms.ListBox listBox2;
    private System.Windows.Forms.TextBox textBox2;
  }
}