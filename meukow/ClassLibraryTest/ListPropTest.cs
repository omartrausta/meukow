using System;
using NUnit.Framework;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ClassLibrary;
using ClassLibrary.Common.Data;

namespace ClassLibraryTest
{
	/// <summary>
	///This is a test class for ClassLibrary.ListProp and is intended
	///to contain all ClassLibrary.ListProp Unit Tests
	///</summary>
	[TestFixture]
	public class ListPropTest
	{
		private readonly String m_strConnectionStringName = "appDatabase";

		/// <summary>
		///A test for GetTable ()
		///</summary>
		[Test]
		public void GetTableTest()
		{
			ListProp target = new ListProp();

			TableDescription actual;

			actual = target.GetTable();

			Assert.AreEqual("ID", actual.Columns[0].Name, "Name is not the same for ID");
			Assert.AreEqual(0, actual.Columns[0].Value, "Value is not the same for ID");
			Assert.AreEqual(DbType.Int32, actual.Columns[0].Type, "Type is not the same for ID");
			Assert.AreEqual(true, actual.Columns[0].IsPrimaryKey, "IsPrimaryKey is not the same for ID");

			Assert.AreEqual("Song", actual.Columns[1].Name, "Name is not the same for Song");
			Assert.AreEqual(0, actual.Columns[1].Value, "Value is not the same for Song");
			Assert.AreEqual(DbType.Int32, actual.Columns[1].Type, "Type is not the same for Song");
			Assert.AreEqual(false, actual.Columns[1].IsPrimaryKey, "IsPrimaryKey is not the same for Song");

			Assert.AreEqual("List", actual.Columns[2].Name, "Name is not the same for List");
			Assert.AreEqual(0, actual.Columns[2].Value, "Value is not the same for List");
			Assert.AreEqual(DbType.Int32, actual.Columns[2].Type, "Type is not the same for List");
			Assert.AreEqual(false, actual.Columns[2].IsPrimaryKey, "IsPrimaryKey is not the same for List");

			Assert.AreEqual("Position", actual.Columns[3].Name, "Name is not the same for Position");
			Assert.AreEqual(0, actual.Columns[3].Value, "Value is not the same for Position");
			Assert.AreEqual(DbType.Int32, actual.Columns[3].Type, "Type is not the same for Position");
			Assert.AreEqual(false, actual.Columns[3].IsPrimaryKey, "IsPrimaryKey is not the same for Position");
		}

		/// <summary>
		///A test for ID
		///</summary>
		[Test]
		public void IDTest()
		{
			ListProp target = new ListProp();

			int val = 0;

			Assert.AreEqual(val, target.ID, "ClassLibrary.ListProp.ID was not set correctly.");

			val = 10;

			target.ID = val;

			Assert.AreEqual(val, target.ID, "ClassLibrary.ListProp.ID was not set correctly with a value.");
		}

		/// <summary>
		///A test for List
		///</summary>
		[Test]
		public void ListTest()
		{
			ListProp target = new ListProp();

			int val = 0;

			Assert.AreEqual(val, target.List, "ClassLibrary.ListProp.List was not set correctly.");

			val = 10;

			target.List = val;

			Assert.AreEqual(val, target.List, "ClassLibrary.ListProp.List was not set correctly with a value.");
		}

		/// <summary>
		///A test for ListProp ()
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			ListProp target = new ListProp();

			Assert.AreEqual(0, target.ID, "ID is not 0.");
			Assert.AreEqual(0, target.Song, "ID is not 0.");
			Assert.AreEqual(0, target.List, "ID is not 0.");
			Assert.AreEqual(0, target.Position, "ID is not 0.");
		}

		/// <summary>
		///A test for Load (IDataReader)
		///</summary>
		[Test]
		public void LoadTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			ListProp target = new ListProp();

			IDataReader reader = null;

			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
			connection.Open();

			String strSQL = "select * from ListProp";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				target.Load(reader);

				Assert.AreEqual(Convert.ToInt32(reader["ID"]), target.ID, "ID is not correct");
				Assert.AreEqual(Convert.ToInt32(reader["Song"]), target.Song, "Song is not correct");
				Assert.AreEqual(Convert.ToInt32(reader["List"]), target.List, "List is not correct");
				Assert.AreEqual(Convert.ToInt32(reader["Position"]), target.Position, "Position is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for Position
		///</summary>
		[Test]
		public void PositionTest()
		{
			ListProp target = new ListProp();

			int val = 0;

			Assert.AreEqual(val, target.Position, "ClassLibrary.ListProp.Position was not set correctly.");

			val = 10;

			target.Position = val;

			Assert.AreEqual(val, target.Position, "ClassLibrary.ListProp.Position was not set correctly with a value.");
		}

		/// <summary>
		///A test for Song
		///</summary>
		[Test]
		public void SongTest()
		{
			ListProp target = new ListProp();

			int val = 0;

			Assert.AreEqual(val, target.Song, "ClassLibrary.ListProp.Song was not set correctly.");

			val = 10;

			target.Song = val;

			Assert.AreEqual(val, target.Song, "ClassLibrary.ListProp.Song was not set correctly with a value.");
		}

		/// <summary>
		///A test for ToString ()
		///</summary>
		[Test]
		public void ToStringTest()
		{
			ListProp target = new ListProp();

			int actual = 0;

			Assert.AreEqual(actual.ToString(), target.ToString(), "ClassLibrary.ListProp.ToString did not return the expected value.");

			actual = 3;

			target.ID = actual;

			Assert.AreEqual(actual.ToString(), target.ToString(), "ClassLibrary.ListProp.ToString did not return the expected value.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.ListPropCollection and is intended
	///to contain all ClassLibrary.ListPropCollection Unit Tests
	///</summary>
	[TestFixture]
	public class ListPropCollectionTest
	{
		/// <summary>
		///A test for Sort (string)
		///</summary>
		[Test]
		public void SortTest()
		{
			ListPropCollection target = new ListPropCollection();

			string strOrderBy = "ID";

			target.Sort(strOrderBy);

			Assert.IsFalse(target.Count > 0, "ListPropCollection is greater than 0.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.ListPropSorter and is intended
	///to contain all ClassLibrary.ListPropSorter Unit Tests
	///</summary>
	[TestFixture]
	public class ListPropSorterTest
	{
		private readonly String m_strConnectionStringName = "appDatabase";
		
		/// <summary>
		///A test for Compare (ListProp, ListProp)
		///</summary>
		[Test]
		public void CompareTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			string strOrderBy = "ID";

			ListPropSorter target = new ListPropSorter(strOrderBy);
			ListProp x = new ListProp();
			ListProp y = new ListProp();
			int expected = 0;
			int actual;

			IDataReader reader = null;

			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
			connection.Open();

			String strSQL = "select * from ListProp";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				x.Load(reader);
				y.Load(reader);

				actual = target.Compare(x, y);

				Assert.AreEqual(expected, actual, "ClassLibrary.ListPropSorter.Compare did not return the expected value.");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}
	}


}
