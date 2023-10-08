using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tema : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            new baglan().Durum_Kont("kullanici");
        }
        if (Session["isim"] != null) { kim.Text = Session["isim"].ToString(); }
    }
    protected void ck_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("giris.aspx");
    }
}
