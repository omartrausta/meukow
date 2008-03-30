using System;
using System.Windows.Forms;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// Public enum that includes the name of the columns in the view and
	/// also how many columns are in the view
	/// </summary>
	#region Enum
	public enum SongColumns
	{
		ColName = 0,
		ColArtist = 1,
		ColSongpath = 2,
		ColDescription = 3,
		NumberOfColumns = 4
	}
	#endregion

	public partial class SongView : UserControl
	{
		#region Member variables
		private SortOrder[] m_arrLastSortOrder = new SortOrder[(int)SongColumns.NumberOfColumns];
		private SongDoc m_document;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the SongDoc document
		/// </summary>
		public SongDoc Document
		{
			get
			{
				return m_document;
			}
			set
			{
				m_document = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public SongView()
		{
			InitializeComponent();
		}
		#endregion

		#region Event handlers
		/// <summary>
		/// OnLoad is run when the view is loaded and the view is populated
		/// with data.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void OnLoad(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				UpdateSongView();
			}
		}

		/// <summary>
		/// Catches when the user wants to sort the view.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSortList(object sender, ColumnClickEventArgs e)
		{
			SortOrder lastOrder = m_arrLastSortOrder[e.Column];
			m_arrLastSortOrder[e.Column] = (lastOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
			m_listViewSong.ListViewItemSorter = new SongSorter((SongColumns)e.Column, lastOrder);
		}

		/// <summary>
		/// OnMenuNewSong when add is selected from context menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuNewSong(object sender, EventArgs e)
		{
			OnNewSong();
		}

		/// <summary>
		/// OnMenuEditSong when edit is selected from context menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuEditSong(object sender, EventArgs e)
		{
			OnEditSong();
		}

		/// <summary>
		/// OnMenuDeleteSong when delete is selected from context menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuDeleteSong(object sender, EventArgs e)
		{
			OnDeleteSong();
		}
		#endregion

		#region Public functions
		/// <summary>
		/// Updates the view.
		/// </summary>
		public void UpdateSongView()
		{
			Invalidate();
			m_document = new SongDoc();
			m_listViewSong.Items.Clear();

			SongCollection songs = Document.GetAllSongs();

			foreach (Song song in songs)
			{
				m_listViewSong.Items.Add(GetListViewItem(song));
			}
			SortOrder lastOrder = m_arrLastSortOrder[0];
			m_arrLastSortOrder[0] = SortOrder.Ascending;
			m_listViewSong.ListViewItemSorter = new SongSorter((SongColumns)0, lastOrder);

		}

		/// <summary>
		/// OnNewSong adds a new song to the database.
		/// </summary>
		public void OnNewSong()
		{
			try
			{
				using (SongDlg dlg = new SongDlg())
				{
					dlg.song = new Song();
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						Song song = dlg.song;
						Document.AddSong(song);
						m_listViewSong.Items.Add(GetListViewItem(song));
					}
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		/// <summary>
		/// OnEditSong is used to change one row in the list.
		/// This function doesn't do anything if nothing is selected.
		/// </summary>
		public void OnEditSong()
		{
			try
			{
				if (m_listViewSong.SelectedItems.Count == 1)
				{
					ListViewItem listViewItem = m_listViewSong.SelectedItems[0];
					Song song = (Song)listViewItem.Tag;

					using (SongDlg dlg = new SongDlg())
					{
						dlg.song = song;

						if (dlg.ShowDialog() == DialogResult.OK)
						{
							song = dlg.song;
							Document.UpdateSong(song);
							int nIndex = listViewItem.Index;
							m_listViewSong.Items.Remove(listViewItem);
							m_listViewSong.Items.Insert(nIndex, GetListViewItem(song));
						}
					}
				}
				else
				{
					MessageBox.Show("Vinsamlegast veldu lag til að breyta.");
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		/// <summary>
		/// OnDeleteSong deletes the selected song.
		/// </summary>
		public void OnDeleteSong()
		{
			try
			{
				if (m_listViewSong.SelectedItems.Count == 1)
				{
					if (MessageBox.Show("Viltu örugglega eyða þessu lagi?", "Eyða lagi",
						MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
					{
						ListViewItem listViewItem = m_listViewSong.SelectedItems[0];
						Song song = (Song)listViewItem.Tag;

						Document.DeleteSong(song);
						m_listViewSong.Items.Remove(listViewItem);
					}
				}
				else
				{
					MessageBox.Show("Vinsamlegast veldu lag til að eyða.");
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}
		#endregion

		#region Protected functions
		/// <summary>
		/// Function that add an instance of Song into a ListViewItem.
		/// </summary>
		/// <param name="song">Song</param>
		/// <returns>ListViewItem</returns>
		protected ListViewItem GetListViewItem(Song song)
		{
			// Fyrsti dálkurinn birtir nafn:
			ListViewItem item = new ListViewItem(song.Name.ToString());

			// Annar dálkurinn birtir kennitölu:
			item.SubItems.Add(song.Artist.ToString());
			item.SubItems.Add(song.SongPath.ToString());
			item.SubItems.Add(song.Description.ToString());

			// Allir nemendur fá sama icon í þetta skiptið:
			item.ImageIndex = 0;
			// en ImageList getur geymt margar myndir, og sérhver færsla
			// getur haft mismunandi image index.

			// Látum sérhvert ListViewItem vita hvaða nemandi 
			// hangir við hverja færslu:
			item.Tag = song;

			// Nóg í bili...
			return item;
		}

		/// <summary>
		/// Shows error message.
		/// </summary>
		/// <param name="ex">Exception</param>
		protected static void HandleError(Exception ex)
		{
			MessageBox.Show("Eftirfarandi villa kom upp: \n\n" + ex.Message);
		}
		#endregion
	}
}
