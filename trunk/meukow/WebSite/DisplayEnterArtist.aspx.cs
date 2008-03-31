using System;
using System.Data;
using ClassLibrary;

public partial class DisplayEnterArtist : System.Web.UI.Page
{
	#region Event Handlers
	/// <summary>
	/// Is fired when the page is loaded.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	/// <summary>
	/// Is fired when user presses m_btnAdd.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
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
	#endregion
}
