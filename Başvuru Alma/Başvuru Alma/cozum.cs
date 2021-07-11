using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hit_Artırma
{
    public partial class cozum : Form
    {
        public cozum()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

             if (textBox1.Text == "" | textBox2.Text == "" )
            {
                MessageBox.Show("Yardım Edebilmemiz İçin Bilgileri Girmek Zorundasınız");
            }
            else
            {
                brov1.Navigate("https://docs.google.com/spreadsheet/viewform?fromEmail=true&formkey=dEQxYS1meFVvYzB0VFhtcFlBekg2aWc6MQ");
                while (brov1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                brov1.Document.GetElementById("entry.0.single").SetAttribute("value", textBox1.Text);
                brov1.Document.GetElementById("entry.1.single").SetAttribute("value", textBox2.Text);
               
                brov1.Document.All["submit"].InvokeMember("click");

             
                while (brov1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                button3.Text = "Gönderildi..";
                button3.Enabled = false;
                timer1.Enabled = true;
            }

        }
        WebBrowser brov1=new WebBrowser();
        private void cozum_Load(object sender, EventArgs e)
        {
            brov1.Navigate("https://docs.google.com/spreadsheet/viewform?fromEmail=true&formkey=dEQxYS1meFVvYzB0VFhtcFlBekg2aWc6MQ");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (brov1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            foreach (HtmlElement elm in brov1.Document.All)
            {
                if (elm.GetAttribute("href") == "https://docs.google.com/spreadsheet/viewform?formkey=dHMzc25jQ3pyajlscTE0aGlzS1Q5eEE6MQ&ifq")
                {
                    timer1.Enabled = false;
                    elm.InvokeMember("click");
                    while (brov1.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                    }
                   
                }

            }
            button3.Enabled = true;
            button3.Text = "Bildir";
            timer1.Enabled = false;
            MessageBox.Show("Çözümünüz Ulaştı");
        }
        }
    }

