using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class redetay : System.Web.UI.Page
{
    public string kurumadi;
    public string zihaleid;
    public int sayfaid;
    protected void Page_Load(object sender, EventArgs e)
    {
        sayfaid = Convert.ToInt32(Request.QueryString["id"].ToString());
        if (!IsPostBack)
        {

            baglan bs = new baglan();
            bs.kurum_bilgisi();
            krm.Text = bs.krmadi;
            sayfa_okundu(sayfaid);
            dtihale.DataSource = dt(sayfaid);
            dtihale.DataBind();
            dogrudanlistesielle.DataSource = veriler(sayfaid);
            dogrudanlistesielle.DataBind();
            fonksiyonlar fs = new fonksiyonlar();
            aciklamalar.DataSource = fs.aciklamalar(sayfaid);
            aciklamalar.DataBind();
            aciklamalar.Visible = true;
            sayfa_okundu(sayfaid);
        }
        if (Session["zihiahleid"] != null)
        {
            zihaleid = Session["zihaleid"].ToString();
        }
    }
    public DataSet dt(int id)
    {
        DataSet DS = new DataSet();
        MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
        MySqlCommand sorgu = new MySqlCommand();
        if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
        MySqlDataAdapter AD = new MySqlDataAdapter("select * from zihale where id=" + id + " ", Baglanti);
        AD.Fill(DS, "Veriler");
        Baglanti.Close();
        return DS;
    }
    public DataSet veriler(int veri)
    {
        DataSet DS = new DataSet();
        MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
        MySqlCommand sorgu = new MySqlCommand();
        if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
        MySqlDataAdapter AD = new MySqlDataAdapter("select * from zihale_icerik where ihale_id=" + veri + " ", Baglanti);
        AD.Fill(DS, "Veriler");
        Baglanti.Close();
        return DS;
    }
    protected void dogrudanlistesielle_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Session["zihaleid"] = Convert.ToString(e.CommandArgument.ToString());
        if (e.CommandName == "duzelt")
        {
            TextBox sutkod = e.Item.FindControl("st") as TextBox;
            TextBox tur1 = e.Item.FindControl("mh") as TextBox;
            TextBox kb1 = e.Item.FindControl("kb") as TextBox;
            TextBox cns1 = e.Item.FindControl("cns") as TextBox;
            TextBox mkt1 = e.Item.FindControl("mkt") as TextBox;
            TextBox brm1 = e.Item.FindControl("brm") as TextBox;
            TextBox syt1 = e.Item.FindControl("syt") as TextBox;
            TextBox bsy1 = e.Item.FindControl("bsy") as TextBox;
            TextBox sf1 = e.Item.FindControl("sf") as TextBox;
            fonksiyonlar fs = new fonksiyonlar();
            fs.degisiklik(Convert.ToInt32(e.CommandArgument));
            try
            {
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Update zihale_icerik set SUT = '" + sutkod.Text + "', mal_hizmet_yapim = '" + tur1.Text + "', kanun_bend = '" + kb1.Text + "', cinsi = '" + cns1.Text + "', miktar = '" + mkt1.Text + "', birim = '" + brm1.Text + "', son_yil_tuketim = '" + syt1.Text + "', birim_son_yil = '" + bsy1.Text + "', son_fiyat = '" + sf1.Text + "' where id = " + Convert.ToInt32(e.CommandArgument) + " ";
                sorgu.ExecuteNonQuery();
                Baglanti.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Hata " + ex.Message.ToString());
                return;
            }
            dogrudanlistesielle.DataSource = veriler(sayfaid);
            dogrudanlistesielle.DataBind();
        }
        if (e.CommandName == "sil")
        {
            try
            {
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Delete from zihale_icerik where id = " + Convert.ToInt32(e.CommandArgument) + " ";
                sorgu.ExecuteNonQuery();
                Baglanti.Close();
            }
            catch (Exception ex)
            {

                return;
            }

            dogrudanlistesielle.DataSource = veriler(sayfaid);
            dogrudanlistesielle.DataBind();

        }

        if (e.CommandName == "ok")
        {

            try
            {
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Update zihale_icerik set onay = 1 where id = " + Convert.ToInt32(e.CommandArgument) + " ";
                sorgu.ExecuteNonQuery();
                Baglanti.Close();
            }
            catch (Exception ex)
            {

                return;
            }
            dogrudanlistesielle.DataSource = veriler(sayfaid);
            dogrudanlistesielle.DataBind();
        }

        if (e.CommandName == "reddet")
        {
            try
            {
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Update zihale_icerik set onay = 9 where id = " + Convert.ToInt32(e.CommandArgument) + " ";
                sorgu.ExecuteNonQuery();
                Baglanti.Close();
            }
            catch (Exception ex)
            {

                return;
            }
            dogrudanlistesielle.DataSource = veriler(sayfaid);
            dogrudanlistesielle.DataBind();
        }

        if (e.CommandName == "ekle")
        {
            TextBox sutkod = e.Item.FindControl("st2") as TextBox;
            TextBox tur1 = e.Item.FindControl("mh2") as TextBox;
            TextBox kb1 = e.Item.FindControl("kb2") as TextBox;
            TextBox cns1 = e.Item.FindControl("cns2") as TextBox;
            TextBox mkt1 = e.Item.FindControl("mkt2") as TextBox;
            TextBox brm1 = e.Item.FindControl("brm2") as TextBox;
            TextBox syt1 = e.Item.FindControl("syt2") as TextBox;
            TextBox bsy1 = e.Item.FindControl("bsy2") as TextBox;
            TextBox sf1 = e.Item.FindControl("sf2") as TextBox;
            veriekle(sutkod.Text, tur1.Text, kb1.Text, cns1.Text, mkt1.Text, brm1.Text, syt1.Text, bsy1.Text, sf1.Text, ihalekodugetir(Convert.ToInt32(sayfaid)), Convert.ToInt32(sayfaid));

            dogrudanlistesielle.DataSource = veriler(Convert.ToInt32(sayfaid));
            dogrudanlistesielle.DataBind();
        }
    }
    public void veriekle(string sut, string turu, string kanunbendi, string cinsi, string miktar, string birim, string sonyiltuketim, string birimsonyil, string sonalimfiyat, string ihalekod, int ihale_id)
    {

        try
        {
            if (turu == "Seçiniz") { turu = ""; }
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "INSERT INTO zihale_icerik(ihale_kod,ihale_id,SUT,mal_hizmet_yapim,kanun_bend,cinsi,miktar,birim,son_yil_tuketim,birim_son_yil,son_fiyat)VALUES(@ihalekod,@ihaleid,@sut,@mal_hizmet_yapim,@kanun_bend,@cinsi,@miktar,@birim,@son_yil_tuketim,@birim_son_yil,@son_fiyat)";
            sorgu.Parameters.AddWithValue("@ihaleid", ihale_id);
            sorgu.Parameters.AddWithValue("@ihalekod", ihalekod);
            sorgu.Parameters.AddWithValue("@sut", sut);
            sorgu.Parameters.AddWithValue("@mal_hizmet_yapim", turu);
            sorgu.Parameters.AddWithValue("@kanun_bend", kanunbendi);
            sorgu.Parameters.AddWithValue("@cinsi", cinsi);
            sorgu.Parameters.AddWithValue("@miktar", miktar);
            sorgu.Parameters.AddWithValue("@birim", birim);
            sorgu.Parameters.AddWithValue("@son_yil_tuketim", sonyiltuketim);
            sorgu.Parameters.AddWithValue("@birim_son_yil", birimsonyil);
            sorgu.Parameters.AddWithValue("@son_fiyat", sonalimfiyat);
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
        }
        catch (Exception ex)
        {

            return;
        }

    }
    protected void sayfa_okundu(int id)
    {
        try
        {
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.CommandText = "update zihale set okunma = 1 , kontroltarih = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id = " + id + " ";
            sorgu.Connection = Baglanti;
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
        }
        catch { }
    }
    public string durumu(string durum)
    {
        string sonuc = "";
        switch (durum)
        {
            case "0":
                sonuc = "Onay Bekliyor"; break;
            case "1":
                sonuc = "Onaylanmış"; break;
            case "9":
                sonuc = "Reddedilmiş"; break;
            default:
                sonuc = "Belirsiz"; break;

        }
        return sonuc;
    }
    protected void dtihale_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        fonksiyonlar fs = new fonksiyonlar();
        if (e.CommandName == "onay")
        {
            islemyap("onay", Convert.ToInt32(e.CommandArgument));
        }
        if (e.CommandName == "reddet")
        {
            islemyap("reddet", Convert.ToInt32(e.CommandArgument));
        }
        if (e.CommandName == "aekle")
        {
            TextBox aciklama = e.Item.FindControl("comment1") as TextBox;
            if (aciklama.Text == "") { return; }
            try
            {

                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "INSERT INTO zih_aciklama(`ihale_id`,`aciklama`,`ekleyen`,`tarih`) VALUES(@ihale_id,@aciklama,@ekleyen,@tarih)";
                sorgu.Parameters.AddWithValue("@ihale_id", sayfaid);
                sorgu.Parameters.AddWithValue("@aciklama", aciklama.Text);
                sorgu.Parameters.AddWithValue("@ekleyen", Session["isim"].ToString());
                sorgu.Parameters.AddWithValue("@tarih", (string)DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                sorgu.ExecuteNonQuery();
                Baglanti.Close();
                dogrudanlistesielle.DataSource = veriler(Convert.ToInt32(e.CommandArgument));
                dogrudanlistesielle.DataBind();
                aciklamalar.DataSource = fs.aciklamalar(sayfaid);
                aciklamalar.DataBind();
                aciklamalar.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write("Hata : " + ex.Message.ToString());
            }

        }
    }
    public void islemyap(string sonuc, int id)
    {
        int x = 5;
        if (sonuc == "reddet")
        {
            dogrudanlistesielle.Visible = false;
            x = 9;
        }
        else
        {
            dogrudanlistesielle.Visible = true;
            x = 0;
        }
        try
        {
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.CommandText = "update zihale set onay = " + x + "  where id = " + id + " ";
            sorgu.Connection = Baglanti;
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
            Baglanti.Open();
            sorgu.CommandText = "update zihale_icerik set onay = " + x + "  where ihale_id = " + id + " ";
            sorgu.Connection = Baglanti;
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
            Baglanti.Open();
            sorgu.CommandText = "INSERT INTO zih_aciklama(`ihale_id`,`aciklama`,`ekleyen`,`tarih`) VALUES(@ihale_id,@aciklama,@ekleyen,@tarih)";
            sorgu.Parameters.AddWithValue("@ihale_id", sayfaid);
            string aciklama = "Bu ihale için  " + Session["isim"].ToString() + " tarafından " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " tarihinde Yeniden Değerlendirme Talebi yapıldı "  ;
            sorgu.Parameters.AddWithValue("@aciklama",(string) aciklama);
            sorgu.Parameters.AddWithValue("@ekleyen", Session["isim"].ToString());
            sorgu.Parameters.AddWithValue("@tarih", (string)DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
            dtihale.DataSource = dt(id);
            dtihale.DataBind();
            dogrudanlistesielle.DataSource = veriler(id);
            dogrudanlistesielle.DataBind();

        }
        catch { }
    }

    public string ihalekodugetir(int id)
    {
        string ikod = "";
        try
        {
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select ihalekod from zihale where id = " + id + "";
            MySqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                ikod = oku["ihalekod"].ToString();
            }
            Baglanti.Close();
            sorgu.Dispose();

        }
        catch
        {

        }
        return ikod;
    }
}