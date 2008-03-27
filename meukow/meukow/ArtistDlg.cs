using System;
using System.Windows.Forms;
using ClassLibrary;

namespace meukow
{
    /// <summary>
    /// StudentDlg sér um hvorutveggja: að leyfa nýskráningu á nemanda,
    /// og að leyfa uppfærslu á nemanda.
    /// Hann validerar input með hjálp ákaflega skemmtilegrar stýringar, sjá:
    /// http://www.codeproject.com/KB/validation/Validator.aspx
    /// </summary>
    public partial class ArtistDlg : Form
    {
        #region Member variables
        private const String FILE_DIALOG_FILTER = "Myndaskrá (*.jpg)|*.jpg";
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
            // OpenFileDialog tilvik búið til
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Skrártegundir síaðar út eftir fasta
            openFileDialog.Filter = FILE_DIALOG_FILTER;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Skráarnafnið vistað sem strengur í memberbreytu
               

             Filename = openFileDialog.FileName;
                // Skrárnafnið sett í textaboxið
                m_txtFileName.Text = Filename;
            }
        }
    }
}