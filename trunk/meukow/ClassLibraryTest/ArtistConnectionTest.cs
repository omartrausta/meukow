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
	///This is a test class for ClassLibrary.ArtistConnection and is intended
	///to contain all ClassLibrary.ArtistConnection Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistConnectionTest
	{
		private readonly String m_strConnectionStringName = "appDatabase";

		/// <summary>
		///A test for ArtistConnection ()
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			ArtistConnection target = new ArtistConnection();

			Assert.AreEqual(0, target.IDParent, "IDParent is not 0.");
			Assert.AreEqual(0, target.IDChild, "IDChild is not 0.");
		}

		/// <summary>
		///A test for GetTable ()
		///</summary>
		[Test]
		public void GetTableTest()
		{
			ArtistConnection target = new ArtistConnection();

			TableDescription actual;

			actual = target.GetTable();

			Assert.AreEqual("IDParent", actual.Columns[0].Name, "Name is not the same for IDParent");
			Assert.AreEqual(0, actual.Columns[0].Value, "Value is not the same for IDParent");
			Assert.AreEqual(DbType.Int32, actual.Columns[0].Type, "Type is not the same for IDParent");
			Assert.AreEqual(false, actual.Columns[0].IsPrimaryKey, "IsPrimaryKey is not the same for IDParent");

			Assert.AreEqual("IDChild", actual.Columns[1].Name, "Name is not the same for IDChild");
			Assert.AreEqual(0, actual.Columns[1].Value, "Value is not the same for IDChild");
			Assert.AreEqual(DbType.Int32, actual.Columns[1].Type, "Type is not the same for IDChild");
			Assert.AreEqual(false, actual.Columns[1].IsPrimaryKey, "IsPrimaryKey is not the same for IDChild");
		}

		/// <summary>
		///A test for IDChild
		///</summary>
		[Test]
		public void IDChildTest()
		{
			ArtistConnection target = new ArtistConnection();

			int val = 0;

			Assert.AreEqual(val, target.IDChild, "ClassLibrary.ArtistConnection.IDChild was not set correctly.");

			val = 10;

			target.IDChild = val;

			Assert.AreEqual(val, target.IDChild, "ClassLibrary.ArtistConnection.IDChild was not set correctly with a value.");
		}

		/// <summary>
		///A test for IDParent
		///</summary>
		[Test]
		public void IDParentTest()
		{
			ArtistConnection target = new ArtistConnection();

			int val = 0;

			Assert.AreEqual(val, target.IDParent, "ClassLibrary.ArtistConnection.IDParent was not set correctly.");

			val = 10;

			target.IDParent = val;

			Assert.AreEqual(val, target.IDParent, "ClassLibrary.ArtistConnection.IDParent was not set correctly with a value.");
		}

		/// <summary>
		///A test for Load (IDataReader)
		///</summary>
		[Test]
		public void LoadTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			ArtistConnection target = new ArtistConnection();

			IDataReader reader = null;

			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
			connection.Open();

			String strSQL = "select * from ArtistConnection";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				target.Load(reader);

				Assert.AreEqual(Convert.ToInt32(reader["IDParent"]), target.IDParent, "IDParent is not correct");
				Assert.AreEqual(Convert.ToInt32(reader["IDChild"]), target.IDChild, "IDChild is not correct");

			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for ToString ()
		///</summary>
		[Test]
		public void ToStringTest()
		{
			ArtistConnection target = new ArtistConnection();

			int actual = 0;

			Assert.AreEqual(actual.ToString(), target.ToString(), "ClassLibrary.List.ToString did not return the expected value.");

			actual = 12;

			target.IDParent = actual;

			Assert.AreEqual(actual.ToString(), target.ToString(), "ClassLibrary.List.ToString did not return the expected value.");
		}
	}
	/// <summary>
	///This is a test class for ClassLibrary.ArtistConnectionCollection and is intended
	///to contain all ClassLibrary.ArtistConnectionCollection Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistConnectionCollectionTest
	{
		/// <summary>
		///A test for Sort (string)
		///</summary>
		[Test]
		public void SortTest()
		{
			ArtistConnectionCollection target = new ArtistConnectionCollection();

			string strOrderBy = "IDParent";

			target.Sort(strOrderBy);

			Assert.IsFalse(target.Count > 0, "ArtistConnectionCollection is greater than 0.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.ArtistConnectionSorter and is intended
	///to contain all ClassLibrary.ArtistConnectionSorter Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistConnectionSorterTest
	{
		private readonly String m_strConnectionStringName = "appDatabase";

		/// <summary>
		///A test for Compare (ArtistConnection, ArtistConnection)
		///</summary>
		[Test]
		public void CompareTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			string strOrderBy = "IDParent";

			ArtistConnectionSorter target = new ArtistConnectionSorter(strOrderBy);
			ArtistConnection x = new ArtistConnection();
			ArtistConnection y = new ArtistConnection();
			int expected = 0;
			int actual;

			IDataReader reader = null;

			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
			connection.Open();

			String strSQL = "select * from ArtistConnection";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				x.Load(reader);
				y.Load(reader);

				actual = target.Compare(x, y);

				Assert.AreEqual(expected, actual, "ClassLibrary.ListSorter.Compare did not return the expected value.");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

	}


}
