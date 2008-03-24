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
			this.Name = "m_ChartView";
			this.Size = new System.Drawing.Size(328, 423);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView m_listViewChart;
		private System.Windows.Forms.ColumnHeader m_colSaeti;
		private System.Windows.Forms.ColumnHeader m_colLag;
		private System.Windows.Forms.ColumnHeader m_colFlytjandi;
	}
}
