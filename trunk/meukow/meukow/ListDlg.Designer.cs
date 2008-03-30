namespace meukow
{
	partial class ListDlg
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
			this.m_lblName = new System.Windows.Forms.Label();
			this.m_lblStarts = new System.Windows.Forms.Label();
			this.m_txtName = new System.Windows.Forms.TextBox();
			this.m_dtStarts = new System.Windows.Forms.DateTimePicker();
			this.m_lblEnds = new System.Windows.Forms.Label();
			this.m_dtEnds = new System.Windows.Forms.DateTimePicker();
			this.m_chkIsWeekList = new System.Windows.Forms.CheckBox();
			this.m_gbHitParadeListInfo = new System.Windows.Forms.GroupBox();
			this.m_gbHitParadeDetail = new System.Windows.Forms.GroupBox();
			this.m_btnAddToList = new System.Windows.Forms.Button();
			this.m_cmbSong = new System.Windows.Forms.ComboBox();
			this.m_lblSong = new System.Windows.Forms.Label();
			this.m_lblArtist = new System.Windows.Forms.Label();
			this.m_lblPosition = new System.Windows.Forms.Label();
			this.m_txtPosition = new System.Windows.Forms.TextBox();
			this.m_cmbArtist = new System.Windows.Forms.ComboBox();
			this.m_gbHitParadeList = new System.Windows.Forms.GroupBox();
			this.m_chartView = new meukow.ChartView();
			this.m_validator = new Itboy.Components.Validator(this.components);
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_gbHitParadeListInfo.SuspendLayout();
			this.m_gbHitParadeDetail.SuspendLayout();
			this.m_gbHitParadeList.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lblName
			// 
			this.m_lblName.AutoSize = true;
			this.m_lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_lblName.Location = new System.Drawing.Point(15, 29);
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(33, 15);
			this.m_lblName.TabIndex = 0;
			this.m_lblName.Text = "Nafn";
			// 
			// m_lblStarts
			// 
			this.m_lblStarts.AutoSize = true;
			this.m_lblStarts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_lblStarts.Location = new System.Drawing.Point(15, 56);
			this.m_lblStarts.Name = "m_lblStarts";
			this.m_lblStarts.Size = new System.Drawing.Size(38, 15);
			this.m_lblStarts.TabIndex = 2;
			this.m_lblStarts.Text = "Byrjar";
			// 
			// m_txtName
			// 
			this.m_txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_txtName.Location = new System.Drawing.Point(61, 26);
			this.m_txtName.Name = "m_txtName";
			this.m_txtName.Size = new System.Drawing.Size(271, 21);
			this.m_txtName.TabIndex = 3;
			this.m_validator.SetType(this.m_txtName, Itboy.Components.ValidationType.Required);
			// 
			// m_dtStarts
			// 
			this.m_dtStarts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_dtStarts.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dtStarts.Location = new System.Drawing.Point(61, 53);
			this.m_dtStarts.Name = "m_dtStarts";
			this.m_dtStarts.Size = new System.Drawing.Size(101, 21);
			this.m_dtStarts.TabIndex = 4;
			// 
			// m_lblEnds
			// 
			this.m_lblEnds.AutoSize = true;
			this.m_lblEnds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_lblEnds.Location = new System.Drawing.Point(15, 83);
			this.m_lblEnds.Name = "m_lblEnds";
			this.m_lblEnds.Size = new System.Drawing.Size(40, 15);
			this.m_lblEnds.TabIndex = 5;
			this.m_lblEnds.Text = "Endar";
			// 
			// m_dtEnds
			// 
			this.m_dtEnds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_dtEnds.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_dtEnds.Location = new System.Drawing.Point(61, 80);
			this.m_dtEnds.Name = "m_dtEnds";
			this.m_dtEnds.Size = new System.Drawing.Size(101, 21);
			this.m_dtEnds.TabIndex = 6;
			// 
			// m_chkIsWeekList
			// 
			this.m_chkIsWeekList.AutoSize = true;
			this.m_chkIsWeekList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_chkIsWeekList.Location = new System.Drawing.Point(18, 107);
			this.m_chkIsWeekList.Name = "m_chkIsWeekList";
			this.m_chkIsWeekList.Size = new System.Drawing.Size(80, 19);
			this.m_chkIsWeekList.TabIndex = 8;
			this.m_chkIsWeekList.Text = "Er vikulisti";
			this.m_chkIsWeekList.UseVisualStyleBackColor = true;
			// 
			// m_gbHitParadeListInfo
			// 
			this.m_gbHitParadeListInfo.Controls.Add(this.m_chkIsWeekList);
			this.m_gbHitParadeListInfo.Controls.Add(this.m_dtEnds);
			this.m_gbHitParadeListInfo.Controls.Add(this.m_lblName);
			this.m_gbHitParadeListInfo.Controls.Add(this.m_lblEnds);
			this.m_gbHitParadeListInfo.Controls.Add(this.m_lblStarts);
			this.m_gbHitParadeListInfo.Controls.Add(this.m_dtStarts);
			this.m_gbHitParadeListInfo.Controls.Add(this.m_txtName);
			this.m_gbHitParadeListInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.m_gbHitParadeListInfo.Location = new System.Drawing.Point(12, 12);
			this.m_gbHitParadeListInfo.Name = "m_gbHitParadeListInfo";
			this.m_gbHitParadeListInfo.Size = new System.Drawing.Size(427, 140);
			this.m_gbHitParadeListInfo.TabIndex = 3;
			this.m_gbHitParadeListInfo.TabStop = false;
			this.m_gbHitParadeListInfo.Text = "Upplýsingar um vinsældalista";
			// 
			// m_gbHitParadeDetail
			// 
			this.m_gbHitParadeDetail.Controls.Add(this.m_btnAddToList);
			this.m_gbHitParadeDetail.Controls.Add(this.m_cmbSong);
			this.m_gbHitParadeDetail.Controls.Add(this.m_lblSong);
			this.m_gbHitParadeDetail.Controls.Add(this.m_lblArtist);
			this.m_gbHitParadeDetail.Controls.Add(this.m_lblPosition);
			this.m_gbHitParadeDetail.Controls.Add(this.m_txtPosition);
			this.m_gbHitParadeDetail.Controls.Add(this.m_cmbArtist);
			this.m_gbHitParadeDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.m_gbHitParadeDetail.Location = new System.Drawing.Point(13, 159);
			this.m_gbHitParadeDetail.Name = "m_gbHitParadeDetail";
			this.m_gbHitParadeDetail.Size = new System.Drawing.Size(426, 140);
			this.m_gbHitParadeDetail.TabIndex = 4;
			this.m_gbHitParadeDetail.TabStop = false;
			this.m_gbHitParadeDetail.Text = "Skrá í vinsældalista";
			// 
			// m_btnAddToList
			// 
			this.m_btnAddToList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_btnAddToList.Location = new System.Drawing.Point(17, 106);
			this.m_btnAddToList.Name = "m_btnAddToList";
			this.m_btnAddToList.Size = new System.Drawing.Size(116, 23);
			this.m_btnAddToList.TabIndex = 8;
			this.m_btnAddToList.Text = "Vista í lista";
			this.m_btnAddToList.UseVisualStyleBackColor = true;
			this.m_btnAddToList.Click += new System.EventHandler(this.OnAddToListClick);
			// 
			// m_cmbSong
			// 
			this.m_cmbSong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cmbSong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cmbSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_cmbSong.FormattingEnabled = true;
			this.m_cmbSong.Location = new System.Drawing.Point(72, 49);
			this.m_cmbSong.Name = "m_cmbSong";
			this.m_cmbSong.Size = new System.Drawing.Size(121, 23);
			this.m_cmbSong.TabIndex = 6;
			this.m_cmbSong.SelectedValueChanged += new System.EventHandler(this.OnSongChanged);
			// 
			// m_lblSong
			// 
			this.m_lblSong.AutoSize = true;
			this.m_lblSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_lblSong.Location = new System.Drawing.Point(14, 52);
			this.m_lblSong.Name = "m_lblSong";
			this.m_lblSong.Size = new System.Drawing.Size(28, 15);
			this.m_lblSong.TabIndex = 4;
			this.m_lblSong.Text = "Lag";
			// 
			// m_lblArtist
			// 
			this.m_lblArtist.AutoSize = true;
			this.m_lblArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_lblArtist.Location = new System.Drawing.Point(14, 81);
			this.m_lblArtist.Name = "m_lblArtist";
			this.m_lblArtist.Size = new System.Drawing.Size(52, 15);
			this.m_lblArtist.TabIndex = 3;
			this.m_lblArtist.Text = "Flytjandi";
			// 
			// m_lblPosition
			// 
			this.m_lblPosition.AutoSize = true;
			this.m_lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_lblPosition.Location = new System.Drawing.Point(14, 25);
			this.m_lblPosition.Name = "m_lblPosition";
			this.m_lblPosition.Size = new System.Drawing.Size(32, 15);
			this.m_lblPosition.TabIndex = 2;
			this.m_lblPosition.Text = "Sæti";
			// 
			// m_txtPosition
			// 
			this.m_txtPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_txtPosition.Location = new System.Drawing.Point(72, 22);
			this.m_txtPosition.Name = "m_txtPosition";
			this.m_txtPosition.Size = new System.Drawing.Size(49, 21);
			this.m_txtPosition.TabIndex = 1;
			// 
			// m_cmbArtist
			// 
			this.m_cmbArtist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.m_cmbArtist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.m_cmbArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
			this.m_cmbArtist.FormattingEnabled = true;
			this.m_cmbArtist.Location = new System.Drawing.Point(72, 79);
			this.m_cmbArtist.Name = "m_cmbArtist";
			this.m_cmbArtist.Size = new System.Drawing.Size(121, 23);
			this.m_cmbArtist.TabIndex = 0;
			// 
			// m_gbHitParadeList
			// 
			this.m_gbHitParadeList.Controls.Add(this.m_chartView);
			this.m_gbHitParadeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.m_gbHitParadeList.Location = new System.Drawing.Point(13, 305);
			this.m_gbHitParadeList.Name = "m_gbHitParadeList";
			this.m_gbHitParadeList.Size = new System.Drawing.Size(426, 336);
			this.m_gbHitParadeList.TabIndex = 5;
			this.m_gbHitParadeList.TabStop = false;
			this.m_gbHitParadeList.Text = "Vinsældalisti";
			// 
			// m_chartView
			// 
			this.m_chartView.Chart = null;
			this.m_chartView.Doc = null;
			this.m_chartView.Location = new System.Drawing.Point(7, 23);
			this.m_chartView.Margin = new System.Windows.Forms.Padding(4);
			this.m_chartView.Name = "m_chartView";
			this.m_chartView.Size = new System.Drawing.Size(410, 300);
			this.m_chartView.TabIndex = 0;
			// 
			// m_validator
			// 
			this.m_validator.Form = this;
			// 
			// m_btnOK
			// 
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Location = new System.Drawing.Point(355, 647);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 6;
			this.m_btnOK.Text = "Í lagi";
			this.m_btnOK.UseVisualStyleBackColor = true;
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(274, 647);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 7;
			this.m_btnCancel.Text = "Hætta við";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// ListDlg
			// 
			this.AcceptButton = this.m_btnAddToList;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(455, 678);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnOK);
			this.Controls.Add(this.m_gbHitParadeList);
			this.Controls.Add(this.m_gbHitParadeDetail);
			this.Controls.Add(this.m_gbHitParadeListInfo);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 674);
			this.Name = "ListDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Skrá vinsældalista";
			this.Load += new System.EventHandler(this.OnLoad);
			this.m_gbHitParadeListInfo.ResumeLayout(false);
			this.m_gbHitParadeListInfo.PerformLayout();
			this.m_gbHitParadeDetail.ResumeLayout(false);
			this.m_gbHitParadeDetail.PerformLayout();
			this.m_gbHitParadeList.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label m_lblName;
		private System.Windows.Forms.DateTimePicker m_dtStarts;
		private System.Windows.Forms.TextBox m_txtName;
		private System.Windows.Forms.Label m_lblStarts;
		private System.Windows.Forms.CheckBox m_chkIsWeekList;
		private System.Windows.Forms.DateTimePicker m_dtEnds;
		private System.Windows.Forms.Label m_lblEnds;
		private System.Windows.Forms.GroupBox m_gbHitParadeListInfo;
		private System.Windows.Forms.GroupBox m_gbHitParadeDetail;
        private System.Windows.Forms.TextBox m_txtPosition;
        private System.Windows.Forms.ComboBox m_cmbArtist;
        private System.Windows.Forms.Label m_lblPosition;
        private System.Windows.Forms.Label m_lblSong;
        private System.Windows.Forms.Label m_lblArtist;
        private System.Windows.Forms.ComboBox m_cmbSong;
        private System.Windows.Forms.GroupBox m_gbHitParadeList;
        private System.Windows.Forms.Button m_btnAddToList;
        private Itboy.Components.Validator m_validator;
        private System.Windows.Forms.Button m_btnOK;
        private ChartView m_chartView;
        private System.Windows.Forms.Button m_btnCancel;
	}
}