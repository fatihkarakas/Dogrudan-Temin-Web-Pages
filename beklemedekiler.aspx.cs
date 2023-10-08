﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Beklemedekiler : System.Web.UI.Page
{
    public string kurumadi;
    public string zihaleid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            baglan bs = new baglan();
            bs.kurum_bilgisi();
            krm.Text = bs.krmadi;
            krmid.Text = Convert.ToString(bs.kurumid);
            dtihale.DataSource = dt();
            dtihale.DataBind();
        }
    }

  

    public DataSet dt()
    {
        DataSet DS = new DataSet();
        MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
        MySqlCommand sorgu = new MySqlCommand();
        if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
        MySqlDataAdapter AD = new MySqlDataAdapter("select * from zihale where onay=0 and kurum_id= " + Convert.ToInt32(krmid.Text) + " order by tarih  ", Baglanti);
        AD.Fill(DS, "Veriler");
        Baglanti.Close();
        return DS;
    }
}