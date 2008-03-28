using System;
using System.Windows.Forms;
using System.Collections;
using ClassLibrary;


namespace meukow
{
    public class ArtistSorter : IComparer
    {
        private ArtistColumn m_column;
		private SortOrder m_order;

		/// <summary>
		/// StudentListSorter hefur aðeins einn smið, enda getur hann ekki virkað
		/// nema hann viti annarsvegar eftir hvaða dálki er verið að raða, og
		/// hins vegar hvernig viðkomandi dálki var raðað síðast.
		/// </summary>
		/// <param name="column"></param>
		/// <param name="order"></param>
        public ArtistSorter(ArtistColumn column, SortOrder order)
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
