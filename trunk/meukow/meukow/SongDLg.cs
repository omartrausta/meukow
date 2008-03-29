using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Collections;

namespace meukow
{
	public partial class SongDlg : Form
	{
		#region Member variables

		private const String FILE_DIALOG_FILTER = "Mp3 lag (*.mp3)|*.MP3";
		private ArtistCollection m_artistCollection = new ArtistCollection();
		private Artist m_artist = new Artist();
		private ArtistDoc artistDoc = new ArtistDoc();
		private Song m_song = null;
		private String m_fileName;

		#endregion

		#region Properties

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

		public SongDlg()
		{
			InitializeComponent();
			HressaCombo();
		}

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

		private void HressaCombo()
		{
			m_artistCollection = artistDoc.GetAllArtists();
			m_cmbArtist.DataSource = m_artistCollection;
		}

		private void btnBrowseClick(object sender, EventArgs e)
		{    
			// OpenFileDialog tilvik búið til
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Skrártegundir síaðar út eftir fasta
            openFileDialog.Filter = FILE_DIALOG_FILTER;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Skráarnafnið vistað sem strengur í memberbreytu    
             Filename = openFileDialog.FileName;
                // Skrárnafnið sett í textaboxið
                m_txtboxSongpath.Text = Filename;
            }
		}
	}
}