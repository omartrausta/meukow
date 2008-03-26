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

		private int m_listID;
		private int m_chartPostion;
		private String m_chartSong;
		private String m_chartArtist;
		//private int m_idSong;
		//private int m_idArtist;

		#endregion

		#region Properties

		public int ChartPostion
		{
			get { return m_chartPostion; }
			set { m_chartPostion = value; }
		}

		public String ChartSong
		{
			get { return m_chartSong; }
			set { m_chartSong = value; }
		}

		public String ChartArtist
		{
			get { return m_chartArtist; }
			set { m_chartArtist = value; }
		}

		public int ListID
		{
		    get { return m_listID; }
		    set { m_listID = value; }
		}

		//public int IdArtist
		//{
		//    get { return m_idArtist; }
		//	  set { m_idArtist = value; }

		//}

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
			return m_chartSong;
		}
		#endregion

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
					case "ChartArtist":
						return x.ChartArtist.CompareTo(y.ChartArtist);
					case "ChartPositon":
						return x.ChartPostion.CompareTo(y.ChartPostion);
					case "ChartSong":
						return x.ChartSong.CompareTo(y.ChartSong);
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


		public void Load(IDataReader reader)
		{
			m_listID = Convert.ToInt32(reader["List"]);
			m_chartPostion = Convert.ToInt32(reader["Position"]);
			m_chartSong = reader["Song_Name"].ToString();
			m_chartArtist = reader["Artist_Name"].ToString();
			
			//m_idArtist = Convert.ToInt32(reader["IdArtist"]);
			//m_idSong = Convert.ToInt32(reader["IdSong"]);
		}
	}
}
