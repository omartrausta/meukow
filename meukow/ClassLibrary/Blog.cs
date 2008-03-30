using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// The Blog class represents a single blog entry.
	/// </summary>
	public class Blog : IDataItem
	{
		#region Member variables
		private int m_nID;
		private int m_nSongID;
		private String m_strTitle;
		private DateTime m_strBlogDate;
		private String m_strBlogContent;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the song id for blog.
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
		/// Gets or sets the content for blog.
		/// </summary>
		public String Content
		{
			get
			{
				return m_strBlogContent;
			}
			set
			{
				 m_strBlogContent = value;
			}
		}

		/// <summary>
		/// Gets or sets the date for blog.
		/// </summary>
		public DateTime BlogDate
		{
			get
			{
				return m_strBlogDate;
			}
			set
			{
				m_strBlogDate = value;
				m_strBlogDate = new DateTime(m_strBlogDate.Year, m_strBlogDate.Month, m_strBlogDate.Day, m_strBlogDate.Hour, m_strBlogDate.Minute, m_strBlogDate.Second);
			}
		}

		/// <summary>
		/// Gets or sets the title for blog.
		/// </summary>
		public String Title
		{
			get
			{
				return m_strTitle;
			}
			set
			{
				m_strTitle = value;
			}
		}

		/// <summary>
		/// Gets or sets the id for blog.
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
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public Blog()
		{
		}
		#endregion

		#region Overridden functions
		/// <summary>
		/// Overridden function for ToString()
		/// </summary>
		/// <returns>Returns the name of the blog.</returns>
		public override string ToString()
		{
			return m_strTitle;
		}
		#endregion

		#region IDataList implementation
		/// <summary>
		/// Load function that loads data from IDataReader to
		/// member variables for blog.
		/// </summary>
		/// <param name="reader">IDataReader with data for blog.</param>
		public void Load(IDataReader reader)
		{
			m_nID = Convert.ToInt32(reader["ID"]);
			m_nSongID = Convert.ToInt32(reader["SongID"]);
			m_strTitle = Convert.ToString(reader["Title"]);
			m_strBlogDate = Convert.ToDateTime(reader["BlogDate"]);
			m_strBlogContent = Convert.ToString(reader["Content"]);
		}

		/// <summary>
		/// Function that returns TableDescription object, this object
		/// can be used when an instance of the class is updated or added.
		/// </summary>
		/// <returns>Returns table description for blog.</returns>
		public TableDescription GetTable()
		{
			ColumnDescription[] columns = 
			{
				new ColumnDescription( "ID", this.ID, DbType.Int32, true ),
				new ColumnDescription( "SongID", this.SongID, DbType.Int32 ),
				new ColumnDescription( "Title", this.Title, DbType.String ),
				new ColumnDescription( "BlogDate", this.BlogDate, DbType.DateTime ),
				new ColumnDescription( "Content", this.Content, DbType.String ),
			};
			return new TableDescription("Blogs ", columns);
		}
		#endregion
	}

	/// <summary>
	/// BlogSorter sorts instances of Blog.
	/// </summary>
	public class BlogSorter : IComparer<Blog>
	{
		#region Member variables
		private readonly String m_strOrderBy;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strOrderBy">String to be ordered by</param>
		public BlogSorter(String strOrderBy)
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		/// <summary>
		/// Function that compares two instances of Blog.
		/// </summary>
		/// <param name="x">Instance x of Blog</param>
		/// <param name="y">Instance y of Blog</param>
		/// <returns></returns>
		public int Compare(Blog x, Blog y)
		{
			switch (m_strOrderBy)
			{
				case "SongID":
					return x.SongID.CompareTo(y.SongID);
				case "Title":
					return x.Title.CompareTo(y.Title);
				case "BlogDate":
					return x.BlogDate.CompareTo(y.BlogDate);
				case "Content":
					return x.Content.CompareTo(y.Content);
			}

			return 0;
		}
		#endregion
	}

	/// <summary>
	/// BlogCollection has collection of Blog
	/// </summary>
	public class BlogCollection : DataList<Blog>
	{
		#region Public functions
		/// <summary>
		/// Sorts Blog by a column.
		/// </summary>
		/// <param name="strOrderBy">The column to be sorted by</param>
		public void Sort(String strOrderBy)
		{
			BlogSorter sorter = new BlogSorter(strOrderBy);
			base.Sort(sorter);
		}
		#endregion
	}
}
