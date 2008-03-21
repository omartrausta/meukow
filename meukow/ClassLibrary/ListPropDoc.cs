using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    class ListPropDoc : BaseDocument
    {
        /// <summary>
        /// StudentDocument sér um öll samskipti við gagnageymsluna
        /// - sem er semsagt gagnagrunnur í þessu tilfelli, en gæti allt eins
        /// verið XML skjal, gögn sótt í gegnum vefþjónustu, serialize-að skjal
        /// eða guðmávitahvað.
        /// </summary>

        #region Public functions
        public ListPropCollection GetAllListProp()
        {
            String strSQL = "select * from ListProp";
            return base.LoadCollection<ListPropCollection, ListProp>(strSQL);
        }

        public ListProp GetListProp(int nID)
        {
            String strSQL = String.Format("select * from ListProp where ID={0}", nID);
            return base.LoadItem<ListProp>(strSQL);
        }

        public void UpdateListProp(ListProp listProp)
        {
            base.UpdateData(listProp.GetTable());
        }

        public void AddListProp(ListProp listProp)
        {
            base.AddData(listProp.GetTable());
        }

        public void DeleteListt(ListProp listProp)
        {
            String strSQL = String.Format("delete from ListProp where ID={0}", listProp.ID);
            base.ExecuteSQL(strSQL);
        }
        #endregion
    }
}
