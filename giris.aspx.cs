using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class giris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            baglan kt = new baglan();
            kt.Durum_Kont();
            if (Request.Cookies["kullanici"] != null && Request.Cookies["parola"] != null)
            {
                user.Text = Request.Cookies["kullanici"].Value;
                password.Text = Request.Cookies["parola"].Value;
            }
        }
    }
    protected void gonder_Click(object sender, EventArgs e)
    {
        if (user.Text == "" || password.Text == "")
        {
            baglan bi = new baglan();
            bi.logyaz(user.Text, password.Text, 0);
            bilgi_ver.Visible = true;
            bilgi_ver.Text = "Kullanıcı adı ve parola boş olamaz";
            return;
        }
        else bilgi_ver.Visible = false;

        baglan b = new baglan();
        b.giris_yap(user.Text, password.Text);
        if (b.hata != "" || b.durum != "Giriş OK")
        {

            bilgi_ver.Visible = true;
            bilgi_ver.Text = b.durum;
            bilgi_ver.Text += b.hata;
        }
        else
        {
            bilgi_ver.Visible = false;
        }
        if (hatirla.Checked)
        {
            Response.Cookies["kullanici"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["Parola"].Expires = DateTime.Now.AddDays(30);
        }
        else
        {
            Response.Cookies["kullanici"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Parola"].Expires = DateTime.Now.AddDays(-1);
        }
        
    }
}