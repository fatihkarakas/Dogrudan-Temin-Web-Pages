using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
public partial class degisiklik : System.Web.UI.Page
{
    public int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != "")
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                           }
        }
        GridView1.DataSource = ds(id);
        GridView1.DataBind();

    }
    public DataSet ds(int id)
    {
        DataSet DS = new DataSet();
        MySqlConnection Baglanti = new MySqlConnection(ConfigurationManager.ConnectionStrings["DB1"].ConnectionString);
        MySqlCommand sorgu = new MySqlCommand();
        if (Baglanti.State == ConnectionState.Closed) { Baglanti.Open(); }
        MySqlDataAdapter AD = new MySqlDataAdapter("select * from zihdegisiklik where ihale_id=" + id + " ", Baglanti);
        AD.Fill(DS, "Veriler");
        Baglanti.Close();
        return DS;
    }
}