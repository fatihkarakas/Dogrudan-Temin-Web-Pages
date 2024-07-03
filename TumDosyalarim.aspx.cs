using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TumDosyalarim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            baglan bs = new baglan();
            bs.kurum_bilgisi();
            fonksiyonlar fs = new fonksiyonlar();
            //fs.ihale_sayilar(bs.krmadi);
            bilgi.DataSource = fs.bilgiler(bs.kurumid);
            bilgi.DataBind();
            ///ihalebeklemede.Text = fs.ihalebeklemede;
            //krm.Text = bs.krmadi;
        }
    }
    

    public enum OnayDurumu
{
    OkunmamisBeklemede = 11,
    OnaylanmamisBeklemede = 0,
    OnaylanmisBeklemede = 1,
    DosyaRedEdildi = 9
}

public enum SonucDurumu
{
    Beklemede = 11,
    Kullanicida = 0,
    Tamamlanmis = 1
}
public string DosyaDurumunuGetir(int onay, int sonuc)
{
    string durum = "";

    if (onay == 11)
    {
        durum = "Okunmamış / Beklemede";
    }
    else if (onay == 0)
    {
        durum = "Onaylanmamış / Beklemede";
    }
    else if (onay == 1)
    {
        if (sonuc == 11)
        {
            durum = "Onaylanmış / Beklemede";
        }
        else if (sonuc == 0)
        {
            durum = "Onaylanmış / Kullanıcıda";
        }
        else if (sonuc == 1)
        {
            durum = "Dosya Tamamlanmış";
        }
    }
    else if (onay == 9)
    {
        durum = "Dosya Red Edildi";
    }

    return durum;
}


 }


