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
	public enum ChartColumns
	{
		ColPosition = 0,
		ColSong = 1,
		ColArtist = 2,
		NumberOfColumns = 3
	}
	#endregion
	partial class ChartView : UserControl
	{
		#region Member variables
		private readonly SortOrder[] m_arrLastSortOrder = new SortOrder[(int)ChartColumns.NumberOfColumns];
		private Chart m_chart;
		private ChartDoc m_chartDoc;
		#endregion

		#region Events and delegates
		public delegate void ChartHandler(Chart chart);
		public event ChartHandler ChartSelected;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public ChartView()
		{
			InitializeComponent();
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets og sets the ChartDoc document.
		/// </summary>
		public ChartDoc Doc
		{
			get
			{
				return m_chartDoc;
			}
			set
			{
				m_chartDoc = value;
			}
		}

		/// <summary>
		/// Gets or sets the Chart
		/// </summary>
		public Chart Chart
		{
			get
			{
				return m_chart;
			}
			set
			{
				m_chart = value;
			}
		}
		#endregion

		#region Public functions
		/// <summary>
		/// Event that is fired to update the chart.
		/// </summary>
		/// <param name="ID">Int ID</param>
		public void OnUpdateChart(int ID)
		{
			if (!this.DesignMode)
			{
				m_chartDoc = new ChartDoc();
				m_listViewChart.Items.Clear();

				ChartCollection charts = Doc.GetChartCollection(ID);

				foreach (Chart chart in charts)
				{
					m_listViewChart.Items.Add(GetListViewItem(chart));
				}
			}
		}

		/// <summary>
		/// Fired when a single list is selected in HitParadeView
		/// </summary>
		/// <param name="strID">String ID</param>
		public void OnHitParadeSelected(String strID)
		{
			OnUpdateChart(Convert.ToInt32(strID));
		}

		/// <summary>
		/// OnEditArtist is used to change one row in the list.
		/// This function doesn't do anything if nothing is selected.
		/// </summary>
		public void OnEditChart()
		{
			try
			{
				if (m_listViewChart.SelectedItems.Count == 1)
				{
					ListViewItem listViewItem = m_listViewChart.SelectedItems[0];
					Chart chart = (Chart)listViewItem.Tag;

					if (ChartSelected != null)
					{
						if (chart != null)
						{
							ChartSelected(chart);
						}
					}
				}
				else
				{
					MessageBox.Show("Vinsamlegast veldu flytjanda til að breyta.");
				}

			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}

		/// <summary>
		/// OnDeleteChart deletes the selected item in chart.
		/// </summary>
		public void OnDeleteChart()
		{
			try
			{
				if (m_listViewChart.SelectedItems.Count == 1)
				{
					if (MessageBox.Show("Ertu viss um að þú viljir eyða þessu sæti?", "DeleteArtist",
					MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
					{
						ListViewItem listViewItem = m_listViewChart.SelectedItems[0];
						Chart chart = (Chart)listViewItem.Tag;
						ChartDoc doc = new ChartDoc();
						doc.DeleteChart(chart);
						m_listViewChart.Items.Remove(listViewItem);
					}
				}
				else
				{
					MessageBox.Show("Vinsamlegast veldu sæti til að eyða.");
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
			}
		}
		#endregion

		#region Event Handlers
		private void OnEditChart(object sender, EventArgs e)
		{
			OnEditChart();
		}

		private void OnDeleteChart(object sender, EventArgs e)
		{
			OnDeleteChart();
		}
		#endregion

		#region Protected functions
		/// <summary>
		/// Function that add an instance of Chart into a ListViewItem.
		/// </summary>
		/// <param name="list">Chart</param>
		/// <returns>ListViewItem</returns>
		protected static ListViewItem GetListViewItem(Chart list)
		{
			ListViewItem item = new ListViewItem(list.Position.ToString());

			item.SubItems.Add(list.SongName.ToString());
			item.SubItems.Add(list.ArtistName.ToString());

			item.ImageIndex = 0;
			item.Tag = list;

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

		/// <summary>
		/// Catches when the user wants to sort the view.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSortChart(object sender, ColumnClickEventArgs e)
		{
			SortOrder lastOrder = m_arrLastSortOrder[e.Column];
			m_arrLastSortOrder[e.Column] = (lastOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
			m_listViewChart.ListViewItemSorter = new ChartSorter((ChartColumns)e.Column, lastOrder);

		}
	}
}
