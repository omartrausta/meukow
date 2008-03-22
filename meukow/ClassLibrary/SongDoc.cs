using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    public class SongDoc : BaseDocument
     {
        /// <summary>
        /// StudentDocument s�r um �ll samskipti vi� gagnageymsluna
        /// - sem er semsagt gagnagrunnur � �essu tilfelli, en g�ti allt eins
        /// veri� XML skjal, g�gn s�tt � gegnum vef�j�nustu, serialize-a� skjal
        /// e�a gu�m�vitahva�.dfdf
        /// </summary>

        #region Public functions
        public SongCollection GetAllSongs()
        {
            String strSQL = "select * from Song";
            return base.LoadCollection<SongCollection, Song>(strSQL);
        }

        public List GetSong(int nID)
        {
            String strSQL = String.Format("select * from Song where ID={0}", nID);
            return base.LoadItem<List>(strSQL);
        }

        public void UpdateSong(Song song)
        {
            base.UpdateData(song.GetTable());
        }

        public void AddList(Song song)
        {
            base.AddData(song.GetTable());
        }

        public void DeleteListt(Song song)
        {
            String strSQL = String.Format("delete from Song where ID={0}", song.ID);
            base.ExecuteSQL(strSQL);
        }
        #endregion
    }
}
