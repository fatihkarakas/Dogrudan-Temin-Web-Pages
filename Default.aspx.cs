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

public partial class _Default : System.Web.UI.Page
{
    public int ihaleid;
    public bool hata;
    public string dosyahatasi;
    public string msdosyaadres = "";
    public int okunmamis, okunmus, oran;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            baglan bs = new baglan();
            bs.kurum_bilgisi();
            fonksiyonlar fs = new fonksiyonlar();
            fs.ihale_sayilar(bs.kurumid);
            toplamihale.Text = fs.toplamihale;
            ihaleonayli.Text = fs.ihaleonayli;
            ihalered.Text = fs.ihalered;
            ihaletamam.Text = fs.ihaletamam;
            mesajislemler ms = new mesajislemler();
            if (Session["User_id"] != null)
            {
                ms.mesajsayilar(Convert.ToInt32(Session["User_id"].ToString()));
                mesajsayi.Text = Convert.ToString(ms.mesajsayi);
                okunmus = ms.okunmus;
                okunmamis = ms.okunmamis;
            }
          
           
            ///ihalebeklemede.Text = fs.ihalebeklemede;
            //krm.Text = bs.krmadi;
        }
    }

}