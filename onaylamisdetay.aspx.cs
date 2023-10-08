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

public partial class onaylamisdetay : System.Web.UI.Page
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
            return;
        }
        if (!IsPostBack)
        {

            baglan bs = new baglan();
            bs.kurum_bilgisi();
            krm.Text = bs.krmadi;
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
        sncdiv.Visible = false;
        if (e.CommandName == "ekle")
        {

            try
            {
                TextBox tem1 = e.Item.FindControl("tem") as TextBox;
                TextBox brkd1 = e.Item.FindControl("brkd") as TextBox;
                TextBox brfyt1 = e.Item.FindControl("brfyt") as TextBox;
                TextBox tdrk1 = e.Item.FindControl("tdrk") as TextBox;
                if (tem1.Text == "" || brkd1.Text == "" || brfyt1.Text == "" || tdrk1.Text == "")
                {
                    sncdiv.Visible = true;
                    sncmsj.Text = "Lütfen Alım dosyası elemalarını doldurunuz";
                    sncmsj.Text += "<br /> Teklif Edilen Marka <br /> Barkod <br /> Birim Fiyat <br /> Tedarikçi <br /> Bilgileri boş olamaz";
                    return;
                }
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Update zihale_icerik set teklif_edilen_marka = '" + tem1.Text + "',  barkod_kod = '" + brkd1.Text + "', birim_fiyat = '" + brfyt1.Text + "', tedarikci = '" + tdrk1.Text + "', kayit_tar = NOW(), sonuc = 0 where id = " + Convert.ToInt32(e.CommandArgument) + "";
                sorgu.ExecuteNonQuery();

                Baglanti.Close();
                sorgu.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("Hata oluştu tekrar deneyiniz !!!" + ex.Message.ToString());
                return;
            }
            dogrudanlistesielle.DataSource = veriler(sayfaid);
            dogrudanlistesielle.DataBind();

        }
        if (e.CommandName == "silmek")
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
    }
    protected void dtihale_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        fonksiyonlar fs = new fonksiyonlar();
        
        if (e.CommandName == "tamamla")
        {
            try
            {
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Update zihale set Sonuc = 0  where id = " + sayfaid + "";
                sorgu.ExecuteNonQuery();

                Baglanti.Close();
                sorgu.Dispose();
            }
            catch (Exception ex)
            {
                Response.Write("Hata oluştu tekrar deneyiniz !!!" + ex.Message.ToString());
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
            aciklamalar.DataSource = fs.aciklamalar(sayfaid);
            aciklamalar.DataBind();
        }
    }
    public bool kt(int id)
    {
        bool ok = false;
        try
        {
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select Count(*) as say from zihale_icerik where ihale_id ="+id+" and Sonuc = 0 ";
            MySqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                if (Convert.ToInt32(oku["say"].ToString()) > 0) { ok = true; }
            }

            Baglanti.Close();
            sorgu.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write("Hata oluştu tekrar deneyiniz !!!" + ex.Message.ToString());
            return ok;
        }
        return ok;
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
                    yazi = "<a class='various fancybox.iframe' title='Değişiklik Yapılmış' target='_blank'  data-width=800 data-height=400 href='degisiklik.aspx?id=" + id + "'> <img src='images/bilgi.png' alt='değişiklik yapılmış' width='15' height='15' /></a> ";
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

}
