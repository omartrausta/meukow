using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    public class ArtistConnectionDoc : BaseDocument
    {
        /// <summary>
        /// StudentDocument s�r um �ll samskipti vi� gagnageymsluna
        /// - sem er semsagt gagnagrunnur � �essu tilfelli, en g�ti allt eins
        /// veri� XML skjal, g�gn s�tt � gegnum vef�j�nustu, serialize-a� skjal
        /// e�a gu�m�vitahva�. vkfdfd
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