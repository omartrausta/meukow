using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ClassLibrary.Common.Data;

namespace ClassLibrary.Common.Data
{
	/// <summary>
	/// ColumnDescription is used to simplify UPDATE and INSERT statements.
	/// A POD class should simply declare a function that returns a 
	/// <see cref="TableDescription"/>TableDescription object, which contains
	/// one ColumnDescription object for each column in the table. <see cref="BaseDocument"/>
	/// Check also out BaseDocument.AddData, and BaseDocument.UpdateData.
	/// </summary>
	public class ColumnDescription
	{
		#region Member variables
		private String m_strColumnName;
		private object m_value;
		private DbType m_type;
		bool m_bPrimaryKey;
		#endregion

		#region Constructors
		public ColumnDescription( String strName, object value, DbType type )
			: this( strName, value, type, false )
		{
		}

		public ColumnDescription( String strName, object value, DbType type, bool bPrimaryKey )
		{
			m_strColumnName = strName;
			m_value = value;
			m_type = type;
			m_bPrimaryKey = bPrimaryKey;
		}
		#endregion

		#region Properties
		public String Name
		{
			get
			{
				return m_strColumnName;
			}
		}

		public object Value
		{
			get
			{
				return m_value;
			}
		}

		public DbType Type
		{
			get
			{
				return m_type;
			}
		}

		public bool IsPrimaryKey
		{
			get
			{
				return m_bPrimaryKey;
			}
		}
		#endregion
	}
}