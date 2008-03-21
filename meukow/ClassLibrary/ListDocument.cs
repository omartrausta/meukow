using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    class ListDocument : BaseDocument
    {
        /// <summary>
        /// StudentDocument sér um öll samskipti við gagnageymsluna
        /// - sem er semsagt gagnagrunnur í þessu tilfelli, en gæti allt eins
        /// verið XML skjal, gögn sótt í gegnum vefþjónustu, serialize-að skjal
        /// eða guðmávitahvað.
        /// </summary>

        #region Public functions
        public ListCollection GetAllList()
        {
            String strSQL = "select * from List";
            return base.LoadCollection<ListCollection, List>(strSQL);
        }

        public List GetArtist(int nID)
        {
            String strSQL = String.Format("select * from List where ID={0}", nID);
            return base.LoadItem<List>(strSQL);
        }

        public void UpdateArtist(List list)
        {
            base.UpdateData(list.GetTable());
        }

        public void AddArtist(List list)
        {
            base.AddData(list.GetTable());
        }

        public void DeleteArtistt(List list)
        {
            String strSQL = String.Format("delete from List where ID={0}", list.ID);
            base.ExecuteSQL(strSQL);
        }
        #endregion
    }
}
