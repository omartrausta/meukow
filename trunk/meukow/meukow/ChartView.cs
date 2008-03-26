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
	public class ChartView : UserControl
	{
		#region Member variables
		private Chart m_chart;
		private ChartDoc m_chartDoc;
		public HitParadeView hitParadeView;	

		public ChartDoc Doc
		{
			get { return m_chartDoc; }
			set { m_chartDoc = value; }
		}



		#endregion

		#region Constructors
		public ChartView()
		{
			InitializeComponent();
		
		}
		#endregion

		#region Properties
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
						ListViewItem lvi = new ListViewItem(dr["Postition"].ToString());
						lvi.SubItems.Add(dr["Song_Name"].ToString());
						lvi.SubItems.Add(dr["Artist_Name"].ToString());

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
		private ListViewItem GetListViewItem(Chart list)
		{
			// Fyrsti dálkurinn birtir nafn:
			ListViewItem item = new ListViewItem(list.ChartPostion.ToString());

			// Annar dálkurinn birtir kennitölu:
			item.SubItems.Add(list.ChartSong.ToString());
			item.SubItems.Add(list.ChartArtist.ToString());

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
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_listViewChart = new System.Windows.Forms.ListView();
			this.m_colSaeti = new System.Windows.Forms.ColumnHeader();
			this.m_colLag = new System.Windows.Forms.ColumnHeader();
			this.m_colFlytjandi = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// m_listViewChart
			// 
			this.m_listViewChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			                                                                              	this.m_colSaeti,
			                                                                              	this.m_colLag,
			                                                                              	this.m_colFlytjandi});
			this.m_listViewChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_listViewChart.Location = new System.Drawing.Point(0, 0);
			this.m_listViewChart.Name = "m_listViewChart";
			this.m_listViewChart.Size = new System.Drawing.Size(328, 423);
			this.m_listViewChart.TabIndex = 0;
			this.m_listViewChart.UseCompatibleStateImageBehavior = false;
			this.m_listViewChart.View = System.Windows.Forms.View.Details;
			// 
			// m_colSaeti
			// 
			this.m_colSaeti.Text = "Sæti";
			// 
			// m_colLag
			// 
			this.m_colLag.Text = "Lag";
			// 
			// m_colFlytjandi
			// 
			this.m_colFlytjandi.Text = "Flytjandi";
			// 
			// ChartView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_listViewChart);
			this.Name = "ChartView";
			this.Size = new System.Drawing.Size(328, 423);
			//this.Load += new System.EventHandler(this.OnLoad);
			this.ResumeLayout(false);

		}

		#endregion

		public void OnHitParadeSelected(String strID)
		{
			OnUpdateChart(Convert.ToInt32(strID));
		}

		public System.Windows.Forms.ListView m_listViewChart;
		private System.Windows.Forms.ColumnHeader m_colSaeti;
		private System.Windows.Forms.ColumnHeader m_colLag;
		private System.Windows.Forms.ColumnHeader m_colFlytjandi;
	}
}
