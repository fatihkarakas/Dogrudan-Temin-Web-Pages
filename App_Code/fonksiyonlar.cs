using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for fonksiyonlar
/// </summary>
public class fonksiyonlar
{
    public string hata;
    public string dosyadurum, dosyabilgi, dosyahatasi;
    public bool dosyahata;
    public int ihale_id;
    public string sut, mal_hizmet_yapim, kanun_bend, cinsi, miktar, birim, son_yil_tuketim, son_alim_barkod, birim_son_yil, son_fiyat, teklif_edilen_marka, barkod_kod, birim_fiyat, tedarikci;
    public MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
    public MySqlDataReader oku;
    public MySqlDataAdapter adpt = new MySqlDataAdapter();
    public MySqlCommand sorgu = new MySqlCommand();
    public string toplamihale, ihaleonayli, ihalered, ihaletamam, ihalebeklemede;
    public string[] krmadi = new string[20];
    public int[] sayisi = new int[20];
    public bool islemhata;
    public string islemhatamesaj;
    public fonksiyonlar()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet bilgiler(int kurum)
    {
        DataSet DS = new DataSet();
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            adpt = new MySqlDataAdapter("select * from zihale where tarih > '20161231' and kurum_id = " + kurum + "", Baglanti);
            adpt.Fill(DS, "Tablo");
            Baglanti.Close();
            
        }
        catch (Exception ex)
        {

        }
        return DS;
    }

    public string bilgiler_sonuc(int onay, int sonuc)
    {
        string bilgi="";
        if (onay == 0)
        {
            bilgi = "Dosya Beklemede";
        }
        return bilgi;
    }

    public void istatistik()
    {
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select count(*) as say , kurum from zihale where tarih > '20161231' group by kurum order by say desc";
            oku = sorgu.ExecuteReader();
            int i = 0;
            while (oku.Read())
            {
                krmadi[i] = oku["kurum"].ToString();
                sayisi[i] = Convert.ToInt32(oku["say"].ToString());
                i = i + 1;
            }
            oku.Close();
            Baglanti.Close();
            sorgu.Dispose();
        }
        catch (Exception ex)
        {
            islemhata = true;
            islemhatamesaj = "Hata Olıuştu " + ex.Message.ToString();
            return;
        }
    }
    public void ihale_sayilar(int kurum)
    {
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select count(*) as say from zihale where tarih > '20161231' and kurum_id = " + kurum + "";
            oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                toplamihale = oku["say"].ToString();
            }
            sorgu.Dispose();
            oku.Close();
            Baglanti.Close();
            sorgu.Connection = Baglanti;
            Baglanti.Open();
            sorgu.CommandText = "select count(*) as say from zihale where kurum_id = " + kurum + " and onay=1 and sonuc=11 and tarih > '20161231'";
            oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                ihaleonayli = oku["say"].ToString();
            }
            sorgu.Dispose();
            oku.Close();
            Baglanti.Close();

            sorgu.Connection = Baglanti;
            Baglanti.Open();
            sorgu.CommandText = "select count(*) as say from zihale where kurum_id = " + kurum + " and onay=9 and tarih > '20161231'";
            oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                ihalered = oku["say"].ToString();
            }
            sorgu.Dispose();
            oku.Close();
            Baglanti.Close();

            sorgu.Connection = Baglanti;
            Baglanti.Open();
            sorgu.CommandText = "select count(*) as say from zihale where kurum_id = " + kurum + " and onay=1 and sonuc=1 and tarih > '20161231'";
            oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                ihaletamam = oku["say"].ToString();
            }
            sorgu.Dispose();
            oku.Close();
            Baglanti.Close();

            sorgu.Connection = Baglanti;
            Baglanti.Open();
            sorgu.CommandText = "select count(*) as say from zihale where kurum_id = " + kurum + " and onay=11 and tarih > '20161231'";
            oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                ihalebeklemede = oku["say"].ToString();
            }
            sorgu.Dispose();
            oku.Close();
            Baglanti.Close();

        }
        catch (Exception ex)
        {

        }
    }

    public void degisiklik(int id)
    {
        hata = "";
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select * from zihale_icerik where id = " + id + "";
            oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                ihale_id = Convert.ToInt32(oku["id"].ToString());
                sut = oku["SUT"].ToString();
                mal_hizmet_yapim = oku["mal_hizmet_yapim"].ToString();
                kanun_bend = oku["kanun_bend"].ToString();
                cinsi = oku["cinsi"].ToString();
                miktar = oku["miktar"].ToString();
                birim = oku["birim"].ToString();
                son_yil_tuketim = oku["son_yil_tuketim"].ToString();
                son_alim_barkod = oku["son_alim_barkod"].ToString();
                birim_son_yil = oku["birim_son_yil"].ToString();
                son_fiyat = oku["son_fiyat"].ToString();
                barkod_kod = oku["barkod_kod"].ToString();
                birim_fiyat = oku["birim_fiyat"].ToString();
                teklif_edilen_marka = oku["teklif_edilen_marka"].ToString();

            }
            oku.Dispose();
            sorgu.Dispose();
            Baglanti.Close();
            Baglanti.Open();
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "INSERT INTO `ankara3bol_web`.`zihdegisiklik`(ihale_id,SUT,mal_hizmet_yapim,kanun_bend,cinsi,miktar,birim,son_yil_tuketim,son_alim_barkod,birim_son_yil,son_fiyat,teklif_edilen_marka,barkod_kod,birim_fiyat,tedarikci)VALUES(@ihale_id,@SUT,@mal_hizmet_yapim,@kanun_bend,@cinsi,@miktar,@birim,@son_yil_tuketim,@son_alim_barkod,@birim_son_yil,@son_fiyat,@teklif_edilen_marka,@barkod_kod,@birim_fiyat,@tedarikci)";
            sorgu.Parameters.AddWithValue("@ihale_id", ihale_id);
            sorgu.Parameters.AddWithValue("@SUT", sut);
            sorgu.Parameters.AddWithValue("@mal_hizmet_yapim", mal_hizmet_yapim);
            sorgu.Parameters.AddWithValue("@kanun_bend", kanun_bend);
            sorgu.Parameters.AddWithValue("@cinsi", cinsi);
            sorgu.Parameters.AddWithValue("@miktar", miktar);
            sorgu.Parameters.AddWithValue("@birim", birim);
            sorgu.Parameters.AddWithValue("@son_yil_tuketim", son_yil_tuketim);
            sorgu.Parameters.AddWithValue("@son_alim_barkod", son_alim_barkod);
            sorgu.Parameters.AddWithValue("@birim_son_yil", birim_son_yil);
            sorgu.Parameters.AddWithValue("@son_fiyat", son_fiyat);
            sorgu.Parameters.AddWithValue("@teklif_edilen_marka", teklif_edilen_marka);
            sorgu.Parameters.AddWithValue("@barkod_kod", barkod_kod);
            sorgu.Parameters.AddWithValue("@birim_fiyat", birim_fiyat);
            sorgu.Parameters.AddWithValue("@tedarikci", teklif_edilen_marka);
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
            sorgu.Dispose();
        }
        catch (Exception ex)
        {
            hata = "Hata Oluştu : " + ex.Message.ToString();
            return;
        }
    }

    public void sifre_degistir(string tck, string parola)
    {
        hata = "";
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "update zih_users set parola = '" + parola + "' where tck = '" + tck + "'";
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
        }
        catch (Exception ex)
        {
            hata = ex.Message.ToString();
            return;
        }
    }

    public void dosya_kontrol(FileUpload fs, int idc, string aciklama, string tip, string dosyaadi)
    {

        dosyadurum = "";
        dosyabilgi = "";
        string[] uygundosya = { ".xls", ".pdf", ".doc", ".docx", ".rar", ".zip", ".xlsx" };
        string uzanti = System.IO.Path.GetExtension(fs.PostedFile.FileName);
        for (int i = 0; i <= uygundosya.Length - 1; i++)
        {
            if (uzanti == uygundosya[i])
            {
                dosyahata = true;
            }
        }
        if (dosyahata == false)
        {
            dosyahata = false;
            dosyadurum = "Dosya tipi uygun değil " + uzanti + " uzantılı dosya yükleyemezsiniz.  Dosyanız : " + fs.PostedFile.FileName;
            dosyahatasi += "Dosya tipi uygun değil " + uzanti + " uzantılı dosya yükleyemezsiniz.  Dosyanız : " + fs.PostedFile.FileName;
            return;
        }
        if (dosyahata == true)
        {
            if (fs.PostedFile.ContentLength > 5000000) { dosyadurum = "Dosya Boyutu Çok Büyük"; dosyahata = false; return; }
            string fn = System.IO.Path.GetFileName(fs.PostedFile.FileName);
            fn = turkce_arin(fn);
            string id = Guid.NewGuid().ToString();
            string dosyaadres = string.Format("{0}{1}_{2}", HttpContext.Current.Server.MapPath("dosyalar\\"), id, fn);
            try
            {
                fs.PostedFile.SaveAs(dosyaadres);
                dosyabilgi = id + "_" + fn;
                dosyahata = true;
                dosyaadres = id + "_" + fn;
                //msdosyaadres = "dosyalar\\" + id + "_" + fn;
                dosyabilgi = dosyaadres;
            }
            catch (Exception ez)
            {
                dosyadurum += "Hata Oluştu :" + ez.Message.ToString();
                dosyahatasi += "Hata :" + ez.Message.ToString();
                dosyahata = false;
                return;
            }

        }

        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "insert into zih_sartname(ihale_id, ihale_dosya, dosya_aciklama, tipi, dosya_adi) values(" + idc + " , 'Dosyalar/" + dosyabilgi + "', '" + aciklama + "', '" + tip + "', '" + dosyaadi + "' )";
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
        }
        catch (Exception ez)
        {
            dosyahata = false;
            dosyahatasi = "Hata :" + ez.Message.ToString();
            return;
        }


    }

    public DataSet sartnameler(int id)
    {
        DataSet Ds = new DataSet();
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            adpt = new MySqlDataAdapter("select * from zih_sartname where ihale_id = " + id + "", Baglanti);
            adpt.Fill(Ds, "tablo");
            Baglanti.Close();
        }
        catch (Exception Ex)
        {

        }
        return Ds;
    }

    public DataSet tumliste()
    {
        DataSet Ds = new DataSet();
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            adpt = new MySqlDataAdapter("select * from zihale where tarih > '20161231'", Baglanti);
            adpt.Fill(Ds, "tablo");
            Baglanti.Close();
        }
        catch (Exception Ex)
        {

        }
        return Ds;
    }

    public string dosyanerede(int onay, int sonuc)
    {
        string sn = "";
        if (onay == 11)
        {
            sn = "Okunmamış / Beklemede";
            return sn;
        }
        if (onay == 0)
        {
            sn = "Onaylanmamış / Beklemede";
            return sn;
        }
        else if (onay == 1)
        {
            if (sonuc == 11)
            {
                sn = "Onaylanmış / Beklemede";
                return sn;
            }
            else if (sonuc == 0)
            {
                sn = "Onaylanmış / Kullanıcıda";
                return sn;
            }
            else if (sonuc == 1)
            {
                sn = "Dosya Tamamlanmış";
            }
        }
        else if (onay == 5)
        {
            sn = "Dosya Rededildi";
            return sn;
        }
        return sn;
    }

    public DataSet aciklamalar(int id)
    {
        DataSet DS = new DataSet();
        Baglanti.Open();
        adpt = new MySqlDataAdapter("select * from zih_aciklama where ihale_id = " + id + "", Baglanti);
        adpt.Fill(DS, "Tables");
        Baglanti.Close();
        return DS;

    }

    public DataSet kurumlar()
    {
        DataSet DS = new DataSet();
        Baglanti.Open();
        adpt = new MySqlDataAdapter("SELECT * FROM ankara3bol_web.zih_kurumlar", Baglanti);
        adpt.Fill(DS, "Tables");
        Baglanti.Close();
        return DS;
    }

    public string turkce_arin(string veri)
    {
        string sonuc = veri;
        sonuc = sonuc.Replace('Ç', 'C');
        sonuc = sonuc.Replace('ç', 'c');
        sonuc = sonuc.Replace('İ', 'I');
        sonuc = sonuc.Replace('ı', 'i');
        sonuc = sonuc.Replace(' ', '_');
        sonuc = sonuc.Replace('Ğ', 'G');
        sonuc = sonuc.Replace('ğ', 'g');
        sonuc = sonuc.Replace('Ö', 'O');
        sonuc = sonuc.Replace('ö', 'o');
        sonuc = sonuc.Replace('Ş', 'S');
        sonuc = sonuc.Replace('ş', 's');
        sonuc = sonuc.Replace('Ü', 'U');
        sonuc = sonuc.Replace('ü', 'u');
        return sonuc;
    }



}