using System;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// ListDoc that inherits BaseDocument
	/// </summary>
	public class ListDoc : BaseDocument
	{
		#region Public functions
		/// <summary>
		/// Function that returns collection of all lists.
		/// </summary>
		/// <returns>Collection of lists.</returns>
		public ListCollection GetAllList()
		{
			String strSQL = "select * from List";
			return base.LoadCollection<ListCollection, List>(strSQL);
		}

		/// <summary>
		/// Returns an instance of List.
		/// </summary>
		/// <param name="nID">The ID of the list.</param>
		/// <returns>Instance of list.</returns>
		public List GetList(int nID)
		{
			String strSQL = String.Format("select * from List where ID={0}", nID);
			return base.LoadItem<List>(strSQL);
		}

		/// <summary>
		/// Updates an instance of list.
		/// </summary>
		/// <param name="list">Instance of list.</param>
		public void UpdateList(List list)
		{
			base.UpdateData(list.GetTable());
		}

		/// <summary>
		/// Adds an instance of list to database.
		/// </summary>
		/// <param name="list">Instance of list.</param>
		public void AddList(List list)
		{
			int newID = base.AddData(list.GetTable());
			list.ID = newID;
		}

		/// <summary>
		/// Delete an instance of list.
		/// </summary>
		/// <param name="list">Instance of list.</param>
		public void DeleteList(List list)
		{
			String strSQL = String.Format("delete from List where ID={0}", list.ID);
			base.ExecuteSQL(strSQL);
		}
		#endregion
	}
}
