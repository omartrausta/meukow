using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace ClassLibrary.Common.Data
{
	/// <summary>
	/// DataList is a custom List<> class which can be used with
	/// BaseDocument. It simplifies reading data using a DataReader instead
	/// of stuffing all the data into a DataSet, only to re-stuff it into
	/// a collection object. Instead we can just use a DataReader, and stuff
	/// the data directly into a collection.
	/// Note that the POD classes stored within the collection must implement
	/// the IDataItem interface (which is NOT a native .NET interface...). An
	/// alternative would have been to use Activator.CreateInstance, which
	/// would have allowed us to use a constructor which accepts a IDataReader
	/// interface object, but it is much slower.
	/// </summary>
	public class DataList<T> : List<T> where T : IDataItem, new( )
	{
		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public DataList( )
		{
		}
		#endregion

		#region public functions
		/// <summary>
		/// Loads data.
		/// </summary>
		/// <param name="reader">IDataReader</param>
		public void OnAddRow( IDataReader reader )
		{
			T t = new T( );
			t.Load( reader );
			this.Add( t );
		}

		/// <summary>
		/// Converts a collection of columns into one string.
		/// </summary>
		/// <param name="columnsToDisplay">Collection of columns to display</param>
		/// <returns>String with all columns.</returns>
		public String ToCSV( String[] columnsToDisplay )
		{
			StringBuilder strCSV = new StringBuilder( );

			if ( this.Count > 0 )
			{
				// First, build a list of properties which we will include,
				// and build the header from them:
				List<PropertyInfo> propList = new List<PropertyInfo>( );
				object firstObj = this[ 0 ];
				Type t = firstObj.GetType( );

				foreach ( String strColName in columnsToDisplay )
				{
					PropertyInfo propInfo = t.GetProperty( strColName );
					propList.Add( propInfo );

					strCSV.Append( strColName );
					strCSV.Append( ";" );
				}
				strCSV.Append( System.Environment.NewLine );

				// Then foreach item in the list, get the values
				// of the corresponding properties and add a new
				// line with those values.
				foreach ( object o in this )
				{
					foreach ( PropertyInfo prop in propList )
					{
						object oValue = prop.GetValue( o, null );
						if ( oValue != null )
						{
							String strValue = oValue.ToString( );
							strCSV.Append( strValue );
						}

						strCSV.Append( ";" );
					}
					strCSV.Append( System.Environment.NewLine );
				}
			}

			return strCSV.ToString( );
		}
		#endregion
	}
}