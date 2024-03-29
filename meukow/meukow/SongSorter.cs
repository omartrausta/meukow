using System.Windows.Forms;
using System.Collections;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// SongSorter that inherits IComparer
	/// </summary>
	public class SongSorter : IComparer
	{
		#region Member variables
		private readonly SongColumns m_column;
		private readonly SortOrder m_order;
		#endregion

		#region Public funtions
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="column">SongColumns</param>
		/// <param name="order">Sortorder</param>
		public SongSorter(SongColumns column, SortOrder order)
		{
			m_column = column;
			m_order = order;
		}

		/// <summary>
		/// Function that compares two instances of Song.
		/// </summary>
		/// <param name="a">Instance a of object</param>
		/// <param name="b">Instance b of object</param>
		/// <returns></returns>
		public int Compare(object a, object b)
		{
			ListViewItem item1 = (ListViewItem)a;
			ListViewItem item2 = (ListViewItem)b;

			Song song1 = (Song)item1.Tag;
			Song song2 = (Song)item2.Tag;

			int nRetval = 0;
			switch (m_column)
			{
				case SongColumns.ColName:
					nRetval = song1.Name.CompareTo(song2.Name);
					break;
				case SongColumns.ColArtist:
					nRetval = song1.Artist.CompareTo(song2.Artist);
					break;
				case SongColumns.ColSongpath:
					nRetval = song1.SongPath.CompareTo(song2.SongPath);
					break;
				case SongColumns.ColDescription:
					nRetval = song1.Description.CompareTo(song2.Description);
					break;
			}

			if (m_order == SortOrder.Ascending)
			{
				nRetval = -nRetval;
			}

			return nRetval;
		}
		#endregion
	}
}

