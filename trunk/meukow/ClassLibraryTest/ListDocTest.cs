using System;
using System.Text;
using NUnit.Framework;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections.Generic;
using ClassLibrary;
using ClassLibrary.Common.Data;

namespace ClassLibraryTest
{
	/// <summary>
	///This is a test class for ClassLibrary.ListDoc and is intended
	///to contain all ClassLibrary.ListDoc Unit Tests
	///</summary>
	[TestFixture]
	public class ListDocTest
	{
		private readonly String m_strConnectionStringName = "appDatabase";

		/// <summary>
		///A test for AddList (List)
		///</summary>
		[Test]
		public void AddListTest()
		{
			ListDoc target = new ListDoc();

			List list = new List();
			List expected = new List();

			list.Name = "ListName";
			list.Starts = new DateTime(2008,1,1);
			list.Ends = new DateTime(2008,1,8);
			list.WeekList = true;

			target.AddList(list);
			
			Assert.AreNotEqual(0, list.ID, "ID is 0 in List.");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from List where ID = " + list.ID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, list.ID, "ID is not correct");
				Assert.AreEqual(expected.Name, list.Name, "Name is not correct");
				Assert.AreEqual(expected.Starts, list.Starts, "Starts is not correct");
				Assert.AreEqual(expected.Ends, list.Ends, "Ends is not correct");
				Assert.AreEqual(expected.WeekList, list.WeekList, "WeekList is not correct");

			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for DeleteListt (List)
		///</summary>
		[Test]
		public void DeleteListtTest()
		{
			ListDoc target = new ListDoc();

			List list = null; // TODO: Initialize to an appropriate value

			target.DeleteListt(list);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for GetAllList ()
		///</summary>
		[Test]
		public void GetAllListTest()
		{
			ListDoc target = new ListDoc();

			ListCollection expected = new ListCollection();
			List expectedList = null;
			ListCollection actual = target.GetAllList();
			
			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from List order by ID";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedList = new List();

				expectedList.ID = Convert.ToInt32(reader["ID"]);
				expectedList.Name = reader["Name"].ToString();
				expectedList.Starts = Convert.ToDateTime(reader["Starts"]);
				expectedList.Ends = Convert.ToDateTime(reader["Ends"]);
				expectedList.WeekList = Convert.ToBoolean(reader["WeekList"]);

				expected.Add(expectedList);
			}

			Assert.AreEqual(expected.Count,actual.Count,"Count is not the same.");

			for (int i = 0; i < actual.Count; i++ )
			{
				Assert.AreEqual(expected[i].ID, actual[i].ID, "ID is not correct");
				Assert.AreEqual(expected[i].Name, actual[i].Name, "Name is not correct");
				Assert.AreEqual(expected[i].Starts, actual[i].Starts, "Starts is not correct");
				Assert.AreEqual(expected[i].Ends, actual[i].Ends, "Ends is not correct");
				Assert.AreEqual(expected[i].WeekList, actual[i].WeekList, "WeekList is not correct");

			}
				
			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for GetList (int)
		///</summary>
		[Test]
		public void GetListTest()
		{
			ListDoc target = new ListDoc();

			int nID = 50; // TODO: Initialize to an appropriate value

			List expected = new List();
			List actual;

			actual = target.GetList(nID);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from List where ID = " + nID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, actual.ID, "ID is not correct");
				Assert.AreEqual(expected.Name, actual.Name, "Name is not correct");
				Assert.AreEqual(expected.Starts, actual.Starts, "Starts is not correct");
				Assert.AreEqual(expected.Ends, actual.Ends, "Ends is not correct");
				Assert.AreEqual(expected.WeekList, actual.WeekList, "WeekList is not correct");

			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for UpdateList (List)
		///</summary>
		[Test]
		public void UpdateListTest()
		{
			ListDoc target = new ListDoc();

			List list = null; // TODO: Initialize to an appropriate value

			target.UpdateList(list);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		private OleDbConnection GetConnection()
		{
			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
			connection.Open();
			return connection;
		}
	}
}
