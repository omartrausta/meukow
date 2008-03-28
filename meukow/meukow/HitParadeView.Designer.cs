namespace meukow
{
	partial class HitParadeView
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
            this.m_listViewHitParade = new System.Windows.Forms.ListView();
            this.m_colHeaderName = new System.Windows.Forms.ColumnHeader();
            this.m_colHeaderNameStarts = new System.Windows.Forms.ColumnHeader();
            this.m_colHeaderNameEnds = new System.Windows.Forms.ColumnHeader();
            this.m_contextMenuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.m_colHeaderName.Text = "Nafn";
            this.m_colHeaderName.Width = 120;
            // 
            // m_colHeaderNameStarts
            // 
            this.m_colHeaderNameStarts.Tag = "Starts";
            this.m_colHeaderNameStarts.Text = "Byrjar";
            // 
            // m_colHeaderNameEnds
            // 
            this.m_colHeaderNameEnds.Tag = "Ends";
            this.m_colHeaderNameEnds.Text = "Endar";
            // 
            // m_contextMenuList
            // 
            this.m_contextMenuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newListToolStripMenuItem,
            this.m_menuItemEditList,
            this.m_menuItemDeleteList});
            this.m_contextMenuList.Name = "m_contextMenuList";
            this.m_contextMenuList.Size = new System.Drawing.Size(153, 92);
            // 
            // newListToolStripMenuItem
            // 
            this.newListToolStripMenuItem.Name = "newListToolStripMenuItem";
            this.newListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newListToolStripMenuItem.Text = "Skrá";
            this.newListToolStripMenuItem.Click += new System.EventHandler(this.OnMenuCreateList);
            // 
            // m_menuItemEditList
            // 
            this.m_menuItemEditList.Name = "m_menuItemEditList";
            this.m_menuItemEditList.Size = new System.Drawing.Size(152, 22);
            this.m_menuItemEditList.Text = "Breyta";
            this.m_menuItemEditList.Click += new System.EventHandler(this.OnMenuEditList);
            // 
            // m_menuItemDeleteList
            // 
            this.m_menuItemDeleteList.Name = "m_menuItemDeleteList";
            this.m_menuItemDeleteList.Size = new System.Drawing.Size(152, 22);
            this.m_menuItemDeleteList.Text = "Eyða";
            this.m_menuItemDeleteList.Click += new System.EventHandler(this.OnMenuDeleteList);
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
		private System.Windows.Forms.ToolStripMenuItem newListToolStripMenuItem;
	}
}
