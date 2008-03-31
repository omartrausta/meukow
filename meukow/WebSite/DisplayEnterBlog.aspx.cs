using System;
using ClassLibrary;

public partial class DisplayEnterBlog : System.Web.UI.Page
{
	/// <summary>
	/// Is run when page is loaded.
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
				// Tek inn tengill þaðan sem notand kom og geymi
				// í session færibreytu.
				String strUrl = Request.UrlReferrer.ToString();
				Session["strUrl"] = strUrl;
			}
			else
			{
				Response.Redirect("default.aspx");
			}
			
			if (!String.IsNullOrEmpty(strID))
			{
				// Munum eftir ID þess lags.
				this.ViewState["ID"] = strID;
				
				// this.ViewState[strUrl] = strUrl;
				// Þetta gerum við til að geta sótt gildi 
				// þessarar breytu
				// þegar verður ýtt á uppfæra.
			}
			else
			{
				Response.Redirect("default.aspx");
			}
		}
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void OnBtnAdd(object sender, EventArgs e)
	{
		// Nálgumst færbreytur sem við höfum safnað.
		object strID = this.ViewState["ID"];
		String strUrl = (String)Session["strUrl"];

		BlogDoc doc = new BlogDoc();
		Blog blog = new Blog();

		blog.Title = m_txtTitle.Text;
		blog.Content = m_txtContent.Text;
		blog.SongID = Convert.ToInt32( strID );
		blog.BlogDate = DateTime.Now;

		// Skrifum blogfærslu og sendum notanda á 
		// síðuna, þaðan sem hann kom.
		doc.AddBlog(blog);
		Response.Redirect(strUrl);
	}
}
