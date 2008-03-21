using System;
using System.Data;


namespace ClassLibrary.Common.Data
{
	/// <summary>
	/// IDataItem is used in conjunction with the DataList collection class.
	/// </summary>
	public interface IDataItem
	{
		void Load( IDataReader reader );
	}
}