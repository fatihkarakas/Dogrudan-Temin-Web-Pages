using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yonetim_mesajlar : System.Web.UI.Page
{
    public int mesajsayi, okunmus, okunmamis;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mesajislemler ms = new mesajislemler();
             ms.mesajgetir(Convert.ToInt32(Session["User_id"].ToString()));
             gelenmesalar.DataSource = ms.ds;
             gelenmesalar.DataBind();
            ms.mesajsayilar(Convert.ToInt32(Session["User_id"].ToString()));
            mesajsayi = ms.mesajsayi;
            okunmamis = ms.okunmamis;
            okunmus = ms.okunmus;


        }
    }
}