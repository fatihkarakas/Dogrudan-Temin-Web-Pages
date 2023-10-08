using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using AjaxControlToolkit;

public partial class yonetim_mesajyaz : System.Web.UI.Page
{
    public bool hata;
    public string dosyahatasi;
    public string msdosyaadres = "";
    public string kisilistesi;
    public string kisiid;
    public string kisiemail;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            isimler(kime_text);
        }
    }

    public void isimler(DropDownList dp)
    {
        try
        {
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            baglanti.Open();
            MySqlDataAdapter adpt = new MySqlDataAdapter("select id,isim from zih_users order by isim ", baglanti);
            DataSet ds = new DataSet();

            adpt.Fill(ds, "user");
            dp.DataSource = ds.Tables[0];
            dp.DataTextField = "isim";
            dp.DataValueField = "id";
            dp.DataBind();
            dp.Items.Add(new ListItem("Seçiniz", "Seçiniz"));
            dp.SelectedValue = "Seçiniz";


        }
        catch (Exception ex)
        {
            div_bilgi.Visible = true;
            bilgiver.Text = "Hata oluştu" + ex.Message.ToString();
        }
    }
    protected void kisi_ekle_btn_Click(object sender, EventArgs e)
    {
        
        if (kime_text.SelectedValue != "Seçiniz")
        {

            for (int i = 0; i <= kimlere_list.Items.Count - 1; i++)
            {
                if (kime_text.SelectedValue == kimlere_list.Items[i].Value)
                {
                    
                    return;
                }
            }

            ListItem list = new ListItem();
            list.Value = kime_text.SelectedValue;
            list.Text = kime_text.SelectedItem.ToString();
            kimlere_list.Items.Add(list);

        }
    }
    protected void cikar_Click(object sender, EventArgs e)
    {

        kimlere_list.Items.Remove(kimlere_list.SelectedItem);

    }

    public void kisi_listesi(ListBox l)
    {
        div_bilgi.Visible = false;
        string s = "";
        for (int i = 0; i <= l.Items.Count - 1; i++)
        {
            if (i == l.Items.Count - 1)
            {
                s += l.Items[i].Value;
            }
            else { s += l.Items[i].Value + ","; }

        }
        s = "where id in(" + s + ")";
        try
        {
            MySqlConnection baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            baglanti.Open();
            MySqlCommand sor = new MySqlCommand("select id,isim, eposta from zih_users " + s + " ", baglanti);
            MySqlCommand sor1 = new MySqlCommand("select count(*) from zih_users " + s + " ", baglanti);
            int y = Convert.ToInt32(sor1.ExecuteScalar());
            baglanti.Close();
            sor1.Dispose();
            baglanti.Open();
            MySqlDataReader oku = sor.ExecuteReader();
            int z = 1;
            while (oku.Read())
            {
                if (z == y)
                {
                    kisilistesi += oku["isim"].ToString();
                    kisiid += oku[0].ToString();
                    kisiemail += oku[2].ToString();
                }
                else
                {
                    kisilistesi += oku["isim"].ToString() + ",";
                    kisiid += oku[0].ToString() + ",";
                    kisiemail += oku[2].ToString() + ",";
                }
                z++;

            }
            oku.Dispose();
            baglanti.Close();

        }
        catch (Exception ex)
        {
            div_bilgi.Visible = true;
            bilgiver.Text = "Hataaa :" + ex.Message.ToString();
        }
    }

    public void dosya_kontrol(FileUpload fs)
    {
        Session["dosya_bilgi"] = "";
        Session["dosya_durum"] = "";
        string[] uygundosya = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".doc", ".xls", ".xlsx", ".pdf", ".docx", ".rar", ".zip" };
        string uzanti = System.IO.Path.GetExtension(fs.PostedFile.FileName);
        for (int i = 0; i <= uygundosya.Length - 1; i++)
        {
            if (uzanti == uygundosya[i])
            {
                hata = true;
            }
        }
        if (hata == false)
        {
            hata = false;
            Session["dosya_durum"] = "Dosya tipi uygun değil " + uzanti + " uzantılı dosya yükleyemezsiniz.  Dosyanız : " + fs.PostedFile.FileName;
            return;
        }
        if (hata == true)
        {
            if (fs.PostedFile.ContentLength > 500000) { Session["dosya_durum"] = "Dosya Boyutu Çok Büyük"; hata = false; return; }
            string fn = System.IO.Path.GetFileName(fs.PostedFile.FileName);
            string id = Guid.NewGuid().ToString();
            string dosyaadres = string.Format("{0}{1}_{2}", Server.MapPath("MesajDosya\\"), id, fn);
            try
            {
                fs.PostedFile.SaveAs(dosyaadres);
                Session["dosya_adres"] = id + "_" + fn;
                hata = true;
                dosyaadres = id + "_" + fn;
                msdosyaadres = "MesajDosya\\" + id + "_" + fn;
                Session["dosya_bilgi"] = dosyaadres;
            }
            catch (Exception ez)
            {
                Session["dosya_durum"] += "Hata Oluştu :" + ez.Message.ToString();
                dosyahatasi = "Hata :" + ez.Message.ToString();
                hata = false;
                return;
            }

        }


    }

   
    protected void Gonder_Click(object sender, EventArgs e)
    {
        if (konu.Text == "")
        {
            div_bilgi.Visible = true;
            bilgiver.Text = "Konu Boş olamaz";
            return;
        }
        else
        {
            div_bilgi.Visible = false;
        }
        if (mesaji.Content.ToString() == "")
        {
            div_bilgi.Visible = true;
            bilgiver.Text = "Mesajınız Boş olamaz";
            return;
        }
        else
        {
            div_bilgi.Visible = false;
        }
        if (kimlere_list.Items.Count == 0)
        {
            div_bilgi.Visible = true;
            bilgiver.Text = "Gönerilecek kişi seçmediniz";
            return;
        }
        else
        {
            div_bilgi.Visible = false;
        }
        if (dosya.PostedFile.FileName != "")
        {
            dosya_kontrol(dosya);
            if (hata == false)
            {
                bilgiver.Text = Session["dosya_durum"].ToString();
                div_bilgi.Visible = true;
                div_bilgi.Attributes["class"] = "hata";
                return;
            }
            else
            {
                div_bilgi.Visible = false;
            }
        }
        kisi_listesi(kimlere_list);
        mesajislemler ms = new mesajislemler();
        ms.msdosyaurl = msdosyaadres;
        ms.mskonu = konu.Text;
        ms.mskimden = Convert.ToInt32(Session["user_id"].ToString());
        ms.mskimeisimler = kisilistesi;
        ms.mskimlere = kisiid;
        ms.msepostalar = kisiemail;
        ms.msmesaj = mesaji.Content.ToString();
        ms.mesayukle(ms.mskonu, ms.msmesaj, ms.mskimden);
        ms.epostalit = kisiemail.Split(',');
        string[] ls = kisiid.Split(',');
        for (int i = 0; i <= ls.Length - 1; i++)
        {
            ms.gelenmesajyaz(Convert.ToInt32(ls[i].ToString()), Session["isim"].ToString(), ms.epostalit[i].ToString());
        }
        if (ms.mesaj_hata != "")
        {
            div_bilgi.Visible = true;
            bilgiver.Text = "Hata " + ms.mesaj_hata;
            return;
        }
        else
        {
            div_bilgi.Visible = true;
            bilgiver.Text = "Mesajınız Gönderildi";

        }
    }
}