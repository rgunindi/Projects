using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using KGB;

namespace Hit_Artırma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
public string KeyUret()

        {  Random rnd = new Random();

            string harfler="ABCDEFGHIJKLMNOPRSTUVYZ123456789";

            int r1,s1,s2,s3,s4,s5;

            r1=rnd.Next(0,10);

            s1=r1+5;

            s2=r1%2+r1%3;

            s3=r1+r1%2;

            s4=r1+r1%3;

            s5=r1%3+3;

            string Key = harfler.Substring(s1, 1) + s2.ToString() + harfler.Substring(s3, 1) + s4.ToString() + harfler.Substring(s5, 1);

            return Key;

        }
public void KeyUret1()
{
   
}

        int i;
        public void bilgilericek()
        {

            i = 0;
            WebBrowser we = new WebBrowser();
            we.Navigate("https://docs.google.com/spreadsheet/lv?key=0AoGC6uQOW5xjdHMzc25jQ3pyajlscTE0aGlzS1Q5eEE&rm=full#gid=0");
            while (we.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            foreach (HtmlElement elm in we.Document.All)
            {
                if (elm.GetAttribute("className") == "s1")
                {
                    try
                    {
                      //  listBox1.Items.Add(elm.InnerText);
                        i++;
                    }
                    catch
                    {


                    }
                }
            }

        }
        WebBrowser brov1 = new WebBrowser();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox5.Text == "")
            {
                MessageBox.Show("Yardım Edebilmemiz İçin Bilgileri Girmek Zorundasınız");
            }
            else
            {
                brov1.Navigate("https://docs.google.com/spreadsheet/viewform?formkey=dHMzc25jQ3pyajlscTE0aGlzS1Q5eEE6MQ&ifq");
                while (brov1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                brov1.Document.GetElementById("entry.0.single").SetAttribute("value", textBox1.Text);
                brov1.Document.GetElementById("entry.1.single").SetAttribute("value", textBox2.Text);
                brov1.Document.GetElementById("entry.2.single").SetAttribute("value", textBox3.Text);
                brov1.Document.GetElementById("entry.4.single").SetAttribute("value", textBox5.Text);
             
                string  sıra = KeyUret()+KGB.Form1.name;
                brov1.Document.GetElementById("entry.5.single").SetAttribute("value", sıra);
                brov1.Document.All["submit"].InvokeMember("click");

                //https://docs.google.com/spreadsheet/viewform?formkey=dHMzc25jQ3pyajlscTE0aGlzS1Q5eEE6MQ&ifq
                while (brov1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                button1.Text = "Gönderildi..";
                button1.Enabled = false;
                butn1.Enabled = true;
                MessageBox.Show("Çözüm Kodunuz= "+sıra,"Sakın Kaybetmeyin");
                textBox6.Text += sıra;
                textBox6.Visible = true;
            }
        }

        private void butn1_Tick(object sender, EventArgs e)
        {
            while (brov1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            foreach (HtmlElement elm in brov1.Document.All)
            {
                if (elm.GetAttribute("href") == "https://docs.google.com/spreadsheet/viewform?formkey=dHMzc25jQ3pyajlscTE0aGlzS1Q5eEE6MQ&ifq")
                {
                    butn1.Enabled = false;
                    elm.InvokeMember("click");
                }
            }
            while (brov1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            button1.Enabled = true;
            button1.Text = "Gönder";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // bilgilericek();
            KGB.Form1.uretken();
           
        }
       
      
        private void timer1_Tick(object sender, EventArgs e)
        {
       timer1.Enabled = false;
                }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giriş g = new Giriş();
            this.Close();
            g.Show();
        }

        }
            
        }

                    
    

        
             
    

