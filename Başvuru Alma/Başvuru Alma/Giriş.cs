using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hit_Artırma
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }
        public static string isim, sifre;
       
        public void vericek()
        {
            ayrac = 0;
            
            WebBrowser wb = new WebBrowser();
            wb.Navigate("https://docs.google.com/spreadsheet/lv?key=0AoGC6uQOW5xjdEJoLV9JS2ZzWUdPTTQwaGhXaFdSVmc&rm=full#gid=0");

            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            foreach (HtmlElement elm in wb.Document.All)
            {
                if (ayrac == 0)
                {
                    if (elm.GetAttribute("className") == "s1")
                    {
                        try
                        {
                            listBox1.Items.Add(elm.InnerText);

                            ayrac = 1;
                        }
                        catch { }
                    }
                }
                else
                {
                    if (elm.GetAttribute("className") == "s1")
                    {
                        try
                        {
                            listBox2.Items.Add(elm.InnerText);
                            ayrac = 0;
                        }
                        catch { }
                    }

                }
            }
        }
        public void hesapkontrol()
        {
            bulundu = false;
            string[] ad = new string[listBox1.Items.Count];

            for (int i = 0; i <= ad.Length; i++)
            {
                if (bulundu == true)
                {
                    break;
                }
                for (int j = 0; j <= ad.Length; j++)
                {
                    try
                        {if (listBox1.Items[i].ToString() == textBox1.Text)
                    {
                        
                            if (listBox2.Items[j].ToString() == textBox2.Text)
                            {
                                MessageBox.Show("Hesap Bulundu");// + listBox1.Items[i] + " " + listBox2.Items[j]
                                                             
                                bulundu = true;
                                break;
                            }
                        }


                        }
                    catch { }
                }
            }
            if (bulundu==false)
            {
                MessageBox.Show("Hesabınız Bulunamadı","Lütfen Bilgileri Kontrol Edin");
            }
          
              
                
           
            if (bulundu==true)
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            kayıt k = new kayıt();
            k.Show();
            this.Hide();
          
        }
        public void izinal()
        {
            WebBrowser w = new WebBrowser();
            w.Navigate("https://docs.google.com/spreadsheet/lv?key=0AoGC6uQOW5xjdEpYWnNMcmtBcktqV2s4NzY5Z25tdVE&rm=full#gid=0");

            while (w.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            foreach (HtmlElement elm in w.Document.All)
            {
                if (elm.GetAttribute("className") == "s1")
                {
                    try
                    {
                        if (elm.InnerText == "Evet")
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("İzin yok");
                            Application.Exit();
                        }
                    }catch{}
                }

            }
        }
        private void Giriş_Load(object sender, EventArgs e)
        {
            izinal();
            vericek();
            try
            {
                textBox1.Text = isim;
                textBox2.Text = sifre;

            }
            catch { }
        }
        int ayrac;
        bool bulundu;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "")
            {
                MessageBox.Show("Giriş İçin Bilgileri Girmek Zorundasınız");
            }
            else
            {
                hesapkontrol();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Cw-Warrior" & textBox2.Text == "Cw-Security-Team")
            {
                MessageBox.Show("Giriş İzni Verildi");
                bilgiler bg = new bilgiler();

                bg.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Üzgünüz Bilgiler Yanlış");
            }
        }
     
        private void button4_Click(object sender, EventArgs e)
        {
     
          
                cozumkontrol ck = new cozumkontrol(); ck.Show(); this.Hide();
          
        }

        private void Giriş_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

     
    }
    }

