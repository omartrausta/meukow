using System;
using System.Collections.Generic;
using System.Data;

namespace ClassLibrary
{
	internal class Song : DBComm
	{
	#region Member variables

	private int m_nID;
	private String m_strName;
	private int m_nArtistID;
	private String m_strSongPath;
	private String m_strDescription;

	#endregion

	#region Properties

	public int ID
	{
		get { return m_nID; }
		set { m_nID = value; }
	}

	public String Name
	{
		get { return m_strName; }
		set { m_strName = value; }
	}

	public int ArtistID
	{
		get { return m_nArtistID; }
		set { m_nArtistID = value; }
	}

	public String SongPath
	{
		get { return m_strSongPath; }
		set { m_strSongPath = value; }
	}

	public String Description
	{
		get { return m_strDescription; }
		set { m_strDescription = value; }
	}

	#endregion
	
	#region Constructors

	public Song( )
	{
	}

	#endregion

	#region IDataList implementation
	public void Load(IDataReader reader)
	{
		m_nID = Convert.ToInt32(reader["ID"]);
		m_strName = reader[ "Name" ].ToString( );
		m_nArtistID = Convert.ToInt32(reader["ArtistID"]);
		m_strSongPath = reader["SongPath"].ToString();
		m_strDescription = reader["Description"].ToString();
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
	public TableDescription GetTable( )
	{
		ColumnDescription[] columns = 
			{
				new ColumnDescription( "ID", this.ID, DbType.Int32, true ),
				new ColumnDescription( "Name", this.Name, DbType.String ),
				new ColumnDescription( "ArtistID", this.ArtistID, DbType.Int32, true ) ),
				new ColumnDescription( "SongPath", this.SongPath, DbType.String ),
				new ColumnDescription( "Description", this.Description, DbType.String ),
			};
			return new TableDescription( "Nemendur", columns );
		}
	}

	#endregion

	/// <summary>
	/// StudentSorter s�r um a� ra�a tilvikum af Student.
	/// </summary>
	public class SongSorter : IComparer<Song>
	{
		#region Member variables
		private String m_strOrderBy;
		#endregion

		#region Constructors
		public SongSorter( String strOrderBy )
		{
			m_strOrderBy = strOrderBy;
		}
		#endregion

		#region IComparer implementation
		public int Compare( Song x, Song y )
		{
			switch ( m_strOrderBy )
			{
				case "Name":
					return x.Name.CompareTo( y.Name );
				case "ArtistID":
					return x.ArtistID.CompareTo( y.ArtistID );
				case "SongPath":
					return x.SongPath.CompareTo( y.SongPath );
				case "Group":
					return x.Description.CompareTo( y.Description );
			}

			return 0;
		}
		#endregion
	}

	public class SongCollection : DataList<Song>
	{
		#region Public functions
		public void Sort( String strOrderBy )
		{
			SongSorter sorter = new SongSorter( strOrderBy );
			base.Sort( sorter );
		}
		#endregion	
	}

	#region Overridden functions

	public override string ToString()
	{
		return m_strName;
	}
	
	#endregion
	}
}
