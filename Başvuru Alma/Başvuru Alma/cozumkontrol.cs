using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hit_Artırma
{
    public partial class cozumkontrol : Form
    {
        public cozumkontrol()
        {
            InitializeComponent();
        }
        WebBrowser wb = new WebBrowser();
        private void cozumkontrol_Load(object sender, EventArgs e)
        {
            wb.Navigate("https://docs.google.com/spreadsheet/lv?key=0AoGC6uQOW5xjdEQxYS1meFVvYzB0VFhtcFlBekg2aWc&rm=full#gid=0");
            vericek();
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
                try
                    {
                        if (listBox1.Items[i].ToString() == textBox1.Text)
                        {
                                MessageBox.Show("Çözüm Bulundu ");// + listBox1.Items[i] + " " + listBox2.Items[j]
                                textBox2.Text = listBox2.Items[i].ToString();
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
        bool bulundu;
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
       
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Mailinizi Girin");
            }
            else
            {
                hesapkontrol();
            }
        }

        private void cozumkontrol_FormClosed(object sender, FormClosedEventArgs e)
        {
            Giriş g = new Giriş(); g.Show(); 
        }
    }
}
