using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// StudentListColumns skilgreinir annars vegar hvaða dálkar eru
	/// í listanum, og hins vegar hversu margir dálkar þeir eru. Þetta enum
	/// þarf að uppfæra ef dálkarnir breytast í design hlutanum.
	/// </summary>
	public enum SongColumns
	{
		ColName = 0,
		ColArtist = 1,
		ColSongpath = 2,
		ColDescription = 3,
		NumberOfColumns = 4
	}
	
	public partial class SongView : UserControl
	{
		#region Member variables
		private SortOrder[] m_arrLastSortOrder = new SortOrder[(int)ListColumns.NumberOfColumns];
		private SongDoc m_document;
		#endregion

		#region Properties
		public SongDoc Document
		{
			get { return m_document; }
			set { m_document = value; }
		}
		#endregion

		#region Constructors
		public SongView()
		{
			InitializeComponent();
		}
		#endregion

		#region Event handlers
		/// <summary>
		/// OnLoad er keyrt í upphafi. Við notum það til þess að sækja allar 
		/// færslur og birta í listanum.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnLoad(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				m_document = new SongDoc();
				m_listViewSong.Items.Clear();

				SongCollection songs = Document.GetAllSongs();

				foreach (Song song in songs)
				{
					m_listViewSong.Items.Add(GetListViewItem(song));
				}
			}
		}
		#endregion
		
		#region Protected functions
		/// <summary>
		/// Fall sem tekur inn tilvik af Song, og skilar til baka
		/// ListViewItem færslu sem táknar þetta lag.
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		private ListViewItem GetListViewItem(Song song)
		{	
			// Fyrsti dálkurinn birtir nafn:
			ListViewItem item = new ListViewItem(song.Name.ToString());

			// Annar dálkurinn birtir kennitölu:
			item.SubItems.Add(song.ArtistID.ToString());
			item.SubItems.Add(song.SongPath.ToString());
			item.SubItems.Add(song.Description.ToString());

			// Allir nemendur fá sama icon í þetta skiptið:
			item.ImageIndex = 0;
			// en ImageList getur geymt margar myndir, og sérhver færsla
			// getur haft mismunandi image index.

			// Látum sérhvert ListViewItem vita hvaða nemandi 
			// hangir við hverja færslu:
			item.Tag = Name;

			// Nóg í bili...
			return item;
		}

		/// <summary>
		/// HandleError sér um að birta villuskilaboð á 
		/// einhvern (mis)smekklega hátt (má sjálfsagt laga...):
		/// </summary>
		/// <param name="ex"></param>
		protected static void HandleError(Exception ex)
		{
			// Hér mætti örugglega koma með vinalegri villuboð:
			MessageBox.Show("Eftirfarandi villa kom upp: \n\n" + ex.Message);
		}

		#endregion
	}
}
