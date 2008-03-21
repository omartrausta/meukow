using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
public	class ArtistConnection : IDataItem
	{
        #region Member variables

        private int m_nIDParent;
        private int m_nIDChild;


        #endregion

        #region Properties
        /// <summary>
        /// public int property for IDParent
        /// </summary>
        public int IDParent
        {
            get { return m_nIDParent; }
            set { m_nIDParent = value; }
        }
        /// <summary>
        /// public int property for IDChild
        /// </summary>
        public int IDChild
        {
            get { return m_nIDChild; }
            set { m_nIDChild = value; }
        }

        #endregion

        #region Constructors

		public ArtistConnection( )
		{
		}

    #region Overridden functions

    public override string ToString()
    {
        return m_nIDParent.ToString();
    }

    #endregion	
   
    public ArtistConnection( DataRow row )
		{
            m_nIDParent = Convert.ToInt32(row["IDParent"]);
		    m_nIDChild = Convert.ToInt32(row["IDChild"]);
          
		}

		#endregion
        #region IDataList implementation
        public void Load(IDataReader reader)
        {
            m_nIDParent = Convert.ToInt32(reader["IDParent"]);
            m_nIDChild = Convert.ToInt32(reader["IDChild"]);
    
        }

        /// <summary>
        /// Fall sem skilar TableDescription hlut, en �ennan hlut m� svo
        /// nota �egar tilvik af klasanum er uppf�rt e�a n�skr��.
        /// Athugi� a� �etta fall �arf ekki endilega a� v�sa � s�mu d�lka
        /// og Load falli�, h�r �tti a�eins a� v�sa � d�lkan�fn � t�flunni
        /// sem �essi klasi tengist, en Load falli� g�ti t.d. s�tt g�gn
        /// �r ��rum d�lkum sem v�ri skila� me� INNER JOIN skipun.
        /// </summary>
        /// <returns></returns>
        public TableDescription GetTable()
        {
            ColumnDescription[] columns = 
			{
				new ColumnDescription( "IDParent", this.IDParent, DbType.Int32, true ),
				new ColumnDescription( "IDChild", this.IDChild, DbType.Int32),
				
			};
            return new TableDescription("ArtistConnection	", columns);
        }

        #endregion
    }
    /// <summary>
    /// StudentSorter s�r um a� ra�a tilvikum af Student.
    /// </summary>

    public class ArtistConnectionSorter : IComparer<ArtistConnection>
    {
        #region Member variables
        private String m_strOrderBy;
        #endregion

        #region Constructors
        public ArtistConnectionSorter(String strOrderBy)
        {
            m_strOrderBy = strOrderBy;
        }
        #endregion

        #region IComparer implementation
        public int Compare(ArtistConnection x, ArtistConnection y)
        {
            switch (m_strOrderBy)
            {
                case "IDParent":
                    return x.IDParent.CompareTo(y.IDParent);
                case "IDChild":
                    return x.IDChild.CompareTo(y.IDChild);
               
            }

            return 0;
        }
        #endregion
    }

    public class ArtistConnectionCollection : DataList<ArtistConnection>
    {
        #region Public functions
        public void Sort(String strOrderBy)
        {
            ArtistConnectionSorter sorter = new ArtistConnectionSorter(strOrderBy);
            base.Sort(sorter);
        }
        #endregion
    }

}