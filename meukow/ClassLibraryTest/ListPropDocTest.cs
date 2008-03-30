using System;
using NUnit.Framework;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ClassLibrary;

namespace ClassLibraryTest
{
	/// <summary>
	///This is a test class for ClassLibrary.ListPropDoc and is intended
	///to contain all ClassLibrary.ListPropDoc Unit Tests
	///</summary>
	[TestFixture]
	public class ListPropDocTest
	{
		#region member variables
		private readonly String m_strConnectionStringName = "appDatabase";
		#endregion

		#region Tests
		/// <summary>
		///A test for AddListProp (ListProp)
		///</summary>
		[Test]
		public void AddListPropTest()
		{
			CopyFile();

			ListPropDoc target = new ListPropDoc();

			ListProp listProp = new ListProp();
			ListProp expected = new ListProp();

			listProp.List = 30;
			listProp.Song = 102;
			listProp.Position = 1;

			target.AddListProp(listProp);

			Assert.AreNotEqual(0, listProp.ID, "ID is 0 in List.");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ListProp where ID = " + listProp.ID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, listProp.ID, "ID is not correct");
				Assert.AreEqual(expected.List, listProp.List, "List is not correct");
				Assert.AreEqual(expected.Song, listProp.Song, "Song is not correct");
				Assert.AreEqual(expected.Position, listProp.Position, "Position is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for DeleteList (ListProp)
		///</summary>
		[Test]
		public void DeleteListtTest()
		{
			CopyFile();

			ListPropDoc target = new ListPropDoc();

			ListProp listProp = new ListProp();

			listProp.ID = 1;

			target.DeleteListProp(listProp);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ListProp where ID = " + listProp.ID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			try
			{
				while (reader.Read())
				{
					Assert.Fail("Delete failed for List");
				}
			}
			catch
			{
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for GetAllListProp ()
		///</summary>
		[Test]
		public void GetAllListPropTest()
		{
			CopyFile();

			ListPropDoc target = new ListPropDoc();

			ListPropCollection expected = new ListPropCollection();
			ListProp expectedListProp = null;
			ListPropCollection actual = target.GetAllListProp();

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ListProp";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedListProp = new ListProp();

				expectedListProp.ID = Convert.ToInt32(reader["ID"]);
				expectedListProp.Song = Convert.ToInt32(reader["Song"]);
				expectedListProp.List = Convert.ToInt32(reader["List"]);
				expectedListProp.Position = Convert.ToInt32(reader["Position"]);

				expected.Add(expectedListProp);
			}

			Assert.AreEqual(expected.Count, actual.Count, "Count is not the same.");

			for (int i = 0; i < actual.Count; i++)
			{
				Assert.AreEqual(expected[i].ID, actual[i].ID, "ID is not correct");
				Assert.AreEqual(expected[i].Song, actual[i].Song, "Song is not correct");
				Assert.AreEqual(expected[i].List, actual[i].List, "List is not correct");
				Assert.AreEqual(expected[i].Position, actual[i].Position, "Position is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for GetListProp (int)
		///</summary>
		[Test]
		public void GetListPropTest()
		{
			CopyFile();

			ListPropDoc target = new ListPropDoc();

			int nID = 50; // TODO: Initialize to an appropriate value

			ListProp expected = new ListProp();
			ListProp actual;

			actual = target.GetListProp(nID);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ListProp where ID = " + nID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, actual.ID, "ID is not correct");
				Assert.AreEqual(expected.Song, actual.Song, "Song is not correct");
				Assert.AreEqual(expected.List, actual.List, "List is not correct");
				Assert.AreEqual(expected.Position, actual.Position, "Position is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for UpdateListProp (ListProp)
		///</summary>
		[Test]
		public void UpdateListPropTest()
		{
			CopyFile();

			ListPropDoc target = new ListPropDoc();

			ListProp listProp = new ListProp();

			ListProp expected = new ListProp();

			int val = 3;

			listProp = target.GetListProp(1);

			listProp.Position = val;

			target.UpdateListProp(listProp);

			Assert.AreEqual(val, listProp.Position, "Position is not correct in List after update");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ListProp where ID = " + listProp.ID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, listProp.ID, "ID is not correct");
				Assert.AreEqual(expected.Song, listProp.Song, "Song is not correct");
				Assert.AreEqual(expected.List, listProp.List, "List is not correct");
				Assert.AreEqual(expected.Position, listProp.Position, "Position is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}
		#endregion

		#region Private functions
		/// <summary>
		/// Copies the data base so that every test can be run with a new instance
		/// of the database
		/// </summary>
		private static void CopyFile()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);
		}

		/// <summary>
		/// Opens connection to database.
		/// </summary>
		/// <returns>Open connection to database.</returns>
		private OleDbConnection GetConnection()
		{
			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
			connection.Open();
			return connection;
		}
		#endregion
	}
}
