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
		private int m_nSongiD;
		private String m_strTitle;
		private DateTime m_strBlogDate;
		private String m_strBlogContent;
		#endregion

		#region Properties

		public int SongID
		{
			get { return m_nSongiD; }
			set { m_nSongiD = value; }
		}
	
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

		/// <summary>
		/// Fall sem skilar TableDescription hlut, en þennan hlut má svo
		/// nota þegar tilvik af klasanum er uppfært eða nýskráð.
		/// Athugið að þetta fall þarf ekki endilega að vísa í sömu dálka
		/// og Load fallið, hér ætti aðeins að vísa í dálkanöfn í töflunni
		/// sem þessi klasi tengist, en Load fallið gæti t.d. sótt gögn
		/// úr öðrum dálkum sem væri skilað með INNER JOIN skipun.
		/// </summary>
		/// <returns></returns>
		public TableDescription GetTable()
		{
			ColumnDescription[] columns = 
			{
				new ColumnDescription( "ID", this.ID, DbType.Int32, true ),
				new ColumnDescription( "SongID", this.SongID, DbType.String ),
				new ColumnDescription( "Title", this.Title, DbType.Int32 ),
				new ColumnDescription( "BlogDate", this.BlogDate, DbType.DateTime ),
				new ColumnDescription( "Content", this.Content, DbType.String ),
			};
			return new TableDescription("Blogs	", columns);
		}
	
	}

	public class BlogCollection : DataList<Blog>
	{
	}
}
