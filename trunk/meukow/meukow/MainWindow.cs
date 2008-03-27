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

		
	}
}