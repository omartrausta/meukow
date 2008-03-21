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
		private String m_strTableName;
		private ColumnDescription[] m_columns;
		#endregion

		#region Constructors
		public TableDescription( )
		{
		}

		public TableDescription( String strTableName, ColumnDescription[] columns )
		{
			m_strTableName = strTableName;
			m_columns = columns;
		}
		#endregion

		#region Properties
		public String Name
		{
			get
			{
				return m_strTableName;
			}
		}

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