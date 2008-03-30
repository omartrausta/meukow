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
	/// <summary>
	///This is a test class for ClassLibrary.StatisticDoc and is intended
	///to contain all ClassLibrary.StatisticDoc Unit Tests
	///</summary>
	[TestFixture]
	public class StatisticDocTest
	{
		#region Member variables
		private readonly String m_strConnectionStringName = "appDatabase";
		#endregion

		/// <summary>
		///A test for GetStatistics ()
		///</summary>
		[Test]
		public void GetStatisticsTest()
		{
			CopyFile();

			StatisticDoc target = new StatisticDoc();

			StatisticCollection expected = new StatisticCollection();
			Statistic expectedStatistic = null;
			StatisticCollection actual = target.GetStatistics();

			IDataReader reader = null;

			OleDbConnection connection = GetConnection();

			String strSQL = "SELECT [Song].[Name] AS [SongName], [ListProp].[Position] AS [Position], COUNT([Song].[ID]) AS [TimesInPosition] FROM [Song] INNER JOIN ([List] INNER JOIN [ListProp] ON [List].[ID] = [ListProp].[List]) ON [Song].[ID] = [ListProp].[Song] WHERE ((([List].[WeekList])=True)) GROUP by [Song].[Name], [ListProp].[Position]";
			OleDbCommand command = new OleDbCommand(strSQL, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				expectedStatistic = new Statistic();

				expectedStatistic.SongName = reader["SongName"].ToString();
				expectedStatistic.Position = Convert.ToInt32(reader["Position"]);
				expectedStatistic.TimesInPosition = Convert.ToInt32(reader["TimesInPosition"]);

				expected.Add(expectedStatistic);
			}

			Assert.AreEqual(expected.Count, actual.Count, "Count is not the same.");

			for (int i = 0; i < actual.Count; i++)
			{
				Assert.AreEqual(expected[i].SongName, actual[i].SongName, "SongName is not correct");
				Assert.AreEqual(expected[i].Position, actual[i].Position, "Position is not correct");
				Assert.AreEqual(expected[i].TimesInPosition, actual[i].TimesInPosition, "TimesInPosition is not correct");
			}

			connection.Dispose();
			command.Dispose();
			reader.Dispose();
		}

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
