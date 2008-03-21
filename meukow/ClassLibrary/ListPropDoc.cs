using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    class ListPropDoc : BaseDocument
    {
        /// <summary>
        /// StudentDocument s�r um �ll samskipti vi� gagnageymsluna
        /// - sem er semsagt gagnagrunnur � �essu tilfelli, en g�ti allt eins
        /// veri� XML skjal, g�gn s�tt � gegnum vef�j�nustu, serialize-a� skjal
        /// e�a gu�m�vitahva�.
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
