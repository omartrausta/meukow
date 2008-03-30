using System;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// SongDoc that inherits BaseDocument
	/// </summary>
	public class SongDoc : BaseDocument
	{
		#region Public functions
		/// <summary>
		/// Function that returns collection of all songs.
		/// </summary>
		/// <returns>Collection of songs.</returns>
		public SongCollection GetAllSongs()
		{
			String strSQL = "SELECT Song.ID, Song.Name, Song.ArtistID, Artist.Name AS ArtistName, Song.SongPath, Song.Description FROM (Artist INNER JOIN Song ON Artist.ID = Song.ArtistID)";
			return base.LoadCollection<SongCollection, Song>(strSQL);
		}

		/// <summary>
		/// Returns an instance of Song.
		/// </summary>
		/// <param name="nID">The ID of the song.</param>
		/// <returns>Instance of song.</returns>
		public Song GetSong(int nID)
		{
			String strSQL = String.Format("SELECT Song.ID, Song.Name, Song.ArtistID, Artist.Name AS ArtistName, Song.SongPath, Song.Description FROM (Artist INNER JOIN Song ON Artist.ID = Song.ArtistID) where Song.ID={0}", nID);
			return base.LoadItem<Song>(strSQL);
		}

		/// <summary>
		/// Updates an instance of song.
		/// </summary>
		/// <param name="song">Instance of song.</param>
		public void UpdateSong(Song song)
		{
			base.UpdateData(song.GetTable());
		}

		/// <summary>
		/// Adds an instance of song to database.
		/// </summary>
		/// <param name="song">Instance of song.</param>
		public void AddSong(Song song)
		{
			int newID = base.AddData(song.GetTable());
			song.ID = newID;
		}

		/// <summary>
		/// Delete an instance of song.
		/// </summary>
		/// <param name="song">Instance of song.</param>
		public void DeleteSong(Song song)
		{
			String strSQL = String.Format("delete from Song where ID={0}", song.ID);
			base.ExecuteSQL(strSQL);
		}
		#endregion
	}
}
