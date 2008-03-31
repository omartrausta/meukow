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

public partial class DisplayArtistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String http = "//";
        if (!this.IsPostBack)
        {
            String strID = Request.QueryString["ID"];

          if (!String.IsNullOrEmpty(strID))
           {
                 //Munum eftir ID þess nemanda sem við erum að birta:
                this.ViewState["Name"] = strID;
                // Þetta gerum við til að geta sótt gildi þessarar breytu
                // þegar verður ýtt á Update takkann.

                ArtistDoc doc = new ArtistDoc();
                Artist artist = doc.GetArtist(Convert.ToInt32(strID));

                if (artist != null)
                {
                    lbl_Name.Text = artist.Name;
                    m_txtDescription.Text = artist.Description;
                    m_WebHypelink.Text = artist.URL;
                    m_WebHypelink.NavigateUrl =http + artist.URL;
                    m_ArtistImage.ImageUrl = artist.Picture;
                }
            }
        }
    }
}
