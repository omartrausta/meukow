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
				HressaLista();
			}
		}
		#endregion

		#region Public functions

		public void HressaLista()
		{
			Invalidate();
			m_document = new SongDoc();
			m_listViewSong.Items.Clear();

			SongCollection songs = Document.GetAllSongs();

			foreach (Song song in songs)
			{
				m_listViewSong.Items.Add(GetListViewItem(song));
			}	
		}
		
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

						// Ef þetta klikkar verður kastað villu:
						Document.AddSong(song);
						//HressaLista();
						m_listViewSong.Items.Add(GetListViewItem(song));
					}
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		public void OnUpdateSong()
		{
			try
			{
				// Tékkum á því hvort það sé ekki örugglega einhver valinn:
				if (m_listViewSong.SelectedItems.Count == 1)
				{
					// ListView á ekkert SelectedItem property, en skilar
					// hinsvegar collection af völdum færslum, því sá
					// möguleiki er fyrir hendi að ListView sé MultiSelect.
					// Við erum samt ekki að nota okkur MultiSelect í þessu
					// tilfelli (sjá properties fyrir ListView stýringuna).
					ListViewItem listViewItem = m_listViewSong.SelectedItems[0];

					// Þetta typecast er í lagi því GetListViewItem sér alltaf
					// um að setja Student tilvik inn í Tag property-ið á 
					// sérhverju itemi:
					Song song = (Song)listViewItem.Tag;

					using (SongDlg dlg = new SongDlg())
					{
						dlg.song = song;

						if (dlg.ShowDialog() == DialogResult.OK)
						{
							// Sækjum gögnin aftur úr samtalsglugganum:
							song = dlg.song;

							// Látum vinnslulagið uppfæra nemandann. Ef það
							// mistekst er kastað villu.
							Document.UpdateSong(song);
							//HressaLista();
							int nIndex = listViewItem.Index;
							// Við uppfærum færsluna með því að fjarlægja þá sem
							// er fyrir og setja nýja inn:
							m_listViewSong.Items.Remove(listViewItem);
							m_listViewSong.Items.Insert(nIndex, GetListViewItem(song));
						}
					}
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

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
						// Sama gildir hér og í OnEditStudent.
						Song song = (Song)listViewItem.Tag;

						// Hér verður kastað villu ef þetta mistekst:
						Document.DeleteSong(song);
						m_listViewSong.Items.Remove(listViewItem);
					}
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		#endregion

		#region Private functions
		private void OnSortList(object sender, ColumnClickEventArgs e)
		{
			SortOrder lastOrder = m_arrLastSortOrder[e.Column];
			m_arrLastSortOrder[e.Column] = (lastOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
			m_listViewSong.ListViewItemSorter = new SongSorter((SongColumns)e.Column, lastOrder);
		}

		/// <summary>
		/// Fall sem tekur inn tilvik af Song, og skilar til baka
		/// ListViewItem færslu sem táknar þetta lag.
		/// </summary>
		/// <param name="song"></param>
		/// <returns></returns>
		private ListViewItem GetListViewItem(Song song)
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
		#endregion
		
		#region Protected functions
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
