using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
		private bool m_bIsNewSong;
		private bool m_bIsNewArtist;
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
                        m_song.SongPath = String.Empty;
                        m_song.Description = String.Empty;
                        m_songDoc.AddSong(m_song);
												m_bIsNewSong = true;
                    }

                    int dsPosition = 0;
                    int dsSongID = 0;
                    int dsArtistID = 0;

                    ChartDoc chartDoc = new ChartDoc();
                    DataSet ds = chartDoc.GetChartList(m_list.ID);

                    DataTable dv = ds.Tables[0];

                    for (int i = 0; i < dv.Rows.Count; i++)
                    {
                        DataRow dr = dv.Rows[i];

                        if (dr.RowState != DataRowState.Deleted)
                        {
                            dsPosition = Convert.ToInt32(dr["Position"]);
                            dsArtistID = Convert.ToInt32(dr["ArtistID"]);
                            dsSongID = Convert.ToInt32(dr["SongID"]);

                            if (dsPosition.Equals(position))
                            {
                                MessageBox.Show("Ekki er leyfilegt að skrá sama sætið oftar en 1 sinni.");
                                break;
                            }

                            if (dsSongID.Equals(m_song.ID) && dsArtistID.Equals(m_artist.ID))
                            {
                                MessageBox.Show("Sama lag með sama flytjanda má ekki vera skráð oftar en 1 sinni.");
                            }
                        }
                    }

                    ListProp listProp = new ListProp();
                    ListPropDoc listPropDoc = new ListPropDoc();

                    listProp.List = m_list.ID;
                    listProp.Position = position;
                    listProp.Song = m_song.ID;

                    listPropDoc.AddListProp(listProp);

                    m_chartView.OnUpdateChart( m_list.ID );

                    m_txtPosition.Text = (position + 1).ToString();
                }
            }
        }

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

		#region Public functions
		/// <summary>
		/// Fired when a single line is selected in ChartView
		/// </summary>
		/// <param name="chart">Chart</param>
		public void OnChartSelected(Chart chart)
		{
			m_txtPosition.Text = chart.Position.ToString();
			m_cmbArtist.Text = chart.ArtistName;
			m_cmbSong.Text = chart.SongName;
		}
		#endregion
	}
}