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
		private int m_nPostion;
	    private int m_nSongID;
		private String m_strSongName;
	    private int m_nArtistID;
		private String m_strArtistName;

		#endregion

		#region Properties

		public int Postion
		{
			get { return m_nPostion; }
			set { m_nPostion = value; }
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
                        return x.Postion.CompareTo(y.Postion);
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

		public void Load(IDataReader reader)
		{
			m_nListID = Convert.ToInt32(reader["List"]);
			m_nPostion = Convert.ToInt32(reader["Position"]);
		    m_nSongID = Convert.ToInt32(reader["SongID"]);
			m_strSongName = reader["SongName"].ToString();
		    m_nArtistID = Convert.ToInt32(reader["ArtistID"]);
			m_strArtistName = reader["ArtistName"].ToString();
		}
	}
}
