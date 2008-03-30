using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ClassLibrary;

public partial class Default2 : System.Web.UI.Page
{
    public string url_filename;
    protected void Page_Load(object sender, EventArgs e)
    {
        //SongDoc Document = new SongDoc();

        //SongCollection songs = Document.GetAllSongs();




        /*if (songs != null)
        {
            GridView1.DataSource = songs;
            GridView1.DataBind();

        }*/

        if (!IsPostBack)
        {
            bind();
        }
    }

    private void bind()
    {
        DataTable table = new DataTable();
        table.Columns.Add("url");
        DataRow dr = table.NewRow();
        dr["url"] = @"http://localhost:1462/WebSite/mp3/80s/1984/Phil_Collins-Against_All_Odds.mp3";
        table.Rows.Add(dr);
        this.GridView1.DataSource = table;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        url_filename = this.GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
        GridView1.SelectedIndex = e.NewSelectedIndex;
        bind();
    }
}
