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
		/// Fall sem skilar TableDescription hlut, en �ennan hlut m� svo
		/// nota �egar tilvik af klasanum er uppf�rt e�a n�skr��.
		/// Athugi� a� �etta fall �arf ekki endilega a� v�sa � s�mu d�lka
		/// og Load falli�, h�r �tti a�eins a� v�sa � d�lkan�fn � t�flunni
		/// sem �essi klasi tengist, en Load falli� g�ti t.d. s�tt g�gn
		/// �r ��rum d�lkum sem v�ri skila� me� INNER JOIN skipun.
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
