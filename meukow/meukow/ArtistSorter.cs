using System.Windows.Forms;
using System.Collections;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// ArtistSorter that inherits IComparer
	/// </summary>
	public class ArtistSorter : IComparer
	{
		#region Member variables
		private readonly ArtistColumn m_column;
		private readonly SortOrder m_order;
		#endregion

		#region Public functions
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="column">ArtistColumn</param>
		/// <param name="order">Sortorder</param>
		public ArtistSorter(ArtistColumn column, SortOrder order)
		{
			m_column = column;
			m_order = order;
		}

		/// <summary>
		/// Function that compares two instances of Artist.
		/// </summary>
		/// <param name="a">Instance a of object</param>
		/// <param name="b">Instance b of object</param>
		/// <returns></returns>
		public int Compare(object a, object b)
		{
			ListViewItem item1 = (ListViewItem)a;
			ListViewItem item2 = (ListViewItem)b;

			Artist artist1 = (Artist)item1.Tag;
			Artist artist2 = (Artist)item2.Tag;

			int nRetval = 0;
			switch (m_column)
			{
				case ArtistColumn.ColName:
					nRetval = artist1.Name.CompareTo(artist2.Name);
					break;
				case ArtistColumn.ColDescription:
					nRetval = artist1.Description.CompareTo(artist2.Description);
					break;
				case ArtistColumn.ColPicture:
					nRetval = artist1.Picture.CompareTo(artist2.Picture);
					break;
				case ArtistColumn.ColURL:
					nRetval = artist1.URL.CompareTo(artist2.URL);
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
