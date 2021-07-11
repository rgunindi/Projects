using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication5
{
  public partial class veri : Form
  {
    public veri()
    {
      InitializeComponent();
    }
    OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/mails.accdb");
    OleDbConnection bags = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "/face.accdb");
    public void faces()
    {
      try
      {

        DataSet ds = new DataSet();
        if (bags.State == ConnectionState.Closed)
        {
          bags.Open();
        }
        {
          ds.Clear();
          OleDbCommand komut = new OleDbCommand("INSERT INTO Face (isim,sifre)Values ('" + Hesap.w1 + "@mynet.com" + "','" + Hesap.w2 + "')", bags);
          komut.ExecuteNonQuery();
         
          bags.Close();

        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        bags.Close();
      }
      if (bags.State == ConnectionState.Open)
      {
        bags.Close();
      }

    }
    public void vt()
    {
     

      try
      {
        DataSet ds = new DataSet();
        if (bag.State == ConnectionState.Closed)
        {
          bag.Open();
          ds.Clear();
          OleDbCommand komut = new OleDbCommand("INSERT INTO Mail (mail,sifre)Values ('" + Hesap.w1+"@mynet.com" + "','" + Hesap.w2 + "')", bag);
          komut.ExecuteNonQuery();
        
          bag.Close();

        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        bag.Close();
      }

    }
    string c;
    private void Form3_Load(object sender, EventArgs e)
    {
      try
      {

      
      //if (Hesap.qw==1)
      {
        OleDbCommand komuts = new OleDbCommand("Select * From Face", bags);
        OleDbCommand komut = new OleDbCommand("Select * From Mail", bag);
        bag.Open();
        OleDbDataReader oku = komut.ExecuteReader();
        bags.Open();
        OleDbDataReader okus = komuts.ExecuteReader();
        oku.Read();
        okus.Read();
        while (oku.Read())
        {
          listBox1.Items.Add(oku["mail"] + " Password: " + oku["sifre"]);
        }
        /*while (okus.Read())
        {
          
         listBox1.Items.Add(oku["isim"] + " Password: " + oku["sifre"]);
        }*/
      }
     /* if (Hesap.adres=="1")
      {
        vt();
      //  timer1.Enabled = true;
      }*/
      
   /*   q = listBox1.Items.Count;
      MessageBox.Show(q.ToString());
      OleDbCommand komutS = new OleDbCommand("Select * From Mail WHERE ID=" + q, bag);
      OleDbDataReader okur = komutS.ExecuteReader();
      c = listBox1.Items[q - 1].ToString();
      MessageBox.Show(c);
      */
      bags.Close();
      bag.Close();
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
     
      OleDbCommand komut = new OleDbCommand("Select * From Mail",bag);
      bag.Open();
      OleDbDataReader oku=komut.ExecuteReader();
      string v;
      int q;
      oku.Read();
      q = listBox1.Items.Count;
      MessageBox.Show("Saldırı İçin "+ q.ToString()+" Tane Mailiniz Var");
     /* OleDbCommand komutS = new OleDbCommand("Select * From Mail WHERE ID="+q, bag);
      OleDbDataReader okur = komutS.ExecuteReader();
      c = listBox1.Items[q-1].ToString();
      MessageBox.Show(c);
      */
      bag.Close();
      MessageBox.Show("Şuan İzin Verilemez", "Düşük Versiyon");
     
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      OleDbCommand komut = new OleDbCommand("Select * From Mail", bag);
      if (bag.State==ConnectionState.Closed)
      {
        bag.Open();

        OleDbDataReader oku = komut.ExecuteReader();

        oku.Read();
        while (oku.Read())
        {
          listBox1.Items.Add(oku["mail"] + " Password: " + oku["sifre"]);
        }
        timer1.Enabled = false;
       // MessageBox.Show("Çalıştı");
      }
    }
  }
}
