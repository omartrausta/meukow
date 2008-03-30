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
	[TestFixture]
	public class BlogDocTest
	{
		#region Member variables
		private readonly String m_strConnectionStringName = "appDatabase";
		#endregion

		#region Tests
		/// <summary>
		///A test for AddBlog (Blog)
		///</summary>
		[Test]
		public void AddBlogTest()
		{
			CopyFile();

			BlogDoc target = new BlogDoc();
			Blog Blog = new Blog();
			Blog expected = new Blog();

			Blog.Title = "BlogTitle";
			Blog.SongID = 1;
			Blog.BlogDate = DateTime.Now;
			Blog.Content = "BlogContent";

			target.AddBlog(Blog);

			Assert.AreNotEqual(0, Blog.ID, "ID is 0 in List.");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Blogs where ID = " + Blog.ID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, Blog.ID, "ID is not correct");
				Assert.AreEqual(expected.SongID, Blog.SongID, "SongID is not correct");
				Assert.AreEqual(expected.Title, Blog.Title, "Title is not correct");
				Assert.AreEqual(expected.BlogDate, Blog.BlogDate, "BlogDate is not correct");
				Assert.AreEqual(expected.Content, Blog.Content, "Content is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for GetAllBlogs ()
		///</summary>
		[Test]
		public void GetAllBlogTest()
		{
			CopyFile();

			BlogDoc target = new BlogDoc();

			BlogCollection expected = new BlogCollection();
			Blog expectedBlog = null;
			BlogCollection actual = target.GetAllBlogs();

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Blogs";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedBlog = new Blog();

				expectedBlog.ID = Convert.ToInt32(reader["ID"]);
				expectedBlog.SongID = Convert.ToInt32(reader["SongID"]);
				expectedBlog.Title = reader["Title"].ToString();
				expectedBlog.BlogDate = Convert.ToDateTime(reader["BlogDate"]);
				expectedBlog.Content = reader["Content"].ToString();

				expected.Add(expectedBlog);
			}

			Assert.AreEqual(expected.Count, actual.Count, "Count is not the same.");

			for (int i = 0; i < actual.Count; i++)
			{
				Assert.AreEqual(expected[i].ID, actual[i].ID, "ID is not correct");
				Assert.AreEqual(expected[i].SongID, actual[i].SongID, "SongID is not correct");
				Assert.AreEqual(expected[i].Title, actual[i].Title, "Title is not correct");
				Assert.AreEqual(expected[i].BlogDate, actual[i].BlogDate, "BlogDate is not correct");
				Assert.AreEqual(expected[i].Content, actual[i].Content, "Content is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for GetBlogSong (int)
		///</summary>
		[Test]
		public void GetAllBlogSongTest()
		{
			CopyFile();

			BlogDoc target = new BlogDoc();

			BlogCollection expected = new BlogCollection();
			Blog expectedBlog = null;
			BlogCollection actual = target.GetBlogSong(1);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = String.Format("SELECT Blogs.ID,	Song.ID AS SongID, Blogs.Title, Blogs.BlogDate, Blogs.Content FROM (Blogs INNER JOIN Song ON Blogs.SongID = Song.ID) WHERE (Blogs.SongID ={0})", 1);
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedBlog = new Blog();

				expectedBlog.ID = Convert.ToInt32(reader["ID"]);
				expectedBlog.SongID = Convert.ToInt32(reader["SongID"]);
				expectedBlog.Title = reader["Title"].ToString();
				expectedBlog.BlogDate = Convert.ToDateTime(reader["BlogDate"]);
				expectedBlog.Content = reader["Content"].ToString();

				expected.Add(expectedBlog);
			}

			Assert.AreEqual(expected.Count, actual.Count, "Count is not the same.");

			for (int i = 0; i < actual.Count; i++)
			{
				Assert.AreEqual(expected[i].ID, actual[i].ID, "ID is not correct");
				Assert.AreEqual(expected[i].SongID, actual[i].SongID, "SongID is not correct");
				Assert.AreEqual(expected[i].Title, actual[i].Title, "Title is not correct");
				Assert.AreEqual(expected[i].BlogDate, actual[i].BlogDate, "BlogDate is not correct");
				Assert.AreEqual(expected[i].Content, actual[i].Content, "Content is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for GetBlog (int)
		///</summary>
		[Test]
		public void GetBlogTest()
		{
			CopyFile();

			BlogDoc target = new BlogDoc();

			int nID = 4;

			Blog expected = new Blog();
			Blog actual;

			actual = target.GetBlog(nID);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = String.Format("SELECT Blogs.ID, Song.ID AS SongID,	Blogs.Title, Blogs.BlogDate, Blogs.Content FROM (Blogs INNER JOIN Song ON Blogs.SongID = Song.ID) WHERE (Blogs.ID ={0})", nID);
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, actual.ID, "ID is not correct");
				Assert.AreEqual(expected.SongID, actual.SongID, "SongID is not correct");
				Assert.AreEqual(expected.Title, actual.Title, "Title is not correct");
				Assert.AreEqual(expected.BlogDate, actual.BlogDate, "BlogDate is not correct");
				Assert.AreEqual(expected.Content, actual.Content, "Content is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}
		#endregion

		#region private functions
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
