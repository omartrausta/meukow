using System;
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

	public Song( DataRow row )
	{
		m_nID = Convert.ToInt32(row["ID"]);
		m_strName = row[ "Name" ].ToString( );
		m_nArtistID = Convert.ToInt32(row["ArtistID"]);
		m_strSongPath = row["SongPath"].ToString();
		m_strDescription = row["Description"].ToString();
	}

	#endregion

	#region Overridden functions

	public override string ToString()
	{
		return m_strName;
	}
	
	#endregion
	}
}
