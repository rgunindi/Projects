using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace WindowsFormsApplication5
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }


  


    public void mail()
    {
      //SqlConnection bag = new SqlConnection();
      //bag.ConnectionString = "Data Source=C:/Mail/Mail.mdf;Initial Catalog=mail;Integrated Security=True";
      //bag.Open();
      MessageBox.Show("Açıldı..");
    }

    public  void mynet()
    {

 //     webBrowser1.Document.All["imageanswer"].InnerText = a.ToString() ;
 //  webBrowser1.Document.All["mform"].InvokeMember("submit");
}

       private void button1_Click(object sender, EventArgs e)
    {    mynet();

          }
    Random rs = new Random();
    Random rss = new Random();

    char[] karakter = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
    
  
     public string uret(int size)//size, Üretilicek şifrenin kaç karakter olucağı  
    {
      string result = string.Empty;
      for (int i = 0; i < 5; i++)
      {
        result += karakter[rs.Next(0, karakter.Length - 1)].ToString();
      }
      return result;
      
         }
     public string uret2(int size)//size, Üretilicek şifrenin kaç karakter olucağı  
     {
       char[] karakterq = "0123456789".ToCharArray();
       string results = string.Empty;
       for (int i = 0; i < 9; i++)
       {
         results += karakterq[rs.Next(0, karakterq.Length - 1)].ToString();
       }
       return results;

     }  
    private void button2_Click(object sender, EventArgs e)
    {
      mynet();
    }

    private void button3_Click(object sender, EventArgs e)
    {
     email();
     
    }
    public static string name,name2;
    public static string pas;
    public void uretken()
    {
      int sayi;
      char[] karakters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
      
      Random r = new Random();
      sayi = r.Next(9);
   
    
      //webBrowser1.Navigate(("http://uyeler.mynet.com/index/mymailkayit.html"));
      string cb = uret(5).ToString();
      cb = karakters[sayi] + cb;
      name = cb;
     
      MessageBox.Show(name2.ToString());
    }
    public void email()
    {
      int sayi;
      char[] karakters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
      Random r = new Random();
      sayi = r.Next(9);
      //webBrowser1.Navigate(("http://uyeler.mynet.com/index/mymailkayit.html"));
      string cb = uret(5).ToString();
      cb = karakters[sayi] + cb;
      name= cb;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      //mail();
     email();
     
      pas = uret2(10);

      name2 = uret2(8);

    //  Giriş gs = new Giriş();
     // gs.Show();
      Hesap hs = new Hesap();
      hs.Show();
      
     

    }

    private void Form1_Shown(object sender, EventArgs e)
    {
      this.Hide();
    }

   // private void Form1_FormClosed(object sender, FormClosedEventArgs e)
  //  {
    //  Application.Exit();
  //  }
   
  }
}
