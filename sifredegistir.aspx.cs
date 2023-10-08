using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sifredegistir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void pdegistir_Click(object sender, EventArgs e)
    {
        sncdiv.Visible = false;
        if (tck.Text == "" || parola.Text == "")
        {
            sncdiv.Visible = true;
            sncmsj.Text = "Hata Oluştu !!! <br />TC Kimlik numaranız ve Parola alanları boş olamaz ";
            return;
        }
        if (parola.Text != parolat.Text)
        {
            sncdiv.Visible = true;
            sncmsj.Text = "Hata Oluştu !!! <br />Parola alanları birbiri ile uyuşmuyor";
            return;
        }

        fonksiyonlar fs = new fonksiyonlar();
        fs.sifre_degistir(tck.Text, parola.Text);
        if (fs.hata != "")
        {
            sncdiv.Visible = true;
            sncmsj.Text = "Hata Oluştu !!! <br /> Hata Kodu: " + fs.hata;
        }

        sncdiv.Visible = true;
        sncmsj.Text = "Şifreniz Başarı İle Değiştirildi";
    }
}