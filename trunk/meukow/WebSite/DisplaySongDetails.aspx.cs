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

public partial class DisplaySongDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String http = "//";
        if (!this.IsPostBack)
        {
            String strID = Request.QueryString["ID"];

            if (!String.IsNullOrEmpty(strID))
            {
                //Munum eftir ID þess Lags sem við erum að birta:
                this.ViewState["Name"] = strID;
                
                SongDoc doc = new SongDoc();
                Song song = doc.GetSong(Convert.ToInt32(strID));
                BlogDoc blocdoc = new BlogDoc();
                //Blog blog = blocdoc.GetBlog(Convert.ToInt32(strID));
                if (song != null)
                {
                    lbl_Name.Text = song.Name;
                    lbl_Artist.Text = song.Artist;
                    txt_Description.Text = song.Description;
                    SongHyperlink.NavigateUrl = song.SongPath;
                    //hyperl_SeeBlogg.NavigateUrl = blog.Title;
                    
                }
            }
        }
    }
}