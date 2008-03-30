using System;
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
		private String m_strTitle;
		private DateTime m_strBlogDate;
		private String m_strBlogContent;
		#endregion

		#region Properties
		public String Content
		{
			get { return m_strBlogContent; }
			set { m_strBlogContent = value; }
		}

		public DateTime BlogDate
		{
			get { return m_strBlogDate; }
			set { m_strBlogDate = value; }
		}

		public String Title
		{
			get { return m_strTitle; }
			set { m_strTitle = value; }
		}

		public int ID
		{
			get { return m_nID; }
			set { m_nID = value; }
		}
		#endregion

		public void Load( IDataReader reader )
		{
			m_nID = Convert.ToInt32( reader[ "ID" ] );
			m_strTitle = Convert.ToString( reader["Title"] );
			m_strBlogDate = Convert.ToDateTime( reader["BlogDate"] );
			m_strBlogContent = Convert.ToString( reader["Content"] );
		}
	}

	public class BlogCollection : DataList<Blog>
	{
	}
}
