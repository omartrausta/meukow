using System;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// ListPropDoc that inherits BaseDocument
	/// </summary>
	public class ListPropDoc : BaseDocument
	{
		#region Public functions
		/// <summary>
		/// Function that returns collection of all ListProp.
		/// </summary>
		/// <returns>Collection of ListProp.</returns>
		public ListPropCollection GetAllListProp()
		{
			String strSQL = "select * from ListProp";
			return base.LoadCollection<ListPropCollection, ListProp>(strSQL);
		}

		/// <summary>
		/// Returns an instance of ListProp.
		/// </summary>
		/// <param name="nID">The ID of the ListProp.</param>
		/// <returns>Instance of ListProp.</returns>
		public ListProp GetListProp(int nID)
		{
			String strSQL = String.Format("select * from ListProp where ID={0}", nID);
			return base.LoadItem<ListProp>(strSQL);
		}

		/// <summary>
		/// Function that returns collection of ListProp for a specific list.
		/// </summary>
		/// <returns>Collection of ListProp for a single list.</returns>
		public ListPropCollection GetListPropByList(int nID)
		{
			String strSQL = String.Format("select * from ListProp where List={0}", nID);
			return base.LoadCollection<ListPropCollection, ListProp>(strSQL);
		}

		/// <summary>
		/// Updates an instance of listProp.
		/// </summary>
		/// <param name="listProp">Instance of listProp.</param>
		public void UpdateListProp(ListProp listProp)
		{
			base.UpdateData(listProp.GetTable());
		}

		/// <summary>
		/// Adds an instance of listProp to database.
		/// </summary>
		/// <param name="listProp">Instance of listProp.</param>
		public void AddListProp(ListProp listProp)
		{
			int newID = base.AddData(listProp.GetTable());
			listProp.ID = newID;
		}

		/// <summary>
		/// Delete an instance of listProp.
		/// </summary>
		/// <param name="listProp">Instance of listProp.</param>
		public void DeleteListProp(ListProp listProp)
		{
			String strSQL = String.Format("delete from ListProp where ID={0}", listProp.ID);
			base.ExecuteSQL(strSQL);
		}
		#endregion
	}
}
