using System;
using System.Windows.Forms;

namespace meukow
{
	partial class MainWindow : Form
	{
		#region Member Variables
		private ArtistView m_artistView;
		private SongView m_SongView;
		private HitParadeView m_HitParadeView;
		private ChartView m_chartView;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public MainWindow()
		{
			InitializeComponent();
			m_HitParadeView.HitParadeSelected += new HitParadeView.HitParadeHandler(m_chartView.OnHitParadeSelected);
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Is fired when user clicks m_tsbtnNewArtist.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNewArtist(object sender, EventArgs e)
		{
			m_artistView.OnNewArtist();
		}

		/// <summary>
		/// Is fired when user clicks m_tsbtnNewList.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNewHitParade(object sender, EventArgs e)
		{
			m_HitParadeView.OnNewList();
		}

		/// <summary>
		/// Is fired when user clicks m_tsbtnEdiList.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEditHitParade(object sender, EventArgs e)
		{
			m_HitParadeView.OnEditList();
		}

		/// <summary>
		/// Is fired when user clicks m_tsbtnDeleteList.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDeleteHitParade(object sender, EventArgs e)
		{
			m_HitParadeView.OnDeleteList();
		}

		/// <summary>
		/// Is fired when user clicks m_tsbtnDeleteArtist.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDeleteArtist(object sender, EventArgs e)
		{
			m_artistView.OnDeleteArtist();
		}

		/// <summary>
		/// Is fired when user clicks m_tsbtnEditArtist.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEditArtist(object sender, EventArgs e)
		{
			m_artistView.OnEditArtist();
		}

		/// <summary>
		/// Is fired when user clicks m_tsbtnNewSong.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNewSong(object sender, EventArgs e)
		{
			m_SongView.OnNewSong();
		}

		/// <summary>
		/// Is fired when user clicks m_tsbtnEditSong.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEditSong(object sender, EventArgs e)
		{
			m_SongView.OnEditSong();
		}

		/// <summary>
		/// Is fired when user clicks m_tsbtnDeleteSong.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDeleteSong(object sender, EventArgs e)
		{
			m_SongView.OnDeleteSong();
		}

		/// <summary>
		/// Is fired when user clicks on tabs.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTabControlClick(object sender, EventArgs e)
		{
			if( m_TabControl.SelectedIndex == 1 && m_HitParadeView.IsNewSong == true )
			{
				m_SongView.UpdateSongView();
			}

			if (m_TabControl.SelectedIndex == 2 && m_HitParadeView.IsNewArtist == true)
			{
				m_artistView.UpdateArtistView();
			}
		}

		/// <summary>
		/// Is fired when user clicks m_tsMenuItemQuit.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnQuitClick(object sender, EventArgs e)
		{
			String s = MessageBox.Show("Viltu örugglega hætta?", "Hætta", MessageBoxButtons.YesNo).ToString();
			if (s == "Yes")
			{
				this.Close();
			}
		}
		
		/// <summary>
		/// Is fired when user clicks m_tsMenuItemAbout.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAboutClick(object sender, EventArgs e)
		{
			using( AboutDlg dlg = new AboutDlg())
			{
				dlg.ShowDialog();
			}
		}
		#endregion
	}
}
