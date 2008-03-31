using System;
using ClassLibrary;

public partial class _Default : System.Web.UI.Page
{
	#region Event Handlers
	/// <summary>
	/// Is fired when the page is loaded.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		ListDoc doc = new ListDoc();
		ListCollection lists = doc.GetAllList();

		if (lists != null)
		{
			m_listGridView.DataSource = lists;
			m_listGridView.DataBind();
		}
	}
	#endregion
}
