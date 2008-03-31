using System;
using System.Data;
using ClassLibrary;

public partial class DisplayChart : System.Web.UI.Page
{
	#region Event Handlers
	/// <summary>
	/// Is fired when the page is loaded.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		String strID = Request.QueryString["ID"];

		if ( !String.IsNullOrEmpty( strID ))
		{
			DataSet dsView = new DataSet();

			ChartDoc chart = new ChartDoc();

			dsView = chart.GetChartList(Convert.ToInt32(strID));

			m_chartGridView.DataSource = dsView;
			m_chartGridView.DataBind();
		}
	}
	#endregion
}
