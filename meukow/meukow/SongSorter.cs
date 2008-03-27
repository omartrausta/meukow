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
		/// StudentListSorter hefur aðeins einn smið, enda getur hann ekki virkað
		/// nema hann viti annarsvegar eftir hvaða dálki er verið að raða, og
		/// hins vegar hvernig viðkomandi dálki var raðað síðast.
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

			// Hér er gert ráð fyrir því að Tag sérhverrar færslu
			// innihaldi tilvísun á Student tilvik:
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

