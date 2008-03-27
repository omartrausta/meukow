using System;
using System.Windows.Forms;
using ClassLibrary;

namespace meukow
{
    /// <summary>
    /// StudentDlg s�r um hvorutveggja: a� leyfa n�skr�ningu � nemanda,
    /// og a� leyfa uppf�rslu � nemanda.
    /// Hann validerar input me� hj�lp �kaflega skemmtilegrar st�ringar, sj�:
    /// http://www.codeproject.com/KB/validation/Validator.aspx
    /// </summary>
    public partial class ArtistDlg : Form
    {
        #region Member variables
        private const String FILE_DIALOG_FILTER = "Myndaskr� (*.jpg)|*.jpg";
        private Artist m_artist;
        private String m_fileName;

        #endregion

        public ArtistDlg()
        {
            InitializeComponent();
        }
        #region Properties
        public Artist Artist
        {
            get
            {
                m_artist.Name = m_txtName.Text;
                m_artist.Description = m_txtDescription.Text;
                m_artist.Picture = m_txtFileName.Text;
                m_artist.URL = m_txtUrl.Text;
                return m_artist;
            }
            set
            {
                m_artist = value;
                m_txtName.Text = m_artist.Name;
                m_txtDescription.Text = m_artist.Description;
                m_txtFileName.Text = m_artist.Picture;
                m_txtUrl.Text = m_artist.URL;
            }

           
		}
        public String Filename
        {
            get
            {
                return m_fileName;
            }
            set
            {
                m_fileName = value;
            }
        }
        #endregion

        private void m_btnBrowse_Click(object sender, EventArgs e)
        {
            // OpenFileDialog tilvik b�i� til
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Skr�rtegundir s�a�ar �t eftir fasta
            openFileDialog.Filter = FILE_DIALOG_FILTER;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Skr�arnafni� vista� sem strengur � memberbreytu
               

             Filename = openFileDialog.FileName;
                // Skr�rnafni� sett � textaboxi�
                m_txtFileName.Text = Filename;
            }
        }
    }
}