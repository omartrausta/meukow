using System;
using System.Collections.Generic;
using System.Data;
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
            //String strSQL = "SELECT Song.Name, Artist.Name AS ArtistName, Song.SongPath, Song.Description FROM (Artist INNER JOIN Song ON Artist.ID = Song.ArtistID)";
            String strSQL = "SELECT * from Song";
			return base.LoadCollection<SongCollection, Song>(strSQL);
        }

    	public DataSet GetTable()
		{
    		String strSQL = "Select * from Song";
    		return base.LoadData(strSQL);
		}

        public Song GetSong(int nID)
        {
            String strSQL = String.Format("select * from Song where ID={0}", nID);
            return base.LoadItem<Song>(strSQL);
        }

        public void UpdateSong(Song song)
        {
            base.UpdateData(song.GetTable());
        }

        public void AddSong(Song song)
        {
          int newID = base.AddData(song.GetTable());
        	song.ID = newID;
        }

        public void DeleteSong(Song song)
        {
            String strSQL = String.Format("delete from Song where ID={0}", song.ID);
            base.ExecuteSQL(strSQL);
        }
        #endregion
    }
}
