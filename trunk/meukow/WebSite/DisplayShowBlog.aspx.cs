using System;
using System.Data;
using ClassLibrary;

public partial class DisplayShowBlog : System.Web.UI.Page
{
	/// <summary>
	/// Is run when the page is loaded.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		String strID = Request.QueryString["ID"];
		if (!this.IsPostBack)
		{
			BlogDoc doc = new BlogDoc();
			
			DataSet dsView = new DataSet();

			if (!String.IsNullOrEmpty(strID))
			{
				// Data loaded into into FormView controler.
				dsView = doc.GetBlog(Convert.ToInt32(strID));
				FormView1.DataSource = dsView;
				FormView1.DataBind();
			}
		}
	}
}
