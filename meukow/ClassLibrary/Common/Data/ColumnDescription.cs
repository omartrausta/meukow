using System;
using System.Data;
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
		private readonly String m_strColumnName;
		private readonly object m_value;
		private readonly DbType m_type;
		private readonly bool m_bPrimaryKey;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strName">Name of column</param>
		/// <param name="value">Value of column</param>
		/// <param name="type">DbType of column</param>
		public ColumnDescription( String strName, object value, DbType type )
		: this( strName, value, type, false )
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strName">Name of column</param>
		/// <param name="value">Value of column</param>
		/// <param name="type">DbType of column</param>
		/// <param name="bPrimaryKey">Is column a primary key</param>
		public ColumnDescription( String strName, object value, DbType type, bool bPrimaryKey )
		{
			m_strColumnName = strName;
			m_value = value;
			m_type = type;
			m_bPrimaryKey = bPrimaryKey;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Returns the name of the column.
		/// </summary>
		public String Name
		{
			get
			{
				return m_strColumnName;
			}
		}

		/// <summary>
		/// Returns the value of the column.
		/// </summary>
		public object Value
		{
			get
			{
				return m_value;
			}
		}

		/// <summary>
		/// Returns the DbType of the column.
		/// </summary>
		public DbType Type
		{
			get
			{
				return m_type;
			}
		}

		/// <summary>
		/// Returns the wether the column is a primary key.
		/// </summary>
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