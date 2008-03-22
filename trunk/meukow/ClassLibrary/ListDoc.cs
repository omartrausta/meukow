using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
    public class ListDoc : BaseDocument
    {
        /// <summary>
        /// StudentDocument s�r um �ll samskipti vi� gagnageymsluna
        /// - sem er semsagt gagnagrunnur � �essu tilfelli, en g�ti allt eins
        /// veri� XML skjal, g�gn s�tt � gegnum vef�j�nustu, serialize-a� skjal
        /// e�a gu�m�vitahva�.
        /// </summary>

        #region Public functions
        public ListCollection GetAllList()
        {
            String strSQL = "select * from List";
            return base.LoadCollection<ListCollection, List>(strSQL);
        }

        public List GetList(int nID)
        {
            String strSQL = String.Format("select * from List where ID={0}", nID);
            return base.LoadItem<List>(strSQL);
        }

        public void UpdateList(List list)
        {
            base.UpdateData(list.GetTable());
        }

        public void AddList(List list)
        {
          int newID = base.AddData(list.GetTable());
        	list.ID = newID;
        }

        public void DeleteListt(List list)
        {
            String strSQL = String.Format("delete from List where ID={0}", list.ID);
            base.ExecuteSQL(strSQL);
        }
        #endregion
    }
}
