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
	///This is a test class for ClassLibrary.SongDoc and is intended
	///to contain all ClassLibrary.SongDoc Unit Tests
	///</summary>
	[TestFixture]
	public class SongDocTest
	{
		private readonly String m_strConnectionStringName = "appDatabase";

		/// <summary>
		///A test for AddSong(song)
		///</summary>
		[Test]
		public void AddSongTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			SongDoc target = new SongDoc();
			Song song = new Song();
			Song expected = new Song();

			song.Name = "SongName";
			song.ArtistID = 2;
			song.SongPath = "SongPath";
			song.Description = "SongDescription";

			target.AddSong(song);

			Assert.AreNotEqual(0, song.ID, "ID is 0 in List.");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Song where ID = " + song.ID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID,song.ID, "ID is not correct");
				Assert.AreEqual(expected.Name, song.Name, "Name is not correct");
				Assert.AreEqual(expected.ArtistID, song.ArtistID, "Artist is not correct");
				Assert.AreEqual(expected.SongPath, song.SongPath, "SongPath is not correct");
				Assert.AreEqual(expected.Description, song.Description, "Description is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for DeleteList (List)
		///</summary>
		[Test]
		public void DeleteSongTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			SongDoc target = new SongDoc();

			Song song = new Song();

			song.ID = 1;

			target.DeleteSong(song);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Song where ID = " + song.ID.ToString();
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
		///A test for GetAllList ()
		///</summary>
		[Test]
		public void GetAllSongTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			SongDoc target = new SongDoc();

			SongCollection expected = new SongCollection();
			Song expectedSong = null;
			SongCollection actual = target.GetAllSongs();

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Song";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedSong = new Song();

				expectedSong.ID = Convert.ToInt32(reader["ID"]);
				expectedSong.Name = reader["Name"].ToString();
				expectedSong.ArtistID = Convert.ToInt32(reader["ArtistID"]);
				expectedSong.SongPath = reader["SongPath"].ToString();
				expectedSong.Description = reader["Description"].ToString();

				expected.Add(expectedSong);
			}

			Assert.AreEqual(expected.Count, actual.Count, "Count is not the same.");

			for (int i = 0; i < actual.Count; i++)
			{
				Assert.AreEqual(expected[i].ID, actual[i].ID, "ID is not correct");
				Assert.AreEqual(expected[i].Name, actual[i].Name, "Name is not correct");
				Assert.AreEqual(expected[i].ArtistID, actual[i].ArtistID, "ArtistID is not correct");
				Assert.AreEqual(expected[i].SongPath, actual[i].SongPath, "SongPath is not correct");
				Assert.AreEqual(expected[i].Description, actual[i].Description, "Description is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for GetList (int)
		///</summary>
		[Test]
		public void GetSongTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			SongDoc target = new SongDoc();

			int nID = 4;

			Song expected = new Song();
			Song actual;

			actual = target.GetSong(nID);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Song where ID = " + nID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID,actual.ID, "ID is not correct");
				Assert.AreEqual(expected.Name, actual.Name, "Name is not correct");
				Assert.AreEqual(expected.ArtistID, actual.ArtistID, "Artist is not correct");
				Assert.AreEqual(expected.SongPath, actual.SongPath, "SongPath is not correct");
				Assert.AreEqual(expected.Description, actual.Description, "Description is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for UpdateList (List)
		///</summary>
		[Test]
		public void UpdateSongTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			SongDoc target = new SongDoc();

			Song song = new Song();

			Song expected = new Song();

			String val = "Test Update Song";

			song = target.GetSong(1);

			song.Name = val;

			target.UpdateSong(song);

			Assert.AreEqual(val, song.Name, "Name is not correct in Song after update");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Song where ID = " + song.ID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, song.ID, "ID is not correct");
				Assert.AreEqual(expected.Name, song.Name, "Name is not correct");
				Assert.AreEqual(expected.ArtistID, song.ArtistID, "Artist is not correct");
				Assert.AreEqual(expected.SongPath, song.SongPath, "SongPath is not correct");
				Assert.AreEqual(expected.Description, song.Description, "Description is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
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