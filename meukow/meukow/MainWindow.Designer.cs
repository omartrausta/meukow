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
			this.listBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.m_mainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.hitParadeView1 = new meukow.HitParadeView();
			((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).BeginInit();
			this.m_mainMenu.SuspendLayout();
			this.m_toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBindingSource
			// 
			this.listBindingSource.DataSource = typeof(ClassLibrary.List);
			// 
			// m_mainMenu
			// 
			this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.m_mainMenu.Location = new System.Drawing.Point(0, 0);
			this.m_mainMenu.Name = "m_mainMenu";
			this.m_mainMenu.Size = new System.Drawing.Size(631, 24);
			this.m_mainMenu.TabIndex = 0;
			this.m_mainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// m_toolStrip
			// 
			this.m_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.m_toolStrip.Location = new System.Drawing.Point(0, 24);
			this.m_toolStrip.Name = "m_toolStrip";
			this.m_toolStrip.Size = new System.Drawing.Size(631, 25);
			this.m_toolStrip.TabIndex = 1;
			this.m_toolStrip.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			// 
			// hitParadeView1
			// 
			this.hitParadeView1.Document = null;
			this.hitParadeView1.Location = new System.Drawing.Point(13, 53);
			this.hitParadeView1.Name = "hitParadeView1";
			this.hitParadeView1.Size = new System.Drawing.Size(415, 435);
			this.hitParadeView1.TabIndex = 2;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(631, 575);
			this.Controls.Add(this.hitParadeView1);
			this.Controls.Add(this.m_toolStrip);
			this.Controls.Add(this.m_mainMenu);
			this.MainMenuStrip = this.m_mainMenu;
			this.Name = "MainWindow";
			this.Text = "MainWindow";
			((System.ComponentModel.ISupportInitialize)(this.listBindingSource)).EndInit();
			this.m_mainMenu.ResumeLayout(false);
			this.m_mainMenu.PerformLayout();
			this.m_toolStrip.ResumeLayout(false);
			this.m_toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.BindingSource listBindingSource;
		private System.Windows.Forms.MenuStrip m_mainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip m_toolStrip;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private HitParadeView hitParadeView1;
	}
}

