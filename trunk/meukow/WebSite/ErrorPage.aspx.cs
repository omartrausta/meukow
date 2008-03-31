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

public partial class PageError : System.Web.UI.Page
{
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
			// Hér mega engar villur komast burtu, því annars endum við
			// í endalausri lúppu!
		}
	}

	protected void OnShowDetails(object sender, EventArgs e)
	{
		m_pnlDetailedMessage.Visible = true;
	}
}