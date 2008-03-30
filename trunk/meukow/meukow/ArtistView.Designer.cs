namespace meukow
{
	partial class ArtistView
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
			this.m_listViewArtist = new System.Windows.Forms.ListView();
			this.m_colHeaderName = new System.Windows.Forms.ColumnHeader();
			this.m_colHeaderDescription = new System.Windows.Forms.ColumnHeader();
			this.m_colHeaderPicture = new System.Windows.Forms.ColumnHeader();
			this.m_colHeaderURL = new System.Windows.Forms.ColumnHeader();
			this.m_contextMenuArtist = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_menuItemNewArtist = new System.Windows.Forms.ToolStripMenuItem();
			this.m_menuItemEditArtist = new System.Windows.Forms.ToolStripMenuItem();
			this.m_menuItemDeleteArtist = new System.Windows.Forms.ToolStripMenuItem();
			this.m_contextMenuArtist.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_listViewArtist
			// 
			this.m_listViewArtist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colHeaderName,
            this.m_colHeaderDescription,
            this.m_colHeaderPicture,
            this.m_colHeaderURL});
			this.m_listViewArtist.ContextMenuStrip = this.m_contextMenuArtist;
			this.m_listViewArtist.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_listViewArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_listViewArtist.FullRowSelect = true;
			this.m_listViewArtist.Location = new System.Drawing.Point(0, 0);
			this.m_listViewArtist.MultiSelect = false;
			this.m_listViewArtist.Name = "m_listViewArtist";
			this.m_listViewArtist.Size = new System.Drawing.Size(477, 453);
			this.m_listViewArtist.TabIndex = 1;
			this.m_listViewArtist.UseCompatibleStateImageBehavior = false;
			this.m_listViewArtist.View = System.Windows.Forms.View.Details;
			this.m_listViewArtist.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnSortList);
			// 
			// m_colHeaderName
			// 
			this.m_colHeaderName.Tag = "Name";
			this.m_colHeaderName.Text = "Nafn";
			this.m_colHeaderName.Width = 150;
			// 
			// m_colHeaderDescription
			// 
			this.m_colHeaderDescription.Tag = "Description";
			this.m_colHeaderDescription.Text = "Lýsing";
			this.m_colHeaderDescription.Width = 150;
			// 
			// m_colHeaderPicture
			// 
			this.m_colHeaderPicture.Tag = "Picture";
			this.m_colHeaderPicture.Text = "Mynd";
			this.m_colHeaderPicture.Width = 100;
			// 
			// m_colHeaderURL
			// 
			this.m_colHeaderURL.Tag = "URl";
			this.m_colHeaderURL.Text = "Heimasíða";
			this.m_colHeaderURL.Width = 130;
			// 
			// m_contextMenuArtist
			// 
			this.m_contextMenuArtist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuItemNewArtist,
            this.m_menuItemEditArtist,
            this.m_menuItemDeleteArtist});
			this.m_contextMenuArtist.Name = "m_contextMenuArtist";
			this.m_contextMenuArtist.Size = new System.Drawing.Size(118, 70);
			// 
			// m_menuItemNewArtist
			// 
			this.m_menuItemNewArtist.Name = "m_menuItemNewArtist";
			this.m_menuItemNewArtist.Size = new System.Drawing.Size(117, 22);
			this.m_menuItemNewArtist.Text = "Skrá";
			this.m_menuItemNewArtist.Click += new System.EventHandler(this.OnMenuNewArtist);
			// 
			// m_menuItemEditArtist
			// 
			this.m_menuItemEditArtist.Name = "m_menuItemEditArtist";
			this.m_menuItemEditArtist.Size = new System.Drawing.Size(117, 22);
			this.m_menuItemEditArtist.Text = "Breyta";
			this.m_menuItemEditArtist.Click += new System.EventHandler(this.OnMenuEditArtist);
			// 
			// m_menuItemDeleteArtist
			// 
			this.m_menuItemDeleteArtist.Name = "m_menuItemDeleteArtist";
			this.m_menuItemDeleteArtist.Size = new System.Drawing.Size(117, 22);
			this.m_menuItemDeleteArtist.Text = "Eyða";
			this.m_menuItemDeleteArtist.Click += new System.EventHandler(this.OnMenuDeleteArtist);
			// 
			// ArtistView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_listViewArtist);
			this.Name = "ArtistView";
			this.Size = new System.Drawing.Size(477, 453);
			this.Load += new System.EventHandler(this.OnLoad);
			this.m_contextMenuArtist.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.ListView m_listViewArtist;
		private System.Windows.Forms.ColumnHeader m_colHeaderName;
		private System.Windows.Forms.ColumnHeader m_colHeaderDescription;
		private System.Windows.Forms.ColumnHeader m_colHeaderPicture;
		private System.Windows.Forms.ColumnHeader m_colHeaderURL;
		private System.Windows.Forms.ContextMenuStrip m_contextMenuArtist;
		private System.Windows.Forms.ToolStripMenuItem m_menuItemNewArtist;
		private System.Windows.Forms.ToolStripMenuItem m_menuItemEditArtist;
		private System.Windows.Forms.ToolStripMenuItem m_menuItemDeleteArtist;
	}
}
