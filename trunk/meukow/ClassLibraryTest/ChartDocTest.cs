using System;
using NUnit.Framework;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ClassLibrary;

namespace ClassLibraryTest
{
	[TestFixture]
	public class ChartDocTest
	{
		#region Member variables
		private readonly String m_strConnectionStringName = "appDatabase";
		#endregion

		#region Tests
		/// <summary>
		///A test for GetChartList (ListID)
		///</summary>
		[Test]
		public void GetChartListTest()
		{
			CopyFile();

			ChartDoc chartdoc = new ChartDoc();
			ChartCollection expected = new ChartCollection();
			Chart expectedChart = null;

			DataSet ds = chartdoc.GetChartList(1);

			Assert.IsNotNull(ds, "DataSet is not null");

			DataTable dv = ds.Tables[0];

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = string.Format("SELECT [ListProp].[List], [ListProp].[Position] AS [Position], [Song].[ID] AS [SongID], [Song].[Name] AS [SongName], [Artist].[ID] AS [ArtistID], [Artist].[Name] AS [ArtistName] FROM (([Artist] INNER JOIN [Song] ON [Artist].[ID] = [Song].[ArtistID]) INNER JOIN [ListProp] ON [Song].[ID] = [ListProp].[Song]) WHERE ([ListProp].[List] = {0})", 1);
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedChart = new Chart();

				expectedChart.ListID = Convert.ToInt32(reader["List"]);
				expectedChart.Position = Convert.ToInt32(reader["Position"]);
				expectedChart.SongID = Convert.ToInt32(reader["SongID"]);
				expectedChart.SongName = reader["SongName"].ToString();
				expectedChart.ArtistID = Convert.ToInt32(reader["ArtistID"]);
				expectedChart.ArtistName = reader["ArtistName"].ToString();

				expected.Add(expectedChart);
			}

			Assert.AreEqual(expected.Count, ds.Tables[0].Rows.Count, "Count is not the same.");

			for (int i = 0; i < dv.Rows.Count; i++)
			{
				DataRow dr = dv.Rows[i];

				if (dr.RowState != DataRowState.Deleted)
				{
					Assert.AreEqual(expected[i].ListID, Convert.ToInt32(dr["List"]), "ListID is not correct");
					Assert.AreEqual(expected[i].Position, Convert.ToInt32(dr["Position"]), "Position is not correct");
					Assert.AreEqual(expected[i].SongID, Convert.ToInt32(dr["SongID"]), "SongID is not correct");
					Assert.AreEqual(expected[i].SongName, dr["SongName"].ToString(), "SongName is not correct");
					Assert.AreEqual(expected[i].ArtistID, Convert.ToInt32(dr["ArtistID"]), "ArtistID is not correct");
					Assert.AreEqual(expected[i].ArtistName, dr["ArtistName"].ToString(), "ArtistName is not correct");
				}
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

		/// <summary>
		///A test for GetChartCollection (ListID)
		///</summary>
		[Test]
		public void GetChartCollectionTest()
		{
			CopyFile();

			ChartDoc target = new ChartDoc();
			ChartCollection expected = new ChartCollection();
			Chart expectedChart = null;
			ChartCollection actual = new ChartCollection();	

			actual = target.GetChartCollection(1);

			Assert.IsTrue(actual.Count > 0, "ChartCollection is not greater than 0.");

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = string.Format("SELECT [ListProp].[List], [ListProp].[Position] AS [Position], [Song].[ID] AS [SongID], [Song].[Name] AS [SongName], [Artist].[ID] AS [ArtistID], [Artist].[Name] AS [ArtistName] FROM (([Artist] INNER JOIN [Song] ON [Artist].[ID] = [Song].[ArtistID]) INNER JOIN [ListProp] ON [Song].[ID] = [ListProp].[Song]) WHERE ([ListProp].[List] = {0})", 1);
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedChart = new Chart();

				expectedChart.ListID = Convert.ToInt32(reader["List"]);
				expectedChart.Position = Convert.ToInt32(reader["Position"]);
				expectedChart.SongID = Convert.ToInt32(reader["SongID"]);
				expectedChart.SongName = reader["SongName"].ToString();
				expectedChart.ArtistID = Convert.ToInt32(reader["ArtistID"]);
				expectedChart.ArtistName = reader["ArtistName"].ToString();

				expected.Add(expectedChart);
			}

			Assert.AreEqual(expected.Count, actual.Count, "Count is not the same.");

			for (int i = 0; i < actual.Count; i++)
			{
				Assert.AreEqual(expected[i].ListID, actual[i].ListID, "ListID is not correct");
				Assert.AreEqual(expected[i].Position, actual[i].Position, "Position is not correct");
				Assert.AreEqual(expected[i].SongID, actual[i].SongID, "SongID is not correct");
				Assert.AreEqual(expected[i].SongName, actual[i].SongName, "SongName is not correct");
				Assert.AreEqual(expected[i].ArtistID, actual[i].ArtistID, "ArtistID is not correct");
				Assert.AreEqual(expected[i].ArtistName, actual[i].ArtistName, "ArtistName is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}
		#endregion

		#region Private functions
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
