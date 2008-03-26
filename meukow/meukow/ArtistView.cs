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
    /// StudentListColumns skilgreinir annars vegar hvaða dálkar eru
    /// í listanum, og hins vegar hversu margir dálkar þeir eru. Þetta enum
    /// þarf að uppfæra ef dálkarnir breytast í design hlutanum.
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
        /// OnLoad er keyrt í upphafi. Við notum það til þess að sækja allar 
        /// færslur og birta í listanum.
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
        /// ListViewItem færslu sem táknar þetta lag.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private ListViewItem GetListViewItem(Artist artist)
        {
            // Fyrsti dálkurinn birtir nafn:
            ListViewItem item = new ListViewItem(artist.Name.ToString());

            // Annar dálkurinn birtir kennitölu:
            item.SubItems.Add(artist.Description.ToString());
            item.SubItems.Add(artist.Picture.ToString());
            item.SubItems.Add(artist.URL.ToString());

            // Allir nemendur fá sama icon í þetta skiptið:
            item.ImageIndex = 0;
            // en ImageList getur geymt margar myndir, og sérhver færsla
            // getur haft mismunandi image index.

            // Látum sérhvert ListViewItem vita hvaða nemandi 
            // hangir við hverja færslu:
            item.Tag = Name;

            // Nóg í bili...
            return item;
        }

        /// <summary>
        /// HandleError sér um að birta villuskilaboð á 
        /// einhvern (mis)smekklega hátt (má sjálfsagt laga...):
        /// </summary>
        /// <param name="ex"></param>
        protected static void HandleError(Exception ex)
        {
            // Hér mætti örugglega koma með vinalegri villuboð:
            MessageBox.Show("Eftirfarandi villa kom upp: \n\n" + ex.Message);
        }

        #endregion
    }
}
