using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TravianManager
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         basla= new basla();
        }
        basla basla;
        DispatcherTimer otoInsaTimer;
        DispatcherTimer hammaddeAlanlariKontrol=new DispatcherTimer();
        bool HammaddeInsaatUygunluk;
        bool InsaatUygunluk;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            KoylerinListesiniAl();
            otoInsaTimer = new DispatcherTimer();
            otoInsaTimer.Interval = TimeSpan.FromSeconds(120);
            otoInsaTimer.Tick += OtoInsaTimer_Tick;
            //-------//
            hammaddeAlanlariKontrol.Interval = TimeSpan.FromSeconds(1.5);
            hammaddeAlanlariKontrol.Tick += HammaddeAlanlariKontrol_Tick;
            hammaddeAlanlariKontrol.Start();
        }
        string KoyInsaatSureleriveIsimleri;
        string KoyID;
        private void HammaddeAlanlariKontrol_Tick(object sender, EventArgs e)
        {
            HammaddeAlanKontrol();
            InsaSureleriKontrol();
            
            if (maceraCheckbox.IsChecked==true)
            {
                basla.macerayaGonder();
            }
        }

        int degerButon;
        private void OtoInsaTimer_Tick(object sender, EventArgs e)
        {
            
            bool hammadde = true, bina = true;
            string[] hammaddeAlanlariIsimleri = { "Odun", "Tuğla", "Demir", "Tarla" };
            string[] BinaAlanlariIsimleri = {"Belediye","Büyük","Dünya","Elçilik",
            "Hammadde","Hazine","Köşk","Merkez","Pazar","Saray","Sığınak","Tahıl",
                "Taşçı","Ticari","Yalak","İçecek","Ahır","Akademi","Askeri","Hastane","Kahraman",
            "Kışla","Silah","Sur","Tamirhane","Toprak","Turnuva","Tuzakçı","Zırh","Çit","Dökümhane",
            "Değirmen","Ekmek","Marangozhane","Tuğla Fırını"};
            if (otoInsaCheck.IsChecked == true)
            {
                foreach (var koy in koyLinkleri)
                {
                    KoyID = koy.Substring(koy.IndexOf('=') + 1);
                    basla.driver.Navigate().GoToUrl(koy);
                    Thread.Sleep(1500);

                    
                    InsaSureleriOtoKontrol();
                    foreach (var item in hammaddeAlanlariIsimleri)
                    {
                        if (KoyInsaatSureleriveIsimleri.Contains(item))
                        {
                            hammadde = false;
                            break;
                        }
                    }
                    foreach (var item in BinaAlanlariIsimleri)
                    {
                        if (KoyInsaatSureleriveIsimleri.Contains(item))
                        {
                            bina = false;
                            break;
                        }
                    }
                    if (cermenRadioBtn.IsChecked==true)
                    {
                        if(hammadde==false || bina==false) { hammadde = true;bina = true; continue; }
                    }
                    if (hammadde & bina)
                    {

                        //HammaddeVeyabina olarak veriyi gönder.
                        otoInsa("HerikisiTrue", KoyID);
                        hammadde = true; bina = true;

                    }
                    else if (hammadde || bina)
                    {
                        string hamTrue = hammadde == true ? "HamTrue" : null;
                        string binaTrue = bina == true ? "BinaTrue" : null;
                        if (hamTrue != null)
                        {
                            otoInsa(hamTrue, KoyID);
                        }
                        else { otoInsa(binaTrue, KoyID); }

                        hammadde = true; bina = true;

                    }
                    else
                    {
                        hammadde = true; bina = true;

                    }
                    
                }
            }
            comboboxVerileriniDoldur(KoyID);
        }
        void InsaSureleriKontrol() {
            try
            {
                lblInsaat.Content = "";
                //string insaat = basla.driver.FindElementByXPath("//*[@id='content']/div[2]/div[1]/ul/li/div[1]").Text ;
                //DateTime time = DateTime.Parse(basla.driver.FindElementByXPath("//*[@id='content']/div[2]/div[1]/ul/li/div[2]/span").Text);
                //lblInsaat.Content = insaat + time.ToString();
                IWebElement el = basla.driver.FindElementByXPath("//*[@id='content']/div[2]/div[1]/ul");
                IList<IWebElement> all = el.FindElements(By.TagName("div"));
                foreach (var item in all)
                {
                    lblInsaat.Content += item.Text+"\n";
                }
                //Tüm butonları alalım
                IEnumerable<Button> collection = GridKoyIsimleri.Children.OfType<Button>();
                foreach (var item in collection)
                {
                    if (item.Content.ToString().Contains("İnşaat Ekle"))
                    {
                        continue;
                    }
                    if (item.Tag.ToString().Contains(basla.driver.Url))
                    {
                        lblKoyIsmı.Content = item.Content;
                    }
                    
                }
            }
            catch (Exception)
            {

                
            }
        }
        void InsaSureleriOtoKontrol()
        {
            try
            {
                KoyInsaatSureleriveIsimleri = "";
                //string insaat = basla.driver.FindElementByXPath("//*[@id='content']/div[2]/div[1]/ul/li/div[1]").Text ;
                //DateTime time = DateTime.Parse(basla.driver.FindElementByXPath("//*[@id='content']/div[2]/div[1]/ul/li/div[2]/span").Text);
                //lblInsaat.Content = insaat + time.ToString();
                IWebElement el = basla.driver.FindElementByXPath("//*[@id='content']/div[2]/div[1]/ul");
                IList<IWebElement> all = el.FindElements(By.TagName("div"));
                foreach (var item in all)
                {
                    KoyInsaatSureleriveIsimleri += item.Text + "    ";
                }
                //Tüm butonları alalım
                IEnumerable<Button> collection = GridKoyIsimleri.Children.OfType<Button>();
                foreach (var item in collection)
                {
                     if (item.Content.ToString().Contains("İnşaat Ekle"))
                    {
                        continue;
                    }
                    if (item.Tag.ToString().Contains(basla.driver.Url))
                    {
                        lblKoyIsmı.Content = item.Content;
                    }

                }
            }
            catch (Exception)
            {


            }
        }

        void HammaddeAlanKontrol()
        {
            try
            {
                Tuple<string, string, string, string, string> veriler = basla.HammaddeAlanlari();
                lblOdun.Content = veriler.Item1;
                lblTugla.Content = veriler.Item2;
                lblDemir.Content = veriler.Item3;
                lblTahil.Content = veriler.Item4;
                lblAsker.Content = veriler.Item5;
            }
            catch (Exception)
            {


            }
        }
        BitmapImage BitmapToImageSource(Bitmap bitmap)
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
        List<string> koyLinkleri;
        void KoylerinListesiniAl()
        {
            koyLinkleri = new List<string>();
            OpenQA.Selenium.IWebElement el = basla.driver.FindElementById("sidebarBoxVillagelist");
            IList<OpenQA.Selenium.IWebElement> all = el.FindElements(OpenQA.Selenium.By.TagName("a"));
            int KoyId = 0;
            foreach (var item in all)
            {
                Button btn = new Button();
                Button btnInsaatEkle = new Button();

                CheckBox checkBox = new CheckBox();
                TextBox txt = new TextBox();

                if (item.GetAttribute("href")!=null& !item.GetAttribute("href").Contains("statistic"))
                {
                    string koyIsmi = item.Text.Substring(0,item.Text.IndexOf("(")).Trim();
                    koyIsmi= koyIsmi;
                    //koyIsmi= koyIsmi.Substring(0, koyIsmi.IndexOf('\r'));
                    //
                    btn.Content = koyIsmi.Trim();
                    btn.Tag = item.GetAttribute("href");
                    btn.Name = "Koy"+KoyId;
                    btn.Click += Btn_Click;
                    //--
                    btnInsaatEkle.Tag = item.GetAttribute("href");
                    btnInsaatEkle.Name = "Koy" + KoyId;
                    btnInsaatEkle.Content = "İnşaat Ekle";
                    btnInsaatEkle.Click += BtnInsaatEkle_Click;
                    //--
                    checkBox.Name= "Koy" + KoyId;
                    checkBox.Tag= item.GetAttribute("href");
                    checkBox.Content = "Otomatik Asker Bas";
                    checkBox.Checked += CheckBox_Checked;
                    
                    GridKoyIsimleri.ColumnDefinitions.Add(new ColumnDefinition() { Name= "Koy" + KoyId });
                    Grid.SetColumn(btn, KoyId);
                    checkBox.SetValue(Grid.RowProperty, 1);
                    Grid.SetColumn(checkBox, KoyId);
                    btnInsaatEkle.SetValue(Grid.RowProperty, 2);
                    Grid.SetColumn(btnInsaatEkle, KoyId);
                    GridKoyIsimleri.Children.Add(btn);
                    GridKoyIsimleri.Children.Add(checkBox);
                    GridKoyIsimleri.Children.Add(btnInsaatEkle);

                    KoyId++;
                    koyLinkleri.Add(item.GetAttribute("href"));
                    
                }

            }
            KoybilgileriniYukleIlkCalisma();
        }

        private void BtnInsaatEkle_Click(object sender, RoutedEventArgs e)
        {
            if (txtManuelInsaat.Text!=null || txtManuelInsaat.Text!="")
            {
            string KoyId = (sender as Button).Tag.ToString();
            KoyId = KoyId.Substring(KoyId.IndexOf("=") + 1);
            listboxMerkez.Items.Add("e" +txtManuelInsaat.Text+"#"+ KoyId);
            }
            else { MessageBox.Show("Boş İnşaat Verisi Girilemez."); }
        }
        void KoybilgileriniYukleIlkCalisma() {
            foreach (var koy in koyLinkleri)
            {
                basla.driver.Navigate().GoToUrl(koy);
                Thread.Sleep(1500);
                hammaddeKoyAnaliz();
                MerkezKoyAnalizi();
            }
        }
        void Koyler()
        {
            OpenQA.Selenium.IWebElement el = basla.driver.FindElementById("sidebarBoxVillagelist");
            IList<OpenQA.Selenium.IWebElement> all = el.FindElements(OpenQA.Selenium.By.TagName("a"));
            int KoyId = 0;
            foreach (var item in all)
            {
                Button btn = new Button();
                CheckBox checkBox = new CheckBox();
                if (item.GetAttribute("href")!=null& !item.GetAttribute("href").Contains("statistic"))
                {
                    string koyIsmi = item.Text.Substring(0,item.Text.IndexOf("(")).Trim();
                    koyIsmi= koyIsmi.Substring(0, koyIsmi.IndexOf('\r'));
                 
                    koyLinkleri.Add(item.GetAttribute("href"));
                    
                }

            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //Checked Edilmesi Durumunda Otomatik Olarak Asker Basılacak.
            //string name = (sender as CheckBox).Name;
            //if (name== "maceraCheckbox")
            //{
            //    basla.macerayaGonder();
            //}
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            
            lblKoyIsmı.Content = (sender as Button).Content+" Köyündesiniz";
            string url = (sender as Button).Tag.ToString();
            basla.driver.Navigate().GoToUrl(url);
            Thread.Sleep(1500);
            if (basla.koy==0)
            {
                basla.driver.Navigate().GoToUrl(basla.urlMerkez);
                Thread.Sleep(1750);
            }
            lblKoyIsmı.Tag = url.Substring(url.IndexOf('=')+1);
            //hammaddeKoyAnaliz();
            //MerkezKoyAnalizi();
            string ID = url.Substring(url.IndexOf('=') + 1);
            comboboxVerileriniDoldur(ID);
        }
        void comboboxVerileriniDoldur(string ID)
        {
            hammaddeCombobox.Items.Clear();
            merkezCombobox.Items.Clear();
            foreach (var item in Hammaddelinkler)
            {
                string veri = item.Value;
                if (veri.Contains(ID))
                {
                    hammaddeCombobox.Items.Add(veri);
                }
            }
            foreach (var item in Merkezlinkler)
            {
                string veri = item.Value;
                if (veri.Contains(ID))
                {
                    merkezCombobox.Items.Add(veri);
                }
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (otoInsaCheck.IsChecked == true)
            {
                otoInsaTimer.Start();
            }
            else { otoInsaTimer.Stop(); }
            //listboxHammadde.Items.Clear();


        }
        void OtoInsa()
        {

        }
        private void AppExit(object sender, RoutedEventArgs e)
        {
            basla.driver.Close();
           // basla.driverSaldiri.Close();
            Environment.Exit(10);
        }
        SortedList<String, String> Merkezlinkler = new SortedList<string, string>();
        SortedList<String, String> Hammaddelinkler = new SortedList<string, string>();

        void MerkezKoyAnalizi()
        {
            
            string odun, tugla, demir, tahil;
            merkezCombobox.Items.Clear();
            try
            {basadon:
                if (!basla.driver.Url.Contains("dorf2"))
                {
                    basla.driver.Navigate().GoToUrl(basla.urlMerkez);
                    Thread.Sleep(1500);
                    goto basadon;
                }
            else if (true)
                {
                    IWebElement el1 = basla.driver.FindElementById("village_map");
                    IList<IWebElement> all = el1.FindElements(By.TagName("div"));
                    try
                    {

                        for (int i = 1; i <= 21; i++)
                        {   
                            IWebElement element = basla.driver.FindElementByXPath("//*[@id='village_map']/div["+i+"]");
                            if (element.Text=="" || element.Text == null)
                            {
                                continue;
                            }
                            Actions action = new Actions(basla.driver);
                            action.MoveToElement(element).Perform();
                            WebDriverWait wait = new WebDriverWait(basla.driver, TimeSpan.FromSeconds(3));
                            var ElementTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("elementTitle")));
                            #region Hammaddeİhtiyaçları
                            var ElementText = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("elementText")));
                            action.MoveToElement(element).Perform();

                            if (ElementText.Text.Contains("Tamamen"))
                            {
                                continue;
                            }
                            odun = ElementText.FindElement(By.XPath("//div/div/div[10]/div[2]/div/div[1]")).Text;
                            tugla = ElementText.FindElement(By.XPath("//div/div/div[10]/div[2]/div/div[2]")).Text;
                            demir = ElementText.FindElement(By.XPath("//div/div/div[10]/div[2]/div/div[3]")).Text;
                            tahil = ElementText.FindElement(By.XPath("//div/div/div[10]/div[2]/div/div[4]")).Text;
                            string gerekliHammaddeler = odun + "*" + tugla + "*" + demir + "*" + tahil;
                            #endregion          //*[@id="village_map"]/div[1]/a
                            string href = basla.driver.FindElementByXPath("//*[@id='village_map']/div[" + i + "]"+"/a").GetAttribute("href");
                            //Aktif Köy Id si ile key belirleyelim. 
                            IWebElement AktifKoy = basla.driver.FindElementById("sidebarBoxVillagelist");
                            string Aktif = AktifKoy.FindElement(By.ClassName("active")).FindElement(By.TagName("a")).GetAttribute("href");
                            Aktif = Aktif.Substring(Aktif.IndexOf('=') + 1);
                            string EklenecekItem = ElementTitle.Text + " #" + href + "!" + Aktif + "@" + gerekliHammaddeler;
                            if (merkezCombobox.Items.Count>0)
                            {//BURASI İŞE YARAMADI AYNI İSİMLE YENİDEN YÜKLEMELER MEVCUT.
                                if (!merkezCombobox.Items[merkezCombobox.Items.Count - 1].ToString().Contains(gerekliHammaddeler))
                                {
                                    merkezCombobox.Items.Add(EklenecekItem);

                                }
                            }
                            else { merkezCombobox.Items.Add(EklenecekItem); }
                            
                            string key = i.ToString() + "#" + Aktif;
                            if (Merkezlinkler.ContainsKey(key))
                            {

                                if (Merkezlinkler[key] == EklenecekItem)
                                {
                                    Merkezlinkler[key] = Merkezlinkler[key]+"*"+EklenecekItem;
                                }
                                else
                                {
                                    Merkezlinkler[key] = EklenecekItem;
                                }
                            }
                            else
                            {
                                Merkezlinkler.Add(i.ToString() + "#" + Aktif, EklenecekItem);
                            }




                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    string comboboxVerisi = "";
                    IWebElement el1 = basla.driver.FindElementById("village_map");
                    IList<IWebElement> all = el1.FindElements(By.TagName("div"));
                    foreach (var item in all)
                    {
                        if (!item.GetAttribute("class").Contains("buildingSlot") & item.GetAttribute("class").Contains("labelLayer"))
                        {
                            if (item.Text!="")
                            {
                                merkezCombobox.Items.Add("Level " + item.Text + "  " + comboboxVerisi );

                            }

                            continue;
                        }
                        string data_aid = item.GetAttribute("data-aid");
                        string data_gid= item.GetAttribute("data-gid");
                        string name = item.GetAttribute("data-name");
                        string link = basla.baseUrl+ "build.php?id="+data_aid+ "&gid="+data_gid; //https://ts50.x5.arabics.travian.com/build.php?id=19&gid=18
                        //comboboxVerisi = name + "-" + data_aid + "-" + data_gid;
                        comboboxVerisi = name + " $" + data_aid;
                        //Aktif Köy Id si ile key belirleyelim. 
                        IWebElement AktifKoy = basla.driver.FindElementById("sidebarBoxVillagelist");
                        //elemete gidip title alabilecek miyiz bakalım.
                        string Aktif = AktifKoy.FindElement(By.ClassName("active")).FindElement(By.TagName("a")).GetAttribute("href");
                        Aktif = Aktif.Substring(Aktif.IndexOf('=') + 1);
                        string key = data_aid + "#" + Aktif;
                        if (Merkezlinkler.ContainsKey(key))
                        {

                            if (Merkezlinkler[key] == link)
                            {
                                Merkezlinkler[key] = Merkezlinkler[key] + "*" + link;
                            }
                            else
                            {
                                Merkezlinkler[key] = link;
                            }
                        }
                        else
                        {
                            Merkezlinkler.Add(data_aid + "#" + Aktif, link);
                        }
                  
                        
                    }
                }
            }
            catch (Exception)
            {

               
            }
            #region İnşaataUygunlukVarMı
            try
            {
                IList<IWebElement> all = basla.driver.FindElements(By.ClassName("good"));
                if (all.Count > 0)
                {
                    InsaatUygunluk = true;
                }
                else
                {
                    InsaatUygunluk = false;
                }
            }
            catch (Exception)
            {

            }
            #endregion
        }
        
        [Obsolete]
        void hammaddeKoyAnaliz()
        {
            hammaddeCombobox.Items.Clear();
            try
            {
                string odun, tugla, demir, tahil;
            basadon:
                if (!basla.driver.Url.Contains("dorf1"))
                {
                    basla.driver.Navigate().GoToUrl(basla.url);
                    Thread.Sleep(1500);
                    goto basadon;
                }
                else
                {
                    IWebElement el1 = basla.driver.FindElementById("resourceFieldContainer");
                    IList<IWebElement> all = el1.FindElements(By.TagName("div"));
                    //Hammadde Alanlarının Resimlerini Alalım.
                  
                    try
                    {
                        for (int i = 1; i <= 18; i++)
                    {
                            IWebElement element = basla.driver.FindElementByXPath("//*[@id='resourceFieldContainer']/a[" + (i + 1) + "]");
                            Actions action = new Actions(basla.driver);
                            action.MoveToElement(element).Perform();
                            WebDriverWait wait = new WebDriverWait(basla.driver, TimeSpan.FromSeconds(3));
                            var ElementTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("elementTitle")));
                            #region Hammaddeİhtiyaçları
                            var ElementText = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("elementText")));
                            action.MoveToElement(element).Perform();

                            if (ElementText.Text.Contains("Tamamen"))
                            {
                                continue;
                            }
                            odun = ElementText.FindElement(By.XPath("//div/div/div[10]/div[2]/div/div[1]")).Text;
                            tugla = ElementText.FindElement(By.XPath("//div/div/div[10]/div[2]/div/div[2]")).Text;
                            demir = ElementText.FindElement(By.XPath("//div/div/div[10]/div[2]/div/div[3]")).Text;
                            tahil = ElementText.FindElement(By.XPath("//div/div/div[10]/div[2]/div/div[4]")).Text;
                            string gerekliHammaddeler = odun + "*" + tugla + "*" + demir + "*" + tahil;
                            #endregion
                           string href= basla.driver.FindElementByXPath("//*[@id='resourceFieldContainer']/a[" + (i + 1) + "]").GetAttribute("href");

                            //Aktif Köy Id si ile key belirleyelim. 
                            IWebElement AktifKoy = basla.driver.FindElementById("sidebarBoxVillagelist");
                            //elemete gidip title alabilecek miyiz bakalım.
                            string Aktif = AktifKoy.FindElement(By.ClassName("active")).FindElement(By.TagName("a")).GetAttribute("href");
                            Aktif = Aktif.Substring(Aktif.IndexOf('=')+1);
                            hammaddeCombobox.Items.Add(ElementTitle.Text+" #"+ href + "!"+Aktif+"@"+gerekliHammaddeler);
                            string key = i.ToString() + "#" + Aktif;
                            if (Hammaddelinkler.ContainsKey(key))
                            {
                                
                                if (Hammaddelinkler[key]== ElementTitle.Text + " #" + href + "!" + Aktif + "@" + gerekliHammaddeler)
                                {
                                    Hammaddelinkler[key] = Hammaddelinkler[key] + "*" + ElementTitle.Text + " #" + href + "!" + Aktif + "@" + gerekliHammaddeler;
                                }
                                else
                                {
                                    Hammaddelinkler[key] = href;
                                }
                            }
                            else
                            {
                                Hammaddelinkler.Add(i.ToString()+"#"+Aktif, ElementTitle.Text + " #" + href + "!" + Aktif + "@" + gerekliHammaddeler);
                            }
                            
                      
                        
                       
                    }
                    }
                    catch (Exception)
                    {

                    }
                   
                }
            }
            catch (Exception ex)
            {
                string m = ex.Message;

            }
            #region İnşaataUygunlukVarMı
            try
            {
                IList<IWebElement> all = basla.driver.FindElements(By.ClassName("good"));
                if (all.Count>0)
                {
                    HammaddeInsaatUygunluk = true;
                }
                else
                {
                    HammaddeInsaatUygunluk = false;
                }
            }
            catch (Exception)
            {

            }
            #endregion
            #region MerkezKöyAnalizineGec
            //MerkezKoyAnalizi();
            #endregion
        }
        void InsaatUygunlukKontrolu()
        {
            #region İnşaataUygunlukVarMı
            try
            {
                basla.driver.Navigate().GoToUrl(basla.url);
                IList<IWebElement> all = basla.driver.FindElements(By.ClassName("good"));
                if (all.Count > 0)
                {
                    HammaddeInsaatUygunluk = true;
                }
                else
                {
                    HammaddeInsaatUygunluk = false;
                }
                Thread.Sleep(1000);
                basla.driver.Navigate().GoToUrl(basla.urlMerkez);
                IList<IWebElement> all2 = basla.driver.FindElements(By.ClassName("good"));
                if (all2.Count > 0)
                {
                    InsaatUygunluk = true;
                }
                else
                {
                    InsaatUygunluk = false;
                }
                basla.driver.Navigate().GoToUrl(basla.url);

            }
            catch (Exception)
            {

            }
            #endregion

        }
        private void Btn_Click1(object sender, RoutedEventArgs e)
        {
            string link = (sender as Button).Tag.ToString();
            listboxHammadde.Items.Add(link);
        }
        private void ListBoxDel_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.Key==Key.Delete)
            {
                int index = (sender as ListBox).SelectedIndex;
                if (index != -1) (sender as ListBox).Items.RemoveAt(index);
            }
        }
        private void Resim_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if ((sender as System.Windows.Controls.Image).Opacity==50)
            {
                (sender as System.Windows.Controls.Image).Opacity = 100;

            }
            else
            {
                (sender as System.Windows.Controls.Image).Opacity = 50;
            }

        }

        [Obsolete]
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            otoInsaTimer.Interval= TimeSpan.FromSeconds(60);
            //basla = new basla();
            //hammaddeKoyAnaliz();
            //MerkezKoyAnalizi();
        }
        IList<DateTime>times = new List<DateTime>();
        private void btnInsaEkle(object sender, RoutedEventArgs e)
        {
            string tag = (sender as Button).Tag.ToString();
            if (tag== "hammadde")
            {
                if (hammaddeCombobox.SelectedItem!=null)
                {
                    if (x5Hammadde.IsChecked == true)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            listboxHammadde.Items.Add(hammaddeCombobox.SelectedItem);
                        }
                    }
                    else { listboxHammadde.Items.Add(hammaddeCombobox.SelectedItem);}
                    
                }
            }
            else
            {
                if (merkezCombobox.SelectedItem != null )
                {
                    if (x5Bina.IsChecked == true)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            listboxMerkez.Items.Add(merkezCombobox.SelectedItem);
                        }
                    }
                    else
                    {listboxMerkez.Items.Add(merkezCombobox.SelectedItem);}
                    
                }
                
            }
        }
        public bool HammaddeEkle(float odun, float tugla, float demir, float tahil)
        {
            //   MessageBox.Show("Lazım OLan Hammaddeler.: "+ odun +"--"+tugla + "--" + demir + "--" + tahil);
            basla.driver.Navigate().GoToUrl(basla.baseUrl + "hero");
            Thread.Sleep(2000);

            //Scrolu kaydır
            ((IJavaScriptExecutor)basla.driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            try
            {
                if (odun < 0)
                {
                    basla.driver.FindElementById("inventory_1").Click();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").Click();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").Clear();
                    basla.driver.FindElementById("amount").SendKeys(odun.ToString());
                    Thread.Sleep(750);
                    basla.driver.FindElementByXPath
                    ("//*[@id='mainLayout']/body/div[1]/div/div/div/div/form/div[6]/button").Click();

                }
                if (tugla < 0)
                {
                    Thread.Sleep(750);
                    basla.driver.FindElementById("inventory_2").Click();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").Click();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").Clear();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").SendKeys(tugla.ToString());
                    Thread.Sleep(750);
                    basla.driver.FindElementByXPath
                    ("//*[@id='mainLayout']/body/div[1]/div/div/div/div/form/div[6]/button").Click();
                }
                if (demir < 0)
                {
                    Thread.Sleep(750);
                    basla.driver.FindElementById("inventory_3").Click();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").Click();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").Clear();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").SendKeys(demir.ToString());
                    Thread.Sleep(750);
                    basla.driver.FindElementByXPath
                    ("//*[@id='mainLayout']/body/div[1]/div/div/div/div/form/div[6]/button").Click();
                }
                if (tahil < 0)
                {
                    Thread.Sleep(750);
                    basla.driver.FindElementById("inventory_4").Click();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").Click();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").Clear();
                    Thread.Sleep(750);
                    basla.driver.FindElementById("amount").SendKeys(tahil.ToString());
                    Thread.Sleep(750);
                    basla.driver.FindElementByXPath
                    ("//*[@id='mainLayout']/body/div[1]/div/div/div/div/form/div[6]/button").Click();
                }
                if (odun + tugla + tahil + demir > 0)
                {
                    return false;
                }

            }
            catch (Exception)
            {


            }


            return true;
        }
        bool DepoArttildiManuelLink ;
        bool insaEt()
        {
            bool depoArtirildi = false;
            string depoLink="";

            EnbasaDon: string msg = null;
            try
            {

                msg = basla.driver.FindElementByClassName("errorMessage").Text;
                if (msg.Contains("Yeterli "))
                {
                    HammaddeAlanKontrol();
                    if (depoArtirildi)
                    {
                    depolinkKontrolu: basla.driver.Navigate().GoToUrl(depoLink);
                        Thread.Sleep(2000);
                        if (!basla.driver.Url.Contains("build"))
                        {
                            goto depolinkKontrolu;
                        }
                        goto depoArtırıldı;
                    }
                devam1: basla.driver.Navigate().GoToUrl(gecerliUrl);
                    Thread.Sleep(2000);
                    if (!basla.driver.Url.Contains("build"))
                    {
                        goto devam1;
                    }
                   depoArtırıldı: float mevcutOdun, mevcutTugla, mevcutDemir, mevcutTahil;
                    float odun, tugla, demir, tahil;
                    odun = float.Parse(basla.driver.FindElementByXPath("//*[@id='contract']/div[1]/div[1]/span").Text);
                    tugla = float.Parse(basla.driver.FindElementByXPath("//*[@id='contract']/div[1]/div[2]/span").Text);
                    demir = float.Parse(basla.driver.FindElementByXPath("//*[@id='contract']/div[1]/div[3]/span").Text);
                    tahil = float.Parse(basla.driver.FindElementByXPath("//*[@id='contract']/div[1]/div[4]/span").Text);
                    //Mevcut hammadde degerleri
                    mevcutOdun = float.Parse(lblOdun.Content.ToString());
                    mevcutTugla = float.Parse(lblTugla.Content.ToString());
                    mevcutDemir = float.Parse(lblDemir.Content.ToString());
                    mevcutTahil = float.Parse(lblTahil.Content.ToString());

                    //Eğer 0 dan büyükse ham gerekmiyor.
                    odun = mevcutOdun - odun > 0 ? 0 : mevcutOdun - odun;
                    tugla = mevcutTugla - tugla > 0 ? 0 : mevcutTugla - tugla;
                    demir = mevcutDemir - demir > 0 ? 0 : mevcutDemir - demir;
                    tahil = mevcutTahil - tahil > 0 ? 0 : mevcutTahil - tahil;

                    if (odun + tugla + tahil + demir < 0)
                    {
                        HammaddeEkle(odun, tugla, demir, tahil);

                    }
                    //Hammadde eklendikten sonra depo gerekiyor ise depo inşası için metodu çağırıp geriye false dönüyoruz.
                    
                    if (depoArtirildi)
                    {
                    depolinkKontrolu: basla.driver.Navigate().GoToUrl(depoLink);
                        Thread.Sleep(2000);
                        if (!basla.driver.Url.Contains("build"))
                        {
                            goto depolinkKontrolu;
                        }
                        if (DepoAlaniInsaet()) { return false; }
                    }
                devam: basla.driver.Navigate().GoToUrl(gecerliUrl);
                    Thread.Sleep(2000);
                    if (!basla.driver.Url.Contains("build"))
                    {
                        goto devam;
                    }
                    msg = null;
                }else if (msg.Contains("Önce hammadde"))
                {
                devam: basla.driver.Navigate().GoToUrl(basla.baseUrl+ "build.php?gid=10");
                    if (!basla.driver.Url.Contains("build"))
                    {
                        goto devam;
                    }
                    depoLink = basla.driver.Url;
                    depoArtirildi = true;
                    goto EnbasaDon;
                }
                else if (msg.Contains("Önce tahıl"))
                {
                devam: basla.driver.Navigate().GoToUrl(basla.baseUrl + "build.php?gid=11");
                    if (!basla.driver.Url.Contains("build"))
                    {
                        goto devam;
                    }
                    depoLink = basla.driver.Url;
                    depoArtirildi = true;
                    goto EnbasaDon;
                }
                else if (msg.Contains("eğlence"))
                {
                    msg = null;
                }
            }
            catch (Exception)
            {


            }
            if (msg==null)
            {
                if (basla.driver.FindElementByClassName("titleInHeader").Text.Contains("Yeni"))
                {

                    IList<IWebElement> all = basla.driver.FindElements(By.ClassName("contractLink"));
                    foreach (var el in all)
                    {

                        if (el.FindElement(By.TagName("button")).Text.Contains("Travian "))
                        {
                            break;
                        }
                        if (el.FindElement(By.TagName("button")).GetAttribute("value").Contains("Mimar"))
                        {
                            break;
                        }
                        el.FindElement(By.TagName("button")).Click();
                        Thread.Sleep(1500);

                        return true;
                    }
                }
             IWebElement seviye = basla.driver.FindElementByClassName("level");
                if (seviye.Text.Contains("Seviye 0"))
                {
                    IList<IWebElement> all = basla.driver.FindElements(By.ClassName("section1"));
                    foreach (var el in all)
                    {
                        if (el.FindElement(By.TagName("button")).Text.Contains("Travian "))
                        {
                            break;
                        }
                        //string timeMetin = basla.driver.FindElementByXPath("//*[@id='build']/div[3]/div[3]/div[2]/div/span").Text;
                        //DateTime time = DateTime.Parse(timeMetin);

                        el.FindElement(By.TagName("button")).Click();
                        //times.Add(time);

                        return true;
                    }
                }
  else if (basla.driver.FindElementByClassName("titleInHeader").Text.Contains("Köşk") || basla.driver.FindElementByClassName("titleInHeader").Text.Contains("Saray"))
                {
                    IList<IWebElement> all = basla.driver.FindElements(By.ClassName("section1"));
                    foreach (var el in all)
                    {

                        if (el.FindElement(By.TagName("button")).Text.Contains("Travian "))
                        {
                            break;
                        }
                        if (el.FindElement(By.TagName("button")).GetAttribute("value").Contains("Mimar"))
                        {
                            break;
                        }
                        string timeMetin = basla.driver.FindElementByXPath("//*[@id='build']/div[3]/div[3]/div[1]/div/span").Text;
                        DateTime time = DateTime.Parse(timeMetin);
                        el.FindElement(By.TagName("button")).Click();
                        times.Add(time);

                        return true;
                    }
                }
                else
                {
                   section2: IList<IWebElement> all = basla.driver.FindElements(By.ClassName("section2"));
                    foreach (var el in all)
                    {
                       
                        if (el.FindElement(By.TagName("button")).Text.Contains("Travian "))
                        {
                            return false;

                        }
                        string timeMetin = basla.driver.FindElementByXPath("//*[@id='build']/div[3]/div[3]/div[2]/div/span").Text;
                        DateTime time = DateTime.Parse(timeMetin);
                        el.FindElement(By.TagName("button")).Click();
                        times.Add(time);

                    }
                    Thread.Sleep(1000);
                    try
                    {
                        basla.driver.Manage().Window.Maximize();
                    }
                    catch (Exception)
                    {


                    }


                    //Video izleme butunu.
                    IList<IWebElement> videoAll = basla.driver.FindElements(By.ClassName("buttonWrapper"));
                    foreach (var videoEl in videoAll)
                    {
                        videoEl.FindElement(By.TagName("button")).Click();
                        Thread.Sleep(25000);
                        if (depoArtirildi)
                        {
                            return false;
                        }
                        return true;
                    }
                   

                    //basla.driver.FindElement(By.XPath("//*[@id='example_video_test']/div[5]/div[1]/button")).Click();
                    try
                    {
                        basla.driver.FindElement(By.CssSelector("#example_video_test > button")).Click();
                        return true;

                    }
                    catch (Exception)
                    {

                        return true;

                    }

                }


            }
            return false;
        }
        bool  DepoAlaniInsaet()
        {
            {
                if (basla.driver.FindElementByClassName("titleInHeader").Text.Contains("Yeni"))
                {

                    IList<IWebElement> all = basla.driver.FindElements(By.ClassName("contractLink"));
                    foreach (var el in all)
                    {

                        if (el.FindElement(By.TagName("button")).Text.Contains("Travian "))
                        {
                            break;
                        }
                        if (el.FindElement(By.TagName("button")).GetAttribute("value").Contains("Mimar"))
                        {
                            break;
                        }
                        el.FindElement(By.TagName("button")).Click();
                        Thread.Sleep(1500);

                        return true;
                    }
                }
                IWebElement seviye = basla.driver.FindElementByClassName("level");
                if (seviye.Text.Contains("Seviye 0"))
                {
                    IList<IWebElement> all = basla.driver.FindElements(By.ClassName("section1"));
                    foreach (var el in all)
                    {
                        if (el.FindElement(By.TagName("button")).Text.Contains("Travian "))
                        {
                            break;
                        }
                     
                        el.FindElement(By.TagName("button")).Click();
                       

                        return true;
                    }
                }
                else if (basla.driver.FindElementByClassName("titleInHeader").Text.Contains("Köşk") || basla.driver.FindElementByClassName("titleInHeader").Text.Contains("Saray"))
                {
                    IList<IWebElement> all = basla.driver.FindElements(By.ClassName("section1"));
                    foreach (var el in all)
                    {

                        if (el.FindElement(By.TagName("button")).Text.Contains("Travian "))
                        {
                            break;
                        }
                        if (el.FindElement(By.TagName("button")).GetAttribute("value").Contains("Mimar"))
                        {
                            break;
                        }
                        string timeMetin = basla.driver.FindElementByXPath("//*[@id='build']/div[3]/div[3]/div[1]/div/span").Text;
                        DateTime time = DateTime.Parse(timeMetin);
                        el.FindElement(By.TagName("button")).Click();
                        times.Add(time);

                        return true;
                    }
                }
                else
                {
                 IList<IWebElement> all = basla.driver.FindElements(By.ClassName("section2"));
                    foreach (var el in all)
                    {

                        if (el.FindElement(By.TagName("button")).Text.Contains("Travian "))
                        {
                            return false;

                        }
                        string timeMetin = basla.driver.FindElementByXPath("//*[@id='build']/div[3]/div[3]/div[2]/div/span").Text;
                        DateTime time = DateTime.Parse(timeMetin);
                        el.FindElement(By.TagName("button")).Click();
                        times.Add(time);

                    }
                    Thread.Sleep(1000);
                    try
                    {
                        basla.driver.Manage().Window.Maximize();
                    }
                    catch (Exception){}

                    //Video izleme butunu.
                    IList<IWebElement> videoAll = basla.driver.FindElements(By.ClassName("buttonWrapper"));
                    foreach (var videoEl in videoAll)
                    {
                        videoEl.FindElement(By.TagName("button")).Click();
                        Thread.Sleep(25000);
                        DepoArttildiManuelLink = true;
                        return true;
                    }
                    try
                    {
                        basla.driver.FindElement(By.CssSelector("#example_video_test > button")).Click();
                        return true;

                    }
                    catch (Exception)
                    {

                        return true;

                    }

                }


            }
            return true;
        }
        string gecerliUrl;
        void otoInsa(string hangiSecenek,string  ID)
        {
            bool breaking = false;
            //Gelen Hammadde veya Merkez true false değerine göre direk ona gidilecek go to lar oluşturulacak.
            if (hangiSecenek == "HerikisiTrue")
            {
                goto durum1;
            }
            else if (hangiSecenek == "HamTrue") { breaking = true; goto durum1;  }
            else { goto durum2; }
            
           durum1: if (listboxHammadde.Items.Count > 0)
            {
                bool gelistirmeVarmi = false;
                //basla.driver.Navigate().GoToUrl(basla.url);
                //Thread.Sleep(1500);
                if (heybeCheck.IsChecked == true)
                {
                    #region KöyIdisiniAyarla
                    if (listboxHammadde.SelectedIndex == -1)
                    {
                         for (int i = 0; i <= listboxHammadde.Items.Count-1; i++)
                        {
                            listboxHammadde.SelectedIndex = i;
                            if (listboxHammadde.SelectedItem==null)
                            {
                                continue;
                            }
                            if (listboxHammadde.SelectedItem.ToString().Contains(ID))
                            {
                                gelistirmeVarmi = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= listboxHammadde.Items.Count - 1; i++)
                        {
                            listboxHammadde.SelectedIndex = i;
                            if (listboxHammadde.SelectedItem.ToString().Contains(ID))
                            {
                                gelistirmeVarmi = true;
                                break;
                            }
                        }
                    }
                    if (!gelistirmeVarmi)
                    {
                        if (breaking)
                        {
                            goto End;
                        }
                        else
                        {
                            goto durum2;
                        }
                    }
                    #endregion KöyIdisiniAyarla
                    string veri = listboxHammadde.SelectedItem.ToString();
                    
                    string link = veri.Substring(veri.IndexOf('#') + 1, veri.IndexOf('!') - veri.IndexOf('#')-1); // İnşaatın Linki. 
                    string HangiKoy = veri.Substring(veri.IndexOf('!') + 1, veri.IndexOf('@') - veri.IndexOf('!')-1);
                    gecerliUrl = link;
                    //Tarla Seviye 3 #https://ts50.x5.arabics.travian.com/build.php?id=1!22265&@325*420*325*95
                    string gerekliHammaddeler = veri.Substring(veri.IndexOf('@') + 1);
                    //hammaddeleri ayır.
                    string[] hammaddeler = gerekliHammaddeler.Split('*');
                    for (int i = 0; i <= hammaddeler.Length - 1; i++)
                    {
                        if (hammaddeler[i] == "")
                        {
                            hammaddeler[i] = "0";
                        }
                    }
                    //Hangi köye ait ise o köye gidilir.
                    basla.driver.Navigate().GoToUrl(basla.url + "?newdid=" + HangiKoy);
                    Thread.Sleep(2000);
                    HammaddeAlanKontrol();
                    //hammaddeCombobox.Items.Add(ElementTitle.Text+" #"+btn.Tag.ToString()+"!"+Aktif+"@"+gerekliHammaddeler);
                    #region hammaddemiktalarınıKontrolEt ve inşayı tamamla.
                    float odun = float.Parse(hammaddeler[0]), tugla = float.Parse(hammaddeler[1]), demir = float.Parse(hammaddeler[2]), tahil = float.Parse(hammaddeler[3]);
                    float mevcutOdun, mevcutTugla, mevcutDemir, mevcutTahil;

                    //Mevcut hammadde degerleri
                    mevcutOdun = float.Parse(lblOdun.Content.ToString());
                    mevcutTugla = float.Parse(lblTugla.Content.ToString());
                    mevcutDemir = float.Parse(lblDemir.Content.ToString());
                    mevcutTahil = float.Parse(lblTahil.Content.ToString());

                    //Eğer 0 dan büyükse ham gerekmiyor.
                    odun = mevcutOdun - odun > 0 ? 0 : mevcutOdun - odun;
                    tugla = mevcutTugla - tugla > 0 ? 0 : mevcutTugla - tugla;
                    demir = mevcutDemir - demir > 0 ? 0 : mevcutDemir - demir;
                    tahil = mevcutTahil - tahil > 0 ? 0 : mevcutTahil - tahil;
                    if (odun + tugla + tahil + demir < 0)
                    {
                        if (HammaddeEkle(odun, tugla, demir, tahil))
                        {
                            //True Döndü Şimdi linke Git.
                            
                           devam: basla.driver.Navigate().GoToUrl(link);
                            Thread.Sleep(2000);
                            if (!basla.driver.Url.Contains("build"))
                            {
                                goto devam;
                            }
                            otoInsaTimer.Stop();
                            //Timer oluşturup içine time değerini atıp dönüş miktarı inşatt süresi kadar olunca time kendliğinden duracak. Durdugunda silim yapacak.
                            bool durum = insaEt();
                            if (durum)
                            {
                                listboxHammaddeInsaat.Items.Add(listboxHammadde.SelectedIndex);
                                listboxHammadde.Items.RemoveAt(listboxHammadde.SelectedIndex);
                               
                            }
                            otoInsaTimer.Start();

                        }
                    }
                    else
                    {
                        devam: basla.driver.Navigate().GoToUrl(link);
                        if (!basla.driver.Url.Contains("build"))
                        {
                            goto devam;
                        }
                        otoInsaTimer.Stop();

                        bool durum = insaEt();
                        if (durum)
                        {
                            listboxHammaddeInsaat.Items.Add(listboxHammadde.SelectedIndex);
                            listboxHammadde.Items.RemoveAt(listboxHammadde.SelectedIndex);

                           

                        }
                        otoInsaTimer.Start();

                    }
                    if (breaking)
                    {
                        goto End;
                    }
                    #endregion

                }
                else
                {
                    #region KöyIdisiniAyarla
                    if (listboxHammadde.SelectedIndex == -1)
                    {
                        for (int i = 0; i <= listboxHammadde.Items.Count - 1; i++)
                        {
                            listboxHammadde.SelectedIndex = i;
                            if (listboxHammadde.SelectedItem.ToString().Contains(ID))
                            {
                                gelistirmeVarmi = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= listboxHammadde.Items.Count - 1; i++)
                        {
                            listboxHammadde.SelectedIndex = i;
                            if (listboxHammadde.SelectedItem.ToString().Contains(ID))
                            {
                                gelistirmeVarmi = true;
                                break;
                            }
                        }
                    }
                    #endregion KöyIdisiniAyarla
                    if (!gelistirmeVarmi)
                    {
                        if (breaking)
                        {
                            goto End;
                        }
                        else
                        {
                            goto durum2;
                        }
                    }
                    string veri = listboxHammadde.SelectedItem.ToString();
                    string link = veri.Substring(veri.IndexOf('#') + 1, veri.IndexOf('!') - veri.IndexOf('#') - 1); // İnşaatın Linki.
                    string HangiKoy = veri.Substring(veri.IndexOf('!') + 1, veri.IndexOf('@') - veri.IndexOf('!') - 1);
                    //Tarla Seviye 3 #https://ts50.x5.arabics.travian.com/build.php?id=1!22265&@325*420*325*95
                    string gerekliHammaddeler = veri.Substring(veri.IndexOf('@') + 1);
                    //hammaddeleri ayır.
                    string[] hammaddeler = gerekliHammaddeler.Split('*');
                    for (int i = 0; i <= hammaddeler.Length - 1; i++)
                    {
                        if (hammaddeler[i] == "")
                        {
                            hammaddeler[i] = "0";
                        }
                    }
                    //Hangi köye ait ise o köye gidilir.
                    basla.driver.Navigate().GoToUrl(basla.url + "?newdid=" + HangiKoy);
                    Thread.Sleep(1500);
                devam: basla.driver.Navigate().GoToUrl(link);
                    Thread.Sleep(1000);
                    if (!basla.driver.Url.Contains("build"))
                    {
                        goto devam;
                    }
                    otoInsaTimer.Stop();

                    bool durum = insaEt();
                    if (durum)
                    {
                        listboxHammaddeInsaat.Items.Add(listboxHammadde.SelectedIndex);
                        listboxHammadde.Items.RemoveAt(listboxHammadde.SelectedIndex);

                       

                    }
                    Thread.Sleep(5000);
                    otoInsaTimer.Start();
                    if (breaking)
                    {
                        goto End;
                    }
                }
            }
            durum2: if (listboxMerkez.Items.Count > 0)
            {
                //basla.driver.Navigate().GoToUrl(basla.urlMerkez);
                //Thread.Sleep(1500);
                bool gelistirmeVarmi = false;

                if (heybeCheck.IsChecked == true)
                {
                    #region KöyIdisiniAyarla
                    if (listboxMerkez.SelectedIndex == -1)
                    {
                        for (int i = 0; i <= listboxMerkez.Items.Count - 1; i++)
                        {
                            listboxMerkez.SelectedIndex = i;
                            if (listboxMerkez.SelectedItem.ToString().Contains(ID))
                            {
                                gelistirmeVarmi = true;

                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= listboxMerkez.Items.Count - 1; i++)
                        {
                            listboxMerkez.SelectedIndex = i;
                            if (listboxMerkez.SelectedItem.ToString().Contains(ID))
                            {
                                gelistirmeVarmi = true;

                                break;
                            }
                        }
                    }
                    #endregion KöyIdisiniAyarla
                    if (!gelistirmeVarmi)
                    {
                        goto End;
                    }
                    if (listboxMerkez.SelectedItem.ToString().Substring(0,1)=="e")
                    {
                        basla.driver.Navigate().GoToUrl(basla.url + "?newdid=" + listboxMerkez.SelectedItem.ToString().Substring('#'+1));
                        Thread.Sleep(2000);
                        string manuelLink = listboxMerkez.SelectedItem.ToString().Substring(1); 
                        manuelLink = manuelLink.Substring(0,manuelLink.IndexOf('#'));gecerliUrl = manuelLink;
                    devam: basla.driver.Navigate().GoToUrl(manuelLink);
                        Thread.Sleep(2000);
                        if (!basla.driver.Url.Contains("build"))
                        {
                            goto devam;
                        }
                        bool durum = insaEt();
                        if (durum)
                        {
                            listboxMerkez.Items.RemoveAt(listboxMerkez.SelectedIndex);
                            goto End;
                        }
                        else
                        {
                            if (DepoArttildiManuelLink)
                            {
                                DepoArttildiManuelLink = false;
                                goto End;
                            }
                            bool manuelbitti = false;
                            for (int i = 0; i <= listboxMerkez.Items.Count - 1; i++)
                            {
                                if (listboxMerkez.Items[i].ToString().Substring(0, 1) != "e")
                                {
                                    manuelbitti = true;
                                    listboxMerkez.SelectedIndex = i;
                                    break;
                                }
                            }
                            if (manuelbitti == false)
                            {
                                goto End;
                            }
                        }
                    }
                    string veri = listboxMerkez.SelectedItem.ToString();
                    string link = veri.Substring(veri.IndexOf('#') + 1, veri.IndexOf('!') - veri.IndexOf('#') - 1); // İnşaatın Linki. 
                    gecerliUrl = link;
                    string HangiKoy = veri.Substring(veri.IndexOf('!') + 1, veri.IndexOf('@') - veri.IndexOf('!') - 1);
                    //Tarla Seviye 3 #https://ts50.x5.arabics.travian.com/build.php?id=1!22265&@325*420*325*95
                    string gerekliHammaddeler = veri.Substring(veri.IndexOf('@') + 1);
                    //hammaddeleri ayır.
                    string[] hammaddeler =gerekliHammaddeler.Split('*');
                    for (int i = 0; i <= hammaddeler.Length-1; i++)
                    {
                        if (hammaddeler[i]=="")
                        {
                            hammaddeler[i] = "0";
                        }
                    }
                    //Hangi köye ait ise o köye gidilir.
                    basla.driver.Navigate().GoToUrl(basla.url + "?newdid=" + HangiKoy);
                    Thread.Sleep(2000);
                    //hammaddeCombobox.Items.Add(ElementTitle.Text+" #"+btn.Tag.ToString()+"!"+Aktif+"@"+gerekliHammaddeler);
                    #region hammaddemiktalarınıKontrolEt ve inşayı tamamla.
                    HammaddeAlanKontrol();
                    float odun = float.Parse(hammaddeler[0]), tugla = float.Parse(hammaddeler[1]), demir = float.Parse(hammaddeler[2]), tahil = float.Parse(hammaddeler[3]);
                    float mevcutOdun, mevcutTugla, mevcutDemir, mevcutTahil;

                    //Mevcut hammadde degerleri
                    mevcutOdun = float.Parse(lblOdun.Content.ToString());
                    mevcutTugla = float.Parse(lblTugla.Content.ToString());
                    mevcutDemir = float.Parse(lblDemir.Content.ToString());
                    mevcutTahil = float.Parse(lblTahil.Content.ToString());

                    //Eğer 0 dan büyükse ham gerekmiyor.
                    odun = mevcutOdun - odun > 0 ? 0 : mevcutOdun - odun;
                    tugla = mevcutTugla - tugla > 0 ? 0 : mevcutTugla - tugla;
                    demir = mevcutDemir - demir > 0 ? 0 : mevcutDemir - demir;
                    tahil = mevcutTahil - tahil > 0 ? 0 : mevcutTahil - tahil;
                    if (odun + tugla + tahil + demir < 0)
                    {
                        if (HammaddeEkle(odun, tugla, demir, tahil))
                        {
                            Thread.Sleep(1500);
                        //True Döndü Şimdi linke Git.
                        devam: basla.driver.Navigate().GoToUrl(link);
                             Thread.Sleep(2000);
                            if (!basla.driver.Url.Contains("build"))
                            {
                                goto devam;
                            }
                            otoInsaTimer.Stop();

                            bool durum = insaEt();
                            if (durum)
                            {
                                listboxMerkezInsaat.Items.Add(listboxMerkez.SelectedIndex);

                                listboxMerkez.Items.RemoveAt(listboxMerkez.SelectedIndex);
                                
                            }
                            Thread.Sleep(5000);

                            otoInsaTimer.Start();

                        }
                    }
                    else
                    {
                        devam: basla.driver.Navigate().GoToUrl(link);
                        Thread.Sleep(1500);
                        if (!basla.driver.Url.Contains("build"))
                        {
                            goto devam;
                        }
                        otoInsaTimer.Stop();

                        bool durum = insaEt();
                        if (durum)
                        {
                            listboxMerkezInsaat.Items.Add(listboxMerkez.SelectedIndex);

                            listboxMerkez.Items.RemoveAt(listboxMerkez.SelectedIndex);

                            

                        }
                        Thread.Sleep(5000);

                        otoInsaTimer.Start();

                    }

                    #endregion

                }
                else
                {
                    #region KöyIdisiniAyarla
                    if (listboxMerkez.SelectedIndex == -1)
                    {
                        for (int i = 0; i <= listboxMerkez.Items.Count - 1; i++)
                        {
                            listboxMerkez.SelectedIndex = i;
                            if (listboxMerkez.SelectedItem.ToString().Contains(ID))
                            {
                                gelistirmeVarmi = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= listboxMerkez.Items.Count - 1; i++)
                        {
                            listboxMerkez.SelectedIndex = i;
                            if (listboxMerkez.SelectedItem.ToString().Contains(ID))
                            {
                                gelistirmeVarmi = true;
                                break;
                            }
                        }
                    }
                    #endregion KöyIdisiniAyarla
                    if (!gelistirmeVarmi)
                    {
                        goto End;
                    }
                    if (listboxMerkez.SelectedItem.ToString().Substring(0, 1) == "e")
                    {
                        basla.driver.Navigate().GoToUrl(basla.url + "?newdid=" + listboxMerkez.SelectedItem.ToString().Substring('#' + 1));
                        Thread.Sleep(2000);
                        string manuelLink = listboxMerkez.SelectedItem.ToString().Substring(1);
                        manuelLink = manuelLink.Substring(0,manuelLink.IndexOf('#'));
                    kontrolEt: basla.driver.Navigate().GoToUrl(manuelLink);
                        Thread.Sleep(2000);
                        if (!basla.driver.Url.Contains("build"))
                        {
                            goto kontrolEt;
                        }
                        bool durumBak = insaEt();
                        if (durumBak)
                        {
                            listboxMerkez.Items.RemoveAt(listboxMerkez.SelectedIndex);
                            goto End;
                        }
                        else
                        {
                            bool manuelbitti = false;
                            for (int i = 0; i <= listboxMerkez.Items.Count-1; i++)
                            {
                                if (listboxMerkez.Items[i].ToString().Substring(0,1)!="e")
                                {
                                    manuelbitti = true;
                                    listboxMerkez.SelectedIndex = i;
                                    break;
                                }
                            }
                            if (manuelbitti==false)
                            {
                                goto End;
                            }
                        }
                    }
                    string veri = listboxMerkez.SelectedItem.ToString();
                    string link = veri.Substring(veri.IndexOf('#') + 1, veri.IndexOf('!') - veri.IndexOf('#') - 1); // İnşaatın Linki.
                    string HangiKoy = veri.Substring(veri.IndexOf('!') + 1, veri.IndexOf('@') - veri.IndexOf('!') - 1);
                    //Tarla Seviye 3 #https://ts50.x5.arabics.travian.com/build.php?id=1!22265&@325*420*325*95
                    string gerekliHammaddeler = veri.Substring(veri.IndexOf('@') + 1);
                    //hammaddeleri ayır.
                    string[] hammaddeler = gerekliHammaddeler.Split('*');
                    for (int i = 0; i <= hammaddeler.Length - 1; i++)
                    {
                        if (hammaddeler[i] == "")
                        {
                            hammaddeler[i] = "0";
                        }
                    }
                    //Hangi köye ait ise o köye gidilir.
                    basla.driver.Navigate().GoToUrl(basla.url + "?newdid=" + HangiKoy);
                    Thread.Sleep(1500);
                   devam: basla.driver.Navigate().GoToUrl(link);
                    Thread.Sleep(1000);
                    
                    if (!basla.driver.Url.Contains("build"))
                    {
                        goto devam;
                    }
                    otoInsaTimer.Stop();

                    bool durum = insaEt();
                    if (durum)
                    {
                        listboxMerkezInsaat.Items.Add(listboxMerkez.SelectedIndex);

                        listboxMerkez.Items.RemoveAt(listboxMerkez.SelectedIndex);
                        

                    }
                    //Thread.Sleep(5000);

                    otoInsaTimer.Start();

                }
            }
            End: breaking = true;
        }

        private void YenidenYukle(object sender, RoutedEventArgs e)
        {
            merkezCombobox.Items.Clear();
            hammaddeCombobox.Items.Clear();
            Hammaddelinkler.Clear();
            Merkezlinkler.Clear();
            GridKoyIsimleri.Children.Clear();
            GridKoyIsimleri.ColumnDefinitions.Clear();
            KoybilgileriniYukleIlkCalisma();
        }
    }
}
