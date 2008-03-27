using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Diagnostics;

namespace meukow
{
	/// <summary>
	/// StudentListColumns skilgreinir annars vegar hva�a d�lkar eru
	/// � listanum, og hins vegar hversu margir d�lkar �eir eru. �etta enum
	/// �arf a� uppf�ra ef d�lkarnir breytast � design hlutanum.
	/// </summary>
	public enum ListColumns
	{
		ColName = 0,
		ColStarts = 1,
		ColEnds = 2,
		NumberOfColumns = 3
	}

	partial class HitParadeView : UserControl
	{
		#region Member variables
		private SortOrder[] m_arrLastSortOrder = new SortOrder[(int)ListColumns.NumberOfColumns];
		private ListDoc m_document;
		#endregion

		#region Event Handlers
		public delegate void HitParadeHandler(string msg);
		public event HitParadeHandler HitParadeSelected;
		#endregion

		#region Properties
		public ListDoc Document
		{
			get { return m_document; }
			set { m_document = value; }
		}
		#endregion

		#region Constructors
		public HitParadeView()
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
		private void OnLoad(object sender, EventArgs e)
		{
			if (!this.DesignMode)
			{
				m_document = new ListDoc();
				m_listViewHitParade.Items.Clear();

				ListCollection students = Document.GetAllList();

				foreach (List list in students)
				{
					m_listViewHitParade.Items.Add(GetListViewItem(list));
				}
			}
		}

		// TODO Skjala �etta fall
		private void OnSortList(object sender, ColumnClickEventArgs e)
		{
			SortOrder lastOrder = m_arrLastSortOrder[e.Column];
			m_arrLastSortOrder[e.Column] = (lastOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
			m_listViewHitParade.ListViewItemSorter = new ListSorter((ListColumns)e.Column, lastOrder);
		}

		private void OnClick(object sender, EventArgs e)
		{
			if (HitParadeSelected != null)
			{
				String nID = OnSelectList();
				if (nID != null)
				{
					HitParadeSelected(nID);
				}
			}
		}
		#endregion

		#region Protected functions
		/// <summary>
		/// Fall sem tekur inn tilvik af List, og skilar til baka
		/// ListViewItem f�rslu sem t�knar �ennan lista.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		private ListViewItem GetListViewItem(List list)
		{
			// Fyrsti d�lkurinn birtir nafn:
			ListViewItem item = new ListViewItem(list.Name);

			// Annar d�lkurinn birtir kennit�lu:
			item.SubItems.Add(list.Starts.ToString().Replace(" 00:00:00",""));
			item.SubItems.Add(list.Ends.ToString().Replace(" 00:00:00", ""));
			item.SubItems.Add(list.WeekList.ToString());

			// Allir nemendur f� sama icon � �etta skipti�:
			item.ImageIndex = 0;
			// en ImageList getur geymt margar myndir, og s�rhver f�rsla
			// getur haft mismunandi image index.

			// L�tum s�rhvert ListViewItem vita hva�a nemandi 
			// hangir vi� hverja f�rslu:
			item.Tag = list;

			// N�g � bili...
			return item;
		}

		/// <summary>
		/// HandleError s�r um a� birta villuskilabo� � 
		/// einhvern (mis)smekklega h�tt (m� sj�lfsagt laga...):
		/// </summary>
		/// <param name="ex"></param>
		protected void HandleError(Exception ex)
		{
			// H�r m�tti �rugglega koma me� vinalegri villubo�:
			MessageBox.Show("Eftirfarandi villa kom upp: \n\n" + ex.Message);
		}

		protected String OnSelectList()
		{
			if (m_listViewHitParade.SelectedItems.Count == 1)
			{
				ListViewItem listViewItem = m_listViewHitParade.SelectedItems[0];

				// �etta typecast er � lagi �v� GetListViewItem s�r alltaf
				// um a� setja Student tilvik inn � Tag property-i� � 
				// s�rhverju itemi:
				List list = (List)listViewItem.Tag;

				return list.ID.ToString();
			}
			else
				return null;
		}
		#endregion

		#region Public functions
		public void OnUpdateChart()
		{
			if (m_listViewHitParade.SelectedItems.Count == 1)
			{
				ListViewItem listViewItem = m_listViewHitParade.SelectedItems[0];
				int ID = Convert.ToInt32(listViewItem.Index);
			}
		}
		#endregion
	}
}
