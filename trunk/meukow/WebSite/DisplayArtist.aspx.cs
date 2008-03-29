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

public partial class DisplayArtist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArtistDoc Document = new ArtistDoc();

        ArtistCollection artists = Document.GetAllArtists();


        if (artists != null)
        {
            m_artistGridView.DataSource = artists;
            m_artistGridView.DataBind();
        } 
    }
}
