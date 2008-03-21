using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    class ArtistDoc : BaseDocument
    {
/// <summary>
	/// StudentDocument s�r um �ll samskipti vi� gagnageymsluna
	/// - sem er semsagt gagnagrunnur � �essu tilfelli, en g�ti allt eins
	/// veri� XML skjal, g�gn s�tt � gegnum vef�j�nustu, serialize-a� skjal
	/// e�a gu�m�vitahva�.
	/// </summary>
	
		#region Public functions
		public ArtistCollection GetAllArtists( )
		{
			String strSQL = "select * from Artist";
			return base.LoadCollection< ArtistCollection, Artist >( strSQL );
		}

		public Artist GetArtist( int nID )
		{
			String strSQL = String.Format( "select * from Artist where ID={0}", nID );
			return base.LoadItem<Artist>( strSQL );
		}

		public void UpdateArtist( Artist artist )
		{
			base.UpdateData( artist.GetTable( ) );
		}

		public void AddArtist( Artist artist )
		{
			base.AddData( artist.GetTable( ) );
		}

		public void DeleteArtistt( Artist artist )
		{
			String strSQL = String.Format( "delete from Artist where ID={0}", artist.ID );
			base.ExecuteSQL( strSQL );
		}
		#endregion
	}
}