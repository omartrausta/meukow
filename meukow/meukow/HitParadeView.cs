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

	public class HitParadeView : UserControl
	{
		#region Member variables
		private SortOrder[] m_arrLastSortOrder = new SortOrder[(int)ListColumns.NumberOfColumns];
		private ListDoc m_document;
		public ChartDoc m_chartDocument;
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

		#endregion
		
		public void OnUpdateChart()
		{
			if(m_listViewHitParade.SelectedItems.Count == 1)
			{
				ListViewItem listViewItem = m_listViewHitParade.SelectedItems[0];
				int ID = Convert.ToInt32(listViewItem.Index);

				

		
				
			}


			
		}

		private String OnSelectList()
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
			this.components = new System.ComponentModel.Container();
			this.m_listViewHitParade = new System.Windows.Forms.ListView();
			this.m_colHeaderName = new System.Windows.Forms.ColumnHeader();
			this.m_colHeaderNameStarts = new System.Windows.Forms.ColumnHeader();
			this.m_colHeaderNameEnds = new System.Windows.Forms.ColumnHeader();
			this.m_contextMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_menuItemEditList = new System.Windows.Forms.ToolStripMenuItem();
			this.m_menuItemDeleteList = new System.Windows.Forms.ToolStripMenuItem();
			this.m_contextMenuList.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_listViewHitParade
			// 
			this.m_listViewHitParade.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colHeaderName,
            this.m_colHeaderNameStarts,
            this.m_colHeaderNameEnds});
			this.m_listViewHitParade.ContextMenuStrip = this.m_contextMenuList;
			this.m_listViewHitParade.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_listViewHitParade.FullRowSelect = true;
			this.m_listViewHitParade.Location = new System.Drawing.Point(0, 0);
			this.m_listViewHitParade.MultiSelect = false;
			this.m_listViewHitParade.Name = "m_listViewHitParade";
			this.m_listViewHitParade.Size = new System.Drawing.Size(498, 608);
			this.m_listViewHitParade.TabIndex = 0;
			this.m_listViewHitParade.UseCompatibleStateImageBehavior = false;
			this.m_listViewHitParade.View = System.Windows.Forms.View.Details;
			this.m_listViewHitParade.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnSortList);
			this.m_listViewHitParade.Click += new System.EventHandler(this.OnClick);
			// 
			// m_colHeaderName
			// 
			this.m_colHeaderName.Tag = "Name";
			this.m_colHeaderName.Text = "Name";
			this.m_colHeaderName.Width = 120;
			// 
			// m_colHeaderNameStarts
			// 
			this.m_colHeaderNameStarts.Tag = "Starts";
			this.m_colHeaderNameStarts.Text = "Starts";
			// 
			// m_colHeaderNameEnds
			// 
			this.m_colHeaderNameEnds.Tag = "Ends";
			this.m_colHeaderNameEnds.Text = "Ends";
			// 
			// m_contextMenuList
			// 
			this.m_contextMenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuItemEditList,
            this.m_menuItemDeleteList});
			this.m_contextMenuList.Name = "m_contextMenuList";
			this.m_contextMenuList.Size = new System.Drawing.Size(136, 48);
			// 
			// m_menuItemEditList
			// 
			this.m_menuItemEditList.Name = "m_menuItemEditList";
			this.m_menuItemEditList.Size = new System.Drawing.Size(135, 22);
			this.m_menuItemEditList.Text = "Edit List";
			// 
			// m_menuItemDeleteList
			// 
			this.m_menuItemDeleteList.Name = "m_menuItemDeleteList";
			this.m_menuItemDeleteList.Size = new System.Drawing.Size(135, 22);
			this.m_menuItemDeleteList.Text = "Delete List";
			// 
			// HitParadeView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_listViewHitParade);
			this.Name = "HitParadeView";
			this.Size = new System.Drawing.Size(498, 608);
			this.Load += new System.EventHandler(this.OnLoad);
			this.m_contextMenuList.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView m_listViewHitParade;
		private System.Windows.Forms.ColumnHeader m_colHeaderName;
		private System.Windows.Forms.ColumnHeader m_colHeaderNameStarts;
		private System.Windows.Forms.ColumnHeader m_colHeaderNameEnds;
		private System.Windows.Forms.ContextMenuStrip m_contextMenuList;
		private System.Windows.Forms.ToolStripMenuItem m_menuItemEditList;
		private System.Windows.Forms.ToolStripMenuItem m_menuItemDeleteList;

		public delegate void HitParadeHandler(string msg);

		public event HitParadeHandler HitParadeSelected;

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
	}
}
