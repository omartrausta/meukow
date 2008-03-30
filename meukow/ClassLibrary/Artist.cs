using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// Artist that inherits IDataItem
	/// </summary>
	public class Artist : IDataItem
	{
		#region Member variables
		private int m_nID;
		private String m_strName;
		private String m_strDescription;
		private String m_strPicture;
		private String m_strURL;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the id for the artist.
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
		/// Gets or sets the name of the artist.
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
		/// Gets or sets the description of the artist.
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
		/// Gets or sets the picture of the artist.
		/// </summary>
		public String Picture
		{
			get
			{
				return m_strPicture;
			}
			set
			{
				m_strPicture = value;
			}
		}

		/// <summary>
		/// Gets or sets the url for the artist.
		/// </summary>
		public String URL
		{
			get
			{
				return m_strURL;
			}
			set
			{
				m_strURL = value;
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public Artist( )
		{
		}
		#endregion

		#region Overridden functions
		/// <summary>
		/// Overridden function for ToString()
		/// </summary>
		/// <returns>Returns the name of the artist.</returns>
		public override string ToString()
		{
			return m_strName;
		}
		#endregion

		#region IDataList implementation
		/// <summary>
		/// Load function that loads data from IDataReader to
		/// member variables for artist.
		/// </summary>
		/// <param name="reader">IDataReader with data for artist.</param>
		public void Load(IDataReader reader)
		{
			m_nID = Convert.ToInt32(reader["ID"]);
			m_strName = reader["Name"].ToString();
			m_strDescription = reader["Description"].ToString();
			m_strPicture = reader["Picture"].ToString();
			m_strURL = reader["URL"].ToString();
		}

		/// <summary>
		/// Function that returns TableDescription object, this object
		/// can be used when an instance of the class is updated or added.
		/// </summary>
		/// <returns>Returns table description for artist.</returns>
		public TableDescription GetTable()
		{
			ColumnDescription[] columns = 
			{
				new ColumnDescription( "ID", this.ID, DbType.Int32, true ),
				new ColumnDescription( "Name", this.Name, DbType.String ),
				new ColumnDescription( "Description", this.Description, DbType.String ),
				new ColumnDescription( "Picture", this.Picture, DbType.String ),
				new ColumnDescription( "URL", this.URL, DbType.String), 
			};

			return new TableDescription("Artist	", columns);
		}
		#endregion
	}

	/// <summary>
	/// ArtistSorter sorts instances of Artist.
	/// </summary>
	public class ArtistSorter : IComparer<Artist>
	{
		#region Member variables
		private readonly String m_strOrderBy;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strOrderBy">String to be ordered by</param>
		public ArtistSorter(String strOrderBy)
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		/// <summary>
		/// Function that compares two instances of Artist.
		/// </summary>
		/// <param name="x">Instance x of Artist</param>
		/// <param name="y">Instance y of Artist</param>
		/// <returns></returns>
		public int Compare(Artist x, Artist y)
		{
			switch (m_strOrderBy)
			{
				case "ID":
					return x.ID.CompareTo(y.ID);
				case "Name":
					return x.Name.CompareTo(y.Name);
				case "Description":
					return x.Description.CompareTo(y.Description);
				case "Picture":
					return x.Picture.CompareTo(y.Picture);
				case "URL":
					return x.URL.CompareTo(y.URL);
			}

			return 0;
		}
		#endregion
	}

	/// <summary>
	/// ArtistCollection has collection of Artist
	/// </summary>
	public class ArtistCollection : DataList<Artist>
	{
		#region Public functions
		/// <summary>
		/// Sorts Artist by a column.
		/// </summary>
		/// <param name="strOrderBy">The column to be sorted by</param>
		public void Sort(String strOrderBy)
		{
			ArtistSorter sorter = new ArtistSorter(strOrderBy);
			base.Sort(sorter);
		}
		#endregion
	}
}
