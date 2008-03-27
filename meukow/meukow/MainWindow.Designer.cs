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
            this.m_tSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_TabControl = new System.Windows.Forms.TabControl();
            this.m_tabVinsaeldarlistar = new System.Windows.Forms.TabPage();
            this.m_toolStripHitParadeList = new System.Windows.Forms.ToolStrip();
            this.m_tSbtnChange = new System.Windows.Forms.ToolStripButton();
            this.m_tSbtnCreate = new System.Windows.Forms.ToolStripButton();
            this.m_tabLog = new System.Windows.Forms.TabPage();
            this.m_toolStripLog = new System.Windows.Forms.ToolStrip();
            this.m_tSbtnSkodalog = new System.Windows.Forms.ToolStripButton();
            this.m_tSbtnSkralog = new System.Windows.Forms.ToolStripButton();
            this.m_tabFlytjendur = new System.Windows.Forms.TabPage();
            this.m_toolStripFlytjendur = new System.Windows.Forms.ToolStrip();
            this.m_tSbtnSkodaflytjendur = new System.Windows.Forms.ToolStripButton();
            this.m_tSbtnSkraflytjendur = new System.Windows.Forms.ToolStripButton();
            this.listBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_chartView = new meukow.ChartView();
            this.m_HitParadeView = new meukow.HitParadeView();
            this.m_SongView = new meukow.SongView();
            this.artistView1 = new meukow.ArtistView();
            this.m_mainMenu.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_tabVinsaeldarlistar.SuspendLayout();
            this.m_toolStripHitParadeList.SuspendLayout();
            this.m_tabLog.SuspendLayout();
            this.m_toolStripLog.SuspendLayout();
            this.m_tabFlytjendur.SuspendLayout();
            this.m_toolStripFlytjendur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // m_mainMenu
            // 
            this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tSMenuItem});
            this.m_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.m_mainMenu.Name = "m_mainMenu";
            this.m_mainMenu.Size = new System.Drawing.Size(708, 24);
            this.m_mainMenu.TabIndex = 0;
            this.m_mainMenu.Text = "menuStrip1";
            // 
            // m_tSMenuItem
            // 
            this.m_tSMenuItem.Name = "m_tSMenuItem";
            this.m_tSMenuItem.Size = new System.Drawing.Size(35, 20);
            this.m_tSMenuItem.Text = "File";
            // 
            // m_TabControl
            // 
            this.m_TabControl.Controls.Add(this.m_tabVinsaeldarlistar);
            this.m_TabControl.Controls.Add(this.m_tabLog);
            this.m_TabControl.Controls.Add(this.m_tabFlytjendur);
            this.m_TabControl.Location = new System.Drawing.Point(0, 24);
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.Size = new System.Drawing.Size(1108, 539);
            this.m_TabControl.TabIndex = 3;
            // 
            // m_tabVinsaeldarlistar
            // 
            this.m_tabVinsaeldarlistar.Controls.Add(this.m_chartView);
            this.m_tabVinsaeldarlistar.Controls.Add(this.m_HitParadeView);
            this.m_tabVinsaeldarlistar.Controls.Add(this.m_toolStripHitParadeList);
            this.m_tabVinsaeldarlistar.Location = new System.Drawing.Point(4, 22);
            this.m_tabVinsaeldarlistar.Name = "m_tabVinsaeldarlistar";
            this.m_tabVinsaeldarlistar.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabVinsaeldarlistar.Size = new System.Drawing.Size(1100, 513);
            this.m_tabVinsaeldarlistar.TabIndex = 0;
            this.m_tabVinsaeldarlistar.Text = "Vinsældarlistar";
            this.m_tabVinsaeldarlistar.UseVisualStyleBackColor = true;
            // 
            // m_toolStripHitParadeList
            // 
            this.m_toolStripHitParadeList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tSbtnChange,
            this.m_tSbtnCreate});
            this.m_toolStripHitParadeList.Location = new System.Drawing.Point(3, 3);
            this.m_toolStripHitParadeList.Name = "m_toolStripHitParadeList";
            this.m_toolStripHitParadeList.Size = new System.Drawing.Size(1094, 25);
            this.m_toolStripHitParadeList.TabIndex = 3;
            this.m_toolStripHitParadeList.Text = "toolStrip2";
            // 
            // m_tSbtnChange
            // 
            this.m_tSbtnChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_tSbtnChange.Image = ((System.Drawing.Image)(resources.GetObject("m_tSbtnChange.Image")));
            this.m_tSbtnChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_tSbtnChange.Name = "m_tSbtnChange";
            this.m_tSbtnChange.Size = new System.Drawing.Size(109, 22);
            this.m_tSbtnChange.Text = "Skoða vinsældarlista";
            this.m_tSbtnChange.Click += new System.EventHandler(this.m_tSbtnSkodavinlistar_Click);
            // 
            // m_tSbtnCreate
            // 
            this.m_tSbtnCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_tSbtnCreate.Image = ((System.Drawing.Image)(resources.GetObject("m_tSbtnCreate.Image")));
            this.m_tSbtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_tSbtnCreate.Name = "m_tSbtnCreate";
            this.m_tSbtnCreate.Size = new System.Drawing.Size(101, 22);
            this.m_tSbtnCreate.Text = "Skrá vinsældarlista";
            // 
            // m_tabLog
            // 
            this.m_tabLog.Controls.Add(this.m_SongView);
            this.m_tabLog.Controls.Add(this.m_toolStripLog);
            this.m_tabLog.Location = new System.Drawing.Point(4, 22);
            this.m_tabLog.Name = "m_tabLog";
            this.m_tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabLog.Size = new System.Drawing.Size(1100, 513);
            this.m_tabLog.TabIndex = 1;
            this.m_tabLog.Text = "Lög";
            this.m_tabLog.UseVisualStyleBackColor = true;
            // 
            // m_toolStripLog
            // 
            this.m_toolStripLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tSbtnSkodalog,
            this.m_tSbtnSkralog});
            this.m_toolStripLog.Location = new System.Drawing.Point(3, 3);
            this.m_toolStripLog.Name = "m_toolStripLog";
            this.m_toolStripLog.Size = new System.Drawing.Size(1094, 25);
            this.m_toolStripLog.TabIndex = 0;
            this.m_toolStripLog.Text = "toolStrip1";
            // 
            // m_tSbtnSkodalog
            // 
            this.m_tSbtnSkodalog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_tSbtnSkodalog.Image = ((System.Drawing.Image)(resources.GetObject("m_tSbtnSkodalog.Image")));
            this.m_tSbtnSkodalog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_tSbtnSkodalog.Name = "m_tSbtnSkodalog";
            this.m_tSbtnSkodalog.Size = new System.Drawing.Size(57, 22);
            this.m_tSbtnSkodalog.Text = "Skoða lög";
            // 
            // m_tSbtnSkralog
            // 
            this.m_tSbtnSkralog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_tSbtnSkralog.Image = ((System.Drawing.Image)(resources.GetObject("m_tSbtnSkralog.Image")));
            this.m_tSbtnSkralog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_tSbtnSkralog.Name = "m_tSbtnSkralog";
            this.m_tSbtnSkralog.Size = new System.Drawing.Size(49, 22);
            this.m_tSbtnSkralog.Text = "Skrá lög";
            // 
            // m_tabFlytjendur
            // 
            this.m_tabFlytjendur.Controls.Add(this.artistView1);
            this.m_tabFlytjendur.Controls.Add(this.m_toolStripFlytjendur);
            this.m_tabFlytjendur.Location = new System.Drawing.Point(4, 22);
            this.m_tabFlytjendur.Name = "m_tabFlytjendur";
            this.m_tabFlytjendur.Padding = new System.Windows.Forms.Padding(3);
            this.m_tabFlytjendur.Size = new System.Drawing.Size(1100, 513);
            this.m_tabFlytjendur.TabIndex = 2;
            this.m_tabFlytjendur.Text = "Flytjendur";
            this.m_tabFlytjendur.UseVisualStyleBackColor = true;
            // 
            // m_toolStripFlytjendur
            // 
            this.m_toolStripFlytjendur.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tSbtnSkodaflytjendur,
            this.m_tSbtnSkraflytjendur});
            this.m_toolStripFlytjendur.Location = new System.Drawing.Point(3, 3);
            this.m_toolStripFlytjendur.Name = "m_toolStripFlytjendur";
            this.m_toolStripFlytjendur.Size = new System.Drawing.Size(1094, 25);
            this.m_toolStripFlytjendur.TabIndex = 0;
            this.m_toolStripFlytjendur.Text = "toolStrip1";
            // 
            // m_tSbtnSkodaflytjendur
            // 
            this.m_tSbtnSkodaflytjendur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_tSbtnSkodaflytjendur.Image = ((System.Drawing.Image)(resources.GetObject("m_tSbtnSkodaflytjendur.Image")));
            this.m_tSbtnSkodaflytjendur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_tSbtnSkodaflytjendur.Name = "m_tSbtnSkodaflytjendur";
            this.m_tSbtnSkodaflytjendur.Size = new System.Drawing.Size(90, 22);
            this.m_tSbtnSkodaflytjendur.Text = "Skoða flytjendur";
            // 
            // m_tSbtnSkraflytjendur
            // 
            this.m_tSbtnSkraflytjendur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.m_tSbtnSkraflytjendur.Image = ((System.Drawing.Image)(resources.GetObject("m_tSbtnSkraflytjendur.Image")));
            this.m_tSbtnSkraflytjendur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_tSbtnSkraflytjendur.Name = "m_tSbtnSkraflytjendur";
            this.m_tSbtnSkraflytjendur.Size = new System.Drawing.Size(82, 22);
            this.m_tSbtnSkraflytjendur.Text = "Skrá flytjendur";
            this.m_tSbtnSkraflytjendur.Click += new System.EventHandler(this.OnNewArtist);
            // 
            // listBindingSource
            // 
            this.listBindingSource.DataSource = typeof(ClassLibrary.List);
            // 
            // m_chartView
            // 
            this.m_chartView.Chart = null;
            this.m_chartView.Doc = null;
            this.m_chartView.Location = new System.Drawing.Point(337, 31);
            this.m_chartView.Name = "m_chartView";
            this.m_chartView.Size = new System.Drawing.Size(328, 330);
            this.m_chartView.TabIndex = 5;
            // 
            // m_HitParadeView
            // 
            this.m_HitParadeView.Document = null;
            this.m_HitParadeView.Location = new System.Drawing.Point(0, 31);
            this.m_HitParadeView.Name = "m_HitParadeView";
            this.m_HitParadeView.Size = new System.Drawing.Size(320, 461);
            this.m_HitParadeView.TabIndex = 4;
            // 
            // m_SongView
            // 
            this.m_SongView.Document = null;
            this.m_SongView.Location = new System.Drawing.Point(0, 31);
            this.m_SongView.Name = "m_SongView";
            this.m_SongView.Size = new System.Drawing.Size(434, 449);
            this.m_SongView.TabIndex = 1;
            // 
            // artistView1
            // 
            this.artistView1.Document = null;
            this.artistView1.Location = new System.Drawing.Point(0, 31);
            this.artistView1.Name = "artistView1";
            this.artistView1.Size = new System.Drawing.Size(532, 453);
            this.artistView1.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 575);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.m_mainMenu);
            this.MainMenuStrip = this.m_mainMenu;
            this.Name = "MainWindow";
            this.Text = "MainWindow V 0.107";
            this.m_mainMenu.ResumeLayout(false);
            this.m_mainMenu.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_tabVinsaeldarlistar.ResumeLayout(false);
            this.m_tabVinsaeldarlistar.PerformLayout();
            this.m_toolStripHitParadeList.ResumeLayout(false);
            this.m_toolStripHitParadeList.PerformLayout();
            this.m_tabLog.ResumeLayout(false);
            this.m_tabLog.PerformLayout();
            this.m_toolStripLog.ResumeLayout(false);
            this.m_toolStripLog.PerformLayout();
            this.m_tabFlytjendur.ResumeLayout(false);
            this.m_tabFlytjendur.PerformLayout();
            this.m_toolStripFlytjendur.ResumeLayout(false);
            this.m_toolStripFlytjendur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.BindingSource listBindingSource;
		private System.Windows.Forms.MenuStrip m_mainMenu;
		private System.Windows.Forms.ToolStripMenuItem m_tSMenuItem;
		private System.Windows.Forms.TabControl m_TabControl;
		private System.Windows.Forms.TabPage m_tabVinsaeldarlistar;
		private System.Windows.Forms.TabPage m_tabLog;
		private System.Windows.Forms.TabPage m_tabFlytjendur;
		private System.Windows.Forms.ToolStrip m_toolStripLog;
		private System.Windows.Forms.ToolStripButton m_tSbtnSkodalog;
		private System.Windows.Forms.ToolStripButton m_tSbtnSkralog;
		private System.Windows.Forms.ToolStrip m_toolStripFlytjendur;
		private System.Windows.Forms.ToolStripButton m_tSbtnSkodaflytjendur;
		private System.Windows.Forms.ToolStripButton m_tSbtnSkraflytjendur;
		private System.Windows.Forms.ToolStrip m_toolStripHitParadeList;
		private System.Windows.Forms.ToolStripButton m_tSbtnChange;
		private System.Windows.Forms.ToolStripButton m_tSbtnCreate;
	}
}

