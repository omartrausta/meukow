using System;
using System.Windows.Forms;
using System.Collections;
using ClassLibrary;

namespace meukow
{
	public class SongSorter
		: IComparer
	{
		private SongColumns m_column;
		private SortOrder m_order;

		/// <summary>
		/// StudentListSorter hefur a�eins einn smi�, enda getur hann ekki virka�
		/// nema hann viti annarsvegar eftir hva�a d�lki er veri� a� ra�a, og
		/// hins vegar hvernig vi�komandi d�lki var ra�a� s��ast.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="order"></param>
		public SongSorter(SongColumns column, SortOrder order)
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

