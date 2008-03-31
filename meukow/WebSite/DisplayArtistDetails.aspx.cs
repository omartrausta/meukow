using System;
using ClassLibrary;

public partial class DisplayArtistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
			//b�um til breytu sem fjarl�gir localhost og leyfir hlekknum a� fara �t fyrir okkar vef
        String http = "//";
        if (!this.IsPostBack)
        {
            String strID = Request.QueryString["ID"];

          if (!String.IsNullOrEmpty(strID))
           {
                 //Munum eftir ID �ess flytjanda sem vi� erum a� birta:
                this.ViewState["Name"] = strID;
               

                ArtistDoc doc = new ArtistDoc();
                Artist artist = doc.GetArtist(Convert.ToInt32(strID));

						//Ef �a� er til artist �� birtum vi� n�nari uppl�singar um hann
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
