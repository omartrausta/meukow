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
		private ArtistCollection m_artistCollection = new ArtistCollection();
		private Artist m_artist = new Artist();
		private Artist m_selectedArtist = new Artist();
		private ArtistDoc artistDoc = new ArtistDoc();
		private Song m_song = null;

		public Song song
		{
			get
			{
				m_song.Name = m_txtboxName.Text;
				m_song.ArtistID = m_selectedArtist.ID;
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
		
		public SongDlg()
		{
			InitializeComponent();
			HressaCombo();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			if (m_song.ID == 0)
			{
				m_btnOK.Text = "Skr�";
				this.Text = "Skr� Lag";
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

		private void OnCombo(object sender, EventArgs e)
		{
			m_selectedArtist = (Artist)m_cmbArtist.SelectedItem;
		}

	}
}