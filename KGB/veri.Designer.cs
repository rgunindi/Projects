namespace WindowsFormsApplication5
{
  partial class veri
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
      this.button1 = new System.Windows.Forms.Button();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Location = new System.Drawing.Point(32, 279);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(280, 26);
      this.button1.TabIndex = 1;
      this.button1.Text = "Saldırı Departmanı";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // listBox1
      // 
      this.listBox1.BackColor = System.Drawing.SystemColors.ControlDark;
      this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.Location = new System.Drawing.Point(0, 0);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(227, 273);
      this.listBox1.TabIndex = 4;
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // veri
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlDark;
      this.ClientSize = new System.Drawing.Size(349, 305);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.button1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "veri";
      this.Text = "Mail Listem";
      this.Load += new System.EventHandler(this.Form3_Load);
      this.ResumeLayout(false);

    }

    #endregion

    // private mailsDataSet1 mailsDataSet1;
  //  private mailsDataSet1TableAdapters.MailTableAdapter mailTableAdapter;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Timer timer1;
  }
}