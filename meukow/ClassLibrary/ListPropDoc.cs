using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    public class ListPropDoc : BaseDocument
    {
        /// <summary>
        /// StudentDocument sér um öll samskipti við gagnageymsluna
        /// - sem er semsagt gagnagrunnur í þessu tilfelli, en gæti allt eins
        /// verið XML skjal, gögn sótt í gegnum vefþjónustu, serialize-að skjal
        /// eða guðmávitahvað.dfdff
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

			public ListPropCollection GetListPropByList(int nID)
				{
					String strSQL = String.Format("select * from ListProp where List={0}", nID);
					return base.LoadCollection<ListPropCollection, ListProp>(strSQL);
				}

    	public void UpdateListProp(ListProp listProp)
        {
            base.UpdateData(listProp.GetTable());
        }

        public void AddListProp(ListProp listProp)
        {
					int newID = base.AddData(listProp.GetTable());
        	listProp.ID = newID;
        }

        public void DeleteListProp(ListProp listProp)
        {
            String strSQL = String.Format("delete from ListProp where ID={0}", listProp.ID);
            base.ExecuteSQL(strSQL);
        }
        #endregion
    }
}
