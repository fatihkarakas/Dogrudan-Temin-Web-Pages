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

public partial class beklemedekilerdetay : System.Web.UI.Page
{
    public string kurumadi;
    public string zihaleid;
    public int sayfaid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            sayfaid = Convert.ToInt32(Request.QueryString["id"].ToString());
        }
        else
        {
            Response.Redirect("beklemedekiler.aspx");
            return;
        }
        if (!IsPostBack)
        {

            baglan bs = new baglan();
            bs.kurum_bilgisi();
            krm.Text = bs.krmadi;
            //sayfa_okundu(sayfaid);
            dtihale.DataSource = dt(sayfaid);
            dtihale.DataBind();
            dogrudanlistesielle.DataSource = veriler(sayfaid);
            dogrudanlistesielle.DataBind();
            fonksiyonlar fs = new fonksiyonlar();
            sartnamerepeat.DataSource = fs.sartnameler(sayfaid);
            sartnamerepeat.DataBind();
            aciklamalar.DataSource = fs.aciklamalar(sayfaid);
            aciklamalar.DataBind();
           
           
        }

        if (sartnamerepeat.Items.Count == 0)
        {
            sartnamerepeat.Visible = false;
        }
        else
        {
            sartnamerepeat.Visible = true;
        }
        if (aciklamalar.Items.Count == 0)
        {
            aciklamalar.Visible = false;
        }
        else
        {
            aciklamalar.Visible = true;
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
            TextBox sab2 = e.Item.FindControl("sabrkd") as TextBox;
            TextBox aciklama1 = e.Item.FindControl("aciklama") as TextBox;
            fonksiyonlar fs = new fonksiyonlar();
            fs.degisiklik(Convert.ToInt32(e.CommandArgument));
            try
            {
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Update zihale_icerik set SUT = '" + sutkod.Text + "', mal_hizmet_yapim = '" + tur1.Text + "', kanun_bend = '" + kb1.Text + "', cinsi = '" + cns1.Text + "', miktar = '" + mkt1.Text + "', birim = '" + brm1.Text + "', son_yil_tuketim = '" + syt1.Text + "', birim_son_yil = '" + bsy1.Text + "', son_fiyat = '" + sf1.Text + "',  son_alim_barkod = '" + sab2.Text + "' where id = " + Convert.ToInt32(e.CommandArgument) + " ";
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
            TextBox sbt2 = e.Item.FindControl("sabrkd2") as TextBox;
            veriekle(sutkod.Text, tur1.Text, kb1.Text, cns1.Text, mkt1.Text, brm1.Text, syt1.Text, bsy1.Text, sf1.Text, ihalekodugetir(sayfaid), sayfaid, sbt2.Text);

            dogrudanlistesielle.DataSource = veriler(sayfaid);
            dogrudanlistesielle.DataBind();
        }
    }
    public void veriekle(string sut, string turu, string kanunbendi, string cinsi, string miktar, string birim, string sonyiltuketim, string birimsonyil, string sonalimfiyat, string ihalekod, int ihale_id, string sonalimbarkod)
    {

        try
        {
            if (turu == "Seçiniz") { turu = ""; }
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "INSERT INTO zihale_icerik(ihale_kod,ihale_id,SUT,mal_hizmet_yapim,kanun_bend,cinsi,miktar,birim,son_yil_tuketim,birim_son_yil,son_fiyat, son_alim_barkod)VALUES(@ihalekod,@ihaleid,@sut,@mal_hizmet_yapim,@kanun_bend,@cinsi,@miktar,@birim,@son_yil_tuketim,@birim_son_yil,@son_fiyat, @son_alim_barkod)";
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
            sorgu.Parameters.AddWithValue("@son_alim_barkod", sonalimbarkod);
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
        Repeater rp = (Repeater)e.Item.FindControl("sartnamerepeat");
        Label lb = (Label)e.Item.FindControl("idcim");
        fonksiyonlar fs = new fonksiyonlar();
       // rp.DataSource = fs.sartnameler(sayfaid);
        //rp.DataBind();
        if (e.CommandName == "goster")
        {
            Session["zihaleid"] = Convert.ToString(e.CommandArgument);
            zihaleid = Convert.ToString(e.CommandArgument);
            dogrudanlistesielle.DataSource = veriler(Convert.ToInt32(zihaleid));
            dogrudanlistesielle.DataBind();
            //Response.Write("gd  " + Convert.ToInt32(e.CommandArgument));

        }
        if (e.CommandName == "sil")
        {

            try
            {
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Delete from zihale where id = " + Convert.ToInt32(e.CommandArgument) + " ";
                sorgu.ExecuteNonQuery();
                sorgu.Dispose();
                Baglanti.Close();
                Baglanti.Open();
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Delete from zihale_icerik where ihale_id = " + Convert.ToInt32(e.CommandArgument) + " ";
                sorgu.ExecuteNonQuery();
                sorgu.Dispose();
                Baglanti.Close();
                Baglanti.Open();
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Delete from zih_sartname where ihale_id = " + Convert.ToInt32(e.CommandArgument) + " ";
                sorgu.ExecuteNonQuery();
                sorgu.Dispose();
                Baglanti.Close();
                Response.Redirect("beklemedekiler.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("Hata : " + ex.Message.ToString());
            }
            Response.Write("Gidiyor  " + Convert.ToInt32(e.CommandArgument));
        }

        if (e.CommandName == "aekle")
        {
            TextBox aciklama = e.Item.FindControl("comment1") as TextBox;
            if (aciklama.Text == "") {  return;}
            try
            {

                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "INSERT INTO zih_aciklama(`ihale_id`,`aciklama`,`ekleyen`,`tarih`) VALUES(@ihale_id,@aciklama,@ekleyen,@tarih)";
                sorgu.Parameters.AddWithValue("@ihale_id", sayfaid);
                sorgu.Parameters.AddWithValue("@aciklama", aciklama.Text);
                sorgu.Parameters.AddWithValue("@ekleyen",Session["isim"].ToString());
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
            x = 1;
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
            sorgu.Dispose();
            if (sonuc == "tonay")
            {
                Baglanti.Open();
                sorgu.CommandText = "update zihale_icerik set onay = " + x + "  where ihale_id = " + id + " ";
                sorgu.Connection = Baglanti;
                sorgu.ExecuteNonQuery();
                Baglanti.Close();
                sorgu.Dispose();
            }
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

    public string degisiklikvarmi(int id)
    {
        string yazi = "";
        try
        {
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select degisiklik from zihale_icerik where id = " + id + "";
            MySqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                if (Convert.ToInt32(oku["degisiklik"].ToString()) == 1)
                {
                    yazi = "<a class='various fancybox.iframe' title='Değişiklik Yapılmış' target='_blank'  data-width=800 data-height=400 href='degisiklik.aspx?id=" + id + "'> <img src='images/bilgi.png' alt='değişiklik yapılmış' /></a> ";
                }
            }
            Baglanti.Close();
            sorgu.Dispose();

        }
        catch
        {

        }
        return yazi;
    }

    protected void btn_srtn_Click(object sender, EventArgs e)
    {
        sartnamediv.Visible = false;
        if (srtn_ekle.PostedFile.FileName.ToString() == "" || dosyadi.Text == "" || dosyaaciklama.Text == "")
        {
            sartnamediv.Visible = true;
            sartnamelabel.Text = "Şartname Dosyası için gerekli bilgileri doldurunuz";
            sartnamelabel.Text += "<br /> Uygun Dosya Seçiniz <br /> Dosya Adını Yazınız <br /> Dosya Açıklama Ekleyiniz <br />";
            return;
        }
        fonksiyonlar fs = new fonksiyonlar();
        fs.dosya_kontrol(srtn_ekle, sayfaid, dosyaaciklama.Text, dosyatip.SelectedValue, dosyadi.Text);
        if (fs.dosyahata == false)
        {
            sartnamediv.Visible = true;
            sartnamelabel.Text = "Hata Oluştu " + fs.dosyahatasi;
            return;
        }
        sartnamerepeat.DataSource = fs.sartnameler(sayfaid);
        sartnamerepeat.DataBind();
        sartnamerepeat.Visible = true;
    }

    public DataSet dt(string kurum)
    {
        DataSet DS = new DataSet();
        MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
        MySqlCommand sorgu = new MySqlCommand();
        if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
        MySqlDataAdapter AD = new MySqlDataAdapter("select * from zihale where kurum='" + kurum + "' and onay= 0", Baglanti);
        AD.Fill(DS, "Veriler");
        Baglanti.Close();
        return DS;
    }

   
}

    