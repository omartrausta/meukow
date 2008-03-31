using System;
using System.Windows.Forms;
using ClassLibrary;

namespace meukow
{
	public partial class SongDlg : Form
	{
		#region Member variables
		private ArtistCollection m_artistCollection = new ArtistCollection();
		private Artist m_artist = new Artist();
		private readonly ArtistDoc artistDoc = new ArtistDoc();
		private Song m_song = null;
		private String m_fileName;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets Song
		/// </summary>
		public Song song
		{
			get
			{
				m_artist = (Artist)m_cmbArtist.SelectedItem;
				m_song.Name = m_txtboxName.Text;
				m_song.ArtistID = m_artist.ID;
				m_song.Artist = m_artist.Name;
				m_song.SongPath = m_txtboxSongpath.Text;
				m_song.Description = m_txtboxDescription.Text;
				return m_song;
			}
			set
			{
				m_song = value;
				m_txtboxName.Text = m_song.Name;
				m_cmbArtist.Text = m_song.Artist;
				m_txtboxSongpath.Text = m_song.SongPath;
				m_txtboxDescription.Text = m_song.Description;
			}
		}

		/// <summary>
		/// Gets or sets Filename.
		/// </summary>
		public String Filename
		{
			get
			{
				return m_fileName;
			}
			set
			{
				m_fileName = value;
			}
		}
		#endregion		

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public SongDlg()
		{
			InitializeComponent();
			RefreshCombo();
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
			if (m_song.ID == 0)
			{
				m_btnOK.Text = "Skrá";
				this.Text = "Skrá Lag";
			}
			else
			{
				m_btnOK.Text = "Breyta";
				this.Text = "Breyta lagi";
			}
		}
		#endregion

		#region Private functions
		/// <summary>
		/// Refreshes the list in m_cmbArtist
		/// </summary>
		private void RefreshCombo()
		{
			m_artistCollection = artistDoc.GetAllArtists();
			m_cmbArtist.DataSource = m_artistCollection;
		}
		#endregion
	}
}