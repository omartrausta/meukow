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

		//private void OnParadeClick(object sender, EventArgs e)
		//{
		//    m_HitParadeView.OnUpdateChart();
		
		//}

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
            artistView1.OnUpdateArtist();
        }

       

        private void OnLeave(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Ertu hættur? Á kannski bara að fara í Bubbles");
        }

		private void OntSbtnSong(object sender, EventArgs e)
		{
			m_SongView.OnNewSong();
		}

		
	}
}
