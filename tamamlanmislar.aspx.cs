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

public partial class tamamlanmislar : System.Web.UI.Page
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
            elemanlar.DataSource = veriler(sayfaid);
            elemanlar.DataBind();
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
        MySqlDataAdapter AD = new MySqlDataAdapter("select * from zihale_icerik where ihale_id=" + veri + " and sonuc<>9  ", Baglanti);
        AD.Fill(DS, "Veriler");
        Baglanti.Close();
        return DS;
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
            sorgu.CommandText = "select Count(*) as say from zihale_icerik where ihale_id =" + id + " and Sonuc = 0 ";
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
}