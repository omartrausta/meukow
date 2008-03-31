using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using ClassLibrary.Common.Data;

namespace meukow
{
	partial class MainWindow : Form
	{
		private ArtistView artistView1;
		private SongView m_SongView;
		private HitParadeView m_HitParadeView;
		private ChartView m_chartView;
        
		public MainWindow()
		{
			InitializeComponent();

			m_HitParadeView.HitParadeSelected += new HitParadeView.HitParadeHandler(m_chartView.OnHitParadeSelected);
		}

		private void m_tSbtnSkodavinlistar_Click(object sender, EventArgs e)
		{
			m_HitParadeView.OnUpdateChart();
		}

        private void OnNewArtist(object sender, EventArgs e)
        {
           artistView1.OnNewArtist();
        }

        private void OnNewHitParade(object sender, EventArgs e)
        {
            m_HitParadeView.OnNewList();
        }

        private void OnEditHitParade(object sender, EventArgs e)
        {
            m_HitParadeView.OnEditList();
        }

        private void OnDeleteHitParade(object sender, EventArgs e)
        {
            m_HitParadeView.OnDeleteList();
        }

        private void OnMenuDeleteArtist(object sender, EventArgs e)
        {
            artistView1.OnDeleteArtist();
        }

        private void OnMenuEditArtist(object sender, EventArgs e)
        {
            artistView1.OnEditArtist();
        }

       

        private void OnLeave(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Ertu hættur? Á kannski bara að fara í Bubbles");
        }

		private void OntSbtnSkraSong(object sender, EventArgs e)
		{
			m_SongView.OnNewSong();
		}

		private void OntSbtnBreytaSong(object sender, EventArgs e)
		{
			m_SongView.OnEditSong();
		}

		private void OntSbtnEydaSong(object sender, EventArgs e)
		{
			m_SongView.OnDeleteSong();
		}

		private void OnTabControlClick(object sender, EventArgs e)
		{
			if( m_TabControl.SelectedIndex == 1 && m_HitParadeView.IsNewSong == true )
			{
				m_SongView.UpdateSongView();
			}

			if (m_TabControl.SelectedIndex == 2 && m_HitParadeView.IsNewArtist == true)
			{
			  artistView1.UpdateArtistView();
			}
		}

		private void OnQuitClick(object sender, EventArgs e)
		{
			String s = MessageBox.Show("Viltu örugglega hætta?", "Hætta", MessageBoxButtons.YesNo).ToString();
			if (s == "Yes")
			{
				this.Close();
			}
		}

		private void OnAboutClick(object sender, EventArgs e)
		{
			using( AboutDlg dlg = new AboutDlg())
			{
				dlg.ShowDialog();
			}
		}
	}
}
