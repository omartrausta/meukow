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


}
