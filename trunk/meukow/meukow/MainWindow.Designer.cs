namespace meukow
{
	partial class MainWindow
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.m_mainMenu = new System.Windows.Forms.MenuStrip();
			this.m_tsFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_tsMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
			this.m_tsHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_tsMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.m_TabControl = new System.Windows.Forms.TabControl();
			this.m_tabHitParade = new System.Windows.Forms.TabPage();
			this.m_chartView = new meukow.ChartView();
			this.m_HitParadeView = new meukow.HitParadeView();
			this.m_toolStripHitParadeList = new System.Windows.Forms.ToolStrip();
			this.m_tsbtnNewList = new System.Windows.Forms.ToolStripButton();
			this.m_tsbtnEditList = new System.Windows.Forms.ToolStripButton();
			this.m_tsbtnDeleteList = new System.Windows.Forms.ToolStripButton();
			this.m_tabSongs = new System.Windows.Forms.TabPage();
			this.m_SongView = new meukow.SongView();
			this.m_toolStripSongs = new System.Windows.Forms.ToolStrip();
			this.m_tsbtnNewSong = new System.Windows.Forms.ToolStripButton();
			this.m_tsbtnEditSong = new System.Windows.Forms.ToolStripButton();
			this.m_tsbtnDeleteSong = new System.Windows.Forms.ToolStripButton();
			this.m_tabArtists = new System.Windows.Forms.TabPage();
			this.m_artistView = new meukow.ArtistView();
			this.m_toolStripArtists = new System.Windows.Forms.ToolStrip();
			this.m_tsbtnNewArtist = new System.Windows.Forms.ToolStripButton();
			this.m_tsbtnEditArtist = new System.Windows.Forms.ToolStripButton();
			this.m_tsbtnDeleteArtist = new System.Windows.Forms.ToolStripButton();
			this.listBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.m_mainMenu.SuspendLayout();
			this.m_TabControl.SuspendLayout();
			this.m_tabHitParade.SuspendLayout();
			this.m_toolStripHitParadeList.SuspendLayout();
			this.m_tabSongs.SuspendLayout();
			this.m_toolStripSongs.SuspendLayout();
			this.m_tabArtists.SuspendLayout();
			this.m_toolStripArtists.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// m_mainMenu
			// 
			this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tsFileMenuItem,
            this.m_tsHelpMenuItem});
			this.m_mainMenu.Location = new System.Drawing.Point(0, 0);
			this.m_mainMenu.Name = "m_mainMenu";
			this.m_mainMenu.Size = new System.Drawing.Size(736, 24);
			this.m_mainMenu.TabIndex = 0;
			this.m_mainMenu.Text = "menuStrip1";
			// 
			// m_tsFileMenuItem
			// 
			this.m_tsFileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tsMenuItemQuit});
			this.m_tsFileMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_tsFileMenuItem.Name = "m_tsFileMenuItem";
			this.m_tsFileMenuItem.Size = new System.Drawing.Size(44, 20);
			this.m_tsFileMenuItem.Text = "Skrá";
			// 
			// m_tsMenuItemQuit
			// 
			this.m_tsMenuItemQuit.Name = "m_tsMenuItemQuit";
			this.m_tsMenuItemQuit.Size = new System.Drawing.Size(111, 22);
			this.m_tsMenuItemQuit.Text = "Hætta";
			this.m_tsMenuItemQuit.Click += new System.EventHandler(this.OnQuitClick);
			// 
			// m_tsHelpMenuItem
			// 
			this.m_tsHelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tsMenuItemAbout});
			this.m_tsHelpMenuItem.Name = "m_tsHelpMenuItem";
			this.m_tsHelpMenuItem.Size = new System.Drawing.Size(43, 20);
			this.m_tsHelpMenuItem.Text = "Hjálp";
			// 
			// m_tsMenuItemAbout
			// 
			this.m_tsMenuItemAbout.Name = "m_tsMenuItemAbout";
			this.m_tsMenuItemAbout.Size = new System.Drawing.Size(124, 22);
			this.m_tsMenuItemAbout.Text = "Um kerfi";
			this.m_tsMenuItemAbout.Click += new System.EventHandler(this.OnAboutClick);
			// 
			// m_TabControl
			// 
			this.m_TabControl.Controls.Add(this.m_tabHitParade);
			this.m_TabControl.Controls.Add(this.m_tabSongs);
			this.m_TabControl.Controls.Add(this.m_tabArtists);
			this.m_TabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_TabControl.Location = new System.Drawing.Point(0, 24);
			this.m_TabControl.Name = "m_TabControl";
			this.m_TabControl.SelectedIndex = 0;
			this.m_TabControl.Size = new System.Drawing.Size(730, 539);
			this.m_TabControl.TabIndex = 3;
			this.m_TabControl.Click += new System.EventHandler(this.OnTabControlClick);
			// 
			// m_tabHitParade
			// 
			this.m_tabHitParade.Controls.Add(this.m_chartView);
			this.m_tabHitParade.Controls.Add(this.m_HitParadeView);
			this.m_tabHitParade.Controls.Add(this.m_toolStripHitParadeList);
			this.m_tabHitParade.Location = new System.Drawing.Point(4, 24);
			this.m_tabHitParade.Name = "m_tabHitParade";
			this.m_tabHitParade.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabHitParade.Size = new System.Drawing.Size(722, 511);
			this.m_tabHitParade.TabIndex = 0;
			this.m_tabHitParade.Text = "Vinsældarlistar";
			this.m_tabHitParade.UseVisualStyleBackColor = true;
			// 
			// m_chartView
			// 
			this.m_chartView.Chart = null;
			this.m_chartView.Doc = null;
			this.m_chartView.Location = new System.Drawing.Point(391, 31);
			this.m_chartView.Name = "m_chartView";
			this.m_chartView.Size = new System.Drawing.Size(328, 476);
			this.m_chartView.TabIndex = 5;
			// 
			// m_HitParadeView
			// 
			this.m_HitParadeView.Document = null;
			this.m_HitParadeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_HitParadeView.IsNewArtist = false;
			this.m_HitParadeView.IsNewSong = false;
			this.m_HitParadeView.Location = new System.Drawing.Point(0, 31);
			this.m_HitParadeView.Name = "m_HitParadeView";
			this.m_HitParadeView.Size = new System.Drawing.Size(385, 476);
			this.m_HitParadeView.TabIndex = 4;
			// 
			// m_toolStripHitParadeList
			// 
			this.m_toolStripHitParadeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_toolStripHitParadeList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tsbtnNewList,
            this.m_tsbtnEditList,
            this.m_tsbtnDeleteList});
			this.m_toolStripHitParadeList.Location = new System.Drawing.Point(3, 3);
			this.m_toolStripHitParadeList.Name = "m_toolStripHitParadeList";
			this.m_toolStripHitParadeList.Size = new System.Drawing.Size(716, 25);
			this.m_toolStripHitParadeList.TabIndex = 3;
			this.m_toolStripHitParadeList.Text = "toolStrip2";
			this.m_toolStripHitParadeList.Visible = false;
			// 
			// m_tsbtnNewList
			// 
			this.m_tsbtnNewList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_tsbtnNewList.Image = ((System.Drawing.Image)(resources.GetObject("m_tsbtnNewList.Image")));
			this.m_tsbtnNewList.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_tsbtnNewList.Name = "m_tsbtnNewList";
			this.m_tsbtnNewList.Size = new System.Drawing.Size(36, 22);
			this.m_tsbtnNewList.Text = "Skrá";
			this.m_tsbtnNewList.Click += new System.EventHandler(this.OnNewHitParade);
			// 
			// m_tsbtnEditList
			// 
			this.m_tsbtnEditList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_tsbtnEditList.Image = ((System.Drawing.Image)(resources.GetObject("m_tsbtnEditList.Image")));
			this.m_tsbtnEditList.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_tsbtnEditList.Name = "m_tsbtnEditList";
			this.m_tsbtnEditList.Size = new System.Drawing.Size(45, 22);
			this.m_tsbtnEditList.Text = "Breyta";
			this.m_tsbtnEditList.Click += new System.EventHandler(this.OnEditHitParade);
			// 
			// m_tsbtnDeleteList
			// 
			this.m_tsbtnDeleteList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_tsbtnDeleteList.Image = ((System.Drawing.Image)(resources.GetObject("m_tsbtnDeleteList.Image")));
			this.m_tsbtnDeleteList.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_tsbtnDeleteList.Name = "m_tsbtnDeleteList";
			this.m_tsbtnDeleteList.Size = new System.Drawing.Size(38, 22);
			this.m_tsbtnDeleteList.Text = "Eyða";
			this.m_tsbtnDeleteList.Click += new System.EventHandler(this.OnDeleteHitParade);
			// 
			// m_tabSongs
			// 
			this.m_tabSongs.Controls.Add(this.m_SongView);
			this.m_tabSongs.Controls.Add(this.m_toolStripSongs);
			this.m_tabSongs.Location = new System.Drawing.Point(4, 24);
			this.m_tabSongs.Name = "m_tabSongs";
			this.m_tabSongs.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabSongs.Size = new System.Drawing.Size(722, 511);
			this.m_tabSongs.TabIndex = 1;
			this.m_tabSongs.Text = "Lög";
			this.m_tabSongs.UseVisualStyleBackColor = true;
			// 
			// m_SongView
			// 
			this.m_SongView.Document = null;
			this.m_SongView.Location = new System.Drawing.Point(0, 31);
			this.m_SongView.Name = "m_SongView";
			this.m_SongView.Size = new System.Drawing.Size(716, 476);
			this.m_SongView.TabIndex = 1;
			// 
			// m_toolStripSongs
			// 
			this.m_toolStripSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_toolStripSongs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tsbtnNewSong,
            this.m_tsbtnEditSong,
            this.m_tsbtnDeleteSong});
			this.m_toolStripSongs.Location = new System.Drawing.Point(3, 3);
			this.m_toolStripSongs.Name = "m_toolStripSongs";
			this.m_toolStripSongs.Size = new System.Drawing.Size(716, 25);
			this.m_toolStripSongs.TabIndex = 0;
			this.m_toolStripSongs.Text = "toolStrip1";
			this.m_toolStripSongs.Visible = false;
			// 
			// m_tsbtnNewSong
			// 
			this.m_tsbtnNewSong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_tsbtnNewSong.Image = ((System.Drawing.Image)(resources.GetObject("m_tsbtnNewSong.Image")));
			this.m_tsbtnNewSong.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_tsbtnNewSong.Name = "m_tsbtnNewSong";
			this.m_tsbtnNewSong.Size = new System.Drawing.Size(36, 22);
			this.m_tsbtnNewSong.Text = "Skrá";
			this.m_tsbtnNewSong.Click += new System.EventHandler(this.OnNewSong);
			// 
			// m_tsbtnEditSong
			// 
			this.m_tsbtnEditSong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_tsbtnEditSong.Image = ((System.Drawing.Image)(resources.GetObject("m_tsbtnEditSong.Image")));
			this.m_tsbtnEditSong.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_tsbtnEditSong.Name = "m_tsbtnEditSong";
			this.m_tsbtnEditSong.Size = new System.Drawing.Size(45, 22);
			this.m_tsbtnEditSong.Text = "Breyta";
			this.m_tsbtnEditSong.Click += new System.EventHandler(this.OnEditSong);
			// 
			// m_tsbtnDeleteSong
			// 
			this.m_tsbtnDeleteSong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_tsbtnDeleteSong.Image = ((System.Drawing.Image)(resources.GetObject("m_tsbtnDeleteSong.Image")));
			this.m_tsbtnDeleteSong.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_tsbtnDeleteSong.Name = "m_tsbtnDeleteSong";
			this.m_tsbtnDeleteSong.Size = new System.Drawing.Size(38, 22);
			this.m_tsbtnDeleteSong.Text = "Eyða";
			this.m_tsbtnDeleteSong.Click += new System.EventHandler(this.OnDeleteSong);
			// 
			// m_tabArtists
			// 
			this.m_tabArtists.Controls.Add(this.m_artistView);
			this.m_tabArtists.Controls.Add(this.m_toolStripArtists);
			this.m_tabArtists.Location = new System.Drawing.Point(4, 24);
			this.m_tabArtists.Name = "m_tabArtists";
			this.m_tabArtists.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabArtists.Size = new System.Drawing.Size(722, 511);
			this.m_tabArtists.TabIndex = 2;
			this.m_tabArtists.Text = "Flytjendur";
			this.m_tabArtists.UseVisualStyleBackColor = true;
			// 
			// m_artistView
			// 
			this.m_artistView.Document = null;
			this.m_artistView.Location = new System.Drawing.Point(0, 31);
			this.m_artistView.Name = "m_artistView";
			this.m_artistView.Size = new System.Drawing.Size(716, 476);
			this.m_artistView.TabIndex = 1;
			// 
			// m_toolStripArtists
			// 
			this.m_toolStripArtists.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_toolStripArtists.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tsbtnNewArtist,
            this.m_tsbtnEditArtist,
            this.m_tsbtnDeleteArtist});
			this.m_toolStripArtists.Location = new System.Drawing.Point(3, 3);
			this.m_toolStripArtists.Name = "m_toolStripArtists";
			this.m_toolStripArtists.Size = new System.Drawing.Size(716, 25);
			this.m_toolStripArtists.TabIndex = 0;
			this.m_toolStripArtists.Text = "toolStrip1";
			// 
			// m_tsbtnNewArtist
			// 
			this.m_tsbtnNewArtist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_tsbtnNewArtist.Image = ((System.Drawing.Image)(resources.GetObject("m_tsbtnNewArtist.Image")));
			this.m_tsbtnNewArtist.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_tsbtnNewArtist.Name = "m_tsbtnNewArtist";
			this.m_tsbtnNewArtist.Size = new System.Drawing.Size(36, 22);
			this.m_tsbtnNewArtist.Text = "Skrá";
			this.m_tsbtnNewArtist.Click += new System.EventHandler(this.OnNewArtist);
			// 
			// m_tsbtnEditArtist
			// 
			this.m_tsbtnEditArtist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_tsbtnEditArtist.Image = ((System.Drawing.Image)(resources.GetObject("m_tsbtnEditArtist.Image")));
			this.m_tsbtnEditArtist.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_tsbtnEditArtist.Name = "m_tsbtnEditArtist";
			this.m_tsbtnEditArtist.Size = new System.Drawing.Size(45, 22);
			this.m_tsbtnEditArtist.Text = "Breyta";
			this.m_tsbtnEditArtist.Click += new System.EventHandler(this.OnEditArtist);
			// 
			// m_tsbtnDeleteArtist
			// 
			this.m_tsbtnDeleteArtist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.m_tsbtnDeleteArtist.Image = ((System.Drawing.Image)(resources.GetObject("m_tsbtnDeleteArtist.Image")));
			this.m_tsbtnDeleteArtist.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.m_tsbtnDeleteArtist.Name = "m_tsbtnDeleteArtist";
			this.m_tsbtnDeleteArtist.Size = new System.Drawing.Size(38, 22);
			this.m_tsbtnDeleteArtist.Text = "Eyða";
			this.m_tsbtnDeleteArtist.Click += new System.EventHandler(this.OnDeleteArtist);
			// 
			// listBindingSource
			// 
			this.listBindingSource.DataSource = typeof(ClassLibrary.List);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 573);
			this.Controls.Add(this.m_TabControl);
			this.Controls.Add(this.m_mainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.m_mainMenu;
			this.Name = "MainWindow";
			this.Text = "Meukow";
			this.m_mainMenu.ResumeLayout(false);
			this.m_mainMenu.PerformLayout();
			this.m_TabControl.ResumeLayout(false);
			this.m_tabHitParade.ResumeLayout(false);
			this.m_tabHitParade.PerformLayout();
			this.m_toolStripHitParadeList.ResumeLayout(false);
			this.m_toolStripHitParadeList.PerformLayout();
			this.m_tabSongs.ResumeLayout(false);
			this.m_tabSongs.PerformLayout();
			this.m_toolStripSongs.ResumeLayout(false);
			this.m_toolStripSongs.PerformLayout();
			this.m_tabArtists.ResumeLayout(false);
			this.m_tabArtists.PerformLayout();
			this.m_toolStripArtists.ResumeLayout(false);
			this.m_toolStripArtists.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.BindingSource listBindingSource;
		private System.Windows.Forms.MenuStrip m_mainMenu;
		private System.Windows.Forms.ToolStripMenuItem m_tsFileMenuItem;
		private System.Windows.Forms.TabControl m_TabControl;
		private System.Windows.Forms.TabPage m_tabHitParade;
		private System.Windows.Forms.TabPage m_tabSongs;
		private System.Windows.Forms.TabPage m_tabArtists;
		private System.Windows.Forms.ToolStrip m_toolStripSongs;
		private System.Windows.Forms.ToolStripButton m_tsbtnNewSong;
        private System.Windows.Forms.ToolStrip m_toolStripArtists;
		private System.Windows.Forms.ToolStripButton m_tsbtnNewArtist;
		private System.Windows.Forms.ToolStrip m_toolStripHitParadeList;
		private System.Windows.Forms.ToolStripButton m_tsbtnEditList;
		private System.Windows.Forms.ToolStripButton m_tsbtnNewList;
        private System.Windows.Forms.ToolStripButton m_tsbtnDeleteList;
		private System.Windows.Forms.ToolStripButton m_tsbtnEditSong;
        private System.Windows.Forms.ToolStripButton m_tsbtnDeleteSong;
        private System.Windows.Forms.ToolStripButton m_tsbtnEditArtist;
        private System.Windows.Forms.ToolStripButton m_tsbtnDeleteArtist;
		private System.Windows.Forms.ToolStripMenuItem m_tsMenuItemQuit;
		private System.Windows.Forms.ToolStripMenuItem m_tsHelpMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_tsMenuItemAbout;
	}
}

