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
			this.m_lblName = new System.Windows.Forms.Label();
			this.m_lblStarts = new System.Windows.Forms.Label();
			this.m_txtName = new System.Windows.Forms.TextBox();
			this.m_dtStarts = new System.Windows.Forms.DateTimePicker();
			this.m_lblEnds = new System.Windows.Forms.Label();
			this.m_dtEnds = new System.Windows.Forms.DateTimePicker();
			this.m_chkIsWeekList = new System.Windows.Forms.CheckBox();
			this.m_gbHitParadeList = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
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
			// m_gbHitParadeList
			// 
			this.m_gbHitParadeList.Controls.Add(this.m_chkIsWeekList);
			this.m_gbHitParadeList.Controls.Add(this.m_dtEnds);
			this.m_gbHitParadeList.Controls.Add(this.m_lblName);
			this.m_gbHitParadeList.Controls.Add(this.m_lblEnds);
			this.m_gbHitParadeList.Controls.Add(this.m_lblStarts);
			this.m_gbHitParadeList.Controls.Add(this.m_dtStarts);
			this.m_gbHitParadeList.Controls.Add(this.m_txtName);
			this.m_gbHitParadeList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_gbHitParadeList.Location = new System.Drawing.Point(12, 12);
			this.m_gbHitParadeList.Name = "m_gbHitParadeList";
			this.m_gbHitParadeList.Size = new System.Drawing.Size(403, 140);
			this.m_gbHitParadeList.TabIndex = 3;
			this.m_gbHitParadeList.TabStop = false;
			this.m_gbHitParadeList.Text = "Upplýsingar um vinsældalista";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(13, 159);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(513, 223);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// ListDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(649, 647);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_gbHitParadeList);
			this.Name = "ListDlg";
			this.Text = "ListDlg";
			this.m_gbHitParadeList.ResumeLayout(false);
			this.m_gbHitParadeList.PerformLayout();
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
		private System.Windows.Forms.GroupBox m_gbHitParadeList;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}