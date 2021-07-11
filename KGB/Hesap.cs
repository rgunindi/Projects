using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using System.Threading;


namespace WindowsFormsApplication5
{
  public partial class Hesap : Form
  {
    public Hesap()
    {
      InitializeComponent();
    }
    WebBrowser brv = new WebBrowser();


    OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/mails.accdb");
    public static string w,w3;
    public static string w1;
    public static string w2;
    
    public void kntrol()
    {
      try
      {
        if (kntrols == 1)
        {

          brv.Document.All["B2"].InvokeMember("click");

          listBox1.Items.Add("Hesabınız Aktifleştirilmiştir.");

        }
        else
          listBox1.Items.Add("Hesap Aktifleştirilmedi");
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message);
      }
     
      
    }
    int c;
   
    public void pay()
    {
      email();
     string url=webBrowser1.Url.ToString(); 

      listBox1.Items.Add("KAYIT ALANINA DÖNÜLDÜ");

      listBox1.Items.Add("----------------------");
      if (url != "http://www.awsurveys.com/adduser.cfm")
      {
        webBrowser1.Navigate("http://www.awsurveys.com/adduser.cfm");
      }
      else
      {

        while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
        {
          Application.DoEvents();


        }
      }
      this.webBrowser1.Document.GetElementById("UserName").SetAttribute("value", name);
      this.webBrowser1.Document.GetElementById("Password").SetAttribute("value", Form1.pas);
      this.webBrowser1.Document.GetElementById("FirstName").SetAttribute("value", name);
      this.webBrowser1.Document.GetElementById("LastName").SetAttribute("value", Form1.name);

      this.webBrowser1.Document.GetElementById("EmailAddress").SetAttribute("value", name + "@mynet.com");
      listBox1.Items.Add("GÜVENLİK KODU GİR");
      //NumberBelow
      this.webBrowser1.Document.GetElementById("NumberBelow").SetAttribute("value", textBox1.Text);
      webBrowser1.Document.Forms[0].InvokeMember("submit");
      paykayit();

      payserver();
   //   else
       // timer4.Enabled = true;
      
    }
    
    public void payserver()
    {
      string a;
      int kntr=1;
      switch (SayiOlustur().ToString())
      {
        case "0": a="I found a great site";
        break;
        case "1": a = "Missing Aspects of Interest"; break;
        case "2": a = "nice"; break;
        case "3": a = "Congratulations have been very nice indeed"; break;
        case "4": a = "A different approach for advertising"; break;
        case "5": a = "A little mixed but beautiful"; break;
        case "6": a = "Content need to be more effective"; break;
        case "7": a = "My opinion: Very nice site"; break;
        default: a = "Nice Site"; break;

      }
      webBrowser1.Navigate("http://www.awsurveys.com/Surveys/Survey1.cfm");
      while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
      {
        Application.DoEvents();
        //Eval1
      }

        try
        {
          

          this.webBrowser1.Document.GetElementById("Eval1").SetAttribute("value", a);
          this.webBrowser1.Document.GetElementById("Eval2").SetAttribute("value", a);
          //login_user
          timer8.Enabled = true;
        }
        catch (Exception ex)
        {
          kntr = 0;
        }
        if (kntr == 0)
        {

          goto yer;
        }
      yer: try
        {
          Application.DoEvents();
          this.webBrowser1.Document.GetElementById("Eval1").SetAttribute("value", a);
          this.webBrowser1.Document.GetElementById("Eval2").SetAttribute("value", a);
          timer8.Enabled = true;
      }
	catch (Exception)
	{
    goto yer;
    
	}
      
    }
    public void payyorumktr ()
    {
      if (webBrowser1.ReadyState==WebBrowserReadyState.Complete)
      {
        HtmlElementCollection all = this.webBrowser1.Document.All;
        IEnumerator enumerator;
        try
        {
          enumerator = all.GetEnumerator();
          while (enumerator.MoveNext())
          {
            HtmlElement current = (HtmlElement)enumerator.Current;
            if (current.GetAttribute("name") == "login_user")
            {
              current.InvokeMember("click");

            }
          }

        }
        finally
        {

        }
      }
     
    }
    public void paykayit()
    {
      OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/para.accdb");
      try
      {

        DataSet ds = new DataSet();
        if (baglan.State == ConnectionState.Closed)
        {
          baglan.Open();
        }
        {
          ds.Clear();
          OleDbCommand komut = new OleDbCommand("INSERT INTO para (İsim,Şifre)Values ('" + name + "','" + Form1.pas + "')", baglan);
          komut.ExecuteNonQuery();
          qw = 1;
          baglan.Close();
          listBox1.Items.Add("Veri Tabanına Kaydedildi..");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        baglan.Close();
      }
      if (baglan.State == ConnectionState.Open)
      {
        baglan.Close();
      }
    }
    public int SayiOlustur()
    {
      Random uretici = new Random();
      int olusanSayi;
      olusanSayi = uretici.Next(8);

      return olusanSayi;
    }

    public void mynet() 
    {
      if (tk==1)
      {
      
      
      if (brv.ReadyState == WebBrowserReadyState.Complete)
      {

        // IEnumerator enumerator;
        this.brv.Document.GetElementById("username").SetAttribute("value", Form1.name);
        this.brv.Document.GetElementById("password1").SetAttribute("value", Form1.pas);
        this.brv.Document.GetElementById("password2").SetAttribute("value", Form1.pas);
        this.brv.Document.GetElementById("birthdateDay").SetAttribute("value", "1");
        this.brv.Document.GetElementById("birthdateMonth").SetAttribute("value", "1");
        this.brv.Document.GetElementById("birthdateYear").SetAttribute("value", "1980");
        this.brv.Document.GetElementById("otherEmail").SetAttribute("value", Form1.name2+g);

        // this.brv.Document.GetElementById("sozlesmec").SetAttribute("value", "1980");


        HtmlElementCollection all = this.brv.Document.All;
        IEnumerator enumerator;
        try
        {
          enumerator = all.GetEnumerator();
          while (enumerator.MoveNext())
          {
            HtmlElement current = (HtmlElement)enumerator.Current;
            if (current.GetAttribute("name") == "sozlesmec")
            {
              current.InvokeMember("click");

            }
          }

        }
        finally
        {

        }
        brv.Document.All["imageanswer"].InnerText = "CYU5";
        brv.Document.All["mform"].InvokeMember("submit");
      
      }
      
      }
      else
      {
        brv.Navigate("http://uyeler.mynet.com/index/mymailkayit.html");
        while (brv.ReadyState == WebBrowserReadyState.Complete)
        {
          mynet();
        }
      }

        

      w1 = Form1.name;
      w2 = Form1.pas;
    //  MessageBox.Show("Kullanıcı Adınız:" + w1.ToString() + "Password:" + w2.ToString());
     
     
    }
    int tk;
    private void button1_Click(object sender, EventArgs e)
    {
      tk = 1;
      mynet();
      tk = 0;
      /*HtmlElementCollection all = this.brv.Document.All;
      IEnumerator enumerator;
      try
      {
        enumerator = all.GetEnumerator();
        while (enumerator.MoveNext())
        {
          HtmlElement current = (HtmlElement)enumerator.Current;
          if (current.GetAttribute("name") == "sozlesmec")
          {
            current.InvokeMember("click");

          }
        }

      }
      finally
      {

      }*/
      pictureBox2.Visible = true;
      label2.Visible = true;
      timer1.Enabled = true;

     
    }
    int r;
    string g,f;

    private void Hesap_Load(object sender, EventArgs e)
    {
      textBox2.Text = pasword;
      kayit.Navigate("http://www.AWSurveys.com?R=Codex");
      webBrowser1.Navigate("http://www.awsurveys.com/adduser.cfm");
      try
      {
        if (face.knt == true)
        {
          listBox1.Visible = true;
        }
      }
      catch
      {

      }
      /*  try
      {


         OleDbCommand komut = new OleDbCommand("Select * From Mail", bag);
      
           bag.Open();
           OleDbDataReader oku = komut.ExecuteReader();
     
           oku.Read();
           while (oku.Read())
           {
            f=Convert.ToString((oku["mail"]));
            r += 1;
           }
           object[] dizi = new object[r+1];
          // dizi[r] = oku[oku.HasRows[r],"mail"];
           brv.Navigate("http://uyeler.mynet.com/index/mymailkayit.html");
    
      
           OleDbDataAdapter odb = new OleDbDataAdapter("Select * From mail",bag);

           DataTable dt = new DataTable();
           odb.Fill(dt);

          g= dt.Rows[r]["mail"].ToString();
   
           }
           catch (Exception Ex)
           {
             MessageBox.Show(Ex.Message);
           }
           bag.Close();*/
      
    }
  
    private void Hesap_FormClosed(object sender, FormClosedEventArgs e)
    {
      Application.Exit();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      veri s = new veri();
      s.Show();
    }
    public static string adres;
    
    private void timer1_Tick(object sender, EventArgs e)
    {
    
       
       try
       {
         HtmlElementCollection all = this.brv.Document.All;
         IEnumerator enumerator;
         enumerator = all.GetEnumerator();
         while (enumerator.MoveNext())
         {
           HtmlElement current = (HtmlElement)enumerator.Current;
           if (current.GetAttribute("href") == "http://profil.eksenim.mynet.com/kayitolbirinciadim.jsp")
           {
             
             label2.Text="   Sonuç Alındı,Başarılı";
            // SendKeys.Send("{ENTER}");
             listBox1.Items.Add("Kayıt Olundu");
             listBox1.Items.Add("Kayıt Olunan Maili Aktifleştirmek İçin A Tuşuna Basınız!!");
             
             pictureBox2.Visible = false;
     
             adres="1";
             timer1.Enabled = false;
           }
         }

       }
       finally
       {

       }

       if (adres == "1")
       {
        // MessageBox.Show("Kayıt Yapıldı");
         kydet();

       }
       else
       {
         listBox1.Items.Add("Kayıt Yapılamadı");
         timer1.Enabled = false;
         label2.Text = "Sonuç Başarısız,Tekrar Dene";
         pictureBox2.Visible = false;
        
       }
      }
    OleDbConnection bags = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/face.accdb");
    public void faces()
    {
      try
      {

        DataSet ds = new DataSet();
        if (bags.State == ConnectionState.Closed)
        {
          bags.Open();
        }
        {
          ds.Clear();
          OleDbCommand komut = new OleDbCommand("INSERT INTO Face (isim,sifre)Values ('" + Hesap.w1 + "@mynet.com" + "','" + Hesap.w2 + "')", bags);
          komut.ExecuteNonQuery();
          qw = 1;
          bags.Close();

        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        bags.Close();
      }
      if (bags.State == ConnectionState.Open)
      {
        bags.Close();
      }
    
    }
    private void button2_Click(object sender, EventArgs e)
    {
  //    MessageBox.Show("Şuan İzin Verilemez","Düşük Versiyon");
      face fs = new face();
      fs.Show();
      this.Hide();

    }
    int kntrols;
    private void timer2_Tick(object sender, EventArgs e)
    {
      if (brv.ReadyState == WebBrowserReadyState.Complete)
      {
        kntrols = 1;
        kntrol();
        timer2.Enabled = false;
      }
      else
      {
        timer2.Enabled = false;
      
        listBox1.Items.Add("Aktifleştirilmedi");
      }
    }
   public static int qw;
    public void kydet() 
    {
      try
      {
        
        DataSet ds = new DataSet();
        if (bag.State == ConnectionState.Closed)
        {
          bag.Open();}
        {
          ds.Clear();
          OleDbCommand komut = new OleDbCommand("INSERT INTO Mail (mail,sifre)Values ('" + Hesap.w1 + "@mynet.com" + "','" + Hesap.w2 + "')", bag);
          komut.ExecuteNonQuery();
          qw = 1;
          bag.Close();

        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        bag.Close();
      }
      if (bag.State==ConnectionState.Open)
      {
        bag.Close();
      }
    }

    private void Hesap_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {

    
      if (e.KeyCode==Keys.A)
      {
        brv.Navigate("http://eposta.mynet.com/index/mymail.html");

       
        timer2.Enabled = true;
      }
      }
      catch (Exception ex)
      {

        listBox1.Items.Add(ex);
      }
    }
    public static int knt;
    private void timer3_Tick(object sender, EventArgs e)
    {
      if (knt==1)
      {
        listBox1.Items.Add(w3);
        timer3.Enabled = false;
      }
    }
    WebBrowser kayit = new WebBrowser();
    private void button4_Click(object sender, EventArgs e)
    {
      //timer4.Enabled = true;
     
      pay();
     
     // timer5.Enabled = true;
      //eeohd7@mynet.com
     // webBrowser1.Navigate("http://www.awsurveys.com/adduser.cfm");
   
    }

    private void timer4_Tick(object sender, EventArgs e)
    {
      timer4.Enabled = false;
      webBrowser1.Navigate("http://www.awsurveys.com/logout.cfm");
      while (webBrowser1.ReadyState!=WebBrowserReadyState.Complete)
      {
        webBrowser1.Navigate("http://www.awsurveys.com/adduser.cfm");
        break;
      
        
      }
      pay();
   
     
     //   webBrowser1.Navigate("http://www.awsurveys.com/adduser.cfm");
      
       // timer5.Enabled = true;
    
    }

    private void button5_Click(object sender, EventArgs e)
    {
      //webBrowser1.Navigate("http://www.awsurveys.com/adduser.cfm");
      MessageBox.Show(SayiOlustur().ToString());
     // payyorumktr();
      MessageBox.Show(pasword.ToString());
      MessageBox.Show(name.ToString());
      MessageBox.Show(Form1.pas.ToString());
      MessageBox.Show(Form1.name.ToString());
    }

    private void timer5_Tick(object sender, EventArgs e)
    {
    /*  string a,b;
      b=webBrowser1.Url.ToString();
      a="http://www.awsurveys.com/adduser.cfm?CFID=45060030&CFTOKEN=84479933";
      if (b!=a);
      {
        webBrowser1.Navigate("http://www.awsurveys.com/adduser.cfm");
        timer5.Enabled = false;
        timer4.Enabled = true;
      }*/
      timer5.Enabled = false;
      webBrowser1.Navigate("http://www.awsurveys.com/adduser.cfm");
      timer6.Enabled = true;
     
    }
    char[] karakter = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

    Random rs = new Random();
    public string uret(int size)//size, Üretilicek şifrenin kaç karakter olucağı  
    {
      string result = string.Empty;
      for (int i = 0; i < 5; i++)
      {
        result += karakter[rs.Next(0, karakter.Length - 1)].ToString();
      }
      return result;

    }
    string name;
    string pasword;
    public void email()
    {
      
      int sayi;
      char[] karakters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
      char[] karakterss = "0123456789".ToCharArray();
      Random r = new Random();
      sayi = r.Next(3);
      //webBrowser1.Navigate(("http://uyeler.mynet.com/index/mymailkayit.html"));
      string cb = uret(5).ToString();
      cb = karakters[sayi] + cb;
      name = string.Empty;
      name = cb;
      cb = uret(7).ToString();
      cb = karakterss[sayi] + cb;
      pasword = cb+name;
      
     
    }

    private void timer6_Tick(object sender, EventArgs e)
    {
      timer6.Enabled = false;
      pay();
      
    }
    
    
    private void timer7_Tick(object sender, EventArgs e)
    {
      textBox2.Text = name;
      email();
    }

    private void Hesap_FormClosing(object sender, FormClosingEventArgs e)
    {
      Application.Exit();
    }

    private void timer8_Tick(object sender, EventArgs e)
    {
      string a = webBrowser1.Url.ToString();
      payyorumktr();

      listBox2.Items.Add("Yorum Yapıldı..");
      
      listBox2.Items.Add(a);
      timer8.Enabled = false;
      timer5.Enabled = true;

    
    }

    private void button6_Click(object sender, EventArgs e)
    {
      textBox2.Text = pasword;
    }

    }




  }
