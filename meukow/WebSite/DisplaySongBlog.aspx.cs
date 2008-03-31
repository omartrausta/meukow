using System;
using ClassLibrary;

public partial class DisplaySongBlog : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			BlogDoc doc = new BlogDoc();
			//Song song = new Song();

			String strID = Request.QueryString["ID"];

			if ( !String.IsNullOrEmpty( strID ))
			{		
				m_blogRepeater.DataSource = doc.GetBlogSong(Convert.ToInt32(strID));	
				m_blogRepeater.DataBind();
			}
		}
	}
}
