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
        private void OnSortList(object sender, ColumnClickEventArgs e)
        {
            SortOrder lastOrder = m_arrLastSortOrder[e.Column];
            m_arrLastSortOrder[e.Column] = (lastOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            m_listViewArtist.ListViewItemSorter = new ArtistSorter((ArtistColumn)e.Column, lastOrder);
        }

        /// <summary>
		/// OnDoubleClickStudent er event handler fyrir �a� �egar er tv�smellt
		/// � f�rslu � listanum.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuNewArtist( object sender, EventArgs e )
		{
			OnNewArtist( );
		}

		/// <summary>
		/// OnSortArtist er event handler fyrir �a� �egar er smellt � d�lk
		/// � Artistlistanum.
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
		/// Fall sem er tengt vi� Context menu listans.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuDeleteArtist( object sender, EventArgs e )
		{
			OnDeleteArtist( );
		}

		/// <summary>
		/// Anna� Context menu fall.
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
		/// OnUpdateStudent er nota� til a� breyta tiltekinni f�rslu.
		/// Falli� passar upp � a� gera ekkert ef engin f�rsla er valin.
		/// </summary>
		public void OnUpdateArtist( )
		{
			try
			{
				// T�kkum � �v� hvort �a� s� ekki �rugglega einhver valinn:
				if ( m_listViewArtist.SelectedItems.Count == 1 )
				{
					// ListView � ekkert SelectedItem property, en skilar
					// hinsvegar collection af v�ldum f�rslum, �v� s�
					// m�guleiki er fyrir hendi a� ListView s� MultiSelect.
					// Vi� erum samt ekki a� nota okkur MultiSelect � �essu
					// tilfelli (sj� properties fyrir ListView st�ringuna).
					ListViewItem listViewItem = m_listViewArtist.SelectedItems[ 0 ];

					// �etta typecast er � lagi �v� GetListViewItem s�r alltaf
					// um a� setja Student tilvik inn � Tag property-i� � 
					// s�rhverju itemi:
					Artist artist = (Artist)listViewItem.Tag;

					using ( ArtistDlg dlg = new ArtistDlg( ) )
					{
						dlg.Artist = artist;

						if ( dlg.ShowDialog( ) == DialogResult.OK )
						{
							// S�kjum g�gnin aftur �r samtalsglugganum:
							artist = dlg.Artist;

							// L�tum vinnslulagi� uppf�ra nemandann. Ef �a�
							// mistekst er kasta� villu.
							Document.UpdateArtist( artist );

							int nIndex = listViewItem.Index;
							// Vi� uppf�rum f�rsluna me� �v� a� fjarl�gja �� sem
							// er fyrir og setja n�ja inn:
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
		/// OnNewStudent s�r um a� leyfa notandanum a� b�a til n�jan
		/// nemanda, og birta hann ef �a� tekst.
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

						// Ef �etta klikkar ver�ur kasta� villu:
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
		/// Gettu hva� �etta fall gerir...
		/// </summary>
		public void OnDeleteArtist( )
		{
			try
			{
				if ( m_listViewArtist.SelectedItems.Count == 1 )
				{
					if ( MessageBox.Show( "Ertu viss um a� �� viljir ey�a �essum flytjanda?", "DeleteArtist",
						MessageBoxButtons.OKCancel, MessageBoxIcon.Warning ) == DialogResult.OK )
					{
						ListViewItem listViewItem = m_listViewArtist.SelectedItems[ 0 ];
						// Sama gildir h�r og � OnEditStudent.
						Artist artist = (Artist)listViewItem.Tag;

						// H�r ver�ur kasta� villu ef �etta mistekst:
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
        /// ListViewItem f�rslu sem t�knar �etta lag.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected ListViewItem GetListViewItem(Artist artist)
        {
            // Fyrsti d�lkurinn birtir nafn:
            ListViewItem item = new ListViewItem(artist.Name.ToString());

            // Annar d�lkurinn birtir kennit�lu:
            item.SubItems.Add(artist.Description.ToString());
            item.SubItems.Add(artist.Picture.ToString());
            item.SubItems.Add(artist.URL.ToString());

            // Allir flytjendur f� sama icon � �etta skipti�:
            item.ImageIndex = 0;
            // en ImageList getur geymt margar myndir, og s�rhver f�rsla
            // getur haft mismunandi image index.

            // L�tum s�rhvert ListViewItem vita hva�a flytjandi 
            // hangir vi� hverja f�rslu:
            item.Tag = artist;

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
        protected String OnSelectList()
        {
            if (m_listViewArtist.SelectedItems.Count == 1)
            {
                ListViewItem listViewItem = m_listViewArtist.SelectedItems[0];

                // �etta typecast er � lagi �v� GetListViewItem s�r alltaf
                // um a� setja Student tilvik inn � Tag property-i� � 
                // s�rhverju itemi:
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
