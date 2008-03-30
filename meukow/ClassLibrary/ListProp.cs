using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// ListProp that inherits IDataItem
	/// </summary>
	public class ListProp : IDataItem
	{
		#region Member variables
		private int m_nID;
		private int m_nSong;
		private int m_nList;
		private int m_nPostion;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the id for the ListProp.
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
		/// Gets or sets the song id for the ListProp.
		/// </summary>
		public int Song
		{
			get
			{
				return m_nSong;
			}
			set
			{
				m_nSong = value;
			}
		}

		/// <summary>
		/// Gets or sets the list id for the ListProp.
		/// </summary>
		public int List
		{
			get
			{
				return m_nList;
			}
			set
			{
				m_nList = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the position for the ListProp.
		/// </summary>
		public int Position
		{
			get
			{
				return m_nPostion;
			}
			set
			{
				m_nPostion = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public ListProp( )
		{
		}
		#endregion

		#region Overridden functions
		/// <summary>
		/// Overridden function for ToString()
		/// </summary>
		/// <returns>Returns the id of the ListProp.</returns>
		public override string ToString()
		{
			return m_nID.ToString();
		}
		#endregion

		#region IDataList implementation
		/// <summary>
		/// Load function that loads data from IDataReader to
		/// member variables for ListProp.
		/// </summary>
		/// <param name="reader">IDataReader with data for ListProp.</param>
		public void Load(IDataReader reader)
		{
			m_nID = Convert.ToInt32(reader["ID"]);
			m_nSong = Convert.ToInt32(reader["Song"]);
			m_nList = Convert.ToInt32(reader["List"]);
			m_nPostion = Convert.ToInt32(reader["Position"]);
		}

		/// <summary>
		/// Function that returns TableDescription object, this object
		/// can be used when an instance of the class is updated or added.
		/// </summary>
		/// <returns>Returns table description for ListProp.</returns>
		public TableDescription GetTable()
		{
			ColumnDescription[] columns = 
			{
				new ColumnDescription( "ID", this.ID, DbType.Int32, true ),
				new ColumnDescription( "Song", this.Song, DbType.Int32 ),
				new ColumnDescription( "List", this.List, DbType.Int32 ),
				new ColumnDescription( "Position",this.Position, DbType.Int32), 
			};

			return new TableDescription( "ListProp	", columns);
		}
		#endregion
	}

	/// <summary>
	/// ListPropSorter sorts instances of ListProp.
	/// </summary>
	public class ListPropSorter : IComparer<ListProp>
	{
		#region Member variables
		private readonly String m_strOrderBy;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strOrderBy">String to be ordered by</param>
		public ListPropSorter(String strOrderBy)
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		/// <summary>
		/// Function that compares two instances of ListProp.
		/// </summary>
		/// <param name="x">Instance x of ListProp</param>
		/// <param name="y">Instance y of ListProp</param>
		/// <returns></returns>
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

	/// <summary>
	/// ListPropCollection has collection of ListProp
	/// </summary>
	public class ListPropCollection : DataList<ListProp>
	{
		#region Public functions
		/// <summary>
		/// Sorts ListProp by a column.
		/// </summary>
		/// <param name="strOrderBy">The column to be sorted by</param>
		public void Sort(String strOrderBy)
		{
			ListPropSorter sorter = new ListPropSorter(strOrderBy);
			base.Sort(sorter);
		}
		#endregion
	}
}