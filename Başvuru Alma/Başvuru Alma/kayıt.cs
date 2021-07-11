using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;



namespace Hit_Artırma
{
    public partial class kayıt : Form
    {
        public kayıt()
        {
            InitializeComponent();
        }
        

        public void bilgicek()
        {
            foreach (HtmlElement elm in mac.Document.All)
            {

                if (elm.GetAttribute("className") == "s1")
                {
                    try
                    {
                        listBox1.Items.Add(elm.InnerText);


                    }
                    catch { }

                }
            }

        }
        string macadresi; 
        public static string GetMacAddress()
        {
            var objects = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
            var result = string.Empty;
            foreach (ManagementObject obj2 in objects)
            {
                if (result.Equals(string.Empty))
                {
                    if (Convert.ToBoolean(obj2["IPEnabled"]))
                        result = obj2["MacAddress"].ToString();
                    obj2.Dispose();
                }
                result = result.Replace(":", string.Empty);
            }
                       
            return result;
        }
         bool bulundu;
        public void hesapkontrol()
        {
            macadresi = GetMacAddress();
            bulundu = false;
            string[] ad = new string[listBox1.Items.Count];

            for (int i = 0; i <= ad.Length; i++)
            {
                if (bulundu == true)
                {
                    break;
                }
               try
                    {
                        if (listBox1.Items[i].ToString() == macadresi)
                        {
                            bulundu = true;
                            break;
                        }
                    }
                    catch { }

            }
                    if (bulundu == false)
                    {
                        this.mackayit.Document.GetElementById("entry.0.single").SetAttribute("value", macadresi);
                        mackayit.Document.All["submit"].InvokeMember("click");
                    }
                    if (bulundu == true)
                    {
                        Giriş g = new Giriş(); g.Show(); this.Close();
                        MessageBox.Show("Üzgünüz Zaten Mevcut Bir Hesabınız Bulunmakta");
                    }
                
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            if (textBox1.Text == "" | textBox2.Text == "")
            {
                MessageBox.Show("Kayıt İçin Bilgileri Girmek Zorundasınız");
            }
            else
            {
                this.wb.Document.GetElementById("entry.0.single").SetAttribute("value", textBox1.Text);
                this.wb.Document.GetElementById("entry.1.single").SetAttribute("value", textBox2.Text);
             
                wb.Document.All["submit"].InvokeMember("click");
                butn1.Enabled = true;
            }
        }
        WebBrowser wb = new WebBrowser();
        WebBrowser mac = new WebBrowser();
        WebBrowser mackayit = new WebBrowser();
        private void kayıt_Load(object sender, EventArgs e)
        {
            GetMacAddress();
            mackayit.Navigate("https://docs.google.com/spreadsheet/viewform?fromEmail=true&formkey=dGItTVR2WWRnMmZUa2U0TWVuRWpNSFE6MQ");
            mac.Navigate("https://docs.google.com/spreadsheet/lv?key=0AoGC6uQOW5xjdGItTVR2WWRnMmZUa2U0TWVuRWpNSFE&rm=full#gid=0");
            wb.Navigate("https://docs.google.com/spreadsheet/viewform?fromEmail=true&formkey=dEJoLV9JS2ZzWUdPTTQwaGhXaFdSVmc6MQ");

            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            bilgicek();
            hesapkontrol();
        }

        private void butn1_Tick(object sender, EventArgs e)
        {
             while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
             foreach (HtmlElement elm in wb.Document.All)
             {
                 if (elm.GetAttribute("href") == "https://docs.google.com/spreadsheet/viewform?formkey=dEJoLV9JS2ZzWUdPTTQwaGhXaFdSVmc6MQ&ifq")
                 {
                     butn1.Enabled = false;
                     MessageBox.Show("Kaydınız Tamamlandı");
                     Giriş.isim = textBox1.Text;
                     Giriş.sifre = textBox2.Text;

                     Giriş g = new Giriş();
                     g.Show();

                     this.Close();
                 }
             }
        }
    }
}

