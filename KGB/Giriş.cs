using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace WindowsFormsApplication5
{
  public partial class Giriş : Form
  {
    public Giriş()
    {
      InitializeComponent();
    }
    [DllImport("wininet.dll", CharSet = CharSet.Auto)]
    extern static bool InternetGetConnectedState(ref InternetGetConnectedStateFlags Description, int ReservedValue);
    [Flags]
    public enum InternetGetConnectedStateFlags
    {
      INTERNET_CONNECTION_MODEM = 0x01,
      INTERNET_CONNECTION_LAN = 0x02,
      INTERNET_CONNECTION_PROXY = 0x04,
      INTERNET_CONNECTION_RAS_INSTALLED = 0x10,
      INTERNET_CONNECTION_OFFLINE = 0x20,
      INTERNET_CONNECTION_CONFIGURED = 0x40
    }    string a;
    int c,d;
    WebBrowser br = new WebBrowser();
    private void Giriş_Load(object sender, EventArgs e)
    {
      button1.BackColor = Color.Black;
      button1.ForeColor = Color.White;
      string w="Med-Cezir";
    button1.Enabled = false;
      br.Navigate("http://meddicezir.onlinewebshop.net/");
      timer2.Enabled = true;
   
      a = "KULLANMANIZ DİLEĞİYLE..";
     
      c=Strings.Len(a);
    
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (d == 1)
      {

        InternetGetConnectedStateFlags flags = 0;
        bool baglantı = InternetGetConnectedState(ref flags, 0);
        if (baglantı)
        {
          Hesap hs = new Hesap();
          hs.Show();
          this.Hide();
        }

        else
        {
          MessageBox.Show("İnternet Bağlantınız Yok Program Sonlanıyor ..", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

          Application.Exit();
        }
      }
      else

      { 
        MessageBox.Show("Program;Coder Tarafından Geçici SÜreliğine Bloke Edilmiştir..","Versiyon:1.0.0");
      Application.Exit();
     
      }
    }
    string w;
    int i=0;
    private void timer1_Tick(object sender, EventArgs e)
    {
      i += 1;
        label2.Text = Strings.Left(a, i);
        if (i==c)
        {
          timer1.Stop();
          label3.Visible = true;
        }
      
    }

    private void Giriş_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      if (br.ReadyState == WebBrowserReadyState.Complete)
      {
        if (br.DocumentTitle == "Med-Cezir")
        {
          d = 1;
          button1.BackColor = Color.Gray;
          button1.Enabled = true;
          timer2.Enabled = false;
        }
        else
        {
          d = 0;
          timer2.Enabled = false;
          MessageBox.Show("Program;Coder Tarafından Geçici SÜreliğine Bloke Edilmiştir..", "Versiyon:1.0.0",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

      } 
    }
  }
}
