namespace meukow
{
	partial class SongDlg
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongDlg));
			this.m_lblName = new System.Windows.Forms.Label();
			this.m_lblArtist = new System.Windows.Forms.Label();
			this.m_lblSongpath = new System.Windows.Forms.Label();
			this.L�sing = new System.Windows.Forms.Label();
			this.m_cmbArtist = new System.Windows.Forms.ComboBox();
			this.m_txtboxName = new System.Windows.Forms.TextBox();
			this.m_txtboxSongpath = new System.Windows.Forms.TextBox();
			this.m_txtboxDescription = new System.Windows.Forms.TextBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_validator = new Itboy.Components.Validator(this.components);
			this.SuspendLayout();
			// 
			// m_lblName
			// 
			this.m_lblName.AutoSize = true;
			this.m_lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_lblName.Location = new System.Drawing.Point(12, 15);
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(33, 15);
			this.m_lblName.TabIndex = 0;
			this.m_lblName.Text = "Nafn";
			// 
			// m_lblArtist
			// 
			this.m_lblArtist.AutoSize = true;
			this.m_lblArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_lblArtist.Location = new System.Drawing.Point(12, 42);
			this.m_lblArtist.Name = "m_lblArtist";
			this.m_lblArtist.Size = new System.Drawing.Size(52, 15);
			this.m_lblArtist.TabIndex = 1;
			this.m_lblArtist.Text = "Flytjandi";
			// 
			// m_lblSongpath
			// 
			this.m_lblSongpath.AutoSize = true;
			this.m_lblSongpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_lblSongpath.Location = new System.Drawing.Point(12, 71);
			this.m_lblSongpath.Name = "m_lblSongpath";
			this.m_lblSongpath.Size = new System.Drawing.Size(62, 15);
			this.m_lblSongpath.TabIndex = 2;
			this.m_lblSongpath.Text = "Sl�� � lag";
			// 
			// L�sing
			// 
			this.L�sing.AutoSize = true;
			this.L�sing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.L�sing.Location = new System.Drawing.Point(12, 100);
			this.L�sing.Name = "L�sing";
			this.L�sing.Size = new System.Drawing.Size(96, 15);
			this.L�sing.TabIndex = 3;
			this.L�sing.Text = "L�sing / ums�gn";
			// 
			// m_cmbArtist
			// 
			this.m_cmbArtist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cmbArtist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cmbArtist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_cmbArtist.FormattingEnabled = true;
			this.m_cmbArtist.Location = new System.Drawing.Point(111, 39);
			this.m_cmbArtist.Name = "m_cmbArtist";
			this.m_cmbArtist.Size = new System.Drawing.Size(271, 23);
			this.m_cmbArtist.TabIndex = 4;
			this.m_validator.SetType(this.m_cmbArtist, Itboy.Components.ValidationType.Required);
			// 
			// m_txtboxName
			// 
			this.m_txtboxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_txtboxName.Location = new System.Drawing.Point(111, 12);
			this.m_txtboxName.Name = "m_txtboxName";
			this.m_txtboxName.Size = new System.Drawing.Size(271, 21);
			this.m_txtboxName.TabIndex = 5;
			this.m_validator.SetType(this.m_txtboxName, Itboy.Components.ValidationType.Required);
			// 
			// m_txtboxSongpath
			// 
			this.m_txtboxSongpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_txtboxSongpath.Location = new System.Drawing.Point(111, 68);
			this.m_txtboxSongpath.Name = "m_txtboxSongpath";
			this.m_txtboxSongpath.Size = new System.Drawing.Size(271, 21);
			this.m_txtboxSongpath.TabIndex = 6;
			// 
			// m_txtboxDescription
			// 
			this.m_txtboxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_txtboxDescription.Location = new System.Drawing.Point(111, 97);
			this.m_txtboxDescription.Multiline = true;
			this.m_txtboxDescription.Name = "m_txtboxDescription";
			this.m_txtboxDescription.Size = new System.Drawing.Size(271, 88);
			this.m_txtboxDescription.TabIndex = 7;
			// 
			// m_btnOK
			// 
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_btnOK.Location = new System.Drawing.Point(226, 191);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 8;
			this.m_btnOK.Text = "� lagi";
			this.m_btnOK.UseVisualStyleBackColor = true;
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_btnCancel.Location = new System.Drawing.Point(307, 191);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 9;
			this.m_btnCancel.Text = "H�tta vi�";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_validator
			// 
			this.m_validator.Form = this;
			// 
			// SongDlg
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(412, 229);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.m_txtboxDescription);
			this.Controls.Add(this.m_txtboxSongpath);
			this.Controls.Add(this.m_txtboxName);
			this.Controls.Add(this.m_cmbArtist);
			this.Controls.Add(this.L�sing);
			this.Controls.Add(this.m_lblSongpath);
			this.Controls.Add(this.m_lblArtist);
			this.Controls.Add(this.m_lblName);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SongDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SongDlg";
			this.Load += new System.EventHandler(this.OnLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label m_lblName;
		private System.Windows.Forms.Label m_lblArtist;
		private System.Windows.Forms.Label m_lblSongpath;
		private System.Windows.Forms.Label L�sing;
		private System.Windows.Forms.ComboBox m_cmbArtist;
		private System.Windows.Forms.TextBox m_txtboxName;
		private System.Windows.Forms.TextBox m_txtboxSongpath;
		private System.Windows.Forms.TextBox m_txtboxDescription;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnCancel;
		private Itboy.Components.Validator m_validator;
	}
}
