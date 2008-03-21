using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
public class ListProp : IDataItem
	{

		#region Member variables

		private int m_nID;
		private int m_nSong;
		private int m_nList;
		private int m_nPostion;

		#endregion

		#region Properties

		public int ID
		{
			get { return m_nID; }
			set { m_nID = value; }
		}
		
		public int Song
		{
			get { return m_nSong; }
			set { m_nSong = value; }
		}
		
		public int List
		{
			get { return m_nList; }
			set { m_nList = value; }
		}	

		public int Position
		{
			get { return m_nPostion; }
			set { m_nPostion = value; }
		}

		#endregion

		#region Constructors

		public ListProp( )
		{
		}

        public override string ToString()
        {
            return m_nID.ToString();
        }


		#endregion

        #region IDataList implementation
        public void Load(IDataReader reader)
        {
            m_nID = Convert.ToInt32(reader["ID"]);
            m_nSong = Convert.ToInt32(reader["Song"]);
            m_nList = Convert.ToInt32(reader["List"]);
            m_nPostion = Convert.ToInt32(reader["Position"]);
           
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
				new ColumnDescription( "ID", this.ID, DbType.Int32, true ),
				new ColumnDescription( "Song", this.Song, DbType.Int32 ),
				new ColumnDescription( "List", this.List, DbType.Int32 ),
				new ColumnDescription("Position",this.Position, DbType.Int32), 
			};
            return new TableDescription("ListProp	", columns);
        }

        #endregion
    }
    /// <summary>
    /// ListPropSorter s�r um a� ra�a tilvikum af vins�ldarlistum.
    /// </summary>

    public class ListPropSorter : IComparer<ListProp>
    {
        #region Member variables
        private String m_strOrderBy;
        #endregion

        #region Constructors
        public ListPropSorter(String strOrderBy)
        {
            m_strOrderBy = strOrderBy;
        }
        #endregion

        #region IComparer implementation
        public int Compare(ListProp x, ListProp y)
        {
            switch (m_strOrderBy)
            {
                case "Song":
                    return x.Song.CompareTo(y.Song);
                case "List":
                    return x.List.CompareTo(y.List);
                case "Position":
                    return x.Position.CompareTo(y.Position);
                
            }

            return 0;
        }
        #endregion
    }

    public class ListPropCollection : DataList<ListProp>
    {
        #region Public functions
        public void Sort(String strOrderBy)
        {
            ListPropSorter sorter = new ListPropSorter(strOrderBy);
            base.Sort(sorter);
        }
        #endregion
    }

}