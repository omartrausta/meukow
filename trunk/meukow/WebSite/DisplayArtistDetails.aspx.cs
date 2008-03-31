using System;
using ClassLibrary;

public partial class DisplayArtistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
			//búum til breytu sem fjarlægir localhost og leyfir hlekknum að fara út fyrir okkar vef
        String http = "//";
        if (!this.IsPostBack)
        {
            String strID = Request.QueryString["ID"];

          if (!String.IsNullOrEmpty(strID))
           {
                 //Munum eftir ID þess flytjanda sem við erum að birta:
                this.ViewState["Name"] = strID;
               

                ArtistDoc doc = new ArtistDoc();
                Artist artist = doc.GetArtist(Convert.ToInt32(strID));

						//Ef það er til artist þá birtum við nánari upplýsingar um hann
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
