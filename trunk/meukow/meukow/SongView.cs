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
		/// OnLoad er keyrt � upphafi. Vi� notum �a� til �ess a� s�kja allar 
		/// f�rslur og birta � listanum.
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

						// Ef �etta klikkar ver�ur kasta� villu:
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
				// T�kkum � �v� hvort �a� s� ekki �rugglega einhver valinn:
				if (m_listViewSong.SelectedItems.Count == 1)
				{
					// ListView � ekkert SelectedItem property, en skilar
					// hinsvegar collection af v�ldum f�rslum, �v� s�
					// m�guleiki er fyrir hendi a� ListView s� MultiSelect.
					// Vi� erum samt ekki a� nota okkur MultiSelect � �essu
					// tilfelli (sj� properties fyrir ListView st�ringuna).
					ListViewItem listViewItem = m_listViewSong.SelectedItems[0];

					// �etta typecast er � lagi �v� GetListViewItem s�r alltaf
					// um a� setja Student tilvik inn � Tag property-i� � 
					// s�rhverju itemi:
					Song song = (Song)listViewItem.Tag;

					using (SongDlg dlg = new SongDlg())
					{
						dlg.song = song;

						if (dlg.ShowDialog() == DialogResult.OK)
						{
							// S�kjum g�gnin aftur �r samtalsglugganum:
							song = dlg.song;

							// L�tum vinnslulagi� uppf�ra nemandann. Ef �a�
							// mistekst er kasta� villu.
							Document.UpdateSong(song);
							//HressaLista();
							int nIndex = listViewItem.Index;
							// Vi� uppf�rum f�rsluna me� �v� a� fjarl�gja �� sem
							// er fyrir og setja n�ja inn:
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
					if (MessageBox.Show("Viltu �rugglega ey�a �essu lagi?", "Ey�a lagi",
						MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
					{
						ListViewItem listViewItem = m_listViewSong.SelectedItems[0];
						// Sama gildir h�r og � OnEditStudent.
						Song song = (Song)listViewItem.Tag;

						// H�r ver�ur kasta� villu ef �etta mistekst:
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
		/// ListViewItem f�rslu sem t�knar �etta lag.
		/// </summary>
		/// <param name="song"></param>
		/// <returns></returns>
		private ListViewItem GetListViewItem(Song song)
		{	
			// Fyrsti d�lkurinn birtir nafn:
			ListViewItem item = new ListViewItem(song.Name.ToString());

			// Annar d�lkurinn birtir kennit�lu:
			item.SubItems.Add(song.Artist.ToString());
			item.SubItems.Add(song.SongPath.ToString());
			item.SubItems.Add(song.Description.ToString());

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
		#endregion
		
		#region Protected functions
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
