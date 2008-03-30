using System;
using System.Windows.Forms;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// Public enum that includes the name of the columns in the view and
	/// also how many columns are in the view
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
		private bool m_bIsNewSong;
		private bool m_bIsNewArtist;
		#endregion

		#region Events and delegates
		public delegate void HitParadeHandler(string msg);
		public event HitParadeHandler HitParadeSelected;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ListDoc document.
		/// </summary>
		public ListDoc Document
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

		/// <summary>
		/// Gets wether a new song was created.
		/// </summary>
		public bool IsNewSong
		{
			get
			{
				return m_bIsNewSong;
			}
			set
			{
				m_bIsNewSong = value;
			}
		}

		/// <summary>
		/// Gets wether a new artist was created.
		/// </summary>
		public bool IsNewArtist
		{
			get
			{
				return m_bIsNewArtist;
			}
			set
			{
				m_bIsNewArtist = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public HitParadeView()
		{
			InitializeComponent();
		}
		#endregion

		#region Event handlers
		/// <summary>
		/// Is fired when the view is loaded
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

		/// <summary>
		/// Catches when the user wants to sort the view.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSortList(object sender, ColumnClickEventArgs e)
		{
			SortOrder lastOrder = m_arrLastSortOrder[e.Column];
			m_arrLastSortOrder[e.Column] = (lastOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
			m_listViewHitParade.ListViewItemSorter = new ListSorter((ListColumns)e.Column, lastOrder);
		}

		/// <summary>
		/// Fired when the user select a single line in the view.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// OnMenuEditList when the edit is selected from context menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuEditList(object sender, EventArgs e)
		{
			OnEditList();
		}

		/// <summary>
		/// OnMenuCreateList when the add is selected from context menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuCreateList(object sender, EventArgs e)
		{
			OnNewList();
		}

		/// <summary>
		/// OnMenuDeleteList when the delete is selected from context menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuDeleteList(object sender, EventArgs e)
		{
			OnDeleteList();
		}
		#endregion

		#region Protected functions
		/// <summary>
		/// Function that add an instance of List into a ListViewItem.
		/// </summary>
		/// <param name="list">List</param>
		/// <returns>ListViewItem</returns>
		private ListViewItem GetListViewItem(List list)
		{
			ListViewItem item = new ListViewItem(list.Name);

			item.SubItems.Add(list.Starts.ToString().Replace(" 00:00:00",""));
			item.SubItems.Add(list.Ends.ToString().Replace(" 00:00:00", ""));
			item.SubItems.Add(list.WeekList.ToString());

			item.ImageIndex = 0;
			item.Tag = list;

			return item;
		}

		/// <summary>
		/// Shows error message.
		/// </summary>
		/// <param name="ex">Exception</param>
		protected void HandleError(Exception ex)
		{
			MessageBox.Show("Eftirfarandi villa kom upp: \n\n" + ex.Message);
		}

		/// <summary>
		/// Update the ChartView
		/// </summary>
		/// <returns></returns>
		protected String OnSelectList()
		{
			if (m_listViewHitParade.SelectedItems.Count == 1)
			{
				ListViewItem listViewItem = m_listViewHitParade.SelectedItems[0];

				List list = (List)listViewItem.Tag;

				return list.ID.ToString();
			}
			else
				return null;
		}
		#endregion

		#region Public functions
		/// <summary>
		/// Updates ChartView.
		/// </summary>
		public void OnUpdateChart()
		{
			if (m_listViewHitParade.SelectedItems.Count == 1)
			{
				ListViewItem listViewItem = m_listViewHitParade.SelectedItems[0];
				int ID = Convert.ToInt32(listViewItem.Index);
			}
		}

		/// <summary>
		/// OnEditList updates selected list to the database.
		/// </summary>
		public void OnEditList()
		{
			try
			{
				if ( m_listViewHitParade.SelectedItems.Count == 1 )
				{
					ListViewItem listViewItem = m_listViewHitParade.SelectedItems[ 0 ];

					List list = (List)listViewItem.Tag;

					using ( ListDlg dlg = new ListDlg( ) )
					{
						dlg.List = list;

						if ( dlg.ShowDialog( ) == DialogResult.OK )
						{
							list = dlg.List;
							Document.UpdateList( list );

							int nIndex = listViewItem.Index;
							m_listViewHitParade.Items.Remove( listViewItem );
							m_listViewHitParade.Items.Insert( nIndex, GetListViewItem( list ) );
						}
					}
				}
				else
				{
					MessageBox.Show("Vinsamlegast veldu vinsældarlista til að breyta.");
				}
			}
			catch ( Exception ex )
			{
				HandleError( ex );
			}
		}

		/// <summary>
		/// OnNewList adds a new list to the database.
		/// </summary>
		public void OnNewList()
		{
			try
			{
				using( ListDlg dlg = new ListDlg())
				{
					dlg.List = new List();
					String result = dlg.ShowDialog().ToString();
					if (result == "OK")
					{
						m_listViewHitParade.Items.Add( GetListViewItem( dlg.List ) );
						m_bIsNewSong = dlg.IsNewSong;
						m_bIsNewArtist = dlg.IsNewArtist;
						Invalidate();
					}
					else if( result == "Cancel")
					{
						if (dlg.List.ID != 0)
						{
							ListDoc listDoc = new ListDoc();
							ListPropDoc listPropDoc = new ListPropDoc();
							ListPropCollection collection = new ListPropCollection();

							listDoc.DeleteList(dlg.List);

							collection = listPropDoc.GetListPropByList(dlg.List.ID);
							if (collection.Count > 0)
							{
								ListProp listProp = new ListProp();
								listProp = listPropDoc.GetListProp(collection[0].ID);
								listPropDoc.DeleteListProp(listProp);
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				HandleError(ex);
			}
		}

		/// <summary>
		/// OnDeleteList deletes the selected list.
		/// </summary>
		public void OnDeleteList()
		{
			try
			{
				if (m_listViewHitParade.SelectedItems.Count == 1)
				{
					if (MessageBox.Show("Viltu örugglega eyða þessum lista?", "DeleteList",
					MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
					{
						ListViewItem listViewItem = m_listViewHitParade.SelectedItems[0];
						List list = (List)listViewItem.Tag;

						Document.DeleteList(list);
						m_listViewHitParade.Items.Remove(listViewItem);
					}
				}
				else
				{
					MessageBox.Show("Vinsamlegast veldu vinsældarlista til að eyða.");
				}

			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}
		#endregion
	}
}
