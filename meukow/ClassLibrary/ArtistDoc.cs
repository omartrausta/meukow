using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;
using System.Data;

namespace ClassLibrary
{
    public class ArtistDoc : BaseDocument
    {
/// <summary>
	/// StudentDocument sér um öll samskipti við gagnageymsluna
	/// - sem er semsagt gagnagrunnur í þessu tilfelli, en gæti allt eins
	/// verið XML skjal, gögn sótt í gegnum vefþjónustu, serialize-að skjal
	/// eða guðmávitahvað.
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
			int newID = base.AddData( artist.GetTable( ) );
			artist.ID = newID;
		}

		public void DeleteArtist( Artist artist )
		{
			String strSQL = String.Format( "delete from Artist where ID={0}", artist.ID );
			base.ExecuteSQL( strSQL );
		}

		public DataSet AllArtistName(String name)
		{
			String strSQL = String.Format("select Name from Artist");
			return base.LoadData(strSQL);
		}
		#endregion
	}
}