using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// Song that inherits IDataItem
	/// </summary>
	public class Song : IDataItem
	{
		#region Member variables
		private int m_nID;
		private String m_strName;
		private int m_nArtistID;
        private String m_strSongPath;
		private String m_strDescription;
		private String m_strArtistName;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the id for the song.
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
		/// Gets or sets the name for the song.
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
		/// Gets or sets the artist id for the song.
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
		/// Gets or sets the song path for the song.
		/// </summary>
		public String SongPath
		{
			get
			{
				if (!String.IsNullOrEmpty(m_strSongPath))
				{
						return "~/" + m_strSongPath;
				}
            
				else
				{
						return String.Empty;
				}
	        
			}
			set
			{
					m_strSongPath = value;
					if (!String.IsNullOrEmpty(m_strSongPath))
					{
						if (m_strSongPath.Substring(0, 1) != "/")
						{
							m_strSongPath = "/" + m_strSongPath;
						}
					}
			}
		}

		/// <summary>
		/// Gets or sets the description for the song.
		/// </summary>
		public String Description
		{
			get
			{
				return m_strDescription;
			}
			set
			{
				m_strDescription = value;
			}
		}

		/// <summary>
		/// Gets or sets the artist name for the song.
		/// </summary>
		public String Artist
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
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public Song( )
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
			return m_strName;
		}
		#endregion

		#region IDataList implementation
		/// <summary>
		/// Load function that loads data from IDataReader to
		/// member variables for song.
		/// </summary>
		/// <param name="reader">IDataReader with data for song.</param>
		public void Load(IDataReader reader)
		{
			m_nID = Convert.ToInt32(reader["ID"]);
			m_strName = reader[ "Name" ].ToString( );
			m_nArtistID = Convert.ToInt32(reader["ArtistID"]);
			m_strArtistName = reader["ArtistName"].ToString();
			m_strSongPath = reader["SongPath"].ToString();
			m_strDescription = reader["Description"].ToString();
		}

		/// <summary>
		/// Function that returns TableDescription object, this object
		/// can be used when an instance of the class is updated or added.
		/// </summary>
		/// <returns>Returns table description for song.</returns>
		public TableDescription GetTable( )
		{
			ColumnDescription[] columns = 
			{
				new ColumnDescription( "ID", this.ID, DbType.Int32, true ),
				new ColumnDescription( "Name", this.Name, DbType.String ),
				new ColumnDescription( "ArtistID", this.ArtistID, DbType.Int32 ),
				new ColumnDescription( "SongPath", m_strSongPath, DbType.String ),
				new ColumnDescription( "Description", this.Description, DbType.String ),
			};

			return new TableDescription( "Song", columns );
		}	
		#endregion
	}

	/// <summary>
	/// SongSorter sorts instances of Song.
	/// </summary>
	public class SongSorter : IComparer<Song>
	{
		#region Member variables
		private readonly String m_strOrderBy;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strOrderBy">String to be ordered by</param>
		public SongSorter( String strOrderBy )
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		/// <summary>
		/// Function that compares two instances of Song.
		/// </summary>
		/// <param name="x">Instance x of Song</param>
		/// <param name="y">Instance y of Song</param>
		/// <returns></returns>
		public int Compare( Song x, Song y )
		{
			switch ( m_strOrderBy )
			{
				case "Name":
					return x.Name.CompareTo( y.Name );
				case "Artist":
					return x.Artist.CompareTo( y.Artist );
				case "SongPath":
					return x.SongPath.CompareTo( y.SongPath );
				case "Description":
					return x.Description.CompareTo( y.Description );
			}

			return 0;
		}
		#endregion
	}

	/// <summary>
	/// SongCollection has collection of Song
	/// </summary>
	public class SongCollection : DataList<Song>
	{
		#region Public functions
		/// <summary>
		/// Sorts Song by a column.
		/// </summary>
		/// <param name="strOrderBy">The column to be sorted by</param>
		public void Sort( String strOrderBy )
		{
			SongSorter sorter = new SongSorter( strOrderBy );
			base.Sort( sorter );
		}
		#endregion	
	}
}
