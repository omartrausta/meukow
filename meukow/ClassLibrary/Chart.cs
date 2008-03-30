using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// Chart that inherits IDataItem
	/// </summary>
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
		/// <summary>
		/// Gets or sets the position for the chart.
		/// </summary>
		public int Position
		{
			get
			{
				return m_nPosition;
			}
			set
			{
				m_nPosition = value;
			}
		}

		/// <summary>
		/// Gets or sets the song ID for the chart.
		/// </summary>
		public int SongID
		{
			get
			{
				return m_nSongID;
			}
			set
			{
				m_nSongID = value;
			}
		}

		/// <summary>
		/// Gets or sets the song name for the chart.
		/// </summary>
		public String SongName
		{
			get
			{
				return m_strSongName;
			}
			set
			{
				m_strSongName = value;
			}
		}

		/// <summary>
		/// Gets or sets the artist ID for the chart.
		/// </summary>
		public int ArtistID
		{
			get
			{
				return m_nArtistID;
			}
			set
			{
				m_nArtistID = value;
			}
		}

		/// <summary>
		/// Gets or sets the artist name for the chart.
		/// </summary>
		public String ArtistName
		{
			get
			{
				return m_strArtistName;
			}
			set
			{
				m_strArtistName = value;
			}
		}

		/// <summary>
		/// Gets or sets the list ID for the chart.
		/// </summary>
		public int ListID
		{
			get
			{
				return m_nListID;
			}
			set
			{
				m_nListID = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public Chart()
		{
		}
		#endregion

		#region Overridden functions
		/// <summary>
		/// Overridden function for ToString()
		/// </summary>
		/// <returns>Returns the name of the song.</returns>
		public override string ToString()
		{
			return m_strSongName;
		}
		#endregion

		#region IDataList implementation
		/// <summary>
		/// Load function that loads data from IDataReader to
		/// member variables for chart.
		/// </summary>
		/// <param name="reader">IDataReader with data for chart.</param>
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
		/// Function that returns TableDescription object, this object
		/// can be used when an instance of the class is updated or added.
		/// </summary>
		/// <returns>Returns table description for chart.</returns>
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

			return new TableDescription("Chart", columns);
		}
		#endregion
	}

	/// <summary>
	/// ChartSorter sorts instances of Chart.
	/// </summary>
	public class ChartSorter : IComparer<Chart>
	{
		#region Member variables
		private readonly String m_strOrderBy;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strOrderBy">String to be ordered by</param>
		public ChartSorter(String strOrderBy)
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		/// <summary>
		/// Function that compares two instances of Chart.
		/// </summary>
		/// <param name="x">Instance x of Chart</param>
		/// <param name="y">Instance y of Chart</param>
		/// <returns></returns>
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

	/// <summary>
	/// ChartCollection has collection of Chart
	/// </summary>
	public class ChartCollection : DataList<Chart>
	{
		#region Public functions
		/// <summary>
		/// Sorts Chart by a column.
		/// </summary>
		/// <param name="strOrderBy">The column to be sorted by</param>
		public void Sort(String strOrderBy)
		{
			ChartSorter sorter = new ChartSorter(strOrderBy);
			base.Sort(sorter);
		}
		#endregion
	}
}
