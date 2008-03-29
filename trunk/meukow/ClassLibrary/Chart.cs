using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	public class Chart : IDataItem
	{
		#region Member Variables

		private int m_nListID;
		private int m_nPosition;
	    private int m_nSongID;
		private String m_strSongName;
	    private int m_nArtistID;
		private String m_strArtistName;

		#endregion

		#region Properties

		public int Position
		{
			get { return m_nPosition; }
			set { m_nPosition = value; }
		}

	    public int SongID
	    {
            get { return m_nSongID; }
            set { m_nSongID = value; }
	    }

		public String SongName
		{
			get { return m_strSongName; }
			set { m_strSongName = value; }
		}

	    public int ArtistID
	    {
            get { return m_nArtistID; }
            set { m_nArtistID = value; }
	    }

		public String ArtistName
		{
			get { return m_strArtistName; }
			set { m_strArtistName = value; }
		}

		public int ListID
		{
		    get { return m_nListID; }
		    set { m_nListID = value; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor for List
		/// </summary>
		public Chart()
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
            m_nListID = Convert.ToInt32(reader["List"]);
            m_nPosition = Convert.ToInt32(reader["Position"]);
            m_nSongID = Convert.ToInt32(reader["SongID"]);
            m_strSongName = reader["SongName"].ToString();
            m_nArtistID = Convert.ToInt32(reader["ArtistID"]);
            m_strArtistName = reader["ArtistName"].ToString();
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
				new ColumnDescription( "List", this.ListID, DbType.Int32, true ),
                new ColumnDescription( "Position", this.Position, DbType.Int32 ),
                new ColumnDescription( "SongID", this.SongID, DbType.Int32 ),
				new ColumnDescription( "SongName", this.SongName, DbType.String ),
                new ColumnDescription( "ArtistID", this.ArtistID, DbType.Int32 ),
				new ColumnDescription( "ArtistName", this.ArtistName, DbType.String ),
			};
            return new TableDescription("List", columns);
        }
        #endregion
    }
    public class ChartSorter : IComparer<Chart>
    {
	    #region Member variables
	    private String m_strOrderBy;
	    #endregion

	    #region Constructors
	    public ChartSorter(String strOrderBy)
	    {
		    m_strOrderBy = strOrderBy;
	    }
	    #endregion

	    #region IComparer implementation
	    public int Compare(Chart x, Chart y)
	    {
		    switch (m_strOrderBy)
		    {
                case "Positon":
                    return x.Position.CompareTo(y.Position);
                case "SongID":
                    return x.SongID.CompareTo(y.SongID);
                case "SongName":
                    return x.SongName.CompareTo(y.SongName);
                case "ArtistID":
                    return x.ArtistID.CompareTo(y.ArtistID);
                case "ArtistName":
                    return x.ArtistName.CompareTo(y.ArtistName);
		    }

		    return 0;
	    }
	    #endregion

    }

    public class ChartCollection : DataList<Chart>
    {
	    #region Public functions
	    public void Sort(String strOrderBy)
	    {
		    ChartSorter sorter = new ChartSorter(strOrderBy);
		    base.Sort(sorter);
	    }
	    #endregion
    }
}
