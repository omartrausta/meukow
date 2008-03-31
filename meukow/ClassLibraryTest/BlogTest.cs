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
	///This is a test class for ClassLibrary.Blog and is intended
	///to contain all ClassLibrary.Blog Unit Tests
	///</summary>
	[TestFixture]
	public class BlogTest
	{
		#region Member variables
		private readonly String m_strConnectionStringName = "appDatabase";
		#endregion

		#region Tests
		/// <summary>
		///A test for BlogID
		///</summary>
		[Test]
		public void BlogIDTest()
		{
			Blog target = new Blog();

			int val = 0;

			Assert.AreEqual(val, target.ID, "ClassLibrary.Blog.ID was not set correctly.");

			val = 10;

			target.ID = val;

			Assert.AreEqual(val, target.ID, "ClassLibrary.Blog.ID was not set correctly with a value.");
		}

		/// <summary>
		///A test for SongID
		///</summary>
		[Test]
		public void SongIDTest()
		{
			Blog target = new Blog();

			int val = 0;

			target.SongID = val;

			Assert.AreEqual(val, target.SongID, "ClassLibrary.Blog.SongID was not set correctly.");

			val = 5;

			target.SongID = val;

			Assert.AreEqual(val, target.SongID, "ClassLibrary.Blog.SongID was not set correctly with a value.");
		}

		/// <summary>
		///A test for GetTable ()
		///</summary>
		[Test]
		public void GetTableTest()
		{
			Blog target = new Blog();

			//TableDescription expected = null;
			TableDescription actual;

			actual = target.GetTable();

			Assert.AreEqual("ID", actual.Columns[0].Name, "Name is not the same for ID");
			Assert.AreEqual(0, actual.Columns[0].Value, "Value is not the same for ID");
			Assert.AreEqual(DbType.Int32, actual.Columns[0].Type, "Type is not the same for ID");
			Assert.AreEqual(true, actual.Columns[0].IsPrimaryKey, "IsPrimaryKey is not the same for ID");

			Assert.AreEqual("SongID", actual.Columns[1].Name, "Name is not the same for ID");
			Assert.AreEqual(0, actual.Columns[1].Value, "Value is not the same for ID");
			Assert.AreEqual(DbType.Int32, actual.Columns[1].Type, "Type is not the same for ID");
			Assert.AreEqual(false, actual.Columns[1].IsPrimaryKey, "IsPrimaryKey is not the same for ID");

			Assert.AreEqual("Title", actual.Columns[2].Name, "Name is not the same for Name");
			Assert.AreEqual(null, actual.Columns[2].Value, "Value is not the same for Name");
			Assert.AreEqual(DbType.String, actual.Columns[2].Type, "Type is not the same for Name");
			Assert.AreEqual(false, actual.Columns[2].IsPrimaryKey, "IsPrimaryKey is not the same for Name");

			Assert.AreEqual("BlogDate", actual.Columns[3].Name, "Name is not the same for Starts");
			Assert.AreEqual(DateTime.MinValue, actual.Columns[3].Value, "Value is not the same for Starts");
			Assert.AreEqual(DbType.DateTime, actual.Columns[3].Type, "Type is not the same for Starts");
			Assert.AreEqual(false, actual.Columns[3].IsPrimaryKey, "IsPrimaryKey is not the same for Starts");

			Assert.AreEqual("Content", actual.Columns[4].Name, "Name is not the same for Name");
			Assert.AreEqual(null, actual.Columns[4].Value, "Value is not the same for Name");
			Assert.AreEqual(DbType.String, actual.Columns[4].Type, "Type is not the same for Name");
			Assert.AreEqual(false, actual.Columns[4].IsPrimaryKey, "IsPrimaryKey is not the same for Name");
		}

		/// <summary>
		///A test for Load (IDataReader)
		///</summary>
		[Test]
		public void LoadTest()
		{
			Blog target = new Blog();

			IDataReader reader = null;

			OleDbConnection connection = new OleDbConnection();

			connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
			connection.Open();

			String strSQL = String.Format("SELECT Blogs.ID, Song.ID AS SongID, Blogs.Title, Blogs.BlogDate, Blogs.Content FROM (Blogs INNER JOIN Song ON Blogs.SongID = Song.ID) WHERE (Blogs.ID ={0})", 1);
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				target.Load(reader);

				Assert.AreEqual(Convert.ToInt32(reader["ID"]), target.ID, "ID is not correct");
				Assert.AreEqual(Convert.ToInt32(reader["SongID"]), target.SongID, "SongID is not correct");
				Assert.AreEqual(reader["Title"].ToString(), target.Title, "Title is not correct");
				Assert.AreEqual(reader["BlogDate"], target.BlogDate, "BlogDate is not correct");
				Assert.AreEqual(reader["Content"].ToString(), target.Content, "Content is not correct");
			}
		}

		/// <summary>
		///A test for Title
		///</summary>
		[Test]
		public void TitleTest()
		{
			Blog target = new Blog();

			string val = null;

			target.Title = val;

			Assert.IsNull(target.Title, "ClassLibrary.Blog.Title was not set correctly.");

			val = "Test titill";

			target.Title = val;

			Assert.AreEqual(val, target.Title, "ClassLibrary.Blog.Title was not set correctly with a value.");
		}

		/// <summary>
		///A test for BlogDate
		///</summary>
		[Test]
		public void BlogDateTest()
		{
			Blog target = new Blog();

			DateTime val = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, DateTime.MinValue.Hour, DateTime.MinValue.Minute, DateTime.MinValue.Second);

			target.BlogDate = val;

			Assert.AreEqual(val, target.BlogDate, "ClassLibrary.Blog.BlogDate was not set correctly.");

			val = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

			target.BlogDate = val;

			Assert.AreEqual(val, target.BlogDate, "ClassLibrary.Blog.BlogDate was not set correctly with a value.");
		}

		/// <summary>
		///A test for Song ()
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			Blog target = new Blog();

			Assert.AreEqual(0, target.ID, "ID is not 0.");
			Assert.AreEqual(0, target.SongID, "SongID is not 0.");
			Assert.IsNull(target.Title, "Title is not null.");
			Assert.AreEqual(DateTime.MinValue, target.BlogDate, "BlogDate is not DateTime.MinValue.");
			Assert.IsNull(target.Content, "Content is not null.");
		}

		/// <summary>
		///A test for Content
		///</summary>
		[Test]
		public void ContentTest()
		{
			Blog target = new Blog();

			string val = null;

			target.Content = val;

			Assert.IsNull(target.Content, "ClassLibrary.Blog.Content was not set correctly.");

			val = "Test SongPath";

			target.Content = val;

			Assert.AreEqual(val, target.Content, "ClassLibrary.Blog.Content was not set correctly with a value.");
		}

		/// <summary>
		///A test for ToString ()
		///</summary>
		[Test]
		public void ToStringTest()
		{
			Blog target = new Blog();

			string expected = null;
			string actual;

			actual = target.ToString();

			Assert.AreEqual(expected, actual, "ClassLibrary.Blog.ToString did not return the expected value.");

			actual = "Test Name";
			expected = "Test Name";

			target.Title = actual;

			Assert.AreEqual(expected, actual, "ClassLibrary.Blog.ToString did not return the expected value.");
		}
		#endregion
	}
}
