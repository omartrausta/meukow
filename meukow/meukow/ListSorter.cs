using System;
// Til að geta notað ListViewItem:
using System.Windows.Forms;
// Til að geta vísað í IComparer:
using System.Collections;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// StudentListSorter sér um röðun á nemendum. Notist 
	/// með ListView stýringum.
	/// </summary>
	public class ListSorter
		: IComparer
	{
		private ListColumns m_column;
		private SortOrder m_order;

		/// <summary>
		/// StudentListSorter hefur aðeins einn smið, enda getur hann ekki virkað
		/// nema hann viti annarsvegar eftir hvaða dálki er verið að raða, og
		/// hins vegar hvernig viðkomandi dálki var raðað síðast.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="order"></param>
		public ListSorter(ListColumns column, SortOrder order)
		{
			m_column = column;
			m_order = order;
		}

		public int Compare(object a, object b)
		{
			ListViewItem item1 = (ListViewItem)a;
			ListViewItem item2 = (ListViewItem)b;

			// Hér er gert ráð fyrir því að Tag sérhverrar færslu
			// innihaldi tilvísun á Student tilvik:
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

			// Ef síðast var raðað í vaxandi röð þá viljum við raða núna
			// í minnkandi röð. Gerum það með því að snúa við skilagildinu hér:
			if (m_order == SortOrder.Ascending)
			{
				nRetval = -nRetval;
			}

			return nRetval;
		}
	}
}