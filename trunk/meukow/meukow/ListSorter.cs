using System;
// Til a� geta nota� ListViewItem:
using System.Windows.Forms;
// Til a� geta v�sa� � IComparer:
using System.Collections;
using ClassLibrary;

namespace meukow
{
	/// <summary>
	/// StudentListSorter s�r um r��un � nemendum. Notist 
	/// me� ListView st�ringum.
	/// </summary>
	public class ListSorter
		: IComparer
	{
		private ListColumns m_column;
		private SortOrder m_order;

		/// <summary>
		/// StudentListSorter hefur a�eins einn smi�, enda getur hann ekki virka�
		/// nema hann viti annarsvegar eftir hva�a d�lki er veri� a� ra�a, og
		/// hins vegar hvernig vi�komandi d�lki var ra�a� s��ast.
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

			// H�r er gert r�� fyrir �v� a� Tag s�rhverrar f�rslu
			// innihaldi tilv�sun � Student tilvik:
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

			// Ef s��ast var ra�a� � vaxandi r�� �� viljum vi� ra�a n�na
			// � minnkandi r��. Gerum �a� me� �v� a� sn�a vi� skilagildinu h�r:
			if (m_order == SortOrder.Ascending)
			{
				nRetval = -nRetval;
			}

			return nRetval;
		}
	}
}