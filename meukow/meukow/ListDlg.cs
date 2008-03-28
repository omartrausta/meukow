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
		private List m_list = null;
		private SongCollection m_songColleciton = null;
		private ArtistCollection m_artistCollection = null;

		public List List
		{
			get { return m_list; }
			set { m_list = value; }
		}

		public ListDlg()
		{
			InitializeComponent();
		}

        private void OnLoad(object sender, EventArgs e)
        {
            m_songColleciton = new SongCollection();
            SongDoc songDoc = new SongDoc();

            m_songColleciton = songDoc.GetAllSongs();

            m_cmbSong.DataSource = m_songColleciton;
        }
	}
}