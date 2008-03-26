using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace meukow
{
    /// <summary>
    /// StudentListColumns skilgreinir annars vegar hva�a d�lkar eru
    /// � listanum, og hins vegar hversu margir d�lkar �eir eru. �etta enum
    /// �arf a� uppf�ra ef d�lkarnir breytast � design hlutanum.
    /// </summary>
    public enum ArtistColumn
    {
        ColName = 0,
        ColDescription = 1,
        ColPicture = 2,
        ColURL = 3,
        NumberOfColumns = 4
    }
    public partial class ArtistView : UserControl
    {
        #region Member variables
        private SortOrder[] m_arrLastSortOrder = new SortOrder[(int)ListColumns.NumberOfColumns];
        private ArtistDoc m_document;
        #endregion

        #region Properties
        public ArtistDoc Document
        {
            get { return m_document; }
            set { m_document = value; }
        }
        #endregion

        #region Constructors
        public ArtistView()
        {
            InitializeComponent();
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// OnLoad er keyrt � upphafi. Vi� notum �a� til �ess a� s�kja allar 
        /// f�rslur og birta � listanum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnLoad(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                m_document = new ArtistDoc();
               m_listViewArtist.Items.Clear();

                ArtistCollection artists = Document.GetAllArtists();

                foreach (Artist artist in artists)
                {
                    m_listViewArtist.Items.Add(GetListViewItem(artist));
                }
            }
        }
        #endregion

        #region Protected functions
        /// <summary>
        /// Fall sem tekur inn tilvik af Song, og skilar til baka
        /// ListViewItem f�rslu sem t�knar �etta lag.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private ListViewItem GetListViewItem(Artist artist)
        {
            // Fyrsti d�lkurinn birtir nafn:
            ListViewItem item = new ListViewItem(artist.Name.ToString());

            // Annar d�lkurinn birtir kennit�lu:
            item.SubItems.Add(artist.Description.ToString());
            item.SubItems.Add(artist.Picture.ToString());
            item.SubItems.Add(artist.URL.ToString());

            // Allir nemendur f� sama icon � �etta skipti�:
            item.ImageIndex = 0;
            // en ImageList getur geymt margar myndir, og s�rhver f�rsla
            // getur haft mismunandi image index.

            // L�tum s�rhvert ListViewItem vita hva�a nemandi 
            // hangir vi� hverja f�rslu:
            item.Tag = Name;

            // N�g � bili...
            return item;
        }

        /// <summary>
        /// HandleError s�r um a� birta villuskilabo� � 
        /// einhvern (mis)smekklega h�tt (m� sj�lfsagt laga...):
        /// </summary>
        /// <param name="ex"></param>
        protected static void HandleError(Exception ex)
        {
            // H�r m�tti �rugglega koma me� vinalegri villubo�:
            MessageBox.Show("Eftirfarandi villa kom upp: \n\n" + ex.Message);
        }

        #endregion
    }
}
