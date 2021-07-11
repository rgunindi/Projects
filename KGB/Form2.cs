using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
          
      {
    //    MessageBox.Show("Çalıştı");
      }
    }
  
    private void button1_Click(object sender, EventArgs e)
    {
     
      Hesap.w= textBox1.Text;

      this.Hide();
     

    }
  }
}
