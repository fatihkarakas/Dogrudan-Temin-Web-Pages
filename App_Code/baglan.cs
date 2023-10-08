using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for baglan
/// </summary>
public class baglan
{
    public string krmadi;
    public int kurumid;
       public MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
       public MySqlDataReader oku;
       public MySqlDataAdapter adpt = new MySqlDataAdapter();
       public MySqlCommand sorgu = new MySqlCommand();
       public DataSet ds = new DataSet();
       public string kuladi, prl;
       public bool kullanici_var;
       public string hata = "";
       public string durum = "";
       public string browser = HttpContext.Current.Request.Browser.Browser.ToString();
       public int logsonuc = 0;

    public void giris_yap(string kullanici, string parola)
    {
        if(Baglanti.State==ConnectionState.Closed)
        {
            Baglanti.Open();
        }
        try
        {
            sorgu = new MySqlCommand();
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select Count(*) from zih_users where kullanici_adi=@kullanici and parola=@parola";
            sorgu.Parameters.AddWithValue("@kullanici", (string)kullanici);
            sorgu.Parameters.AddWithValue("@parola", (string)parola);
            kullanici_var = (Convert.ToInt32(sorgu.ExecuteScalar()) == 1) ? true : false;
            int say = Convert.ToInt32(sorgu.ExecuteScalar());
            switch(say)
            {
                case 0: durum = "Kullanıcı adı veya parola hatalı"; break;
                case 1: durum = "Giriş OK"; kullanici_var = true; logsonuc = 1; break;
                default: durum = "Sistem yöneticiniz ile görüşün"; break;
            }
            sorgu.Dispose();
            Baglanti.Close();
            if (kullanici_var)
            {
                Baglanti.Open();
                sorgu.CommandText = "select * from zih_users where kullanici_adi=@kullanici and parola=@parola";
                sorgu.Parameters.AddWithValue("kullanici", (string)kullanici);
                sorgu.Parameters.AddWithValue("parola", (string)parola);
                
                oku = sorgu.ExecuteReader();
                while(oku.Read())
                {
                kuladi = oku["kullanici_adi"].ToString() + " " + oku["eposta"].ToString(); ;
                prl = oku["parola"].ToString();
                HttpContext.Current.Session["kullanici"] = oku["kullanici_adi"].ToString();
                HttpContext.Current.Session["user_id"] = oku["id"].ToString();
                HttpContext.Current.Session["isim"] = oku["isim"].ToString();
                HttpContext.Current.Session["yetki"] = (Convert.ToUInt32(oku["yetki"].ToString())==1)?"admin":"kullanici";
                HttpContext.Current.Session["kurum"] = oku["kurumu"].ToString();
                HttpContext.Current.Session["eposta"] = oku["eposta"].ToString();

                }
                oku.Close();
            }
            
        }
        catch(Exception ex)
        {
            hata += ex.Message.ToString();
        }
        finally
        {
            Baglanti.Close();
            logyaz(kullanici, parola, logsonuc);
            Durum_Kont();
        }
    }

public void Durum_Kont()
    {
        if (HttpContext.Current.Session["kullanici"] != null && HttpContext.Current.Session["yetki"] != null)
        {
            if (HttpContext.Current.Session["yetki"] == "admin")
            {
                HttpContext.Current.Response.Redirect("yonetim/default.aspx");
            }
            else if (HttpContext.Current.Session["yetki"] == "kullanici") { HttpContext.Current.Response.Redirect("/default.aspx"); }
        }
       
    }
public void Durum_Kont(string sayfa)
{
    if (sayfa == "yönetim")
    {
        if (HttpContext.Current.Session["kullanici"] == "" || HttpContext.Current.Session["yetki"] != "admin")
        {
            HttpContext.Current.Response.Redirect("../giris.aspx");
        }
    }
    if(sayfa=="kullanici")
    {
        if (HttpContext.Current.Session["kullanici"] == "" || HttpContext.Current.Session["yetki"] != "kullanici")
        {
            HttpContext.Current.Response.Redirect("/giris.aspx");
        }
    }

}
    public void OturumKapat(string sayfa)
{
    HttpContext.Current.Session.Abandon();
    HttpContext.Current.Response.Redirect("/giris.aspx"); 
}
    public string kurum_bilgisi()
    {
        
        try
        {
            Baglanti.Open();
            sorgu = new MySqlCommand();
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select * from zih_kurumlar where id=" +Convert.ToInt32(HttpContext.Current.Session["kurum"].ToString());
            oku = sorgu.ExecuteReader();
            while(oku.Read())
            {
                krmadi = oku["kurumadi"].ToString();
                kurumid = Convert.ToInt32(oku["id"].ToString());
             }
            oku.Dispose();
            Baglanti.Close();
            }
        catch(Exception ex)
        {
            return ex.Message.ToString();
        }
        HttpContext.Current.Session["kurumadi"] = krmadi;
       return krmadi;
     }
  
    public string IPogren()
    {
        
        string ipString = "";
        if (string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
        {
            ipString = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        else
        {
            ipString = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .FirstOrDefault();
        }
        return ipString;
    }
    public void logyaz(string kullanici, string parola, int sonuc)
    {
        try
         {
         if(Baglanti.State==ConnectionState.Closed)  {
            Baglanti.Open();
        }
         
             sorgu = new MySqlCommand();
             sorgu.Connection = Baglanti;
             sorgu.CommandText = "INSERT INTO zih_log(kullanici, parola, sonuc, zaman, ipadres, browser) VALUES (@kullanici,@parola,@sonuc,@zaman,@ipadres,@browser)";
             sorgu.Parameters.AddWithValue("@kullanici", (string)kullanici);
             sorgu.Parameters.AddWithValue("@parola", (string)parola);
             sorgu.Parameters.AddWithValue("@sonuc", (int)sonuc);
             sorgu.Parameters.AddWithValue("@zaman", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
             sorgu.Parameters.AddWithValue("@ipadres", (string) IPogren() );
             sorgu.Parameters.AddWithValue("@browser", (string)browser);
             sorgu.ExecuteNonQuery();
             Baglanti.Close();
             sorgu.Dispose();
         }
        catch(Exception ex)
         {
             hata ="Hata" + ex.Message.ToString();
			 
                       
         }
    }
}