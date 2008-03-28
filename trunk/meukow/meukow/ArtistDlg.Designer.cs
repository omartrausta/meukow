namespace meukow
{
    partial class ArtistDlg
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
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_lblName = new System.Windows.Forms.Label();
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.m_txtDescription = new System.Windows.Forms.TextBox();
            this.m_lblPicture = new System.Windows.Forms.Label();
            this.m_lblUrl = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.m_txtUrl = new System.Windows.Forms.TextBox();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnBrowse = new System.Windows.Forms.Button();
            this.m_txtFileName = new System.Windows.Forms.TextBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_txtName
            // 
            this.m_txtName.Location = new System.Drawing.Point(104, 38);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(317, 20);
            this.m_txtName.TabIndex = 0;
            // 
            // m_lblName
            // 
            this.m_lblName.AutoSize = true;
            this.m_lblName.Location = new System.Drawing.Point(48, 41);
            this.m_lblName.Name = "m_lblName";
            this.m_lblName.Size = new System.Drawing.Size(30, 13);
            this.m_lblName.TabIndex = 1;
            this.m_lblName.Text = "Nafn";
            // 
            // m_lblDescription
            // 
            this.m_lblDescription.AutoSize = true;
            this.m_lblDescription.Location = new System.Drawing.Point(51, 98);
            this.m_lblDescription.Name = "m_lblDescription";
            this.m_lblDescription.Size = new System.Drawing.Size(37, 13);
            this.m_lblDescription.TabIndex = 2;
            this.m_lblDescription.Text = "L�sing";
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.Location = new System.Drawing.Point(104, 98);
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtDescription.Size = new System.Drawing.Size(317, 88);
            this.m_txtDescription.TabIndex = 3;
            // 
            // m_lblPicture
            // 
            this.m_lblPicture.AutoSize = true;
            this.m_lblPicture.Location = new System.Drawing.Point(51, 245);
            this.m_lblPicture.Name = "m_lblPicture";
            this.m_lblPicture.Size = new System.Drawing.Size(33, 13);
            this.m_lblPicture.TabIndex = 4;
            this.m_lblPicture.Text = "Mynd";
            // 
            // m_lblUrl
            // 
            this.m_lblUrl.AutoSize = true;
            this.m_lblUrl.Location = new System.Drawing.Point(30, 307);
            this.m_lblUrl.Name = "m_lblUrl";
            this.m_lblUrl.Size = new System.Drawing.Size(58, 13);
            this.m_lblUrl.TabIndex = 5;
            this.m_lblUrl.Text = "Heimas��a";
            // 
            // m_txtUrl
            // 
            this.m_txtUrl.Location = new System.Drawing.Point(104, 304);
            this.m_txtUrl.Name = "m_txtUrl";
            this.m_txtUrl.Size = new System.Drawing.Size(218, 20);
            this.m_txtUrl.TabIndex = 6;
            // 
            // m_btnOK
            // 
            this.m_btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_btnOK.Location = new System.Drawing.Point(405, 380);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(75, 23);
            this.m_btnOK.TabIndex = 9;
            this.m_btnOK.Text = "OK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            // 
            // m_btnBrowse
            // 
            this.m_btnBrowse.Location = new System.Drawing.Point(307, 239);
            this.m_btnBrowse.Name = "m_btnBrowse";
            this.m_btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.m_btnBrowse.TabIndex = 10;
            this.m_btnBrowse.Text = "...";
            this.m_btnBrowse.UseVisualStyleBackColor = true;
            this.m_btnBrowse.Click += new System.EventHandler(this.m_btnBrowse_Click);
            // 
            // m_txtFileName
            // 
            this.m_txtFileName.Location = new System.Drawing.Point(104, 242);
            this.m_txtFileName.Name = "m_txtFileName";
            this.m_txtFileName.Size = new System.Drawing.Size(158, 20);
            this.m_txtFileName.TabIndex = 11;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Location = new System.Drawing.Point(499, 380);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_btnCancel.TabIndex = 12;
            this.m_btnCancel.Text = "H�tta vi�";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // ArtistDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 425);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_txtFileName);
            this.Controls.Add(this.m_btnBrowse);
            this.Controls.Add(this.m_btnOK);
            this.Controls.Add(this.m_txtUrl);
            this.Controls.Add(this.m_lblUrl);
            this.Controls.Add(this.m_lblPicture);
            this.Controls.Add(this.m_txtDescription);
            this.Controls.Add(this.m_lblDescription);
            this.Controls.Add(this.m_lblName);
            this.Controls.Add(this.m_txtName);
            this.Name = "ArtistDlg";
            this.Text = "ArtistDlg";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_txtName;
        private System.Windows.Forms.Label m_lblName;
        private System.Windows.Forms.Label m_lblDescription;
        private System.Windows.Forms.TextBox m_txtDescription;
        private System.Windows.Forms.Label m_lblPicture;
        private System.Windows.Forms.Label m_lblUrl;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox m_txtUrl;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Button m_btnBrowse;
        private System.Windows.Forms.TextBox m_txtFileName;
        private System.Windows.Forms.Button m_btnCancel;
    }
}