using System;
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
								//Ef það er til lag þá birtum við nánari upplýsingar um það
                if (song != null)
                {
                    lbl_Name.Text = song.Name;
                    lbl_Artist.Text = song.Artist;
                    txt_Description.Text = song.Description;
                    SongHyperlink.NavigateUrl = song.SongPath;
                   
                    
                }
            }
        }
    }
}