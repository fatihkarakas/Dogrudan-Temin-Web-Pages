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

public partial class Dosya_Ac : System.Web.UI.Page
{
    
    public int ihaleid;
    public bool hata;
    public string dosyahatasi;
    public string msdosyaadres = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            baglan bs = new baglan();
            bs.kurum_bilgisi();
            krm.Text = bs.krmadi;
            krmid.Text = Convert.ToString(bs.kurumid);
        }
    }
    protected void zihale_btn_Click(object sender, EventArgs e)
    {
        sncdiv.Visible = false;
        snc.Visible = false;
        if (ihale_adi.Text == "")
        {
            snc.Text = "İhale Dosya Adı Giriniz!!";
            snc.Visible = true;
            return;
        }
        else
        {
            snc.Visible = false;
        }
        if (iaciklama.Text == "")
        {
            snc.Text = "İhale dosyası için bir açıklama giriniz!!";
            snc.Visible = true;
            return;
        }
        else
        {
            snc.Visible = false;
        }
        string id = Guid.NewGuid().ToString();
        try
        {
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "INSERT INTO zihale(kurum, icerik, aciklama,  ihalekod, tarih, ekleyen, kurum_id) VALUES (@kurum,@icerik,@aciklama,@ihalekod,@tarih, @ekleyen, @kurum_id);SELECT LAST_INSERT_ID()";
            sorgu.Parameters.AddWithValue("@icerik", (string)ihale_adi.Text);
            sorgu.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sorgu.Parameters.AddWithValue("@ihalekod", (string)id);
            sorgu.Parameters.AddWithValue("@kurum", (string)krm.Text);
            sorgu.Parameters.AddWithValue("@kurum_id", (int)Convert.ToInt32(krmid.Text));
            sorgu.Parameters.AddWithValue("@aciklama", (string)iaciklama.Text);
            sorgu.Parameters.AddWithValue("@ekleyen", Convert.ToInt32(Session["user_id"].ToString()));
            //sorgu.Parameters.AddWithValue("@ekleyen", Convert.ToInt32(Session["user_id"].ToString()));
            ihaleid = Convert.ToInt32(sorgu.ExecuteScalar());
            Baglanti.Close();

        }
        catch (Exception ex)
        {
            sncdiv.Visible = true;
            sncmsj.Text = "İhale veritabanına Eklenemedi  HATA :" + ex.Message.ToString();

            return;
        }
        ilk.Visible = false;
        pnl_snc.Visible = true;
        ia.Text = ihale_adi.Text;
        iac.Text = iaciklama.Text;
        iid.Text = Convert.ToString(ihaleid);
        ikod.Text = id;
        ihale_adi.Text = "";
        iaciklama.Text = "";
    }
    protected void elleekle_Click(object sender, EventArgs e)
    {
        elleeklepnl.Visible = true;
        elemanlistesipaneli.Visible = true;
        dogrudanlistesielle.DataSource = verigetir();
        dogrudanlistesielle.DataBind();
        excelpanel.Visible = false;
    }
    public void veriekle(string sut, string turu, string kanunbendi, string cinsi, string miktar, string birim, string sonyiltuketim, string birimsonyil, string sonalimfiyat, string ihalekod, int ihale_id, string sonalimbarkod)
    {
        eklersonuc.Visible = false;
        try
        {
            if (turu == "Seçiniz") { turu = ""; }
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "INSERT INTO zihale_icerik(ihale_kod,ihale_id,SUT,mal_hizmet_yapim,kanun_bend,cinsi,miktar,birim,son_yil_tuketim,birim_son_yil,son_fiyat,son_alim_barkod)VALUES(@ihalekod,@ihaleid,@sut,@mal_hizmet_yapim,@kanun_bend,@cinsi,@miktar,@birim,@son_yil_tuketim,@birim_son_yil,@son_fiyat, @son_alim_barkod)";
            sorgu.Parameters.AddWithValue("@ihaleid", ihale_id);
            sorgu.Parameters.AddWithValue("@ihalekod", ihalekod);
            sorgu.Parameters.AddWithValue("@sut", sut);
            sorgu.Parameters.AddWithValue("@mal_hizmet_yapim", turu);
            sorgu.Parameters.AddWithValue("@kanun_bend", kanunbendi);
            sorgu.Parameters.AddWithValue("@cinsi", cinsi);
            sorgu.Parameters.AddWithValue("@miktar", miktar);
            sorgu.Parameters.AddWithValue("@birim", birim);
            sorgu.Parameters.AddWithValue("@son_yil_tuketim", sonyiltuketim);
            sorgu.Parameters.AddWithValue("@birim_son_yil", birimsonyil);
            sorgu.Parameters.AddWithValue("@son_fiyat", sonalimfiyat);
            sorgu.Parameters.AddWithValue("@son_alim_barkod", sonalimbarkod);
            sorgu.ExecuteNonQuery();
            Baglanti.Close();
        }
        catch (Exception ex)
        {
            eklersonuc.Visible = true;
            eklersonuc.Text = "Hata Oluştu :" + ex.Message;
            return;
        }
        eklersonuc.Visible = true;
        eklersonuc.Text = "Dosya Eklendi";
    }
    protected void elleekler_Click(object sender, EventArgs e)
    {
        eklersonuc.Visible = false;
        if (sutkodu.Text == "" || tur.SelectedValue == "Seçiniz" || cinsitext.Text == "" || kanuntext.Text == "")
        {
            eklersonuc.Text = "Lütfen boş veri girmeyiniz";
            eklersonuc.Visible = true;
            return;
        }
        veriekle(sutkodu.Text, tur.SelectedValue, kanuntext.Text, cinsitext.Text, miktartext.Text, birimitext.Text, sonyiltext.Text, birimsonyiltext.Text, sonalimfiyattext.Text, ikod.Text, Convert.ToInt32(iid.Text), sabarkod.Text);
        dogrudanlistesielle.DataSource = verigetir();
        dogrudanlistesielle.DataBind();
    }

    public DataSet verigetir()
    {
        DataSet DS = new DataSet();
        MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
        MySqlCommand sorgu = new MySqlCommand();
        if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
        MySqlDataAdapter AD = new MySqlDataAdapter("select * from zihale_icerik where ihale_id=" + iid.Text + " and ihale_kod='" + ikod.Text + "'", Baglanti);
        AD.Fill(DS, "Veriler");
        Baglanti.Close();
        return DS;
    }
    protected void dogrudanlistesielle_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "duzelt")
        {
            TextBox sutkod = e.Item.FindControl("st") as TextBox;
            TextBox tur1 = e.Item.FindControl("mh") as TextBox;
            TextBox kb1 = e.Item.FindControl("kb") as TextBox;
            TextBox cns1 = e.Item.FindControl("cns") as TextBox;
            TextBox mkt1 = e.Item.FindControl("mkt") as TextBox;
            TextBox brm1 = e.Item.FindControl("brm") as TextBox;
            TextBox syt1 = e.Item.FindControl("syt") as TextBox;
            TextBox bsy1 = e.Item.FindControl("bsy") as TextBox;
            TextBox sf1 = e.Item.FindControl("sf") as TextBox;
            TextBox sab2 = e.Item.FindControl("sabrkd") as TextBox;
            try
            {
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Update zihale_icerik set SUT = '" + sutkod.Text + "', mal_hizmet_yapim = '" + tur1.Text + "', kanun_bend = '" + kb1.Text + "', cinsi = '" + cns1.Text + "', miktar = '" + mkt1.Text + "', birim = '" + brm1.Text + "', son_yil_tuketim = '" + syt1.Text + "', birim_son_yil = '" + bsy1.Text + "', son_fiyat = '" + sf1.Text + "', son_alim_barkod= '" + sab2.Text + "' where id = " + Convert.ToInt32(e.CommandArgument) + " ";
                sorgu.ExecuteNonQuery();
                Baglanti.Close();
            }
            catch (Exception ex)
            {
                eklersonuc.Visible = true;
                eklersonuc.Text = "Hata Oluştu :" + ex.Message;
                return;
            }
            dogrudanlistesielle.DataSource = verigetir();
            dogrudanlistesielle.DataBind();
        }
        if (e.CommandName == "sil")
        {
            try
            {
                MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
                MySqlCommand sorgu = new MySqlCommand();
                if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
                sorgu.Connection = Baglanti;
                sorgu.CommandText = "Delete from zihale_icerik where id = " + Convert.ToInt32(e.CommandArgument) + " ";
                sorgu.ExecuteNonQuery();
                Baglanti.Close();
            }
            catch (Exception ex)
            {
                eklersonuc.Visible = true;
                eklersonuc.Text = "Hata Oluştu :" + ex.Message;
                return;
            }
            dogrudanlistesielle.DataSource = verigetir();
            dogrudanlistesielle.DataBind();
        }
        if (e.CommandName == "ekle")
        {
            TextBox sutkod = e.Item.FindControl("st2") as TextBox;
            TextBox tur1 = e.Item.FindControl("mh2") as TextBox;
            TextBox kb1 = e.Item.FindControl("kb2") as TextBox;
            TextBox cns1 = e.Item.FindControl("cns2") as TextBox;
            TextBox mkt1 = e.Item.FindControl("mkt2") as TextBox;
            TextBox brm1 = e.Item.FindControl("brm2") as TextBox;
            TextBox syt1 = e.Item.FindControl("syt2") as TextBox;
            TextBox bsy1 = e.Item.FindControl("bsy2") as TextBox;
            TextBox sf1 = e.Item.FindControl("sf2") as TextBox;
            TextBox sab2 = e.Item.FindControl("sabrkd2") as TextBox;
            veriekle(sutkod.Text, tur1.Text, kb1.Text, cns1.Text, mkt1.Text, brm1.Text, syt1.Text, bsy1.Text, sf1.Text, ikod.Text, Convert.ToInt32(iid.Text), sab2.Text);

            dogrudanlistesielle.DataSource = verigetir();
            dogrudanlistesielle.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (excelcek.PostedFile.FileName != "")
        {
            dosya_kontrol(excelcek);
            if (hata == false)
            {
                excelhata.Visible = true;
                excelhata.Text = Session["dosya_durum"].ToString();
                return;
            }
        }
        else
        {
            excelhata.Visible = true;
            excelhata.Text = "Dosya Boş Olamaz";
            return;
        }
        try
        {
            string excel_dosya = Session["dosya_bilgi"].ToString();
            DataSet myDataset = new DataSet();
            String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Server.MapPath("dosyalar\\") + excel_dosya + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";
            OleDbDataAdapter myData = new OleDbDataAdapter("SELECT * FROM [Sayfa1$]", strConn);
            myData.TableMappings.Add("Table", "ExcelTest");
            myData.Fill(myDataset);
            elemanexcel.DataSource = myDataset.Tables[0].DefaultView;
            elemanexcel.DataBind();
        }
        catch (Exception ex)
        {
            excelhata.Visible = true;
            excelhata.Text = ex.Message.ToString();
        }
        excelhata.Visible = true;
        excelhata.Attributes.CssStyle.Remove("class");
        excelhata.Attributes["class"] = "tamamdir";
        excelhata.Text = "Excel Veri Okundu";
        exceldiv.Visible = true;
    }

    public void dosya_kontrol(FileUpload fs)
    {
        Session["dosya_bilgi"] = "";
        Session["dosya_durum"] = "";
        string[] uygundosya = { ".xls" };
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
            string dosyaadres = string.Format("{0}{1}_{2}", Server.MapPath("dosyalar\\"), id, fn);
            try
            {
                fs.PostedFile.SaveAs(dosyaadres);
                Session["dosya_adres"] = id + "_" + fn;
                hata = true;
                dosyaadres = id + "_" + fn;
                msdosyaadres = "dosyalar\\" + id + "_" + fn;
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
    protected void ex_d_ekle_Click(object sender, EventArgs e)
    {
        excelhata.Visible = false;
        sncdiv0.Visible = false;
        int say = 0;
        foreach (GridViewRow gr in elemanexcel.Rows)
        {
            if (gr.Cells[0].Text != "" || gr.Cells[1].Text != "" || gr.Cells[2].Text != "" || gr.Cells[3].Text != "" || gr.Cells[4].Text != "")
            {
                try
                {
                    veriekle(dt(gr.Cells[1].Text), dt(gr.Cells[2].Text), dt(gr.Cells[3].Text), dt(gr.Cells[4].Text), dt(gr.Cells[5].Text), dt(gr.Cells[6].Text), dt(gr.Cells[7].Text), dt(gr.Cells[8].Text), dt(gr.Cells[9].Text), ikod.Text, Convert.ToInt32(iid.Text), dt(gr.Cells[10].Text));
                }
                catch (Exception ex)
                {
                    sncdiv0.Visible = true;
                    sncmsj0.Text = "Hata oluştu :" + ex.Message.ToString();
                    return;
                }
                say++;
            }
            excelhata.Text = "Veritabanına " + say + " liste elemanı başarıyla eklendi!!";
        }
        dogrudanlistesielle.DataSource = verigetir();
        dogrudanlistesielle.DataBind();
    }
    public string dt(string veri)
    {
        veri = veri.Replace("&#246;", "ö");
        veri = veri.Replace("&#252;", "ü");
        veri = veri.Replace("&#220;", "Ü");
        veri = veri.Replace("&#231;", "ç");
        veri = veri.Replace("&#199;", "Ç");
        veri = veri.Replace("&#214;", "Ö");
        veri = veri.Replace("&nbsp;", "");
        veri = veri.Trim();
        return veri;
    }
    protected void excelekle_Click(object sender, EventArgs e)
    {
        excelpanel.Visible = true;
        elemanlistesipaneli.Visible = true;
        dogrudanlistesielle.DataSource = verigetir();
        dogrudanlistesielle.DataBind();
        elleeklepnl.Visible = false;
    }

    public string ihalekodugetir(int id)
    {
        string ikod = "";
        try
        {
            MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
            MySqlCommand sorgu = new MySqlCommand();
            if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
            sorgu.Connection = Baglanti;
            sorgu.CommandText = "select ihalekod from zihale where id = " + id + "";
            MySqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                ikod = oku["ihalekod"].ToString();
            }
            Baglanti.Close();
            sorgu.Dispose();

        }
        catch
        {

        }
        return ikod;
    }
    protected void btn_srtn_Click(object sender, EventArgs e)
    {
        sartnamediv.Visible = false;
        if (srtn_ekle.PostedFile.FileName.ToString() == "" || dosyadi.Text == "" || dosyaaciklama.Text == "")
        {
            sartnamediv.Visible = true;
            sartnamelabel.Text = "Şartame Dosyası için gerekli bilgileri Dodurunuz";
            sartnamelabel.Text += "<br /> Uygun Dosya Seçiniz <br /> Dosya Adını Yazınız <br /> Dosya Açıklama Ekleyiniz <br />";
            return;
        }
        fonksiyonlar fs = new fonksiyonlar();
        fs.dosya_kontrol(srtn_ekle, Convert.ToInt32(iid.Text), dosyaaciklama.Text, dosyatip.SelectedValue, dosyadi.Text);
        if (fs.dosyahata == false)
        {
            sartnamediv.Visible = true;
            sartnamelabel.Text = "Hata Oluştu " + fs.dosyahatasi;
            return;
        }
        sartnamaler.DataSource = fs.sartnameler(Convert.ToInt32(iid.Text));
        sartnamaler.DataBind();
    }

}