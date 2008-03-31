using System;
using System.Windows.Forms;
using ClassLibrary;

namespace meukow
{
	public partial class ListDlg : Form
	{
		#region Member Variables
		private List m_list = null;
		private SongCollection m_songColleciton = null;
		private ArtistCollection m_artistCollection = null;
		private Song m_song = null;
		private Artist m_artist = null;
		private SongDoc m_songDoc = null;
		private ArtistDoc m_artistDoc = null;
		private ListDoc m_listDoc = null;
		private ListPropDoc m_listPropDoc = null;
		private ListProp m_listProp = null;
		private ListPropCollection m_listPropCollection = null;
		private bool m_bIsNewSong;
		private bool m_bIsNewArtist;
		private Chart m_oldChart = null;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or Sets List.
		/// </summary>
		public List List
		{
			get
			{
				return m_list;
			}
			set
			{
				m_list = value;
			}
		}

		/// <summary>
		/// Gets wether a new song was created.
		/// </summary>
		public bool IsNewSong
		{
			get
			{
				return m_bIsNewSong;
			}
		}

		/// <summary>
		/// Gets wether a new artist was created.
		/// </summary>
		public bool IsNewArtist
		{
			get
			{
				return m_bIsNewArtist;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public ListDlg()
		{
			InitializeComponent();
			m_chartView.ChartSelected += new ChartView.ChartHandler(OnChartSelected);
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
			m_songColleciton = new SongCollection();
			m_songDoc = new SongDoc();

			m_songColleciton = m_songDoc.GetAllSongs();

			m_cmbSong.DataSource = m_songColleciton;

			m_artistCollection = new ArtistCollection();
			m_artistDoc = new ArtistDoc();

			m_artistCollection = m_artistDoc.GetAllArtists();

			m_cmbArtist.DataSource = m_artistCollection;
			m_cmbSong.SelectedIndex = -1;
			m_cmbArtist.SelectedIndex = -1;

			if (List.ID == 0)
			{
				this.Text = "Skrá vinsældalista";
				m_txtPosition.Text = "1";
			}
			else
			{
				this.Text = "Breyta vinsældalista";
				m_txtName.Text = m_list.Name;
				m_dtStarts.Value = m_list.Starts;
				m_dtEnds.Value = m_list.Ends;
				m_chkIsWeekList.Checked = m_list.WeekList;
				m_txtPosition.Text = "";

				m_chartView.OnUpdateChart( m_list.ID );
			}
		}

		/// <summary>
		/// Is fired when user clicks m_btnAddToList.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAddToListClick(object sender, EventArgs e)
		{
			if (m_dtStarts.Value >= m_dtEnds.Value)
			{
				MessageBox.Show("Byrjunar dagsetning þarf að vera minni en enda dagssetning.");
			}
			else
			{
				if( m_list.ID == 0)
				{
					m_list = new List();

					m_list.Name = m_txtName.Text;
					m_list.Starts = m_dtStarts.Value;
					m_list.Ends = m_dtEnds.Value;
					m_list.WeekList = m_chkIsWeekList.Checked;

					m_listDoc = new ListDoc();

					m_listDoc.AddList(m_list);
				}

				if (m_txtPosition.Text.Trim() != string.Empty && m_cmbSong.Text != "" && m_cmbArtist.Text != "")
				{
					int position = Convert.ToInt32(m_txtPosition.Text);
					bool isFound = false;

					m_artist = new Artist();
					m_artist = (Artist) m_cmbArtist.SelectedItem;
					if (m_artist == null)
					{
						m_artist = new Artist();
						m_artistDoc = new ArtistDoc();
						m_artist.Name = m_cmbArtist.Text;
						m_artist.Description = String.Empty;
						m_artist.Picture = String.Empty;
						m_artist.URL = String.Empty;
						m_artistDoc.AddArtist(m_artist);
						m_bIsNewArtist = true;
					}

					m_song = new Song();
					m_song = (Song) m_cmbSong.SelectedItem;
					if (m_song == null)
					{
						m_song = new Song();
						m_songDoc = new SongDoc();
						m_song.Name = m_cmbSong.Text;
						m_song.ArtistID = m_artist.ID;
						m_song.Description = String.Empty;
						m_songDoc.AddSong(m_song);
						m_bIsNewSong = true;
					}
					else
					{
						if (m_song.ArtistID != m_artist.ID)
						{
							m_song.ArtistID = m_artist.ID;
							m_song.Artist = m_artist.Name;
							m_songDoc = new SongDoc();
							m_songDoc.AddSong(m_song);
						}
					}
					m_listPropDoc = new ListPropDoc();
					m_listPropCollection = new ListPropCollection();
					m_listPropCollection = m_listPropDoc.GetListPropByList(m_list.ID);

					foreach (ListProp prop in m_listPropCollection)
					{
						if (prop.Song.Equals(m_song.ID) && m_song.ArtistID.Equals(m_artist.ID))
						{
							MessageBox.Show("Sama lag með sama flytjanda má ekki vera skráð oftar en 1 sinni.");
							break;
						}

						if (prop.Position.Equals(m_oldChart.Position) && prop.Song.Equals(m_oldChart.SongID))
						{
							isFound = true;
							m_listPropDoc = new ListPropDoc();

							prop.Position = position;
							prop.Song = m_song.ID;

							m_listPropDoc.UpdateListProp(prop);
						}
					}

					if( isFound == false )
					{
						m_listPropDoc = new ListPropDoc();
						m_listProp = new ListProp();

						m_listProp.List = m_list.ID;
						m_listProp.Position = position;
						m_listProp.Song = m_song.ID;

						m_listPropDoc.AddListProp(m_listProp);
					}
					m_chartView.OnUpdateChart( m_list.ID );
					m_txtPosition.Text = (position + 1).ToString();
				}
			}
		}

		/// <summary>
		/// Is fired when user selects a song in m_cmbSong.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSongChanged(object sender, EventArgs e)
		{
			if (m_cmbSong.SelectedIndex > 0)
			{
				Song song = new Song();
				song = (Song) m_cmbSong.SelectedItem;

				if (song.ID != 0 && song.ArtistID != 0)
				{
					m_cmbArtist.Text = string.Empty;
					m_cmbArtist.Text = song.Artist;
				}
			}
		}
		#endregion

		#region private functions
		/// <summary>
		/// Fired when a single line is selected in ChartView
		/// </summary>
		/// <param name="chart">Chart</param>
		private void OnChartSelected(Chart chart)
		{
			m_txtPosition.Text = chart.Position.ToString();
			m_cmbSong.Text = chart.SongName;
			m_cmbArtist.Text = chart.ArtistName;
			m_oldChart = new Chart();
			m_oldChart = chart;
		}
		#endregion
	}
}
