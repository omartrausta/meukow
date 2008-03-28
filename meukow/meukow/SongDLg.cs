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
		public SongDlg()
		{
			InitializeComponent();
		}

		private Song m_song;

		//TODO fylla combobox með nöfnum laga og grípa ID lags 
		public Song song
		{
			get
			{
				return m_song;
			}
			set
			{
				m_song = value;
			}
		}
	}
}