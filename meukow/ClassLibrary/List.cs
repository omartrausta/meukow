using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	public class List : IDataItem
	{
		#region Member variables
		private int m_nID;
		private String m_strName;
		private DateTime m_dtStarts;
		private DateTime m_dtEnds;
		private bool m_bWeekList;
		#endregion

		#region Properties
		/// <summary>
		/// public int property for ID
		/// </summary>
		public int ID
		{
			get { return m_nID; }
			set { m_nID = value; }
		}

		/// <summary>
		/// public string property for Name
		/// </summary>
		public String Name
		{
			get { return m_strName; }
			set { m_strName = value; }
		}

		/// <summary>
		/// public date time property for Starts
		/// </summary>
		public DateTime Starts
		{
			get { return m_dtStarts; }
			set { m_dtStarts = value; }
		}

		/// <summary>
		/// public date time property for Ends
		/// </summary>
		public DateTime Ends
		{
			get { return m_dtEnds; }
			set { m_dtEnds = value; }
		}

		/// <summary>
		/// public bool property for WeekList
		/// </summary>
		public bool WeekList
		{
			get { return m_bWeekList; }
			set { m_bWeekList = value; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor for List
		/// </summary>
		public List( )
		{
		}

#endregion

		#region Overridden functions
		public override string ToString()
		{
			return m_strName;
		}
		#endregion

		#region IDataList implementation
		public void Load(IDataReader reader)
		{
			m_nID = Convert.ToInt32(reader["ID"]);
			m_strName = reader["Name"].ToString();
			m_dtStarts = Convert.ToDateTime(reader["Starts"]);
			m_dtEnds = Convert.ToDateTime(reader["Ends"]);
			m_bWeekList = Convert.ToBoolean(reader["WeekList"]);
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
				new ColumnDescription( "ID", this.ID, DbType.Int32, true ),
				new ColumnDescription( "Name", this.Name, DbType.String ),
				new ColumnDescription( "Starts", this.Starts, DbType.DateTime ),
				new ColumnDescription( "Ends", this.Ends, DbType.DateTime ),
				new ColumnDescription( "WeekList", this.WeekList, DbType.Boolean ),
			};
			return new TableDescription("List", columns);
		}

		#endregion
	}

	public class ListSorter : IComparer<List>
	{
		#region Member variables
		private String m_strOrderBy;
		#endregion

		#region Constructors
		public ListSorter(String strOrderBy)
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		public int Compare(List x, List y)
		{
			switch (m_strOrderBy)
			{
				case "Name":
					return x.Name.CompareTo(y.Name);
				case "Starts":
					return x.Starts.CompareTo(y.Starts);
				case "Ends":
					return x.Ends.CompareTo(y.Ends);
				case "WeekList":
					return x.WeekList.CompareTo(y.WeekList);
			}

			return 0;
		}
		#endregion
	}

	public class ListCollection : DataList<List>
	{
		#region Public functions
		public void Sort(String strOrderBy)
		{
			ListSorter sorter = new ListSorter(strOrderBy);
			base.Sort(sorter);
		}
		#endregion
	}
}
