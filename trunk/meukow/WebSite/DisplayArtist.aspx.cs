using System;
using ClassLibrary;

public partial class DisplayArtist : System.Web.UI.Page
{
	#region Event Handlers
	/// <summary>
	/// Is fired when the page is loaded.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
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
	#endregion
}
