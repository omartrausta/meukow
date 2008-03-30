using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// List that inherits IDataItem
	/// </summary>
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
		/// Gets or sets the id for the list.
		/// </summary>
		public int ID
		{
			get
			{
				return m_nID;
			}
			set
			{
				m_nID = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the list.
		/// </summary>
		public String Name
		{
			get
			{
				return m_strName;
			}
			set
			{
				m_strName = value;
			}
		}

		/// <summary>
		/// Gets or sets the start date of the list.
		/// </summary>
		public DateTime Starts
		{
			get
			{
				return m_dtStarts;
			}
			set 
			{ 
				m_dtStarts = value; 
				m_dtStarts = new DateTime( m_dtStarts.Year, m_dtStarts.Month, m_dtStarts.Day );
			}
		}

		/// <summary>
		/// Gets or sets the end date of the list.
		/// </summary>
		public DateTime Ends
		{
			get
			{
				return m_dtEnds;
			}
			set
			{
				m_dtEnds = value;
				m_dtEnds = new DateTime(m_dtEnds.Year, m_dtEnds.Month, m_dtEnds.Day);
			}
		}

		/// <summary>
		/// Gets or sets wether the list is a week list or not.
		/// </summary>
		public bool WeekList
		{
			get
			{
				return m_bWeekList;
			}
			set
			{
				m_bWeekList = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public List( )
		{
		}

		#endregion

		#region Overridden functions
		/// <summary>
		/// Overridden function for ToString()
		/// </summary>
		/// <returns>Returns the name of the list.</returns>
		public override string ToString()
		{
			return m_strName;
		}
		#endregion

		#region IDataList implementation
		/// <summary>
		/// Load function that loads data from IDataReader to
		/// member variables for list.
		/// </summary>
		/// <param name="reader">IDataReader with data for list.</param>
		public void Load(IDataReader reader)
		{
			m_nID = Convert.ToInt32(reader["ID"]);
			m_strName = reader["Name"].ToString();
			m_dtStarts = Convert.ToDateTime(reader["Starts"]);
			m_dtEnds = Convert.ToDateTime(reader["Ends"]);
			m_bWeekList = Convert.ToBoolean(reader["WeekList"]);
		}

		/// <summary>
		/// Function that returns TableDescription object, this object
		/// can be used when an instance of the class is updated or added.
		/// </summary>
		/// <returns>Returns table description for list.</returns>
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

	/// <summary>
	/// ListSorter sorts instances of List.
	/// </summary>
	public class ListSorter : IComparer<List>
	{
		#region Member variables
		private readonly String m_strOrderBy;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strOrderBy">String to be ordered by</param>
		public ListSorter(String strOrderBy)
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		/// <summary>
		/// Function that compares two instances of List.
		/// </summary>
		/// <param name="x">Instance x of List</param>
		/// <param name="y">Instance y of List</param>
		/// <returns></returns>
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

	/// <summary>
	/// ListCollection has collection of List
	/// </summary>
	public class ListCollection : DataList<List>
	{
		#region Public functions
		/// <summary>
		/// Sorts List by a column.
		/// </summary>
		/// <param name="strOrderBy">The column to be sorted by</param>
		public void Sort(String strOrderBy)
		{
			ListSorter sorter = new ListSorter(strOrderBy);
			base.Sort(sorter);
		}
		#endregion
	}
}
