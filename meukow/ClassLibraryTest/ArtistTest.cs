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
	///This is a test class for ClassLibrary.Artist and is intended
	///to contain all ClassLibrary.Artist Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistTest
	{
		private readonly String m_strConnectionStringName = "appDatabase";
		/// <summary>
		///A test for Artist ()
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			Artist target = new Artist();

			Assert.AreEqual(0, target.ID, "ID is not 0.");
			Assert.IsNull(target.Name, "Name is not null.");
			Assert.IsNull(target.Picture, "Starts is not null.");
			Assert.IsNull(target.URL, "URL is not null.");
			Assert.IsNull(target.Description, "WeekList is not null.");
		}

		/// <summary>
		///A test for Description
		///</summary>
		[Test]
		public void DescriptionTest()
		{
			Artist target = new Artist();

			string val = null;

			target.Description = val;

			Assert.IsNull(target.Description, "ClassLibrary.Artist.Description was not set correctly.");

			val = "Test Description";

			target.Description = val;

			Assert.AreEqual(val, target.Description, "ClassLibrary.Artist.Description was not set correctly with a value.");
		}

		/// <summary>
		///A test for GetTable ()
		///</summary>
		[Test]
		public void GetTableTest()
		{
			Artist target = new Artist();

			TableDescription actual;

			actual = target.GetTable();

			Assert.AreEqual("ID", actual.Columns[0].Name, "Name is not the same for ID");
			Assert.AreEqual(0, actual.Columns[0].Value, "Value is not the same for ID");
			Assert.AreEqual(DbType.Int32, actual.Columns[0].Type, "Type is not the same for ID");
			Assert.AreEqual(true, actual.Columns[0].IsPrimaryKey, "IsPrimaryKey is not the same for ID");

			Assert.AreEqual("Name", actual.Columns[1].Name, "Name is not the same for Name");
			Assert.AreEqual(null, actual.Columns[1].Value, "Value is not the same for Name");
			Assert.AreEqual(DbType.String, actual.Columns[1].Type, "Type is not the same for Name");
			Assert.AreEqual(false, actual.Columns[1].IsPrimaryKey, "IsPrimaryKey is not the same for Name");

			Assert.AreEqual("Description", actual.Columns[2].Name, "Name is not the same for Description");
			Assert.AreEqual(null, actual.Columns[2].Value, "Value is not the same for Description");
			Assert.AreEqual(DbType.String, actual.Columns[2].Type, "Type is not the same for Description");
			Assert.AreEqual(false, actual.Columns[2].IsPrimaryKey, "IsPrimaryKey is not the same for Description");

			Assert.AreEqual("Picture", actual.Columns[3].Name, "Name is not the same for Picture");
			Assert.AreEqual(null, actual.Columns[3].Value, "Value is not the same for Picture");
			Assert.AreEqual(DbType.String, actual.Columns[3].Type, "Type is not the same for Picture");
			Assert.AreEqual(false, actual.Columns[3].IsPrimaryKey, "IsPrimaryKey is not the same for Picture");

			Assert.AreEqual("Url", actual.Columns[4].Name, "Name is not the same for Url");
			Assert.AreEqual(null, actual.Columns[4].Value, "Value is not the same for Url");
			Assert.AreEqual(DbType.String, actual.Columns[4].Type, "Type is not the same for Url");
			Assert.AreEqual(false, actual.Columns[4].IsPrimaryKey, "IsPrimaryKey is not the same for Url");

		}

		/// <summary>
		///A test for ID
		///</summary>
		[Test]
		public void IDTest()
		{
			Artist target = new Artist();

			int val = 0; 

			Assert.AreEqual(val, target.ID, "ClassLibrary.Artist.ID was not set correctly.");

			val = 10;

			target.ID = val;

			Assert.AreEqual(val, target.ID, "ClassLibrary.Artist.ID was not set correctly with a value.");
		}

		/// <summary>
		///A test for Load (IDataReader)
		///</summary>
		[Test]
		public void LoadTest()
		{
			Artist target = new Artist();

			IDataReader reader = null;

			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
			connection.Open();

			String strSQL = "select * from Artist";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				target.Load(reader);

				Assert.AreEqual(Convert.ToInt32(reader["ID"]), target.ID, "ID is not correct");
				Assert.AreEqual(reader["Name"].ToString(), target.Name, "Name is not correct");
				Assert.AreEqual(reader["Picture"].ToString(), target.Picture, "Picture is not correct");
				Assert.AreEqual(reader["URL"].ToString(), target.URL, "URL is not correct");
				Assert.AreEqual(reader["Description"].ToString(), target.Description, "Description is not correct");
			}
		}

		/// <summary>
		///A test for Name
		///</summary>
		[Test]
		public void NameTest()
		{
			Artist target = new Artist();

			string val = null;

			target.Name = val;

			Assert.IsNull(target.Name, "ClassLibrary.List.Name was not set correctly.");

			val = "Test nafn";

			target.Name = val;

			Assert.AreEqual(val, target.Name, "ClassLibrary.List.Name was not set correctly with a value.");

		}

		/// <summary>
		///A test for Picture
		///</summary>
		[Test]
		public void PictureTest()
		{
			Artist target = new Artist();

			string val = null; 

			target.Picture = val;

			Assert.IsNull(target.Picture,"ClassLibrary.List.Picture was not set correctly.");

			val = "Test Picture";

			target.Picture = val;

			Assert.AreEqual(val, target.Picture, "ClassLibrary.Artist.Picture was not set correctly.");

		}

		/// <summary>
		///A test for ToString ()
		///</summary>
		[Test]
		public void ToStringTest()
		{
			Artist target = new Artist();

			string expected = null;
			string actual;

			actual = target.ToString();

			Assert.AreEqual(expected, actual, "ClassLibrary.Artist.ToString did not return the expected value.");

			actual = "Test Name";
			expected = "Test Name";

			target.Name = actual;

			Assert.AreEqual(expected, actual, "ClassLibrary.Artist.ToString did not return the expected value.");
		}

		/// <summary>
		///A test for URL
		///</summary>
		[Test]
		public void URLTest()
		{
			Artist target = new Artist();

			string val = null;

			Assert.IsNull(target.Picture, "ClassLibrary.List.Picture was not set correctly.");

			val = "Test URL";

			target.Picture = val;

			Assert.AreEqual(val, target.Picture, "ClassLibrary.Artist.URL was not set correctly.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.ArtistCollection and is intended
	///to contain all ClassLibrary.ArtistCollection Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistCollectionTest
	{
		/// <summary>
		///A test for Sort (string)
		///</summary>
		[Test]
		public void SortTest()
		{
			ArtistCollection target = new ArtistCollection();

			string strOrderBy = null; // TODO: Initialize to an appropriate value

			target.Sort(strOrderBy);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.ArtistSorter and is intended
	///to contain all ClassLibrary.ArtistSorter Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistSorterTest
	{
		private readonly String m_strConnectionStringName = "appDatabase";

		/// <summary>
		///A test for Compare (Artist, Artist)
		///</summary>
		[Test]
		public void CompareTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			string strOrderBy = "Name";

			ArtistSorter target = new ArtistSorter(strOrderBy);
			Artist x = new Artist();
			Artist y = new Artist();
			int expected = 0;
			int actual;

			IDataReader reader = null;

			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
			connection.Open();

			String strSQL = "select * from Artist";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				x.Load(reader);
				y.Load(reader);

				actual = target.Compare(x, y);

				Assert.AreEqual(expected, actual, "ClassLibrary.SongSorter.Compare did not return the expected value.");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}
	}
}
