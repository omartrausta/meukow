using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    public class ArtistConnectionDoc : BaseDocument
    {
        /// <summary>
        /// StudentDocument sér um öll samskipti við gagnageymsluna
        /// - sem er semsagt gagnagrunnur í þessu tilfelli, en gæti allt eins
        /// verið XML skjal, gögn sótt í gegnum vefþjónustu, serialize-að skjal
        /// eða guðmávitahvað. vkfdfd
        /// </summary>

        #region Public functions
        public ArtistConnectionCollection GetAllArtistsConnection()
        {
            String strSQL = "select * from ArtistConnection";
            return base.LoadCollection<ArtistConnectionCollection, ArtistConnection>(strSQL);
        }

        public ArtistConnection GetArtistConnection(int nIDParent, int nIDChild)
        {
            String strSQL = String.Format("select * from ArtistConnection where IDParent={0} and IDChild={1}", nIDParent, nIDChild);
            return base.LoadItem<ArtistConnection>(strSQL);
        }

			public void UpdateArtistConnection(ArtistConnection oldArtistConnection, ArtistConnection newArtistConnection)
        {
					String strSQL = String.Format("delete from ArtistConnection where IDParent={0} and IDChild={1}", oldArtistConnection.IDParent, oldArtistConnection.IDChild);
					base.ExecuteSQL(strSQL);

					base.AddData(newArtistConnection.GetTable());
        }

        public void AddArtistConnection(ArtistConnection artistConnection)
        {
            base.AddData(artistConnection.GetTable());
        }

        public void DeleteArtistConnection(ArtistConnection artistConnection)
        {
					String strSQL = String.Format("delete from ArtistConnection where IDParent={0} and IDChild={1}", artistConnection.IDParent, artistConnection.IDChild);
            base.ExecuteSQL(strSQL);
        }
        #endregion
    }
}