using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace WindowsFormsApplication5
{
  public partial class face : Form
  {
    public face()
    {
      InitializeComponent();
    }
    OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/mails.accdb");
    OleDbConnection bags = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/face.accdb");
    string w1, w2;
    WebBrowser vb = new WebBrowser();
    public void faces()
    {

      if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
      {

        // IEnumerator enumerator;
        this.webBrowser1.Document.GetElementById("firstname").SetAttribute("value", "Kazanov");
        this.webBrowser1.Document.GetElementById("lastname").SetAttribute("value", "Recai");
        this.webBrowser1.Document.GetElementById("credential").SetAttribute("value", Form1.name + "@mynet.com");
        this.webBrowser1.Document.GetElementById("gender").SetAttribute("value", "2");

        this.webBrowser1.Document.GetElementById("month").SetAttribute("value", "1");
        this.webBrowser1.Document.GetElementById("day").SetAttribute("value", "1");
        this.webBrowser1.Document.GetElementById("year").SetAttribute("value", "1980");

        this.webBrowser1.Document.GetElementById("password").SetAttribute("value", Form1.pas);
        webBrowser1.Document.All["submit"].InvokeMember("click");
       
       
      //  webBrowser1.Document.All["captcha_response"].InnerText = "hariano 808";
        timer2.Enabled = true;
        //   webBrowser1.Document.All["captcha_submit_text"].InvokeMember("click");

        // this.webBrowser1.Document.GetElementById("sozlesmec").SetAttribute("value", "1980");

        /*
        HtmlElementCollection all = this.webBrowser1.Document.All;
        IEnumerator enumerator;
        try
        {
          enumerator = all.GetEnumerator();
          while (enumerator.MoveNext())
          {
            HtmlElement current = (HtmlElement)enumerator.Current;
            if (current.GetAttribute("name") == "submit")
            {
              current.InvokeMember("click");

            }
          }

        }
        finally
        {

        }
        webBrowser1.Document.All["imageanswer"].InnerText = "CYU5";
        webBrowser1.Document.All["mform"].InvokeMember("submit");
        */
      }

      else
      {
        MessageBox.Show("Biraz Bekleyin Ve Tekrar Deneyin..");
      }
      w1 = Form1.name;
      w2 = Form1.pas;
     // MessageBox.Show("Facebook Kullanıcı Adınız:" + w1.ToString() + "Password:" + w2.ToString());
 
    }
    public void kayit()
    {
      try
      {
        DataSet ds = new DataSet();
        if (bags.State == ConnectionState.Closed)
        {
          bags.Open();}{
          ds.Clear();
          OleDbCommand komut = new OleDbCommand("INSERT INTO Face (isim,sifre)Values ('" + w1 + "','" +w2 + "')", bags);
          komut.ExecuteNonQuery();

        //  bag.Close();

        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        bags.Close();
      }



    }
    private void button2_Click(object sender, EventArgs e)
    {
      string a, b;
      OleDbCommand komut = new OleDbCommand("Select * From Mail", bag);
      if (bag.State == ConnectionState.Closed)
      {
        bag.Open();
      }{

        OleDbDataReader oku = komut.ExecuteReader();

        oku.Read();
        while (oku.Read())
        {
          a = oku["mail"].ToString();
          b = oku["sifre"].ToString();
          faces();
        }
        
      }
    }
    public static string adres;
    public void faceveri() 
    {
    
    
    }
    private void face_Load(object sender, EventArgs e)
    {
      webBrowser1.Navigate("http://m.facebook.com/r.php?refid=0");
     
       
      //
      OleDbCommand komut = new OleDbCommand("Select * From face", bags);
      if (bags.State == ConnectionState.Closed)
      {
        bags.Open();

        OleDbDataReader oku = komut.ExecuteReader();

        oku.Read();
        listBox1.Items.Add("KAYITLI FACEBOOK HESAPLARINIZ");
        try
        {
          while (oku.Read())
          {

            listBox1.Items.Add(oku["isim"].ToString() + " Şifreniz: " + oku["sifre"].ToString());


          }
        }
      
      catch (Exception ex)
      {
     // MessageBox.Show(ex.Message);
      }
      }
    }
   
  public static  bool knt;
    private void timer1_Tick(object sender, EventArgs e)
    {

      try
      {
        HtmlElementCollection all = this.webBrowser1.Document.All;
        IEnumerator enumerator;
        enumerator = all.GetEnumerator();
        while (enumerator.MoveNext())
        {
          HtmlElement current = (HtmlElement)enumerator.Current;
          //if (current.GetAttribute("href") == "http://profil.eksenim.mynet.com/kayitolbirinciadim.jsp")
          {
            if (this.webBrowser1.DocumentText.IndexOf("Onay Kodu") != -1)
            {
              knt = true;
            
            label2.Text = "   Sonuç Alındı,Başarılı";
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            
            timer1.Enabled = false;
          Hesap.w3=("Facebook Üye Kayıt Yapıldı ");
          Hesap.knt = 1;
            timer1.Enabled = false;
         
            }
          }
        }

      }
      finally
      {

      }

      if (knt==true)
      {
        MessageBox.Show("Kayıt Yapıldı");
        kayit();

      }
      else
      {
        MessageBox.Show("Kayıt Yapılamadı");
        timer1.Enabled = false;
        label2.Text = "Sonuç Başarısız,Tekrar Dene";
        pictureBox2.Visible = false;
        pictureBox3.Visible = true;
      }
    }

    private void face_FormClosed(object sender, FormClosedEventArgs e)
    {
     
     
      if (bag.State==ConnectionState.Open)
      {
        bag.Close();
      }
      Application.Exit();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void timer2_Tick(object sender, EventArgs e)
    {
      this.Width = 543;
      adres = webBrowser1.Url.ToString();
      if (webBrowser1.Url.ToString() == "http://m.facebook.com/r.php?refid=0")
      {
      
    
        timer2.Enabled = false;
        button4.Visible = true;
        label1.Visible = true;
        webBrowser1.Visible = true;
        
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
     
    }

    private void button4_Click(object sender, EventArgs e)
    {
      this.Width = 286;
      try
      {
        webBrowser1.Document.All["captcha_response"].InnerText = textBox1.Text;
        webBrowser1.Document.All["captcha_submit_text"].InvokeMember("click");

        timer1.Enabled = true;
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message);

      }
     
    }

    private void face_FormClosed_1(object sender, FormClosedEventArgs e)
    {
      
      Hesap h = new Hesap();
      h.Show();
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      webBrowser1.Refresh();
    }
  }
}
