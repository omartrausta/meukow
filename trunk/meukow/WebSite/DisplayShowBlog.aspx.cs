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

public partial class DisplayShowBlog : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		String strID = null;
		strID = Request.QueryString["ID"];
		if (!this.IsPostBack)
		{
			BlogDoc doc = new BlogDoc();

			DataSet dsView = new DataSet();

			if (!String.IsNullOrEmpty(strID))
			{
				dsView = doc.GetBlog(Convert.ToInt32(strID));
				FormView1.DataSource = dsView;
				FormView1.DataBind();
			}
		}
	}
}
