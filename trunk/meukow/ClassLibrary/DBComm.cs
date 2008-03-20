using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ClassLibrary
{
	/// <summary>
	/// Klasi sem heldur utan um öll samskipti við gagnagrunn, tengist honum, eyðir
	/// skoðar eða bætir við færslum
	/// </summary>
	public class DBComm
	{
		protected static OleDbConnection OpenConnection()
		{
			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString =
				"Provider=Microsoft.JET.OLEDB.4.0;" +
				"data source=vinsældarlisti.mdb;" + //TODO: Breyta vísun á gagnagrunn, sameiginlegur gagnagrunnur með vef
				"Persist Security Info=False";
			connection.Open();

			return connection;
		}
	}








}
