using System.Windows.Forms;
using System.Collections;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// ChartSorter that inherits IComparer
	/// </summary>
	public class ChartSorter : IComparer
	{
		#region Member variables
		private readonly ChartColumns m_column;
		private readonly SortOrder m_order;
		#endregion

		#region Public funtions
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="column">SongColumns</param>
		/// <param name="order">Sortorder</param>
		public ChartSorter(ChartColumns column, SortOrder order)
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

			Chart chart1 = (Chart)item1.Tag;
			Chart chart2 = (Chart)item2.Tag;

			int nRetval = 0;
			switch (m_column)
			{
				case ChartColumns.ColPosition:
					nRetval = chart1.Position.CompareTo(chart2.Position);
					break;
				case ChartColumns.ColSong:
					nRetval = chart1.SongName.CompareTo(chart2.SongName);
					break;
				case ChartColumns.ColArtist:
					nRetval = chart1.ArtistName.CompareTo(chart2.ArtistName);
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
