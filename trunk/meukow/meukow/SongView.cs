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
	/// StudentListColumns skilgreinir annars vegar hva�a d�lkar eru
	/// � listanum, og hins vegar hversu margir d�lkar �eir eru. �etta enum
	/// �arf a� uppf�ra ef d�lkarnir breytast � design hlutanum.
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
		private SongDoc m_Song_document;
		private ArtistDoc m_Artist_document;
		private Artist m_Artist;
		#endregion

		#region Properties
		public SongDoc Document1
		{
			get { return m_Song_document; }
			set { m_Song_document = value; }
		}
		public ArtistDoc Document2
		{
			get { return m_Artist_document; }
			set { m_Artist_document = value; }
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
		/// OnLoad er keyrt � upphafi. Vi� notum �a� til �ess a� s�kja allar 
		/// f�rslur og birta � listanum.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnLoad(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				m_Song_document = new SongDoc();
				m_Artist_document = new ArtistDoc();
				m_Artist = new Artist();
				m_listViewSong.Items.Clear();
				SongCollection songs = Document1.GetAllSongs();
				foreach (Song song in songs)
				{
					m_Artist = m_Artist_document.GetArtist(song.ArtistID);
					m_listViewSong.Items.Add(GetListViewItem(song));
				}
			}
		}
		#endregion

		#region Protected functions
		/// <summary>
		/// Fall sem tekur inn tilvik af Song, og skilar til baka
		/// ListViewItem f�rslu sem t�knar �etta lag.
		/// </summary>
		/// <param name="song"></param>
		/// <returns></returns>
		private ListViewItem GetListViewItem(Song song)
		{	
			// Fyrsti d�lkurinn birtir nafn:
			ListViewItem item = new ListViewItem(song.Name);
			
			// Annar d�lkurinn birtir kennit�lu
			
			item.SubItems.Add(m_Artist.Name);
			item.SubItems.Add(song.SongPath);
			item.SubItems.Add(song.Description);

			// Allir nemendur f� sama icon � �etta skipti�:
			item.ImageIndex = 0;
			// en ImageList getur geymt margar myndir, og s�rhver f�rsla
			// getur haft mismunandi image index.

			// L�tum s�rhvert ListViewItem vita hva�a nemandi 
			// hangir vi� hverja f�rslu:
			item.Tag = song;

			// N�g � bili...
			return item;
		}

		/// <summary>
		/// HandleError s�r um a� birta villuskilabo� � 
		/// einhvern (mis)smekklega h�tt (m� sj�lfsagt laga...):
		/// </summary>
		/// <param name="ex"></param>
		protected static void HandleError(Exception ex)
		{
			// H�r m�tti �rugglega koma me� vinalegri villubo�:
			MessageBox.Show("Eftirfarandi villa kom upp: \n\n" + ex.Message);
		}

		#endregion
	}
}
