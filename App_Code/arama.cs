using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;

/// <summary>
/// Summary description for arama
/// </summary>
public class arama
{
    public MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
    public MySqlDataReader oku;
    public MySqlDataAdapter adpt = new MySqlDataAdapter();
    public MySqlCommand sorgu = new MySqlCommand();
    public DataSet ds = new DataSet();
    public bool islemhata;
    public string hatamesaj;
	public arama()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet arama_sonuc(string aranankelime, string aranansutun)
    {
        islemhata = false;
        ds = new DataSet();
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            adpt = new MySqlDataAdapter("select * from zihale_icerik where " + aranansutun + " like '%" + aranankelime + "%'", Baglanti);
            adpt.Fill(ds, "Sonuc");
            Baglanti.Close();
        }
        catch (Exception ex)
        {
            islemhata = true;
            hatamesaj = ex.Message.ToString();
        }
        return ds;
    }

    public DataSet kurum_rapor(int kurum)
    {
        islemhata = false;
        ds = new DataSet();
        try
        {
           
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            adpt = new MySqlDataAdapter("SELECT *,CAST((birim_fiyat *miktar)as decimal(11,2)) as TOPLAM FROM zihale_icerik left outer join zihale as zi on (zi.id=zihale_icerik.ihale_id) where  kurum_id=" + kurum +" order by zi.id", Baglanti);
            adpt.Fill(ds, "Sonuc");
            Baglanti.Close();
        }
        catch (Exception ex)
        {
            islemhata = true;
            hatamesaj = ex.Message.ToString();
        }
        return ds;
    }
    public DataSet kurum_rapor()
    {
        islemhata = false;
        ds = new DataSet();
        try
        {

            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            adpt = new MySqlDataAdapter("SELECT *,CAST((birim_fiyat *miktar)as decimal(11,2)) as TOPLAM FROM zihale_icerik left outer join zihale as zi on (zi.id=zihale_icerik.ihale_id) order by zi.id", Baglanti);
            adpt.Fill(ds, "Sonuc");
            Baglanti.Close();
        }
        catch (Exception ex)
        {
            islemhata = true;
            hatamesaj = ex.Message.ToString();
        }
        return ds;
    }

    public DataSet kurum_rapor_tarih(int kurum, string ba_tarih, string bi_tarih)
    {
        islemhata = false;
        ds = new DataSet();
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            adpt = new MySqlDataAdapter("SELECT *, miktar * birim_fiyat as TOPLAM FROM zihale_icerik left outer join zihale as zi on (zi.id=zihale_icerik.ihale_id)where  kayit_tar between '"+ ba_tarih + "' and '" + bi_tarih +"' and zi.onay=1 and kurum_id=" + kurum +" order by zi.id", Baglanti);
            adpt.Fill(ds, "Sonuc");
            Baglanti.Close();
        }
        catch (Exception ex)
        {
            islemhata = true;
            hatamesaj = ex.Message.ToString();
        }
        return ds;
    }
    public DataSet kurum_rapor_tarih(string ba_tarih, string bi_tarih)
    {
        islemhata = false;
        ds = new DataSet();
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            adpt = new MySqlDataAdapter("SELECT *, miktar * birim_fiyat as TOPLAM FROM zihale_icerik left outer join zihale as zi on (zi.id=zihale_icerik.ihale_id)where  kayit_tar between '" + ba_tarih + "' and '" + bi_tarih + "' and zi.onay=1 order by zi.id", Baglanti);
            adpt.Fill(ds, "Sonuc");
            Baglanti.Close();
        }
        catch (Exception ex)
        {
            islemhata = true;
            hatamesaj = ex.Message.ToString();
        }
        return ds;
    }
}