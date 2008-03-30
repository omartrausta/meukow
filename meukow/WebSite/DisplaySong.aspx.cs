using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Media;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ClassLibrary;


public partial class DisplaySong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SongDoc Document = new SongDoc();

        SongCollection songs = Document.GetAllSongs();


        if (songs != null)
        {
            m_songGridView.DataSource = songs;
            m_songGridView.DataBind();

        }


    }
 
    protected void m_songGridView_SelectedRow(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.m_songGridView, "Select$" + e.Row.RowIndex);
           SoundPlayer player = new SoundPlayer();
            player.Play();
        }
    }
}
