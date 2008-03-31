using System;
using ClassLibrary;

public partial class DisplayEnterBlog : System.Web.UI.Page
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
			// Tek inn færibreytu með querystring.
			String strID = Request.QueryString["ID"];
			if (Request.UrlReferrer != null)
			{
				// Store a link where the users is coming from
				// to session parameter.
				String strUrl = Request.UrlReferrer.ToString();
				Session["strUrl"] = strUrl;
			}
			else
			{
				Response.Redirect("default.aspx");
			}
			
			if (!String.IsNullOrEmpty(strID))
			{
				// Remember the ID of the song.
				this.ViewState["ID"] = strID;
			}
			else
			{
				Response.Redirect("default.aspx");
			}
		}
	}
	/// <summary>
	/// Button to confirm the blog entry.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void OnBtnAdd(object sender, EventArgs e)
	{
		// Access the gathered parameters
		object strID = this.ViewState["ID"];
		String strUrl = (String)Session["strUrl"];

		BlogDoc doc = new BlogDoc();
		Blog blog = new Blog();

		blog.Title = m_txtTitle.Text;
		blog.Content = m_txtContent.Text;
		blog.SongID = Convert.ToInt32( strID );
		blog.BlogDate = DateTime.Now;

		// We add the blog entry to the database
		// and redirect the user to the prior page.
		doc.AddBlog(blog);
		Response.Redirect(strUrl);
	}
}
