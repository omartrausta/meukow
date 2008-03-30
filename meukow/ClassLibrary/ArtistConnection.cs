using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// ArtistConnection that inherits IDataItem
	/// </summary>
	public class ArtistConnection : IDataItem
	{
		#region Member variables
		private int m_nIDParent;
		private int m_nIDChild;
		#endregion

		#region Properties
		/// <summary>
		/// Gets og sets the id for the parent.
		/// </summary>
		public int IDParent
		{
			get
			{
				return m_nIDParent;
			}
			set
			{
				m_nIDParent = value;
			}
		}

		/// <summary>
		/// Gets og sets the id for the child.
		/// </summary>
		public int IDChild
		{
			get
			{
				return m_nIDChild;
			}
			set
			{
				m_nIDChild = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public ArtistConnection( )
		{
		}
		#endregion

		#region Overridden functions
		/// <summary>
		/// Overridden function for ToString()
		/// </summary>
		/// <returns>Returns the id for parent.</returns>
		public override string ToString()
		{
			return m_nIDParent.ToString();
		}
		#endregion	

		#region IDataList implementation
		/// <summary>
		/// Load function that loads data from IDataReader to
		/// member variables for artist connection.
		/// </summary>
		/// <param name="reader"></param>
		public void Load(IDataReader reader)
		{
			m_nIDParent = Convert.ToInt32(reader["IDParent"]);
			m_nIDChild = Convert.ToInt32(reader["IDChild"]);
		}

		/// <summary>
		/// Function that returns TableDescription object, this object
		/// can be used when an instance of the class is updated or added.
		/// </summary>
		/// <returns>Returns table description for artist connection.</returns>
		public TableDescription GetTable()
		{
			ColumnDescription[] columns = 
			{
				new ColumnDescription( "IDParent", this.IDParent, DbType.Int32),
				new ColumnDescription( "IDChild", this.IDChild, DbType.Int32),
			};

			return new TableDescription("ArtistConnection	", columns);
		}
		#endregion
	}

	/// <summary>
	/// ArtistConnectionSorter sorts instances of ArtistConnection.
	/// </summary>
	public class ArtistConnectionSorter : IComparer<ArtistConnection>
	{
		#region Member variables
		private readonly String m_strOrderBy;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strOrderBy">String to be ordered by</param>
		public ArtistConnectionSorter(String strOrderBy)
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		/// <summary>
		/// Function that compares two instances of ArtistConnection.
		/// </summary>
		/// <param name="x">Instance x of ArtistConnection</param>
		/// <param name="y">Instance y of ArtistConnection</param>
		/// <returns></returns>
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

	/// <summary>
	/// ArtistCollection has collection of Artist
	/// </summary>
	public class ArtistConnectionCollection : DataList<ArtistConnection>
	{
		#region Public functions
		/// <summary>
		/// Sorts ArtistConnection by a column.
		/// </summary>
		/// <param name="strOrderBy">The column to be sorted by</param>
		public void Sort(String strOrderBy)
		{
			ArtistConnectionSorter sorter = new ArtistConnectionSorter(strOrderBy);
			base.Sort(sorter);
		}
		#endregion
	}
}