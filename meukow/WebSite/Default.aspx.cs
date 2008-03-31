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


public partial class _Default : System.Web.UI.Page
{
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

}
