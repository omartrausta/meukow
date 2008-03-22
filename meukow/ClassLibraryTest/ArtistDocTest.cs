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
	public class ArtistDocTest
	{
		private readonly String m_strConnectionStringName = "appDatabase";

		/// <summary>
		///A test for AddList (List)
		///</summary>
		[Test]
		public void AddArtistTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			ArtistDoc target = new ArtistDoc();
			Artist artist = new Artist();
			Artist expected = new Artist();

			artist.Name = "ArtistName";
			artist.Picture = "ArtistPicture";
			artist.URL = "ArtistURL";
			artist.Description = "ArtistDescription";

			target.AddArtist(artist);

			Assert.AreNotEqual(0, artist.ID, "ID is 0 in List.");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from List where ID = " + artist.ID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, artist.ID, "ID is not correct");
				Assert.AreEqual(expected.Name, artist.Name, "Name is not correct");
				Assert.AreEqual(expected.Picture, artist.Picture, "Picture is not correct");
				Assert.AreEqual(expected.URL, artist.URL, "URL is not correct");
				Assert.AreEqual(expected.Description, artist.Description, "Description is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for DeleteList (List)
		///</summary>
		[Test]
		public void DeleteArtistTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			ArtistDoc target = new ArtistDoc();

			Artist artist = new Artist();

			artist.ID = 1;

			target.DeleteArtist(artist);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from List where ID = " + artist.ID.ToString();
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
		public void GetAllArtistTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			ArtistDoc target = new ArtistDoc();

			ArtistCollection expected = new ArtistCollection();
			Artist expectedArtist = null;
			ArtistCollection actual = target.GetAllArtists();

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Artist";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedArtist = new Artist();

				expectedArtist.ID = Convert.ToInt32(reader["ID"]);
				expectedArtist.Name = reader["Name"].ToString();
				expectedArtist.Picture = reader["Picture"].ToString();
				expectedArtist.URL = reader["URL"].ToString();
				expectedArtist.Description = reader["Description"].ToString();

				expected.Add(expectedArtist);
			}

			Assert.AreEqual(expected.Count, actual.Count, "Count is not the same.");

			for (int i = 0; i < actual.Count; i++)
			{
				Assert.AreEqual(expected[i].ID, actual[i].ID, "ID is not correct");
				Assert.AreEqual(expected[i].Name, actual[i].Name, "Name is not correct");
				Assert.AreEqual(expected[i].Picture, actual[i].Picture, "Picture is not correct");
				Assert.AreEqual(expected[i].URL, actual[i].URL, "URL is not correct");
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
		public void GetArtistTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			ArtistDoc target = new ArtistDoc();

			int nID = 4;

			Artist expected = new Artist();
			Artist actual;

			actual = target.GetArtist(nID);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Artist where ID = " + nID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, actual.ID, "ID is not correct");
				Assert.AreEqual(expected.Name, actual.Name, "Name is not correct");
				Assert.AreEqual(expected.Picture, actual.Picture, "Picture is not correct");
				Assert.AreEqual(expected.URL, actual.URL, "URL is not correct");
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
		public void UpdateArtistTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			ArtistDoc target = new ArtistDoc();

			Artist artist = new Artist();

			Artist expected = new Artist();

			String val = "Test Update Artist";

			artist = target.GetArtist(1);

			artist.Name = val;

			target.UpdateArtist(artist);

			Assert.AreEqual(val, artist.Name, "Name is not correct in Artist after update");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from Artist where ID = " + artist.ID.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.ID, artist.ID, "ID is not correct");
				Assert.AreEqual(expected.Name, artist.Name, "Name is not correct");
				Assert.AreEqual(expected.Picture, artist.Picture, "Picture is not correct");
				Assert.AreEqual(expected.URL, artist.URL, "URL is not correct");
				Assert.AreEqual(expected.Description, artist.Description, "Description is not correct");
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
