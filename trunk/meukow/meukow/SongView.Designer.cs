namespace meukow
{
	partial class SongView
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
			this.m_contextMenuSong = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_listViewSong = new System.Windows.Forms.ListView();
			this.m_colHeaderName = new System.Windows.Forms.ColumnHeader();
			this.m_colHeaderArtist = new System.Windows.Forms.ColumnHeader();
			this.m_colHeaderSongpath = new System.Windows.Forms.ColumnHeader();
			this.m_colHeaderDescription = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// m_contextMenuSong
			// 
			this.m_contextMenuSong.Name = "m_contextMenuSong";
			this.m_contextMenuSong.Size = new System.Drawing.Size(61, 4);
			// 
			// m_listViewSong
			// 
			this.m_listViewSong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colHeaderName,
            this.m_colHeaderArtist,
            this.m_colHeaderSongpath,
            this.m_colHeaderDescription});
			this.m_listViewSong.ContextMenuStrip = this.m_contextMenuSong;
			this.m_listViewSong.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_listViewSong.FullRowSelect = true;
			this.m_listViewSong.Location = new System.Drawing.Point(0, 0);
			this.m_listViewSong.MultiSelect = false;
			this.m_listViewSong.Name = "m_listViewSong";
			this.m_listViewSong.Size = new System.Drawing.Size(513, 449);
			this.m_listViewSong.TabIndex = 1;
			this.m_listViewSong.UseCompatibleStateImageBehavior = false;
			this.m_listViewSong.View = System.Windows.Forms.View.Details;
			this.m_listViewSong.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnSortList);
			// 
			// m_colHeaderName
			// 
			this.m_colHeaderName.Tag = "Name";
			this.m_colHeaderName.Text = "Nafn";
			this.m_colHeaderName.Width = 113;
			// 
			// m_colHeaderArtist
			// 
			this.m_colHeaderArtist.Tag = "Artist";
			this.m_colHeaderArtist.Text = "Flytjandi";
			this.m_colHeaderArtist.Width = 88;
			// 
			// m_colHeaderSongpath
			// 
			this.m_colHeaderSongpath.Tag = "Songpath";
			this.m_colHeaderSongpath.Text = "Slóð á lag";
			this.m_colHeaderSongpath.Width = 74;
			// 
			// m_colHeaderDescription
			// 
			this.m_colHeaderDescription.Tag = "Description";
			this.m_colHeaderDescription.Text = "Lýsing / umsögn";
			this.m_colHeaderDescription.Width = 142;
			// 
			// SongView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_listViewSong);
			this.Name = "SongView";
			this.Size = new System.Drawing.Size(513, 449);
			this.Load += new System.EventHandler(this.OnLoad);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip m_contextMenuSong;
		private System.Windows.Forms.ListView m_listViewSong;
		private System.Windows.Forms.ColumnHeader m_colHeaderName;
		private System.Windows.Forms.ColumnHeader m_colHeaderArtist;
		private System.Windows.Forms.ColumnHeader m_colHeaderSongpath;
		private System.Windows.Forms.ColumnHeader m_colHeaderDescription;
	}
}
