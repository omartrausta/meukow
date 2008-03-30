using System;
using ClassLibrary.Common.Data;
using System.Data;

namespace ClassLibrary
{
	/// <summary>
	/// ArtistDoc that inherits BaseDocument
	/// </summary>
	public class ArtistDoc : BaseDocument
	{
		#region Public functions
		/// <summary>
		/// Function that returns collection of all artists.
		/// </summary>
		/// <returns>Collection of artists.</returns>
		public ArtistCollection GetAllArtists( )
		{
			String strSQL = "select * from Artist";
			return base.LoadCollection< ArtistCollection, Artist >( strSQL );
		}

		/// <summary>
		/// Returns an instance of Artist.
		/// </summary>
		/// <param name="nID">The ID of the artist.</param>
		/// <returns>Instance of artist.</returns>
		public Artist GetArtist( int nID )
		{
			String strSQL = String.Format( "select * from Artist where ID={0}", nID );
			return base.LoadItem<Artist>( strSQL );
		}

		/// <summary>
		/// Updates an instance of artist.
		/// </summary>
		/// <param name="artist">Instance of artist.</param>
		public void UpdateArtist( Artist artist )
		{
			base.UpdateData( artist.GetTable( ) );
		}

		/// <summary>
		/// Adds an instance of artist to database.
		/// </summary>
		/// <param name="artist">Instance of artist.</param>
		public void AddArtist( Artist artist )
		{
			int newID = base.AddData( artist.GetTable( ) );
			artist.ID = newID;
		}

		/// <summary>
		/// Delete an instance of artist.
		/// </summary>
		/// <param name="artist">Instance of artist.</param>
		public void DeleteArtist( Artist artist )
		{
			String strSQL = String.Format( "delete from Artist where ID={0}", artist.ID );
			base.ExecuteSQL( strSQL );
		}

		/// <summary>
		/// Function that returns dataset with all artists.
		/// </summary>
		/// <returns>Dataset with artists.</returns>
		public DataSet AllArtistName()
		{
			String strSQL = String.Format("select Name from Artist");
			return base.LoadData(strSQL);
		}
		#endregion
	}
}