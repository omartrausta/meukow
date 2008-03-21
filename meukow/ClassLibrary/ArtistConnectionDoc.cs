using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    class ArtistConnectionDoc : BaseDocument
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

        public ArtistConnection GetArtistConnection(int nID)
        {
            String strSQL = String.Format("select * from ArtistConnection where ID={0}", nID);
            return base.LoadItem<ArtistConnection>(strSQL);
        }

        public void UpdateArtistConnection(ArtistConnection artistConnection)
        {
            base.UpdateData(artistConnection.GetTable());
        }

        public void AddArtistConnection(ArtistConnection artistConnection)
        {
            base.AddData(artistConnection.GetTable());
        }

        public void DeleteArtistConnection(ArtistConnection artistConnection)
        {
            String strSQL = String.Format("delete from ArtistConnection where ID={0}", artistConnection.ID);
            base.ExecuteSQL(strSQL);
        }
        #endregion
    }
}