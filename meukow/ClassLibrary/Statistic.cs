using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// Statistic that inherits IDataItem
	/// </summary>
	public class Statistic : IDataItem
	{
		#region Member variables
		private String m_strSongName;
		private int m_nPosition;
		private int m_nTimesInPosition;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the song name for the statistics.
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
		/// Gets or sets the position for the statistics.
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
		/// Gets or sets the times in positioin for the statistics.
		/// </summary>
		public int TimesInPosition
		{
			get
			{
				return m_nTimesInPosition;
			}
			set
			{
				m_nTimesInPosition = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public Statistic()
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
		/// member variables for statistic.
		/// </summary>
		/// <param name="reader">IDataReader with data for statistic.</param>
		public void Load(IDataReader reader)
		{
			m_strSongName = reader["SongName"].ToString();
			m_nPosition = Convert.ToInt32(reader["Position"]);
			m_nTimesInPosition = Convert.ToInt32(reader["TimesInPosition"]);
		}

		/// <summary>
		/// Function that returns TableDescription object, this object
		/// can be used when an instance of the class is updated or added.
		/// </summary>
		/// <returns>Returns table description for statistic.</returns>
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

	/// <summary>
	/// StatisticSorter sorts instances of Statistic.
	/// </summary>
	public class StatisticSorter : IComparer<Statistic>
	{
		#region Member variables
		private readonly String m_strOrderBy;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strOrderBy">String to be ordered by</param>
		public StatisticSorter(String strOrderBy)
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		/// <summary>
		/// Function that compares two instances of Statistic.
		/// </summary>
		/// <param name="x">Instance x of Statistic</param>
		/// <param name="y">Instance y of Statistic</param>
		/// <returns></returns>
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

	/// <summary>
	/// StatisticCollection has collection of Statistic
	/// </summary>
	public class StatisticCollection : DataList<Statistic>
	{
		#region Public functions
		/// <summary>
		/// Sorts Statistic by a column.
		/// </summary>
		/// <param name="strOrderBy">The column to be sorted by</param>
		public void Sort(String strOrderBy)
		{
			StatisticSorter sorter = new StatisticSorter(strOrderBy);
			base.Sort(sorter);
		}
		#endregion
	}
}
