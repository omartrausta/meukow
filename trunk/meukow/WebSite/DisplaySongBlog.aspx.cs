using System;

using ClassLibrary;

public partial class DisplaySongBlog : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			BlogDoc doc = new BlogDoc();

			m_blogRepeater.DataSource = doc.GetAllBlogs();
			m_blogRepeater.DataBind();
		}
	}
}
