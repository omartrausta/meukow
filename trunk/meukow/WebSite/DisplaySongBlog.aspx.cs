using System;
using ClassLibrary;

public partial class DisplaySongBlog : System.Web.UI.Page
{
	/// <summary>
	/// Is run when the page is loaded.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			String strID = Request.QueryString["ID"];

			if ( !String.IsNullOrEmpty( strID ))
			{
				BlogDoc doc = new BlogDoc();
				SongDoc songdoc = new SongDoc();
				// Data loaded into into FormView controler.
				// Data loaded to Repeater controler.
				m_blogRepeater.DataSource = doc.GetBlogSong(Convert.ToInt32(strID));
				m_blogRepeater.DataBind();
				m_formView.DataSource = songdoc.GetdsSong(Convert.ToInt32(strID));
				m_formView.DataBind();
			}
		}
	}
}
