using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace KonuBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void linklericek()
        {
          
            textBox1.Clear();
            webBrowser1.Navigate(textBox4.Text);
            webBrowser2.Navigate(textBox3.Text);
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            if (textBox2.Text != "")
            {


                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("a");

                foreach (HtmlElement item in links)
                {

                    try
                    {
                        string id = item.GetAttribute("href");
                        // string[] deger = id.Split('=');
                        int index = id.LastIndexOf(",0.cwx");
                        
                        if (index != -1)
                        {
                            
                            listBox1.Items.Add(id);
                            this.Text = listBox1.Items.Count.ToString();
                        }
                    }
                    catch
                    {


                    }

                }

                timer1.Enabled = true;
            }
            else { MessageBox.Show("Başlanacak Link Sayısını Girin"); }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string a;
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("td");
            foreach (HtmlElement item in col)
            {

                a = item.InnerText;
                MessageBox.Show(a);

            }
         
            }




        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= listBox1.Items.Count-1; i++)
            {for (int j = 0; j <= 10; j++)
			{
                try
                {
                    if (listBox1.Items[i].ToString() == j.ToString())
                    {
                        listBox1.Items.RemoveAt(i);
                    }
                }
                catch 
                {
                    
                  
                }
			 
			}
                
            }
            timer1.Enabled = true;
        }
        
        int adet;
        private void timer1_Tick(object sender, EventArgs e)
        {
            while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            textBox1.Clear();
            if (textBox2.Text == "")
            {
                timer1.Enabled = false;
                MessageBox.Show("Kutu Boş olamaz");

            }
            else
            {
                adet = Convert.ToInt32(textBox2.Text);
                adet = adet + 1;
                textBox2.Text = (adet).ToString();


                timer1.Enabled = false;

                {
                    webBrowser1.Navigate(listBox1.Items[adet].ToString());
                    baslık = listBox1.Items[adet].ToString();
                    int sayi = baslık.Length;
                    baslık = baslık.Substring(35, sayi - 48);
                    baslık2 = baslık.Split('-');
                    baslık = "";
                    for (int i = 0; i <= baslık2.Length - 1; i++)
                    {
                        baslık += " " + baslık2[i].ToString();
                    }
                    timer2.Enabled = true;


                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HtmlElementCollection linkler = webBrowser1.Document.GetElementsByTagName("a");

            foreach (HtmlElement element in linkler)
            {
                listBox1.Items.Add(element.InnerHtml + "    " + element.InnerText);
                //        MessageBox.Show(element.InnerHtml+ "    "+ element.InnerText);
            }

        }
       
        private void button2_Click_1(object sender, EventArgs e)
        {
            linklericek();
        }
        string baslık;
        string []baslık2;
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            int adet = 0;
          
            timer2.Enabled = false;
            while (webBrowser1.ReadyState!=WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            linkcek();
            foreach (HtmlElement elm in webBrowser1.Document.All)
            {
                if (elm.GetAttribute("className") == "mesaj")
                {
                    //    degerler.Add(elm.InnerText);
                 adet++;
                
                        textBox1.Text += (elm.InnerText);
                  
            


                    if (adet==1)
                    {
                        for (int i = 0; i <= listBox2.Items.Count; i++)
                        {
                            try
                            {
                               // textBox1.Text += "KONUYA AİT LİNKLER:" + "[url]" + listBox2.Items[i].ToString() + "[/url]";
                            }
                            catch 
                            {
                                
                             
                            }

                           
                            
                        }
                    }
                 
                       
                        
                    
                }
            }
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            listBox2.Items.Clear();
            webBrowser2.Navigate(textBox3.Text);
            while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            timer3.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            foreach (HtmlElement elm in webBrowser2.Document.All)
            {
                if (elm.GetAttribute("alt") == "Yeni Konu")
                {
                    elm.InvokeMember("click");
                }
            }
            while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            timer4.Enabled = true;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Enabled = false;
        

            foreach (HtmlElement elm in webBrowser2.Document.All)
            {
                if (elm.GetAttribute("name") == "subject")
                {
                    elm.InnerText = baslık;
                }
            }
            foreach (HtmlElement elm in webBrowser2.Document.All)
            {
                if (elm.GetAttribute("id") == "message")
                {
                    elm.InnerText = textBox1.Text;
                }
            }
            timer6.Enabled = true;
          //  devamet();

        }
        public void devamet()
        {
            foreach (HtmlElement elm in webBrowser2.Document.All)
            {
                if (elm.GetAttribute("value") == "Gönder")
                {
                    elm.InvokeMember("Click");
                }
            }

            while (webBrowser2.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
           // webBrowser2.Navigate(textBox3.Text);
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            devamet();
            timer1.Enabled = true;
        }

   
        private void Form1_Load(object sender, EventArgs e)
        {
        
            webBrowser2.Navigate(textBox3.Text);
          
          
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            timer5.Enabled = false;
            devamet();
            timer1.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer6.Enabled = true;
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                timer6.Enabled = false;

                timer5.Enabled = true;

            }
            else if (radioButton2.Checked)
            {
                timer6.Enabled = false;
                timer5.Enabled = false;
            }
            else
            {
                timer6.Enabled = false;
            }
        }
        int[] index;
        string[] ab;
        int sayi;
        public void linkcek()
        {

            ab = new string[14];
            index = new int[7];
            ab[0] = "http://www.cyber";
            ab[1] = "http://www.grafiklerdunyasi.com";

            ab[2] = "http://www.facebook.com";
            ab[3] = "http://www.bilgininadresi.net";
            ab[4] = "http://www.bg.org.tr";
            ab[5] = "http://www.turk-h.org";
            ab[6] = "http://www.kemalsener.av.tr";
            ab[7] = "http://www.adlibilirkisi.org";
            ab[8] = "http://www.bilenesor.org";
            ab[9] = "javascript";
            ab[10] = "msnim";
            ab[11] = " ";
            ab[12] = "http://cyber-security.org.tr";
            ab[13] = "http://www.grafikerlerdunyasi.com";





            HtmlElementCollection links = webBrowser1.Document.GetElementsByTagName("a");

            foreach (HtmlElement item in links)
            {

                try
                {
                    string id = item.GetAttribute("href");
                    sayi = 0;

                    int index2 = id.IndexOf(ab[0]);
                    int index3 = id.IndexOf(ab[1]);
                    int index4 = id.IndexOf(ab[2]);
                    int index5 = id.IndexOf(ab[3]);
                    int index6 = id.IndexOf(ab[4]);
                    int index7 = id.IndexOf(ab[5]);
                    int index8 = id.IndexOf(ab[6]);
                    int index9 = id.IndexOf(ab[7]);
                    int index10 = id.IndexOf(ab[8]);
                    int index11 = id.IndexOf(ab[9]);
                    int index12 = id.IndexOf(ab[10]);
                    int index13 = id.IndexOf(ab[11]);
                    int index14 = id.IndexOf(ab[12]);
                    int index15 = id.IndexOf(ab[13]);
                    if (index2 == -1 & index3 == -1 & index4 == -1 & index5 == -1 & index6 == -1 & index7 == -1 & index8 == -1 & index9 == -1 & index10 == -1 & index11 == -1 & index12 == -1 & index13 == -1 & index14 == -1 & index15 == -1)
                    {
                        string yazı;
                        yazı = id;
                        string[] yazı2;
                        char[] karakter = { ' ' };
                        yazı2 = yazı.Split(karakter, StringSplitOptions.RemoveEmptyEntries);
                        yazı = "";
                      
                        for (int i = 0; i <= yazı2.Length - 1; i++)
                        {

                            yazı += yazı2[i];
                            
                         
                                listBox2.Items.Add(yazı);
  
                        
                        }
                        
                    
                    }

                }
                catch
                {


                }
            }
        }


      

     
        }
    }


