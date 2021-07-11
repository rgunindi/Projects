using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Microsoft.VisualBasic;
using System.Windows.Media.Imaging;
using System.Threading;

namespace TravianManager
{
    public class basla
    {
        public static ChromeDriver driver;
        public static ChromeDriver driverSaldiri;
        public static string url, baseUrl,urlMerkez;
        static string secenek = null;

        public basla()
        {



            secenek = Interaction.InputBox("Url Tercihi-> Amerco 1 - Arabia 2 - Europa 3", "","",400,100);
        Etiket:
            if (secenek == "1")
            {
                url = "https://ts100.x10.international.travian.com/dorf1.php";
                baseUrl = "https://ts100.x10.international.travian.com/";
                urlMerkez = "https://ts100.x10.international.travian.com/dorf2.php";
            }
            else if (secenek == "2")
            {
                url = "https://ts50.x5.arabics.travian.com/dorf1.php";
                baseUrl = "https://ts50.x5.arabics.travian.com/";
                urlMerkez = "https://ts50.x5.arabics.travian.com/dorf2.php";
            }
            else if (secenek == "3")
            {
                
                url = "https://ts20.x2.europe.travian.com/dorf1.php";
                baseUrl = "https://ts20.x2.europe.travian.com/";
                urlMerkez = "https://ts20.x2.europe.travian.com/dorf2.php";
            }
            else
            {
                goto Etiket;
            }

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--mute-audio");
            options.AddArgument("--headless");

            

            ChromeOptions options2 = new ChromeOptions();
            options2.AddArgument("--mute-audio");
            options2.AddArgument("--headless");


            driver = new ChromeDriver(driverService, options);

            //driverSaldiri = new ChromeDriver(driverService, options2);
            
            driver.Manage().Window.Maximize();

            try
            {
                driver.Navigate().GoToUrl(url);
                //driverSaldiri.Navigate().GoToUrl(url);
                System.Threading.Thread.Sleep(2000);
                giris();
            }
            catch (Exception)
            {

                driver.Close();
               // driverSaldiri.Close();
                
            }
          
           


        }
        public static void giris()
        {
            if (secenek == "1")
            {
                driver.FindElementByName("name").SendKeys("*****");// LoginName
                driver.FindElementByName("password").SendKeys("*****"); 
            }
            else if(secenek == "3")
            {
                driver.FindElementByName("name").SendKeys("*****");// LoginName
                driver.FindElementByName("password").SendKeys("*****");
            }
            else
            {
                driver.FindElementByName("name").SendKeys("*****");// LoginName
                driver.FindElementByName("password").SendKeys("*****");
            }
            try
            {
                try
                {
                    driver.FindElementByName("s1").Click();
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception)
                {

                    driver.FindElementById("cmpbntnotxt").Click();
                    System.Threading.Thread.Sleep(2000);
                    driver.FindElementByName("s1").Click();
                    System.Threading.Thread.Sleep(1000);
                }

                try
                {
                    driver.FindElementById("cmpbntnotxt").Click();
                    System.Threading.Thread.Sleep(2000);
                }
                catch (Exception)
                {
                    driver.FindElementByName("s1").Click();
                    System.Threading.Thread.Sleep(1000);
                    driver.FindElementById("cmpbntnotxt").Click();
                    System.Threading.Thread.Sleep(2000);
                }


            }
            catch (Exception)
            {


            }
            //giris2();
        }
        public static void giris2()
        {
            if (secenek == "1")
            {
                driverSaldiri.FindElementByName("name").SendKeys("****");// LoginName
                driverSaldiri.FindElementByName("password").SendKeys("*****");
            }
            else if (secenek == "3")
            {
                driverSaldiri.FindElementByName("name").SendKeys("*****");// LoginName
                driverSaldiri.FindElementByName("password").SendKeys("*****");
            }
            else
            {
                driverSaldiri.FindElementByName("name").SendKeys("*****");// LoginName
                driverSaldiri.FindElementByName("password").SendKeys("*****");
            }

            try
            {


                try
                {
                    driverSaldiri.FindElementByName("s1").Click();
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception)
                {

                    driverSaldiri.FindElementById("cmpbntnotxt").Click();
                    System.Threading.Thread.Sleep(2000);
                    driverSaldiri.FindElementByName("s1").Click();
                    System.Threading.Thread.Sleep(1000);
                }

                try
                {
                    driverSaldiri.FindElementById("cmpbntnotxt").Click();
                    System.Threading.Thread.Sleep(2000);
                }
                catch (Exception)
                {
                    driverSaldiri.FindElementByName("s1").Click();
                    System.Threading.Thread.Sleep(1000);
                    driverSaldiri.FindElementById("cmpbntnotxt").Click();
                    System.Threading.Thread.Sleep(2000);
                }

            }
            catch (Exception)
            {


            }
        }
        public static int koy = 2;
        public static Bitmap TakeScreenshot()
        {
            if (koy == 0)
            {
                ((IJavaScriptExecutor)basla.driver).ExecuteScript("window.scrollTo(180, document.body)");

            }
            //Ekran Görüntüsünün Resmini Çek
            Screenshot screenshot = ((ITakesScreenshot)basla.driver).GetScreenshot();
            //Belleğe Aktar
            var bmpScreen = new Bitmap(new MemoryStream(screenshot.AsByteArray));
            //Browserda istediğimiz element yerinin kordinatlarını bul
            IWebElement element;
            if (basla.driver.Url.Contains("dorf2"))
            {
                //*[@id="village_map"]
                //window.scrollTo(150, document.body);

                element = basla.driver.FindElement(By.XPath("//*[@id='village_map']"));
                koy = 1;
            }
            else
            {
                //element = basla.driver.FindElement(By.Id("resourceFieldContainer"));/svg[2]
                element = basla.driver.FindElementByXPath("//*[@id='resourceFieldContainer']");
                koy = 0;
            }

            var cropArea = new Rectangle(element.Location, element.Size);
            //    var cropArea = new Rectangle(x, y, yukselık, z);
            //Resmi alınan kordinatlara göre kes
            try
            {
                bmpScreen = bmpScreen.Clone(cropArea, bmpScreen.PixelFormat);

                driver.Navigate().GoToUrl(url);
                //Clipboarda Resmi Ata ve Atanan resmi PictureBox'ta Göster
                //Clipboard.SetImage(bmpScreen);
                //pictureBox1.Image = Clipboard.GetImage();
            }
            catch
            {
                //FlushMemory();
                GC.Collect();
            }

            //  pictureBox1.Image = Clipboard.GetImage();
            //Clipboard.GetImage();

            return bmpScreen;
        }
        public static Bitmap TakeScreenshot2(IWebElement el)
        {
            if (koy == 0)
            {
                ((IJavaScriptExecutor)basla.driver).ExecuteScript("window.scrollTo(180, document.body)");

            }
            //Ekran Görüntüsünün Resmini Çek
            Screenshot screenshot = ((ITakesScreenshot)basla.driver).GetScreenshot();
            //Belleğe Aktar
            var bmpScreen = new Bitmap(new MemoryStream(screenshot.AsByteArray));
            //Browserda istediğimiz element yerinin kordinatlarını bul
           
            var cropArea = new Rectangle(el.Location, el.Size);
            //    var cropArea = new Rectangle(x, y, yukselık, z);
            //Resmi alınan kordinatlara göre kes
            try
            {
                bmpScreen = bmpScreen.Clone(cropArea, bmpScreen.PixelFormat);
            }
            catch
            {
                GC.Collect();
            }


            return bmpScreen;
        }

        static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (System.IO.MemoryStream memory = new System.IO.MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
        public Tuple<string, string,string,string,string> HammaddeAlanlari()
        {
        YenidenDene: string odun="", tugla="", demir="", tahil="", asker="";
         try
            {
                 odun = basla.driver.FindElementById("l1").Text ;
                tugla = basla.driver.FindElementById("l2").Text ;
               demir = basla.driver.FindElementById("l3").Text;
               tahil = basla.driver.FindElementById("l4").Text;
                string veri = basla.driver.Url.Substring(basla.driver.Url.Length - 9);
                if (basla.driver.FindElementByXPath("//*[@id='troops']").Displayed)
                {
                    IWebElement tableElement = basla.driver.FindElement(By.XPath("//*[@id='troops']/tbody"));
                    IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
                    IList<IWebElement> rowTD;
                    foreach (IWebElement row in tableRow)
                    {
                        rowTD = row.FindElements(By.TagName("td"));


                        if (rowTD.Count > 0)
                        {
                            foreach (var item in rowTD)
                            {
                                if (!String.IsNullOrEmpty(item.Text)) asker += item.Text + "\n";
                                //lblAsker.Text = asker;
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
                if (driver.Url.Contains("login"))
                {
                    giris();
                }
                else
                {
                    driver.Navigate().GoToUrl(url);
                    goto YenidenDene;
                }
            }
           // giris();
            return Tuple.Create(odun,tugla,demir,tahil,asker);
        }
        public static void macerayaGonder()
        {
            try
            {
                if (basla.driverSaldiri.FindElementByClassName("heroHome").Displayed)
                {
                    string maceraSayisi = basla.driverSaldiri.FindElementByClassName("content").Text;
                    int maceraSayisiInt = int.Parse(maceraSayisi);
                    if (maceraSayisiInt > 0)
                    {
                        basla.driverSaldiri.Navigate().GoToUrl(basla.baseUrl + "/hero/adventures");
                        Thread.Sleep(1500);
                        basla.driverSaldiri.FindElementByClassName("adventureSendButton").Click();
                        Thread.Sleep(1000);
                    }

                }
            }
            catch (Exception ex)
            {

                string m = ex.Message;
                if (!basla.driverSaldiri.Url.Contains("dorf1")) giris2();


            }
            try
            {
                basla.driverSaldiri.Navigate().GoToUrl(basla.url);
                
            }
            catch (Exception)
            {

                
            }
            //giris2();
        }
    }
}
