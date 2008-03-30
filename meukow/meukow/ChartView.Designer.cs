namespace meukow
{
	partial class ChartView
	{
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
			this.m_listViewChart = new System.Windows.Forms.ListView();
			this.m_colPosition = new System.Windows.Forms.ColumnHeader();
			this.m_colSong = new System.Windows.Forms.ColumnHeader();
			this.m_colArtist = new System.Windows.Forms.ColumnHeader();
			this.m_contextMenuChart = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_menuItemEditChart = new System.Windows.Forms.ToolStripMenuItem();
			this.m_menuItemDeleteChart = new System.Windows.Forms.ToolStripMenuItem();
			this.m_contextMenuChart.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_listViewChart
			// 
			this.m_listViewChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colPosition,
            this.m_colSong,
            this.m_colArtist});
			this.m_listViewChart.ContextMenuStrip = this.m_contextMenuChart;
			this.m_listViewChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_listViewChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_listViewChart.FullRowSelect = true;
			this.m_listViewChart.Location = new System.Drawing.Point(0, 0);
			this.m_listViewChart.MultiSelect = false;
			this.m_listViewChart.Name = "m_listViewChart";
			this.m_listViewChart.Size = new System.Drawing.Size(328, 600);
			this.m_listViewChart.TabIndex = 0;
			this.m_listViewChart.UseCompatibleStateImageBehavior = false;
			this.m_listViewChart.View = System.Windows.Forms.View.Details;
			this.m_listViewChart.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnSortChart);
			// 
			// m_colPosition
			// 
			this.m_colPosition.Text = "Sæti";
			this.m_colPosition.Width = 46;
			// 
			// m_colSong
			// 
			this.m_colSong.Text = "Lag";
			this.m_colSong.Width = 125;
			// 
			// m_colArtist
			// 
			this.m_colArtist.Text = "Flytjandi";
			this.m_colArtist.Width = 152;
			// 
			// m_contextMenuChart
			// 
			this.m_contextMenuChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuItemEditChart,
            this.m_menuItemDeleteChart});
			this.m_contextMenuChart.Name = "contextMenuStrip1";
			this.m_contextMenuChart.Size = new System.Drawing.Size(118, 48);
			// 
			// m_menuItemEditChart
			// 
			this.m_menuItemEditChart.Name = "m_menuItemEditChart";
			this.m_menuItemEditChart.Size = new System.Drawing.Size(117, 22);
			this.m_menuItemEditChart.Text = "Breyta";
			this.m_menuItemEditChart.Click += new System.EventHandler(this.OnEditChart);
			// 
			// m_menuItemDeleteChart
			// 
			this.m_menuItemDeleteChart.Name = "m_menuItemDeleteChart";
			this.m_menuItemDeleteChart.Size = new System.Drawing.Size(117, 22);
			this.m_menuItemDeleteChart.Text = "Eyða";
			this.m_menuItemDeleteChart.Click += new System.EventHandler(this.OnDeleteChart);
			// 
			// ChartView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_listViewChart);
			this.Name = "ChartView";
			this.Size = new System.Drawing.Size(328, 600);
			this.m_contextMenuChart.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ColumnHeader m_colPosition;
		private System.Windows.Forms.ColumnHeader m_colSong;
		private System.Windows.Forms.ColumnHeader m_colArtist;
		private System.Windows.Forms.ContextMenuStrip m_contextMenuChart;
		private System.Windows.Forms.ToolStripMenuItem m_menuItemEditChart;
		private System.Windows.Forms.ToolStripMenuItem m_menuItemDeleteChart;
		private System.Windows.Forms.ListView m_listViewChart;
	}
}
