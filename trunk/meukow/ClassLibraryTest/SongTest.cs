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
	///This is a test class for ClassLibrary.Song and is intended
	///to contain all ClassLibrary.Song Unit Tests
	///</summary>
	[TestFixture]
	public class SongTest
	{
        private readonly String m_strConnectionStringName = "appDatabase";
		/// <summary>
		///A test for ArtistID
		///</summary>
		[Test]
		public void ArtistIDTest()
		{
			Song target = new Song();

            int val = 0;

            Assert.AreEqual(val, target.ArtistID, "ClassLibrary.Song.ArtistID was not set correctly.");

            val = 10;

            target.ArtistID = val;

            Assert.AreEqual(val, target.ArtistID, "ClassLibrary.Song.ArtistID was not set correctly with a value.");
		}

		/// <summary>
		///A test for Description
		///</summary>
		[Test]
		public void DescriptionTest()
		{
			Song target = new Song();

            string val = null;

            target.Description = val;

            Assert.IsNull(target.Description, "ClassLibrary.Song.Description was not set correctly.");

            val = "Test Description";

            target.Description = val;

            Assert.AreEqual(val, target.Description, "ClassLibrary.Song.Description was not set correctly with a value.");
		}

		/// <summary>
		///A test for GetTable ()
		///</summary>
		[Test]
		public void GetTableTest()
		{
			Song target = new Song();

			//TableDescription expected = null;
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

            Assert.AreEqual("ArtistID", actual.Columns[2].Name, "Name is not the same for ID");
            Assert.AreEqual(0, actual.Columns[2].Value, "Value is not the same for ID");
            Assert.AreEqual(DbType.Int32, actual.Columns[2].Type, "Type is not the same for ID");
            Assert.AreEqual(false, actual.Columns[2].IsPrimaryKey, "IsPrimaryKey is not the same for ID");

            Assert.AreEqual("SongPath", actual.Columns[3].Name, "Name is not the same for Name");
            Assert.AreEqual(null, actual.Columns[3].Value, "Value is not the same for Name");
            Assert.AreEqual(DbType.String, actual.Columns[3].Type, "Type is not the same for Name");
            Assert.AreEqual(false, actual.Columns[3].IsPrimaryKey, "IsPrimaryKey is not the same for Name");

            Assert.AreEqual("Description", actual.Columns[4].Name, "Name is not the same for Name");
            Assert.AreEqual(null, actual.Columns[4].Value, "Value is not the same for Name");
            Assert.AreEqual(DbType.String, actual.Columns[4].Type, "Type is not the same for Name");
            Assert.AreEqual(false, actual.Columns[4].IsPrimaryKey, "IsPrimaryKey is not the same for Name");
		}

		/// <summary>
		///A test for ID
		///</summary>
		[Test]
		public void IDTest()
		{
			Song target = new Song();

            int val = 0;

            Assert.AreEqual(val, target.ID, "ClassLibrary.Song.ID was not set correctly.");

            val = 10;

            target.ID = val;

            Assert.AreEqual(val, target.ID, "ClassLibrary.Song.ID was not set correctly with a value.");
		}

		/// <summary>
		///A test for Load (IDataReader)
		///</summary>
		[Test]
		public void LoadTest()
		{
			Song target = new Song();

            IDataReader reader = null;

            OleDbConnection connection = new OleDbConnection();

            connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
            connection.Open();

            String strSQL = "select * from Song";
            OleDbCommand command = new OleDbCommand(strSQL, connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                target.Load(reader);

                Assert.AreEqual(Convert.ToInt32(reader["ID"]), target.ID, "ID is not correct");
                Assert.AreEqual(reader["Name"].ToString(), target.Name, "Name is not correct");
                Assert.AreEqual(Convert.ToInt32(reader["ArtistID"]), target.ArtistID, "ArtistID is not correct");
                Assert.AreEqual(reader["SongPath"].ToString(), target.SongPath, "SongPath is not correct");
                Assert.AreEqual(reader["Description"].ToString(), target.Description, "Description is not correct");
            }
		}

		/// <summary>
		///A test for Name
		///</summary>
		[Test]
		public void NameTest()
		{
			Song target = new Song();

            string val = null;

            target.Name = val;

            Assert.IsNull(target.Name, "ClassLibrary.Song.Name was not set correctly.");

            val = "Test nafn";

            target.Name = val;

            Assert.AreEqual(val, target.Name, "ClassLibrary.Song.Name was not set correctly with a value.");
		}

		/// <summary>
		///A test for Song ()
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			Song target = new Song();

            Assert.AreEqual(0, target.ID, "ID is not 0.");
            Assert.IsNull(target.Name, "Name is not null.");
            Assert.AreEqual(0, target.ArtistID, "ArtistID is not 0.");
            Assert.IsNull(target.SongPath, "SongPath is not null.");
            Assert.IsNull(target.Description, "Description is not null.");
		}

		/// <summary>
		///A test for SongPath
		///</summary>
		[Test]
		public void SongPathTest()
		{
			Song target = new Song();

            string val = null;

            target.Description = val;

            Assert.IsNull(target.SongPath, "ClassLibrary.Song.SongPath was not set correctly.");

            val = "Test SongPath";

            target.SongPath = val;

            Assert.AreEqual(val, target.SongPath, "ClassLibrary.Song.SongPath was not set correctly with a value.");
		}

		/// <summary>
		///A test for ToString ()
		///</summary>
		[Test]
		public void ToStringTest()
		{
			Song target = new Song();

            string expected = null;
            string actual;

            actual = target.ToString();

            Assert.AreEqual(expected, actual, "ClassLibrary.Song.ToString did not return the expected value.");

            actual = "Test Name";
            expected = "Test Name";

            target.Name = actual;

            Assert.AreEqual(expected, actual, "ClassLibrary.Song.ToString did not return the expected value.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.SongCollection and is intended
	///to contain all ClassLibrary.SongCollection Unit Tests
	///</summary>
	[TestFixture]
	public class SongCollectionTest
	{
		/// <summary>
		///A test for Sort (string)
		///</summary>
		[Test]
		public void SortTest()
		{
			SongCollection target = new SongCollection();

            string strOrderBy = "Name";

            target.Sort(strOrderBy);

            Assert.IsFalse(target.Count > 0, "ListCollection is greater than 0.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.SongSorter and is intended
	///to contain all ClassLibrary.SongSorter Unit Tests
	///</summary>
	[TestFixture]
	public class SongSorterTest
	{
        private readonly String m_strConnectionStringName = "appDatabase";
		/// <summary>
		///A test for Compare (Song, Song)
		///</summary>
		[Test]
		public void CompareTest()
		{
            System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

            string strOrderBy = "Name";

            SongSorter target = new SongSorter(strOrderBy);
            Song x = new Song();
            Song y = new Song();
            int expected = 0;
            int actual;

            IDataReader reader = null;

            OleDbConnection connection = new OleDbConnection();

            connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
            connection.Open();

            String strSQL = "select * from Song";
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
