using System;
using NUnit.Framework;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ClassLibrary;

namespace ClassLibraryTest
{
	/// <summary>
	///This is a test class for ClassLibrary.ArtistConnectionDoc and is intended
	///to contain all ClassLibrary.ArtistConnectionDoc Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistConnectionDocTest
	{
		#region Member variables
		private readonly String m_strConnectionStringName = "appDatabase";
		#endregion

		#region Tests
		/// <summary>
		///A test for AddArtistConnection (ArtistConnection)
		///</summary>
		[Test]
		public void AddArtistConnectionTest()
		{
			CopyFile();

			ArtistConnectionDoc target = new ArtistConnectionDoc();
			ArtistConnection actual = new ArtistConnection();
			ArtistConnection expected = new ArtistConnection();

			actual.IDParent = 1;
			actual.IDChild = 2;

			target.AddArtistConnection(actual);

			Assert.AreNotEqual(0, actual.IDParent, "IDParent is 0 in List.");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ArtistConnection where IDParent = " + actual.IDParent.ToString() + " AND IDChild = " + actual.IDChild.ToString();

			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.IDParent, actual.IDParent, "IDParent is not correct");
				Assert.AreEqual(expected.IDChild, actual.IDChild, "IDChild is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for DeleteArtistConnection (ArtistConnection)
		///</summary>
		[Test]
		public void DeleteArtistConnectionTest()
		{
			CopyFile();

			ArtistConnectionDoc target = new ArtistConnectionDoc();
			ArtistConnection actual = new ArtistConnection();

			actual.IDParent = 14;
			actual.IDChild = 13;

			target.DeleteArtistConnection(actual);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ArtistConnection where IDParent = " + actual.IDParent.ToString() + " and IDChild = " +
			actual.IDChild.ToString();
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			try
			{
				while (reader.Read())
				{
					Assert.Fail("Delete failed for ArtistConnection");
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
		///A test for GetAllArtistsConnection ()
		///</summary>
		[Test]
		public void GetAllArtistsConnectionTest()
		{
			CopyFile();

			ArtistConnectionDoc target = new ArtistConnectionDoc();

			ArtistConnectionCollection expected = new ArtistConnectionCollection();
			ArtistConnection expectedArtistConnection = null;
			ArtistConnectionCollection actual = target.GetAllArtistsConnection();

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ArtistConnection";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedArtistConnection = new ArtistConnection();

				expectedArtistConnection.IDParent = Convert.ToInt32(reader["IDParent"]);
				expectedArtistConnection.IDChild = Convert.ToInt32(reader["IDChild"]);

				expected.Add(expectedArtistConnection);
			}

			Assert.AreEqual(expected.Count, actual.Count, "Count is not the same.");

			for (int i = 0; i < actual.Count; i++)
			{
				Assert.AreEqual(expected[i].IDParent, actual[i].IDParent, "IDParent is not correct");
				Assert.AreEqual(expected[i].IDChild, actual[i].IDChild, "IDChild is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for GetArtistConnection (int)
		///</summary>
		[Test]
		public void GetArtistConnectionTest()
		{
			CopyFile();

			ArtistConnectionDoc target = new ArtistConnectionDoc();

			int nIDParent = 14;
			int nIDChild = 13;

			ArtistConnection expected = new ArtistConnection();
			ArtistConnection actual;

			actual = target.GetArtistConnection(nIDParent, nIDChild);

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ArtistConnection where IDParent = " + nIDParent.ToString() + " and IDChild = " +
			nIDChild.ToString();

			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.IDParent, actual.IDParent, "IDParent is not correct");
				Assert.AreEqual(expected.IDChild, actual.IDChild, "IDChild is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for UpdateArtistConnection (ArtistConnection)
		///</summary>
		[Test]
		public void UpdateArtistConnectionTest()
		{
			CopyFile();

			ArtistConnectionDoc target = new ArtistConnectionDoc();

			ArtistConnection oldArtistConnection = new ArtistConnection();

			ArtistConnection expected = new ArtistConnection();

			int valParent = 14;
			int valChild = 13;

			oldArtistConnection = target.GetArtistConnection(valParent,valChild);

			ArtistConnection newArtistConnection = new ArtistConnection();
			newArtistConnection.IDParent = 22;
			newArtistConnection.IDChild = 13;

			oldArtistConnection.IDParent = valParent;

			target.UpdateArtistConnection(oldArtistConnection, newArtistConnection);

			Assert.AreNotEqual(newArtistConnection.IDParent, oldArtistConnection.IDParent, "IDParent is not correct in List after update");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "select * from ArtistConnection where IDParent = " + oldArtistConnection.IDParent.ToString() +
			" and IDChild = " + oldArtistConnection.IDChild.ToString();

			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				Assert.Fail("Delete failed for ArtistConnection");
			}


			strSQL = "select * from ArtistConnection where IDParent = " + newArtistConnection.IDParent.ToString() +
			" and IDChild = " + newArtistConnection.IDChild.ToString();

			command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expected.Load(reader);

				Assert.AreEqual(expected.IDParent, newArtistConnection.IDParent, "IDParent is not correct");
				Assert.AreEqual(expected.IDChild, newArtistConnection.IDChild, "IDChild is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}
		#endregion

		#region private functions
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

		/// <summary>
		/// Copies the data base so that every test can be run with a new instance
		/// of the database
		/// </summary>
		private static void CopyFile()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);
		}
		#endregion
	}
}
