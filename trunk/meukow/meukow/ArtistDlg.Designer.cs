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
					this.components = new System.ComponentModel.Container();
					this.m_txtName = new System.Windows.Forms.TextBox();
					this.m_lblName = new System.Windows.Forms.Label();
					this.m_lblDescription = new System.Windows.Forms.Label();
					this.m_txtDescription = new System.Windows.Forms.TextBox();
					this.m_lblPicture = new System.Windows.Forms.Label();
					this.m_lblUrl = new System.Windows.Forms.Label();
					this.m_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
					this.m_txtUrl = new System.Windows.Forms.TextBox();
					this.m_btnOK = new System.Windows.Forms.Button();
					this.m_txtFileName = new System.Windows.Forms.TextBox();
					this.m_btnCancel = new System.Windows.Forms.Button();
					this.m_validator = new Itboy.Components.Validator(this.components);
					this.SuspendLayout();
					// 
					// m_txtName
					// 
					this.m_txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_txtName.Location = new System.Drawing.Point(85, 12);
					this.m_txtName.Name = "m_txtName";
					this.m_txtName.Size = new System.Drawing.Size(271, 21);
					this.m_txtName.TabIndex = 0;
					this.m_validator.SetType(this.m_txtName, Itboy.Components.ValidationType.Required);
					// 
					// m_lblName
					// 
					this.m_lblName.AutoSize = true;
					this.m_lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_lblName.Location = new System.Drawing.Point(16, 15);
					this.m_lblName.Name = "m_lblName";
					this.m_lblName.Size = new System.Drawing.Size(33, 15);
					this.m_lblName.TabIndex = 1;
					this.m_lblName.Text = "Nafn";
					// 
					// m_lblDescription
					// 
					this.m_lblDescription.AutoSize = true;
					this.m_lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_lblDescription.Location = new System.Drawing.Point(12, 39);
					this.m_lblDescription.Name = "m_lblDescription";
					this.m_lblDescription.Size = new System.Drawing.Size(42, 15);
					this.m_lblDescription.TabIndex = 2;
					this.m_lblDescription.Text = "Lýsing";
					// 
					// m_txtDescription
					// 
					this.m_txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_txtDescription.Location = new System.Drawing.Point(85, 39);
					this.m_txtDescription.Multiline = true;
					this.m_txtDescription.Name = "m_txtDescription";
					this.m_txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
					this.m_txtDescription.Size = new System.Drawing.Size(271, 88);
					this.m_txtDescription.TabIndex = 3;
					// 
					// m_lblPicture
					// 
					this.m_lblPicture.AutoSize = true;
					this.m_lblPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_lblPicture.Location = new System.Drawing.Point(17, 136);
					this.m_lblPicture.Name = "m_lblPicture";
					this.m_lblPicture.Size = new System.Drawing.Size(37, 15);
					this.m_lblPicture.TabIndex = 4;
					this.m_lblPicture.Text = "Mynd";
					// 
					// m_lblUrl
					// 
					this.m_lblUrl.AutoSize = true;
					this.m_lblUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_lblUrl.Location = new System.Drawing.Point(17, 163);
					this.m_lblUrl.Name = "m_lblUrl";
					this.m_lblUrl.Size = new System.Drawing.Size(67, 15);
					this.m_lblUrl.TabIndex = 5;
					this.m_lblUrl.Text = "Heimasíða";
					// 
					// m_txtUrl
					// 
					this.m_txtUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_txtUrl.Location = new System.Drawing.Point(85, 160);
					this.m_txtUrl.Name = "m_txtUrl";
					this.m_txtUrl.Size = new System.Drawing.Size(271, 21);
					this.m_txtUrl.TabIndex = 6;
					// 
					// m_btnOK
					// 
					this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
					this.m_btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_btnOK.Location = new System.Drawing.Point(200, 187);
					this.m_btnOK.Name = "m_btnOK";
					this.m_btnOK.Size = new System.Drawing.Size(75, 23);
					this.m_btnOK.TabIndex = 9;
					this.m_btnOK.Text = "Í lagi";
					this.m_btnOK.UseVisualStyleBackColor = true;
					// 
					// m_txtFileName
					// 
					this.m_txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_txtFileName.Location = new System.Drawing.Point(85, 133);
					this.m_txtFileName.Name = "m_txtFileName";
					this.m_txtFileName.Size = new System.Drawing.Size(271, 21);
					this.m_txtFileName.TabIndex = 11;
					// 
					// m_btnCancel
					// 
					this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					this.m_btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
					this.m_btnCancel.Location = new System.Drawing.Point(281, 187);
					this.m_btnCancel.Name = "m_btnCancel";
					this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
					this.m_btnCancel.TabIndex = 12;
					this.m_btnCancel.Text = "Hætta við";
					this.m_btnCancel.UseVisualStyleBackColor = true;
					// 
					// m_validator
					// 
					this.m_validator.Form = this;
					// 
					// ArtistDlg
					// 
					this.AcceptButton = this.m_btnOK;
					this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
					this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
					this.CancelButton = this.m_btnCancel;
					this.ClientSize = new System.Drawing.Size(382, 218);
					this.Controls.Add(this.m_btnCancel);
					this.Controls.Add(this.m_txtFileName);
					this.Controls.Add(this.m_btnOK);
					this.Controls.Add(this.m_txtUrl);
					this.Controls.Add(this.m_lblUrl);
					this.Controls.Add(this.m_lblPicture);
					this.Controls.Add(this.m_txtDescription);
					this.Controls.Add(this.m_lblDescription);
					this.Controls.Add(this.m_lblName);
					this.Controls.Add(this.m_txtName);
					this.MaximizeBox = false;
					this.MinimizeBox = false;
					this.Name = "ArtistDlg";
					this.ShowInTaskbar = false;
					this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
					this.Text = "Flytjandi";
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
        private System.Windows.Forms.FolderBrowserDialog m_folderBrowserDialog;
        private System.Windows.Forms.TextBox m_txtUrl;
			private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.TextBox m_txtFileName;
        private System.Windows.Forms.Button m_btnCancel;
			private Itboy.Components.Validator m_validator;
    }
}