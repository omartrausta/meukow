using System;

public partial class DisplaySameArtist : System.Web.UI.Page
{
	#region Event Handlers
	/// <summary>
	/// Is fired when the page is loaded.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	/// <summary>
	/// Is fired when user presses m_btnGoBack.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void OnGoBack(object sender, EventArgs e)
	{
		Response.Redirect("DisplayEnterArtist.aspx");
	}
	#endregion
}
