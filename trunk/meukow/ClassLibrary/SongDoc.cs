using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    public class SongDoc : BaseDocument
     {
        /// <summary>
        /// StudentDocument sér um öll samskipti við gagnageymsluna
        /// - sem er semsagt gagnagrunnur í þessu tilfelli, en gæti allt eins
        /// verið XML skjal, gögn sótt í gegnum vefþjónustu, serialize-að skjal
        /// eða guðmávitahvað.dfdf
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
