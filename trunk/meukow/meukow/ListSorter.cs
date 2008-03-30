using System.Windows.Forms;
using System.Collections;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// ListSorter that inherits IComparer
	/// </summary>
	public class ListSorter : IComparer
	{
		#region Member variables
		private readonly ListColumns m_column;
		private readonly SortOrder m_order;
		#endregion

		#region Public funtions
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="column">ListColumns</param>
		/// <param name="order">Sortorder</param>
		public ListSorter(ListColumns column, SortOrder order)
		{
			m_column = column;
			m_order = order;
		}

		/// <summary>
		/// Function that compares two instances of List.
		/// </summary>
		/// <param name="a">Instance a of object</param>
		/// <param name="b">Instance b of object</param>
		/// <returns></returns>
		public int Compare(object a, object b)
		{
			ListViewItem item1 = (ListViewItem)a;
			ListViewItem item2 = (ListViewItem)b;

			List list1 = (List)item1.Tag;
			List list2 = (List)item2.Tag;

			int nRetval = 0;
			switch (m_column)
			{
				case ListColumns.ColName:
					nRetval = list1.Name.CompareTo(list2.Name);
					break;
				case ListColumns.ColStarts:
					nRetval = list1.Starts.CompareTo(list2.Starts);
					break;
				case ListColumns.ColEnds:
					nRetval = list1.Ends.CompareTo(list2.Ends);
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