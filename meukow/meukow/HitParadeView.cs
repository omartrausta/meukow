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
	/// StudentListColumns skilgreinir annars vegar hvaða dálkar eru
	/// í listanum, og hins vegar hversu margir dálkar þeir eru. Þetta enum
	/// þarf að uppfæra ef dálkarnir breytast í design hlutanum.
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
		/// OnLoad er keyrt í upphafi. Við notum það til þess að sækja allar 
		/// færslur og birta í listanum.
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

		// TODO Skjala þetta fall
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
		/// ListViewItem færslu sem táknar þennan lista.
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		private ListViewItem GetListViewItem(List list)
		{
			// Fyrsti dálkurinn birtir nafn:
			ListViewItem item = new ListViewItem(list.Name);

			// Annar dálkurinn birtir kennitölu:
			item.SubItems.Add(list.Starts.ToString().Replace(" 00:00:00",""));
			item.SubItems.Add(list.Ends.ToString().Replace(" 00:00:00", ""));
			item.SubItems.Add(list.WeekList.ToString());

			// Allir nemendur fá sama icon í þetta skiptið:
			item.ImageIndex = 0;
			// en ImageList getur geymt margar myndir, og sérhver færsla
			// getur haft mismunandi image index.

			// Látum sérhvert ListViewItem vita hvaða nemandi 
			// hangir við hverja færslu:
			item.Tag = list;

			// Nóg í bili...
			return item;
		}

		/// <summary>
		/// HandleError sér um að birta villuskilaboð á 
		/// einhvern (mis)smekklega hátt (má sjálfsagt laga...):
		/// </summary>
		/// <param name="ex"></param>
		protected void HandleError(Exception ex)
		{
			// Hér mætti örugglega koma með vinalegri villuboð:
			MessageBox.Show("Eftirfarandi villa kom upp: \n\n" + ex.Message);
		}

		protected String OnSelectList()
		{
			if (m_listViewHitParade.SelectedItems.Count == 1)
			{
				ListViewItem listViewItem = m_listViewHitParade.SelectedItems[0];

				// Þetta typecast er í lagi því GetListViewItem sér alltaf
				// um að setja Student tilvik inn í Tag property-ið á 
				// sérhverju itemi:
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
