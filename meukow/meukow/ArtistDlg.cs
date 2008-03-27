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
    /// StudentDlg s�r um hvorutveggja: a� leyfa n�skr�ningu � nemanda,
    /// og a� leyfa uppf�rslu � nemanda.
    /// Hann validerar input me� hj�lp �kaflega skemmtilegrar st�ringar, sj�:
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