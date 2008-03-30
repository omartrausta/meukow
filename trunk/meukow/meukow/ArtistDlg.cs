using System;
using System.Windows.Forms;
using ClassLibrary;
using Itboy.Components;

namespace meukow
{
	public partial class ArtistDlg : Form
	{
		#region Member variables
		private const String FILE_DIALOG_FILTER = "Myndaskrá (*.jpg)|*.jpg";
		private Artist m_artist;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets Artist
		/// </summary>
		public Artist Artist
		{
			get
			{
				m_artist.Name = m_txtName.Text;
				m_artist.Description = m_txtDescription.Text;
				m_artist.Picture = m_txtFileName.Text;
				m_artist.URL = m_txtUrl.Text;
				return m_artist;
			}
			set
			{
				m_artist = value;
				m_txtName.Text = m_artist.Name;
				m_txtDescription.Text = m_artist.Description;
				m_txtFileName.Text = m_artist.Picture;
				m_txtUrl.Text = m_artist.URL;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public ArtistDlg()
		{
			InitializeComponent();
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Is fired when the dialog is loaded.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLoad(object sender, EventArgs e)
		{
			if (m_artist.ID == 0)
			{
				m_btnOK.Text = "Skrá";
				this.Text = "Skrá flytjanda";
			}
			else
			{
				m_btnOK.Text = "Breyta";
				this.Text = "Breyta Flytjanda";
			}
		}
		#endregion
	}
}