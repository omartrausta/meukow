using System;

public partial class PageError : System.Web.UI.Page
{
	/// <summary>
	/// Is run when the page is loaded.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!IsPostBack)
			{
				object oEx = Session["LastError"];

				if (oEx != null)
				{
					Exception ex = (Exception)oEx;

					if (ex.InnerException != null)
					{
						m_lblErrorMessage.Text = ex.InnerException.Message;
						m_lblSource.Text = ex.InnerException.Source;
						m_lblStackTrace.Text = ex.InnerException.StackTrace;
						m_lblHelpLink.Text = ex.InnerException.HelpLink;
					}
					else
					{
						m_lblErrorMessage.Text = ex.Message;
						m_lblSource.Text = ex.Source;
						m_lblStackTrace.Text = ex.StackTrace;
						m_lblHelpLink.Text = ex.HelpLink;
					}
				}
			}
#if DEBUG
			m_lnkShowDetails.Visible = false;
			m_pnlDetailedMessage.Visible = true;
#else
			m_lnkShowDetails.Visible = true;
			m_pnlDetailedMessage.Visible = false;
#endif
		}
		catch
		{
			// No errors or infinity LOOP.
		}
	}

	protected void OnShowDetails(object sender, EventArgs e)
	{
		m_pnlDetailedMessage.Visible = true;
	}
}