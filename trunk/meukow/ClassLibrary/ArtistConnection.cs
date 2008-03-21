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
        /// Fall sem skilar TableDescription hlut, en þennan hlut má svo
        /// nota þegar tilvik af klasanum er uppfært eða nýskráð.
        /// Athugið að þetta fall þarf ekki endilega að vísa í sömu dálka
        /// og Load fallið, hér ætti aðeins að vísa í dálkanöfn í töflunni
        /// sem þessi klasi tengist, en Load fallið gæti t.d. sótt gögn
        /// úr öðrum dálkum sem væri skilað með INNER JOIN skipun.
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
    /// StudentSorter sér um að raða tilvikum af Student.
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