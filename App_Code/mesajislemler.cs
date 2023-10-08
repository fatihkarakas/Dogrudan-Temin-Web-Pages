using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
//using System.Net.Mail;
using System.Web.Mail;
using System.Net;
using System.Text;
/// <summary>
/// Summary description for mesajislemler
/// </summary>
public class mesajislemler
{
    public MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
    public MySqlDataReader oku;
    public MySqlDataAdapter adpt = new MySqlDataAdapter();
    public MySqlCommand sorgu = new MySqlCommand();
    public DataSet ds = new DataSet();
    public string mesaj_hata;
    public string mskonu;
    public string msmesaj;
    public string msdosya;
    public string mskimlere;
    public int mskimden;
    public string mskimeisimler;
    public string msguid;
    public string msdosyaurl = "yok";
    public string msepostalar;
    public string[] epostalit;
    public int mesajsayi, okunmamis, okunmus, gonderilen;
	public mesajislemler()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void mail_gonder(string kime, string mesaj)
    {
        MailMessage message = new MailMessage();
        message.BodyFormat = MailFormat.Html;
        message.BodyEncoding = System.Text.Encoding.GetEncoding("iso-8859-9");
        message.BodyFormat = MailFormat.Html;
        message.From = "ankarakhb3@gmail.com";
        //message.Bcc = "fatihkarakas@outlook.com";
        message.To = kime;
        //message.Bcc= "uses@uses.gov.tr";
        message.Subject = "Doğrudan Temin Programından Mesaj Aldınız!!";
        message.Body = mesaj + "<br />Sisteme Giriş yapmak için <a href='http://dt.ankara3.khb.saglik.gov.tr'>Tıklayınız</a>";
       
        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "ankarakhb3@gmail.com");
       // message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "uses2015.,");
        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "Dt372054!");
        SmtpMail.SmtpServer = "smtp.gmail.com";
        //SmtpMail.SmtpServer = "mail.uses.gov.tr";

        // - smtp.gmail.com use port 465 or 587
        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");//port is: 465

        // - smtp.gmail.com use STARTTLS (some call this SSL)
        message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
        SmtpMail.Send(message);
        //SmtpMail.SmtpServer = "smtp.gmail.com";

        //var smtp = new SmtpClient
        //{
        //    Host = "smtp.gmail.com",
        //    Port = 465,
        //    EnableSsl = true,
        //    DeliveryMethod = SmtpDeliveryMethod.Network,
        //    UseDefaultCredentials = false,
        //    Credentials = new NetworkCredential("ankarakhb3@gmail.com", "Dt372054!")
        //};
        //using (var message = new MailMessage("ankarakhb3@gmail.com", kime)
        //{
        //    Subject = "Doğrudan Temin Programından Mesaj Aldınız!!",
        //    Body = mesaj +  "<br />Sisteme Giriş yapmak için <a href='http://dt.ankara3.khb.saglik.gov.tr'>Tıklayınız</a>",
        //    IsBodyHtml = true,
            
        //})
        //{
        //    smtp.Send(message);
        //}
    }
    public void mesajgidenler(int kim)
    {
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu = new MySqlCommand();
            sorgu.Connection = Baglanti;
            sorgu.CommandType = CommandType.Text;
            sorgu.CommandText = "SELECT `mgid`, `konu`, `mesaj`, `kimden`, `kime`, `kime_isimler`, `tarih`,  `gonderilen_kod`,  CASE dosyaurl WHEN '' THEN 'images/dosyayok.png' ELSE 'images/dosyavar.png' END as dosyaurl from zih_gidenmesaj where kimden = " + kim + " order by mgid desc";
            adpt = new MySqlDataAdapter(sorgu);
            ds = new DataSet();
            adpt.Fill(ds, "mesajlar");
            Baglanti.Close();
            adpt.Dispose();
            sorgu.Dispose();
        }
        catch (Exception ex)
        {
            mesaj_hata = "Hata oluştu :" + ex.Message.ToString();
        }
    }
    public void mesajgetir(int kim)
    {
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu = new MySqlCommand();
            sorgu.Connection = Baglanti;
            sorgu.CommandType = CommandType.Text;
            sorgu.CommandText = "SELECT `mid`,`konu`,`mesaj`,`tarih`,`kimden`,`kimdenisim`, CASE okundu WHEN 1 THEN 'images/okunmus.png' when 0 THEN 'images/okunmamis.png' end as okundu, CASE dosyaurl WHEN '' THEN 'images/dosyayok.png' ELSE 'images/dosyavar.png' END as dosyaurl from zih_gelenmesaj where kime = " + kim + " order by mid desc";
            adpt = new MySqlDataAdapter(sorgu);
            ds = new DataSet();
            adpt.Fill(ds, "mesajlar");
            Baglanti.Close();
            adpt.Dispose();
            sorgu.Dispose();
        }
        catch (Exception ex)
        {
            mesaj_hata = "Hata oluştu :" + ex.Message.ToString();
        }
    }
    public void mesayukle(string konu, string mesaj, int kimden)
    {
        if (konu == "" || mesaj == "" || kimden == 0)
        {
            mesaj_hata = "Gönderilecek veriler eksik";
            return;
        }
        mesaj_hata = "";
        msguid = Guid.NewGuid().ToString();

        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "INSERT INTO `zih_gidenmesaj`( `konu`, `mesaj`, `kimden`, `kime`, `kime_isimler`, `tarih`, `dosyaurl`, `gonderilen_kod`) VALUES (@konu,@mesaj,@kimden,@kime,@kime_isimler,@tarih,@dosyaurl,@gonderilen_kod)";
            sorgu.Parameters.AddWithValue("@konu", (string)mskonu);
            sorgu.Parameters.AddWithValue("@mesaj", (string)msmesaj);
            sorgu.Parameters.AddWithValue("@kimden", (int)mskimden);
            sorgu.Parameters.AddWithValue("@kime", (string)mskimlere);
            sorgu.Parameters.AddWithValue("@kime_isimler", (string)mskimeisimler);
            sorgu.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sorgu.Parameters.AddWithValue("@dosyaurl", (string)msdosyaurl);
            sorgu.Parameters.AddWithValue("@gonderilen_kod", (string)msguid);
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
            sorgu.Dispose();

        }
        catch (Exception ex)
        {
            mesaj_hata = "Hata oluştu :" + ex.Message.ToString();
        }

    }
    public void gelenmesajyaz(int kime, string kimdenisim, string kimemail)
    {
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu = new MySqlCommand();
            sorgu.Connection = Baglanti;

            sorgu.CommandText = "INSERT INTO `zih_gelenmesaj`( `konu`, `mesaj`, `tarih`, `kimden`,`kimdenisim`,  `kime`, `dosyaurl`, `mesaj_kod`) VALUES (@konu,@mesaj,@tarih,@kimden,@kimedenisim,@kime,@dosyaurl,@gonderilen_kod)";
            sorgu.Parameters.AddWithValue("@konu", (string)mskonu);
            sorgu.Parameters.AddWithValue("@mesaj", (string)msmesaj);
            sorgu.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sorgu.Parameters.AddWithValue("@kimden", (int)mskimden);
            sorgu.Parameters.AddWithValue("@kimedenisim", (string)kimdenisim);
            sorgu.Parameters.AddWithValue("@kime", (int)kime);
            sorgu.Parameters.AddWithValue("@dosyaurl", (string)msdosyaurl);
            sorgu.Parameters.AddWithValue("@gonderilen_kod", (string)msguid);
            sorgu.ExecuteNonQuery();
            mail_gonder(kimemail, msmesaj);
            Baglanti.Close();
            sorgu.Dispose();
        }
        catch (Exception ex)
        {
            mesaj_hata = "Hata oluştu :" + ex.Message.ToString();
        }

    }
    public void mesajsayilar(int kim)
    {
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu = new MySqlCommand();
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "SELECT Count(*) FROM zih_gidenmesaj where kimden = " + kim + "";
            gonderilen = Convert.ToInt32(sorgu.ExecuteScalar());
            sorgu.CommandText = "select Count(*) from zih_gelenmesaj where kime= " + kim +"";
            mesajsayi = Convert.ToInt32(sorgu.ExecuteScalar());
            sorgu.CommandText = "select Count(*) from zih_gelenmesaj where kime= " + kim + " and okundu =0";
            okunmamis = Convert.ToInt32(sorgu.ExecuteScalar());
            sorgu.CommandText = "select Count(*) from zih_gelenmesaj where kime= " + kim + " and okundu =1";
            okunmus = Convert.ToInt32(sorgu.ExecuteScalar());
            Baglanti.Close();
            sorgu.Dispose();
        }
        catch (Exception ex)
        {
            mesaj_hata = "Hata oluştu :" + ex.Message.ToString();
        }
    }
}