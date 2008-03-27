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
		private Song m_song = null;
		private Artist m_artist = null;

		public List List
		{
			get { return m_list; }
			set { m_list = value; }
		}

		public ListDlg()
		{
			InitializeComponent();
		}
	}
}