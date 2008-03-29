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
	public partial class SongDlg : Form
	{
		private ArtistCollection m_artistCollection = null;
		private Artist m_artist = null;
		private Song m_song = null;

		//TODO fylla combobox með nöfnum laga og grípa ID lags 
		public Song song
		{
			get
			{
				m_song.Name = m_txtboxName.Text;
				m_song.ArtistID = m_artist.ID;
				m_song.SongPath = m_txtboxSongpath.Text;
				m_song.Description = m_txtboxDescription.Text;
				return m_song;
			}
			set
			{
				m_song = value;
				m_txtboxName.Text = m_song.Name;
				m_artist.ID = m_song.ArtistID;
				m_cmbArtist.Text = m_song.Artist;
				m_txtboxSongpath.Text = m_song.SongPath;
				m_txtboxDescription.Text = m_song.Description;
			}
		}
		
		public SongDlg()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			m_artist = new Artist();
			m_artistCollection = new ArtistCollection();
			ArtistDoc artistDoc = new ArtistDoc();

			m_artistCollection = artistDoc.GetAllArtists();
			m_cmbArtist.DataSource = m_artistCollection;

			m_artist = (Artist) m_cmbArtist.SelectedItem;
		}
	}
}