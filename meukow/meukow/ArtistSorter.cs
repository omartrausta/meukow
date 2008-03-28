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
		/// StudentListSorter hefur a�eins einn smi�, enda getur hann ekki virka�
		/// nema hann viti annarsvegar eftir hva�a d�lki er veri� a� ra�a, og
		/// hins vegar hvernig vi�komandi d�lki var ra�a� s��ast.
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

			// H�r er gert r�� fyrir �v� a� Tag s�rhverrar f�rslu
			// innihaldi tilv�sun � Student tilvik:
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
