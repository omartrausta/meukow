using System;
using System.Windows.Forms;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// Public enum that includes the name of the columns in the view and
	/// also how many columns are in the view
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
		private readonly SortOrder[] m_arrLastSortOrder = new SortOrder[(int)ArtistColumn.NumberOfColumns];
		private ArtistDoc m_document;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the ArtistDoc document.
		/// </summary>
		public ArtistDoc Document
		{
			get
			{
				return m_document;
			}
			set
			{
				m_document = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public ArtistView()
		{
			InitializeComponent();
		}
		#endregion

		#region Event handlers
		/// <summary>
		/// OnLoad is run when the view is loaded and the view is populated
		/// with data.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLoad(object sender, EventArgs e)
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

		/// <summary>
		/// Catches when the user wants to sort the view.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSortList(object sender, ColumnClickEventArgs e)
		{
			SortOrder lastOrder = m_arrLastSortOrder[e.Column];
			m_arrLastSortOrder[e.Column] = (lastOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
			m_listViewArtist.ListViewItemSorter = new ArtistSorter((ArtistColumn)e.Column, lastOrder);
		}

		/// <summary>
		/// OnMenuNewArtist when the add is selected from context menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuNewArtist( object sender, EventArgs e )
		{
			OnNewArtist( );
		}

		/// <summary>
		/// OnMenuNewArtist when the delete is selected from context menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuDeleteArtist( object sender, EventArgs e )
		{
			OnDeleteArtist( );
		}

		/// <summary>
		/// OnMenuNewArtist when the edit is selected from context menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMenuEditArtist( object sender, EventArgs e )
		{
			OnEditArtist( );
		}
		#endregion

		#region Public functions
		/// <summary>
		/// OnEditArtist is used to change one row in the list.
		/// This function doesn't do anything if nothing is selected.
		/// </summary>
		public void OnEditArtist( )
		{
			try
			{
				if ( m_listViewArtist.SelectedItems.Count == 1 )
				{
					ListViewItem listViewItem = m_listViewArtist.SelectedItems[ 0 ];
					Artist artist = (Artist)listViewItem.Tag;

					using ( ArtistDlg dlg = new ArtistDlg( ) )
					{
						dlg.Artist = artist;

						if ( dlg.ShowDialog( ) == DialogResult.OK )
						{
							artist = dlg.Artist;

							Document.UpdateArtist( artist );

							int nIndex = listViewItem.Index;

							m_listViewArtist.Items.Remove( listViewItem );
							m_listViewArtist.Items.Insert( nIndex, GetListViewItem( artist ) );
						}
					}
				}
				else
				{
					MessageBox.Show("Vinsamlegast veldu flytjanda til að breyta.");
				}

			}
			catch ( Exception ex )
			{
				HandleError( ex );
			}
		}

		/// <summary>
		/// OnNewArtist adds a new artist to the database.
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
						Document.AddArtist(artist);

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
		/// OnDeleteArtist deletes the selected artist.
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
						Artist artist = (Artist)listViewItem.Tag;

						Document.DeleteArtist( artist );
						m_listViewArtist.Items.Remove( listViewItem );
					}
				}
				else
				{
					MessageBox.Show("Vinsamlegast veldu flytjanda til að eyða.");
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
		/// Function that add an instance of Artist into a ListViewItem.
		/// </summary>
		/// <param name="artist">Artist</param>
		/// <returns>ListViewItem</returns>
		protected static ListViewItem GetListViewItem(Artist artist)
		{
			ListViewItem item = new ListViewItem(artist.Name.ToString());

			item.SubItems.Add(artist.Description.ToString());
			item.SubItems.Add(artist.Picture.ToString());
			item.SubItems.Add(artist.URL.ToString());

			item.ImageIndex = 0;
			item.Tag = artist;

			return item;
		}

		/// <summary>
		/// Shows error message.
		/// </summary>
		/// <param name="ex">Exception</param>
		protected static void HandleError(Exception ex)
		{
			MessageBox.Show("Eftirfarandi villa kom upp: \n\n" + ex.Message);
		}
		#endregion
	}
}
