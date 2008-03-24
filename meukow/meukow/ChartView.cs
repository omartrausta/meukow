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
	public partial class ChartView : UserControl
	{
		#region Member variables
		private List m_list;
		#endregion

		#region Constructors
		public ChartView()
		{
			InitializeComponent();
		}
		#endregion

		#region Properties
		public List List
		{
			get
			{
				return m_list;
			}
			set
			{
				m_list = value;
			}
		}
		#endregion

		public void GetList( )
		{
			ListPropCollection propCollection = new ListPropCollection();
			ListPropDoc listPropDoc = new ListPropDoc();
			SongDoc songDoc = new SongDoc();
			ArtistDoc artistDoc = new ArtistDoc();
			
			propCollection = listPropDoc.GetListPropByList( m_list.ID);

			foreach (ListProp listProp in propCollection)
			{
				ListViewItem item = new ListViewItem(listProp.Position.ToString());

				Song song = new Song();
				song = songDoc.GetSong(listProp.Song);
				item.SubItems.Add(song.Name);

				Artist artist = new Artist();
				artist = artistDoc.GetArtist(song.ArtistID);
				item.SubItems.Add(artist.Name);

				item.ImageIndex = 0;
				item.Tag = listProp;

				m_listViewChart.Items.Add(item);
			}
		}

	}
}
