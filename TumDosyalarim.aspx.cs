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
          public string dosyanerede(int onay, int sonuc)
    {
        string sn = "";
        if (onay == 11)
        {
            sn = "Okunmamış / Beklemede";
            return sn;
        }
        if (onay == 0)
        {
            sn = "Onaylanmamış / Beklemede";
            return sn;
        }
        else if (onay == 1)
        {
            if (sonuc == 11)
            {
                sn = "Onaylanmış / Beklemede";
                return sn;
            }
            else if (sonuc == 0)
            {
                sn = "Onaylanmış / Kullanıcıda";
                return sn;
            }
            else if (sonuc == 1)
            {
                sn = "Dosya Tamamlanmış";
            }
          
        }
        else if (onay == 9)
        {
            sn = "Dosya Red Edildi";
            return sn;
        }
        return sn;
    }
}
