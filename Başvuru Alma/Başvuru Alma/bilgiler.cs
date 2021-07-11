using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hit_Artırma
{
    public partial class bilgiler : Form
    {
        public bilgiler()
        {
            InitializeComponent();
        }
        int adet;
        public void bilgilericek()
        {

            adet = 0;
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
                
                    if (adet==1)
                    {
                        listBox2.Items.Add(elm.InnerText);
                       
                        adet++;
                    }
                    else if (adet == 2)
                    {
                        listBox3.Items.Add(elm.InnerText);
                       
                        adet++;
                    }
                    else if (adet == 3)
                    {
                        listBox4.Items.Add(elm.InnerText);
                        
                        adet++;
                    }
                
                    else
                    {
                        adet = 0;
                        try
                        {
                            listBox1.Items.Add(elm.InnerText);

                            adet++;
                        }
                        catch
                        {


                        }
                    }
                } 
            }
           

        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Visible = false; listBox2.Visible = false; listBox3.Visible = false; listBox4.Visible = false;
            bilgilericek();
                     
            timer1.Enabled = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Giriş g = new Giriş(); g.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cozum c = new cozum();
            c.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            cozulenlerisil();
                   
        }
        //-------------------------------------------------------------------------------------------------
        int ayrac;
        public void vericek()
        {
            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            ayrac = 0;
            foreach (HtmlElement elm in wb.Document.All)
            {
                if (ayrac == 0)
                {
                    if (elm.GetAttribute("className") == "s1")
                    {
                        try
                        {
                            listBox5.Items.Add(elm.InnerText);

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
                            string a = elm.InnerText;
                            ayrac = 0;
                        }
                        catch { }
                    }

                }
            }
        }
        string[] ad;
        public void hesapkontrol()
        {
            bulundu = false;
           ad = new string[listBox1.Items.Count];

            for (int i = 0; i <= ad.Length; i++)
            {
                if (bulundu == true)
                {
                    break;
                }
                try
                {
                    if (listBox3.Items[i].ToString() == listBox5.Items[i].ToString())
                    {
                        MessageBox.Show("Aynı Adres Bulundu ");// + listBox1.Items[i] + " " + listBox2.Items[j]
                        ad[i] = listBox3.Items[i].ToString();
                        bulundu = true;
                        break;

                    }


                }
                catch { }

            }
            if (bulundu == false)
            {
                MessageBox.Show("Çözüm Bulunamadı", "Lütfen Daha Sonra Tekrar Deneyin");
            }

        }
        public void cozulenlerisil()
        {
            try
            {
                for (int i = 0; i <= listBox5.Items.Count - 1; i++)
                {

                    for (int j = 0; j <= listBox4.Items.Count - 1; j++)
                    {
                        if (listBox5.Items[i].ToString() == listBox4.Items[j].ToString())
                        {

                            listBox1.Items.RemoveAt(j);
                            listBox2.Items.RemoveAt(j);

                            listBox3.Items.RemoveAt(j);
                            listBox4.Items.RemoveAt(j);
                            listBox1.Visible = true; listBox2.Visible = true; listBox3.Visible = true; listBox4.Visible = true;
                            timer1.Enabled = false;
                        }
                    }
                }

            }
            catch { }

        }
        bool bulundu;
        WebBrowser wb = new WebBrowser();
        private void bilgiler_Load(object sender, EventArgs e)
        {
            wb.Navigate("https://docs.google.com/spreadsheet/lv?key=0AoGC6uQOW5xjdEQxYS1meFVvYzB0VFhtcFlBekg2aWc&rm=full#gid=0");
            vericek();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listBox3.Items[listBox4.SelectedIndex] + " = " + listBox4.SelectedItem.ToString();
                textBox2.Text = "Sorun Kodu:" + listBox4.SelectedItem.ToString();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bilgiler bg = new bilgiler();
            bg.Show();
            this.Close();
        }

      

      
    }
}
