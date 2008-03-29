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
	partial class ChartView : UserControl
	{
		#region Member variables
		private Chart m_chart;
		private ChartDoc m_chartDoc;
		#endregion

		#region Constructors
		public ChartView()
		{
			InitializeComponent();
		
		}
		#endregion

		#region Properties
		public ChartDoc Doc
		{
			get { return m_chartDoc; }
			set { m_chartDoc = value; }
		}

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

		#region Event handlers
		public void OnUpdateChart(int ID)
		{
			if (!this.DesignMode)
			{
				m_chartDoc = new ChartDoc();
				m_listViewChart.Items.Clear();

				//Chart.ChartCollection charts = Doc.GetAllList();




				DataSet ds = m_chartDoc.GetChartList(ID);
				DataTable dv = ds.Tables[0];

				for (int i = 0; i < dv.Rows.Count; i++)
				{
					DataRow dr = dv.Rows[i];

					if (dr.RowState != DataRowState.Deleted)
					{
						ListViewItem lvi = new ListViewItem(dr["Position"].ToString());
						lvi.SubItems.Add(dr["SongName"].ToString());
						lvi.SubItems.Add(dr["ArtistName"].ToString());

						m_listViewChart.Items.Add(lvi);
					}

					
				}



				//foreach (DataRow row in dv.Rows)
				//{
				//    m_listViewChart.Items.Add(row.ToString());
				//}
				//m_listViewChart.Items.Add();
				
			}
		}

		public void OnHitParadeSelected(String strID)
		{
			OnUpdateChart(Convert.ToInt32(strID));
		}
		#endregion

		#region Protected functions
		protected ListViewItem GetListViewItem(Chart list)
		{
			// Fyrsti d�lkurinn birtir nafn:
			ListViewItem item = new ListViewItem(list.Position.ToString());

			// Annar d�lkurinn birtir kennit�lu:
			item.SubItems.Add(list.SongName.ToString());
			item.SubItems.Add(list.ArtistName.ToString());

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
		#endregion
	}
}
