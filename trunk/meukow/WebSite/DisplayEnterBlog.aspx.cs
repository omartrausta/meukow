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

public partial class DisplayEnterBlog : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			String strID = Request.QueryString["ID"];

			if (!String.IsNullOrEmpty(strID))
			{
				// Munum eftir ID þess nemanda sem við erum að birta:
				this.ViewState["ID"] = strID;
				// Þetta gerum við til að geta sótt gildi þessarar breytu
				// þegar verður ýtt á Update takkann
			}
		}
	}

	protected void OnBtnAdd(object sender, EventArgs e)
	{
		object strID = this.ViewState["ID"];
		
		BlogDoc doc = new BlogDoc();
		Blog blog = new Blog();

		blog.Title = m_txtTitle.Text;
		blog.Content = m_txtContent.Text;
		blog.SongID = Convert.ToInt32( strID );
		blog.BlogDate = DateTime.Now;

		doc.AddBlog(blog);
	}
}
