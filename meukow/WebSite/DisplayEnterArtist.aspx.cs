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
using ClassLibrary.Common.Data;

public partial class DisplayEnterArtist : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void OnBtnAdd(object sender, EventArgs e)
	{

		ArtistDoc artistdoc = new ArtistDoc();
		Artist artist = new Artist();

		artist.Name = m_txtName.Text;
		artist.Description = m_txtDescription.Text;
		artist.Picture = m_txtPicture.Text;
		artist.URL = m_txtURL.Text;

		DataSet ds = artistdoc.AllArtistName();

		DataTable dt = ds.Tables[0];
		bool noNameConflict = true;

		for (int i = 0; i < dt.Rows.Count; i++)
		{
			String artistDB = dt.Rows[i][0].ToString();
			

			if(artistDB.Equals(artist.Name))
			{
				noNameConflict = false;
				Response.Redirect("DisplaySameArtist.aspx");
			}
		}

		if(noNameConflict)
		{
			artistdoc.AddArtist(artist);
		}
		
	}
}
