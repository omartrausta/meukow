using System;
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

    protected void m_songGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}

