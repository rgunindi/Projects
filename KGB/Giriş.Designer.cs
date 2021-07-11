namespace WindowsFormsApplication5
{
  partial class Giriş
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
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label3 = new System.Windows.Forms.Label();
      this.timer2 = new System.Windows.Forms.Timer(this.components);
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(164, 24);
      this.label1.TabIndex = 0;
      this.label1.Text = "HOŞ GELDİNİZ..";
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button1.ForeColor = System.Drawing.Color.White;
      this.button1.Location = new System.Drawing.Point(362, 0);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(145, 33);
      this.button1.TabIndex = 2;
      this.button1.Text = "Giriş";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.label2.Location = new System.Drawing.Point(12, 46);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(102, 24);
      this.label2.TabIndex = 3;
      this.label2.Text = "Hakkında:";
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 80;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.label3.Location = new System.Drawing.Point(328, 281);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(179, 24);
      this.label3.TabIndex = 4;
      this.label3.Text = "Coder ŞehSuVaRi";
      this.label3.Visible = false;
      // 
      // timer2
      // 
      this.timer2.Enabled = true;
      this.timer2.Interval = 80;
      this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::KGB.Properties.Resources.YBnr1;
      this.pictureBox1.Location = new System.Drawing.Point(-2, 308);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(509, 68);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 5;
      this.pictureBox1.TabStop = false;
      // 
      // Giriş
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.CornflowerBlue;
      this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.ClientSize = new System.Drawing.Size(506, 375);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label1);
      this.ForeColor = System.Drawing.Color.Coral;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.Name = "Giriş";
      this.Text = "Giriş||Versiyon:1.0.0";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Giriş_FormClosed);
      this.Load += new System.EventHandler(this.Giriş_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Timer timer2;
    private System.Windows.Forms.PictureBox pictureBox1;

  }
}