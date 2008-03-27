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
using ClassLibrary.Common.Data;

public partial class DisplayChart : System.Web.UI.Page
{
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
}
