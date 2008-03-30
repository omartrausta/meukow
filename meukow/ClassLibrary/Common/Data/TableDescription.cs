using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ClassLibrary.Common.Data;

namespace ClassLibrary.Common.Data
{
	/// <summary>
	/// TableDescription is used to simplify INSERT and UPDATE statements.
	/// <see cref="ColumnDescription"/>
	/// </summary>
	public class TableDescription
	{
		#region Member variables
		private readonly String m_strTableName;
		private readonly ColumnDescription[] m_columns;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public TableDescription( )
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strTableName">Name of table.</param>
		/// <param name="columns">collection of column descriptions</param>
		public TableDescription( String strTableName, ColumnDescription[] columns )
		{
			m_strTableName = strTableName;
			m_columns = columns;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Returns the name of a table.
		/// </summary>
		public String Name
		{
			get
			{
				return m_strTableName;
			}
		}

		/// <summary>
		/// Returns a collection of columns.
		/// </summary>
		public ColumnDescription[] Columns
		{
			get
			{
				return m_columns;
			}
		}
		#endregion
	}
}