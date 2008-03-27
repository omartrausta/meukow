using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary.Common.Data;
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
        private Artist m_artist;
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
                //m_artist.Picture = .Text;
                m_artist.URL = m_txtUrl.Text;
                return m_artist;
            }
            set
            {
                m_artist = value;
                m_txtName.Text = m_artist.Name;
                m_txtDescription.Text = m_artist.Description;
               // m_txtSSN.Text = m_student.SSN;
                m_txtUrl.Text = m_artist.URL;
            }
        }
        #endregion
    }
}