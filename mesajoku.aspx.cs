using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yonetim_mesajoku : System.Web.UI.Page
{
    public int mesajid = 0;
    public string kimden, mesaj, baslik, tarih, dosya;
    public bool dosya_var = false;
    public MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
    public MySqlDataReader oku;
    public MySqlDataAdapter adpt = new MySqlDataAdapter();
    public MySqlCommand sorgu = new MySqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                mesajid = Convert.ToInt32(Request.QueryString["id"].ToString());
            }
            if (mesajid == 0)
            {
                Response.Redirect("mesajlar.aspx");
                return;
            }
        }
        mesajgetir(mesajid);
    }

    public void mesajgetir(int id)
    {
        try
        {
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu = new MySqlCommand();
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select * from zih_gelenmesaj where mid = " + id + "";
            oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                kimden = oku["kimdenisim"].ToString();
                mesaj = oku["mesaj"].ToString();
                baslik = oku["konu"].ToString();
                tarih = oku["tarih"].ToString();
                dosya = oku["dosyaurl"].ToString();
                dosya_var = (dosya == "") ? false : true;

            }
            oku.Dispose();
            Baglanti.Close();
            sorgu.Dispose();
            sorgu = new MySqlCommand();
            Baglanti.Open();
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "update zih_gelenmesaj set okundu = 1 where mid = " + id + "";
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
            sorgu.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write("Hata Oluştu :" + ex.Message.ToString());
            return;
        }


    }

}