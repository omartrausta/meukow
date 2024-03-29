using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using ClassLibrary.Common.Data;

namespace ClassLibrary.Common.Data
{
	/// <summary>
	/// BaseDocument is a base class for other Document (sometimes called
	/// DAO - Data Access Objects) classes which need to access a database.
	/// It retrieves information about the connection string from a config
	/// file - it expects an entry in the connectionString section in
	/// the config file, the default name of this section is "appDatabase".
	/// The name of that section can be customized 
	/// <see ref="BaseDocument.BaseDocument( String )"/> by using
	/// the non-empty constructor for BaseDocument.
	/// </summary>
	public class BaseDocument
	{
		#region Delegates
		/// <summary>
		/// Delegate for OnFetchRow
		/// </summary>
		/// <param name="reader">IDataReader</param>
		public delegate void OnFetchRow( IDataReader reader );
		#endregion

		#region Member variables
		/// <summary>
		/// The name of the connection string entry in xxx.config file.
		/// The default value is just a guess, this can be customized
		/// by using the constructor which accepts a string parameter.
		/// </summary>
		protected String m_strConnectionStringName = "appDatabase";

		/// <summary>
		/// The connection string itself. There is no way to specify
		/// a reasonable default for this string, since it will surely
		/// be different for each application.
		/// </summary>
		protected String m_strConnectionString = "";

		/// <summary>
		/// The name of the provider we use to connect to the database.
		/// Luckily, ASP.NET supports provider-agnostic code which we use.
		/// </summary>
		protected String m_strProviderName = "System.Data.OleDb";
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public BaseDocument( ) : this( "" )
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strConnectionStringName">The connection string</param>
		public BaseDocument( String strConnectionStringName )
		{
			if ( !String.IsNullOrEmpty( strConnectionStringName ) )
			{
				m_strConnectionStringName = strConnectionStringName;
			}

			// This will either load the connection string from 
			// web.config (ASP.NET projects) or App.config (WinForms).
			// To make it work under other circumstances (such as
			// in unit testing projects) we also handle it when
			// such file doesn't exist.
			m_strConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();

			Debug.Assert( m_strConnectionString.Length > 0, "BaseDocument.BaseDocument: the connection string defined in .config file cannot be empty!" );
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets/Sets the connection string property. This is basically 
		/// supplied in order to allow unit tests to specify a custom
		/// connection string.
		/// </summary>
		public String ConnectionString
		{
			get
			{
				return m_strConnectionString;
			}
			set
			{
				m_strConnectionString = value;
			}
		}

		/// <summary>
		/// Returns the factory which is used to create DB objects.
		/// </summary>
		protected DbProviderFactory Factory
		{
			get
			{
				return DbProviderFactories.GetFactory( m_strProviderName );
			}
		}
		#endregion

		#region Public functions
		/// <summary>
		/// OpenConnection takes care of opening a connection to the database.
		/// This function is declared as virtual in order to allow derived
		/// classes to override this behaviour.
		/// This function should only be used internally, and whoever calls
		/// this function must remember to close the connection.
		/// </summary>
		/// <returns>A valid IDbConnection object.</returns>
		public virtual IDbConnection OpenConnection( )
		{
			IDbConnection connection = Factory.CreateConnection( );
			connection.ConnectionString = m_strConnectionString;
			connection.Open( );

			return connection;
		}

		/// <summary>
		/// LoadCollection accepts a SQL statement as a parameter, and returns
		/// a T collection of U objects.
		/// TODO: figure out how we can skip the U type parameter!!!
		/// </summary>
		/// <typeparam name="T">The collection which will be returned (must
		/// inherit from Common.Data.DataList</typeparam>
		/// <typeparam name="U">The type which the collection stores (must
		/// inherit from Common.Data.IDataItem)</typeparam>
		/// <param name="strSQL">The SQL statement which will be used
		/// to load the collection.</param>
		/// <returns>A T collection of U objects</returns>
		public T LoadCollection<T,U>( String strSQL ) where T : DataList<U>, new()
			where U: IDataItem, new()
		{
			T t = new T( );

			this.LoadData( strSQL, t.OnAddRow );

			return t;
		}

		/// <summary>
		/// LoadItem loads a single item from a database. It returns a
		/// constructed and loaded object, or null if no object was
		/// found based on the SQL statement.
		/// </summary>
		/// <typeparam name="T">The type of the object which is to be loaded (must
		/// inherit from Common.Data.IDataItem</typeparam>
		/// <param name="strSQL">The SQL statement which will be used.</param>
		/// <returns></returns>
		public T LoadItem<T>( String strSQL ) 
			where T : IDataItem, new( )
		{
			T t = default(T);

			OnFetchRow func = delegate( IDataReader reader )
			{
				t = new T( );
				t.Load( reader );
			};

			this.LoadData( strSQL, func );

			return t;
		}

		/// <summary>
		/// LoadData fetches data from a given SQL statement and returns a 
		/// DataSet object. If something fails it returns null and shows an
		/// Assert window.
		/// </summary>
		/// <param name="strSQL">SQL statement</param>
		/// <returns>DataSet item that includes the data or null if there was
		/// an error.</returns>
		public DataSet LoadData( String strSQL )
		{
			DataSet ds = null;
			IDbConnection connection = null;
			IDbCommand command = null;
			IDbDataAdapter adapter = null;

			try
			{
				connection = OpenConnection( );
				command = CreateCommand( strSQL, connection );
				adapter = CreateSelectAdapter( command );
				ds = new DataSet( );
				adapter.Fill( ds );
				connection.Close( );
			}
			catch ( Exception ex )
			{
				Debug.Fail( ex.Message, ex.Source );
				throw;
			}
			finally
			{
				if ( adapter != null && adapter is IDisposable )
				{
					( (IDisposable)adapter ).Dispose( );
				}
				if (command != null)
				{
					command.Dispose();
				}
				if (connection != null)
				{
					connection.Dispose();
				}
			}
			return ds;
		}

		/// <summary>
		/// This overload of the function LoadData takes in delegate
		/// object which called for each datarow that is read in.
		/// This function uses DataReader to read the data.
		/// </summary>
		/// <param name="strSQL">The SQL statement which will be used.</param>
		/// <param name="fetchRowDelegate">OnFetchRow delegate</param>
		public void LoadData( String strSQL, OnFetchRow fetchRowDelegate )
		{
			IDbConnection connection = null;
			IDbCommand command = null;
			IDataReader reader = null;

			try
			{
				connection = OpenConnection( );
				command = CreateCommand( strSQL, connection );
				reader = command.ExecuteReader( );

				// Loop through each record and call the delegate
				// for each entry:
				while ( reader.Read( ) )
				{
					fetchRowDelegate( reader );
				}
			}
			catch ( Exception ex )
			{
				Debug.Fail( ex.Message, ex.Source );
				// Maintain stack trace by using throw; instead of throw ex;
				throw;
			}
			finally
			{
				// Cleanup:
				if ( reader != null )
				{
					reader.Dispose( );
				}
				if ( command != null )
				{
					command.Dispose( );
				}
				if ( connection != null )
				{
					connection.Dispose( );
				}
			}
		}

		/// <summary>
		/// This function runs a specific SQL statement.
		/// </summary>
		/// <param name="strSQL">The SQL statement to be run.</param>
		public void ExecuteSQL( String strSQL )
		{
			IDbConnection connection = null;
			IDbCommand command = null;

			try
			{
				connection = OpenConnection( );
				command = CreateCommand( strSQL, connection );
				command.ExecuteNonQuery( );
			}
			catch ( Exception ex )
			{
				Debug.Fail( ex.Message, ex.Source );
				throw;
			}
			finally
			{
				// Clean up:
				if (command != null)
				{
					command.Dispose();
				}
				if (connection != null)
				{
					connection.Dispose();
				}
			}
		}

		/// <summary>
		/// ExecuteTransaction accepts an array of SQL statements (such as multiple
		/// DELETE statements) and executes them inside a transaction.
		/// </summary>
		/// <param name="arrStrSQLStatements">The SQL statements to execute.</param>
		public void ExecuteTransaction( String[] arrStrSQLStatements )
		{
			IDbConnection connection = null;
			IDbTransaction transaction = null;

			try
			{
				connection = OpenConnection( );
				transaction = connection.BeginTransaction( );

				foreach ( String strSQL in arrStrSQLStatements )
				{
					using ( IDbCommand command = CreateCommand( strSQL, connection, transaction ) )
					{
						command.ExecuteNonQuery( );
					}
				}
				transaction.Commit( );
			}
			catch ( Exception ex )
			{
				if ( transaction != null )
				{
					transaction.Rollback( );
				}

				Debug.Fail( ex.Message, ex.Source );
				throw;
			}
			finally
			{
				// Hreinsa upp allar au�lindir:
				if ( transaction != null )
				{
					transaction.Dispose( );
				}
				if ( connection != null )
				{
					connection.Dispose( );
				}
			}
		}

		/// <summary>
		/// UpdateData is a generic function that handles UPDATE Sql statements.
		/// The TableDescription object parameter should contain all information
		/// about the update, such as all columns, their types, the values to
		/// be inserted, and the primary key which controls what record should
		/// be updated.
		/// </summary>
		/// <param name="table">TableDescription of the table to be updated.</param>
		public void UpdateData( TableDescription table )
		{
			IDbConnection connection = null;
			IDbCommand command = null;
			DbParameter param = null;

			try
			{
				connection = OpenConnection( );

				ColumnDescription primaryKey = null;
				StringBuilder strBldr = new StringBuilder( );
				String strWhere = "";
				String strSQL;

				// Build the SQL parameter list:
				for ( int i = 0; i < table.Columns.Length; i++ )
				{
					ColumnDescription col = table.Columns[ i ];

					// Update operations of course will not update the primary key
					// (assuming it is auto generated):
					if ( !col.IsPrimaryKey )
					{
						strBldr.Append( "[" );
						strBldr.Append( col.Name );
						strBldr.Append( "] = @" );
						strBldr.Append( col.Name );
						if ( i < ( table.Columns.Length - 1 ) )
						{
							strBldr.Append( ", " );
						}
					}
					else
					{
						strWhere = col.Name + " = @" + col.Name;
					}
				}

				strSQL = String.Format( "UPDATE {0} SET {1} WHERE {2}",
									table.Name,
									strBldr.ToString( ),
									strWhere );

				command = CreateCommand( strSQL, connection );

				foreach ( ColumnDescription col in table.Columns )
				{
					if ( !col.IsPrimaryKey )
					{
						param = this.CreateParameter( command, col.Name, col.Value, col.Type );
					}
					else
					{
						primaryKey = col;
					}
				}

				// Order of parameters is important with the OleDb provider, the 
				// primary key is the last parameter in the SQL statement and hence
				// must be created last. This shouldn't matter in theory, but
				// it does in practice.
				if ( primaryKey != null )
				{
					param = this.CreateParameter( command, primaryKey.Name, primaryKey.Value, primaryKey.Type );
				}

				// Finally, perform the insert:
				command.ExecuteNonQuery( );
			}
			catch ( Exception ex )
			{
				Debug.Write( ex );
				throw;
			}
			finally
			{
				if ( command != null )
				{
					command.Dispose( );
				}
				if ( connection != null )
				{
					connection.Dispose( );
				}
			}
		}

		/// <summary>
		/// AddData is a generic function which handles INSERT sql statements.
		/// The implementation is very similar to the UpdateDate function,
		/// but not similar enough to be reusable. It assumes that the 
		/// table in question will generate its own primary key. The function
		/// then fetches the generated primary key and returns it.
		/// </summary>
		/// <param name="table">TableDescription of the table to be inserted into.</param>
		/// <returns>The generated primary key of the new record.</returns>
		public int AddData( TableDescription table )
		{
			IDbConnection connection = null;
			IDbCommand command = null;
			IDbCommand idCommand = null;
			DbParameter param = null;

			try
			{
				StringBuilder strBldrColumnNames = new StringBuilder( );
				StringBuilder strBldrValues = new StringBuilder( );
				String strSQL;

				for ( int i = 0; i < table.Columns.Length; i++ )
				{
					ColumnDescription col = table.Columns[ i ];

					// We assume that the Insert operation will generate 
					// the primary key, hence we should NOT try to mess with it.
					if ( !col.IsPrimaryKey )
					{
						strBldrColumnNames.Append( "[" );
						strBldrColumnNames.Append( col.Name );
						strBldrColumnNames.Append( "]" );
						if ( i < ( table.Columns.Length - 1 ) )
						{
							strBldrColumnNames.Append( ", " );
						}

						strBldrValues.Append( "@" );
						strBldrValues.Append( col.Name );
						if ( i < ( table.Columns.Length - 1 ) )
						{
							strBldrValues.Append( ", " );
						}
					}
				}

				strSQL = String.Format( "INSERT INTO {0} ( {1} ) VALUES ({2})",
									table.Name,
									strBldrColumnNames.ToString( ),
									strBldrValues.ToString( ) );

				connection = OpenConnection( );

				command = CreateCommand( strSQL, connection );

				foreach ( ColumnDescription col in table.Columns )
				{
					if ( !col.IsPrimaryKey )
					{
						param = this.CreateParameter( command, col.Name, col.Value, col.Type );
					}
				}

				command.ExecuteNonQuery( );

				int newID = 0;
				// TODO: this approach is not safe since this returns the last
				// ID generated by the current open connection, but a trigger
				// could in theory insert into a different table which would
				// return a different ID. 
				idCommand = CreateCommand( "SELECT @@IDENTITY", connection );
				// TODO: check out SCOPE_IDENTITY( )
				// http://msdn2.microsoft.com/en-us/library/ms190315.aspx
				// 
				// Retrieve the identity value and store it in the CategoryID column.
				object o = idCommand.ExecuteScalar( );
				if ( o != null )
				{
					newID = Convert.ToInt32( o );
				}

				return newID;
			}
			catch ( Exception ex )
			{
				Debug.Write( ex );
				throw;
			}
			finally
			{
				if ( idCommand != null )
				{
					idCommand.Dispose( );
				}
				if ( command != null )
				{
					command.Dispose( );
				}
				if ( connection != null )
				{
					connection.Dispose( );
				}
			}
		}
		#endregion

		#region Protected helper functions

		/// <summary>
		/// Function that creates parameter for INSERT/UPDATE statements.
		/// </summary>
		/// <param name="command">IDbCommand object that is added parameters to.</param>
		/// <param name="strName">Name of the parameter. It is used twice, both for
		/// SourceColumn and as name for the parameter.</param>
		/// <param name="oValue">The value for the parameter.</param>
		/// <param name="type">Type of the column.</param>
		/// <returns>The columns needed for INSERT/UPDATE.</returns>
		protected DbParameter CreateParameter( IDbCommand command, String strName, object oValue, DbType type )
		{
			DbParameter param = Factory.CreateParameter( );
			param.DbType = type;
			param.ParameterName = "@" + strName;
			param.SourceColumn = strName;
			param.Value = oValue;
			param.SourceVersion = DataRowVersion.Current;

			command.Parameters.Add( param );

			return param;
		}

		/// <summary>
		/// Overload of CreateParameter that is declared above.
		/// </summary>
		/// <param name="command">IDbCommand object that is added parameters to.</param>
		/// <param name="strName">Name of the parameter. It is used twice, both for
		/// SourceColumn and as name for the parameter.</param>
		/// <param name="oValue">The value for the parameter.</param>
		/// <returns>DbParameter</returns>
		protected DbParameter CreateParameter(IDbCommand command, String strName, object oValue)
		{
			return CreateParameter( command, strName, oValue, DbType.String );
		}

		/// <summary>
		/// Function that creates a command.
		/// </summary>
		/// <param name="strSQL">SQL statement</param>
		/// <param name="connection">IDbconnection</param>
		/// <returns>IDbCommand</returns>
		protected IDbCommand CreateCommand( String strSQL, IDbConnection connection )
		{
			IDbCommand command = Factory.CreateCommand( );
			command.Connection = connection;
			command.CommandText = strSQL;

			return command;
		}

		/// <summary>
		/// Function that creates a command.
		/// </summary>
		/// <param name="strSQL">SQL statement</param>
		/// <param name="connection">IDbconnection</param>
		/// <param name="transaction">IDbTransaction</param>
		/// <returns>IDbCommand</returns>
		protected IDbCommand CreateCommand( String strSQL, IDbConnection connection, IDbTransaction transaction )
		{
			IDbCommand command = CreateCommand( strSQL, connection );
			command.Transaction = transaction;

			return command;
		}

		/// <summary>
		/// Creates adapter with Factory.CreateDataAdapter( ) for the command.
		/// </summary>
		/// <param name="command">IDbCommand</param>
		/// <returns>IDbDataAdapter</returns>
		protected IDbDataAdapter CreateSelectAdapter( IDbCommand command )
		{
			IDbDataAdapter adapter = Factory.CreateDataAdapter( );
			adapter.SelectCommand = command;

			return adapter;
		}
		#endregion
	}
}