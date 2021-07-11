using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hit_Artırma;
namespace KGB
{
    public partial class Form1 : Form
    {
        public static Random rs = new Random();
        public static Random rss = new Random();
        public static string name, name2;
        public static string pas;
        public static int pas2;

        public static char[] karakter = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();


        public static string uret(int size)//size, Üretilicek şifrenin kaç karakter olucağı  
        {
            string result = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                result += karakter[rs.Next(0, karakter.Length - 1)].ToString();
            }
            return result;

        }
        public static void uretken()
        {
            int sayi;
            char[] karakters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            Random r = new Random();
            sayi = r.Next(9);
            
            string cb = uret(5).ToString();
            cb = karakters[sayi] + cb;
            name = cb;
                    }
               private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    
    
    }
}