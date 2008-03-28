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
        private SortOrder[] m_arrLastSortOrder = new SortOrder[(int)ArtistColumn.NumberOfColumns];
        private ArtistDoc m_document;
        #endregion

        #region Event Handlers
        public delegate void HitArtistHandler(string msg);
        public event HitArtistHandler HitArtistSelected;
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
        private void OnSortList(object sender, ColumnClickEventArgs e)
        {
            SortOrder lastOrder = m_arrLastSortOrder[e.Column];
            m_arrLastSortOrder[e.Column] = (lastOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            m_listViewArtist.ListViewItemSorter = new ArtistSorter((ArtistColumn)e.Column, lastOrder);
        }

        /// <summary>
		/// OnDoubleClickStudent er event handler fyrir það þegar er tvísmellt
		/// á færslu í listanum.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuNewArtist( object sender, EventArgs e )
		{
			OnNewArtist( );
		}

		/// <summary>
		/// OnSortArtist er event handler fyrir það þegar er smellt á dálk
		/// í Artistlistanum.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/*private void OnSortArtist( object sender, ColumnClickEventArgs e )
		{
			SortOrder lastOrder = m_arrLastSortOrder[ e.Column ];
			m_arrLastSortOrder[ e.Column ] = ( lastOrder == SortOrder.Ascending ) ? SortOrder.Descending : SortOrder.Ascending;
			m_listViewArtist.ListViewItemSorter = new ArtistListSorter( (ArtistListColumns)e.Column, lastOrder );
		}*/

		/// <summary>
		/// Fall sem er tengt við Context menu listans.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuDeleteArtist( object sender, EventArgs e )
		{
			OnDeleteArtist( );
		}

		/// <summary>
		/// Annað Context menu fall.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuEditArtist( object sender, EventArgs e )
		{
			OnUpdateArtist( );
		}
		#endregion

		#region Public functions
		/// <summary>
		/// OnUpdateStudent er notað til að breyta tiltekinni færslu.
		/// Fallið passar upp á að gera ekkert ef engin færsla er valin.
		/// </summary>
		public void OnUpdateArtist( )
		{
			try
			{
				// Tékkum á því hvort það sé ekki örugglega einhver valinn:
				if ( m_listViewArtist.SelectedItems.Count == 1 )
				{
					// ListView á ekkert SelectedItem property, en skilar
					// hinsvegar collection af völdum færslum, því sá
					// möguleiki er fyrir hendi að ListView sé MultiSelect.
					// Við erum samt ekki að nota okkur MultiSelect í þessu
					// tilfelli (sjá properties fyrir ListView stýringuna).
					ListViewItem listViewItem = m_listViewArtist.SelectedItems[ 0 ];

					// Þetta typecast er í lagi því GetListViewItem sér alltaf
					// um að setja Student tilvik inn í Tag property-ið á 
					// sérhverju itemi:
					Artist artist = (Artist)listViewItem.Tag;

					using ( ArtistDlg dlg = new ArtistDlg( ) )
					{
						dlg.Artist = artist;

						if ( dlg.ShowDialog( ) == DialogResult.OK )
						{
							// Sækjum gögnin aftur úr samtalsglugganum:
							artist = dlg.Artist;

							// Látum vinnslulagið uppfæra nemandann. Ef það
							// mistekst er kastað villu.
							Document.UpdateArtist( artist );

							int nIndex = listViewItem.Index;
							// Við uppfærum færsluna með því að fjarlægja þá sem
							// er fyrir og setja nýja inn:
							m_listViewArtist.Items.Remove( listViewItem );
							m_listViewArtist.Items.Insert( nIndex, GetListViewItem( artist ) );
						}
					}
				}
			}
			catch ( Exception ex )
			{
				HandleError( ex );
			}
		}

		/// <summary>
		/// OnNewStudent sér um að leyfa notandanum að búa til nýjan
		/// nemanda, og birta hann ef það tekst.
		/// </summary>
		public void OnNewArtist( )
		{
			try
			{
				using ( ArtistDlg dlg = new ArtistDlg( ) )
				{
					dlg.Artist = new Artist( );
					if ( dlg.ShowDialog( ) == DialogResult.OK )
					{
						Artist artist = dlg.Artist;

						// Ef þetta klikkar verður kastað villu:
						Document.AddArtist( artist );

                        m_listViewArtist.Items.Add(GetListViewItem(artist));
					}
				}
			}
			catch ( Exception ex )
			{
				HandleError( ex );
			}
		}

		/// <summary>
		/// Gettu hvað þetta fall gerir...
		/// </summary>
		public void OnDeleteArtist( )
		{
			try
			{
				if ( m_listViewArtist.SelectedItems.Count == 1 )
				{
					if ( MessageBox.Show( "Ertu viss um að þú viljir eyða þessum flytjanda?", "DeleteArtist",
						MessageBoxButtons.OKCancel, MessageBoxIcon.Warning ) == DialogResult.OK )
					{
						ListViewItem listViewItem = m_listViewArtist.SelectedItems[ 0 ];
						// Sama gildir hér og í OnEditStudent.
						Artist artist = (Artist)listViewItem.Tag;

						// Hér verður kastað villu ef þetta mistekst:
						Document.DeleteArtist( artist );
						m_listViewArtist.Items.Remove( listViewItem );
					}
				}
			}
			catch ( Exception ex )
			{
				HandleError( ex );
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
        protected ListViewItem GetListViewItem(Artist artist)
        {
            // Fyrsti dálkurinn birtir nafn:
            ListViewItem item = new ListViewItem(artist.Name.ToString());

            // Annar dálkurinn birtir kennitölu:
            item.SubItems.Add(artist.Description.ToString());
            item.SubItems.Add(artist.Picture.ToString());
            item.SubItems.Add(artist.URL.ToString());

            // Allir flytjendur fá sama icon í þetta skiptið:
            item.ImageIndex = 0;
            // en ImageList getur geymt margar myndir, og sérhver færsla
            // getur haft mismunandi image index.

            // Látum sérhvert ListViewItem vita hvaða flytjandi 
            // hangir við hverja færslu:
            item.Tag = artist;

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
        protected String OnSelectList()
        {
            if (m_listViewArtist.SelectedItems.Count == 1)
            {
                ListViewItem listViewItem = m_listViewArtist.SelectedItems[0];

                // Þetta typecast er í lagi því GetListViewItem sér alltaf
                // um að setja Student tilvik inn í Tag property-ið á 
                // sérhverju itemi:
                List list = (List)listViewItem.Tag;

                return list.ID.ToString();
            }
            else
                return null;
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (HitArtistSelected != null)
            {
                String nID = OnSelectList();
                if (nID != null)
                {
                    HitArtistSelected(nID);
                }
            }
        }

        
       
    }
}
