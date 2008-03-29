using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    public class Statistic : IDataItem
    {
        #region Member variables
		private String m_strSongName;
		private int m_nPosition;
        private int m_nTimesInPosition;
		#endregion

		#region Properties
		/// <summary>
		/// public string property for SongName
		/// </summary>
		public String SongName
		{
			get { return m_strSongName; }
			set { m_strSongName = value; }
		}

        /// <summary>
		/// public int property for Position
		/// </summary>
		public int Position
		{
			get { return m_nPosition; }
			set { m_nPosition = value; }
		}

        /// <summary>
		/// public int property for Count
		/// </summary>
        public int TimesInPosition
		{
            get { return m_nTimesInPosition; }
            set { m_nTimesInPosition = value; }
		}
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor for List
		/// </summary>
        public Statistic()
		{
		}

#endregion

		#region Overridden functions
		public override string ToString()
		{
            return m_strSongName;
		}
		#endregion

		#region IDataList implementation
		public void Load(IDataReader reader)
		{
            m_strSongName = reader["SongName"].ToString();
            m_nPosition = Convert.ToInt32(reader["Position"]);
            m_nTimesInPosition = Convert.ToInt32(reader["TimesInPosition"]);
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
				new ColumnDescription( "SongName", this.SongName, DbType.String ),
				new ColumnDescription( "Position", this.Position, DbType.Int32 ),
				new ColumnDescription( "TimesInPosition", this.TimesInPosition, DbType.Int32 ),
			};
            return new TableDescription("Statistic", columns);
		}

		#endregion
    }

    public class StatisticSorter : IComparer<Statistic>
    {
        #region Member variables
        private String m_strOrderBy;
        #endregion

        #region Constructors
        public StatisticSorter(String strOrderBy)
        {
            m_strOrderBy = strOrderBy;
        }
        #endregion

        #region IComparer implementation
        public int Compare(Statistic x, Statistic y)
        {
            switch (m_strOrderBy)
            {
                case "SongName":
                    return x.SongName.CompareTo(y.SongName);
                case "Position":
                    return x.Position.CompareTo(y.Position);
                case "TimesInPosition":
                    return x.TimesInPosition.CompareTo(y.TimesInPosition);
            }

            return 0;
        }
        #endregion
    }

    public class StatisticCollection : DataList<Statistic>
    {
        #region Public functions
        public void Sort(String strOrderBy)
        {
            StatisticSorter sorter = new StatisticSorter(strOrderBy);
            base.Sort(sorter);
        }
        #endregion
    }
}
