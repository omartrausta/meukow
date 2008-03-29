using System;
using NUnit.Framework;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using ClassLibrary;
using ClassLibrary.Common.Data;

namespace ClassLibraryTest
{
    [TestFixture]
    public class StatisticTest
    {
        private readonly String m_strConnectionStringName = "appDatabase";

        /// <summary>
		///A test for SongName
		///</summary>
		[Test]
		public void SongNameTest()
		{
			Statistic target = new Statistic();

            String val = null; 

			Assert.IsNull(target.SongName, "ClassLibrary.Statistic.SongName was not set correctly.");

			val = "SongName";

			target.SongName = val;

			Assert.AreEqual(val, target.SongName, "ClassLibrary.Statistic.SongName was not set correctly with a value.");
		}

        /// <summary>
        ///A test for Position
        ///</summary>
        [Test]
        public void PositionTest()
        {
            Statistic target = new Statistic();

            int val = 0;

            Assert.AreEqual(val, target.Position, "ClassLibrary.Statistic.Position was not set correctly.");

            val = 10;

            target.Position = val;

            Assert.AreEqual(val, target.Position, "ClassLibrary.Statistic.Position was not set correctly with a value.");
        }

        /// <summary>
        ///A test for TimesInPosition
        ///</summary>
        [Test]
        public void TimesInPositionTest()
        {
            Statistic target = new Statistic();

            int val = 0;

            Assert.AreEqual(val, target.TimesInPosition, "ClassLibrary.Statistic.TimesInPosition was not set correctly.");

            val = 10;

            target.TimesInPosition = val;

            Assert.AreEqual(val, target.TimesInPosition, "ClassLibrary.Statistic.TimesInPosition was not set correctly with a value.");
        }

        /// <summary>
        ///A test for GetTable ()
        ///</summary>
        [Test]
        public void GetTableTest()
        {
            Statistic target = new Statistic();

            TableDescription actual;

            actual = target.GetTable();

            Assert.AreEqual("SongName", actual.Columns[0].Name, "Name is not the same for SongName");
            Assert.AreEqual(null, actual.Columns[0].Value, "Value is not the same for SongName");
            Assert.AreEqual(DbType.String, actual.Columns[0].Type, "Type is not the same for SongName");
            Assert.AreEqual(false, actual.Columns[0].IsPrimaryKey, "IsPrimaryKey is not the same for SongName");

            Assert.AreEqual("Position", actual.Columns[1].Name, "Name is not the same for Position");
            Assert.AreEqual(0, actual.Columns[1].Value, "Value is not the same for Position");
            Assert.AreEqual(DbType.Int32, actual.Columns[1].Type, "Type is not the same for Position");
            Assert.AreEqual(false, actual.Columns[1].IsPrimaryKey, "IsPrimaryKey is not the same for Position");

            Assert.AreEqual("TimesInPosition", actual.Columns[2].Name, "Name is not the same for TimesInPosition");
            Assert.AreEqual(0, actual.Columns[2].Value, "Value is not the same for TimesInPosition");
            Assert.AreEqual(DbType.Int32, actual.Columns[2].Type, "Type is not the same for TimesInPosition");
            Assert.AreEqual(false, actual.Columns[2].IsPrimaryKey, "IsPrimaryKey is not the same for TimesInPosition");
        }

        /// <summary>
        ///A test for Statistic ()
        ///</summary>
        [Test]
        public void ConstructorTest()
        {
            Statistic target = new Statistic();

            Assert.IsNull(target.SongName, "SongName is not null.");
            Assert.AreEqual(0, target.Position, "Position is not 0.");
            Assert.AreEqual(0, target.TimesInPosition, "TimesInPosition is not 0.");
           }

       /// <summary>
       ///A test for Load
       ///</summary>
       [Test]
       public void LoadTest()
       {
           System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

           Statistic target = new Statistic();

           IDataReader reader = null;

           OleDbConnection connection = new OleDbConnection();

           connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
           connection.Open();

           String strSQL = "SELECT [Song].[Name] AS [SongName], [ListProp].[Position] AS [Position], COUNT([Song].[ID]) AS [TimesInPosition] FROM [Song] INNER JOIN ([List] INNER JOIN [ListProp] ON [List].[ID] = [ListProp].[List]) ON [Song].[ID] = [ListProp].[Song] WHERE ((([List].[WeekList])=True)) GROUP by [Song].[Name], [ListProp].[Position]";
           OleDbCommand command = new OleDbCommand(strSQL, connection);
           reader = command.ExecuteReader();

           while (reader.Read())
           {
               target.Load(reader);

               Assert.AreEqual(reader["SongName"].ToString(), target.SongName, "SongName is not correct");
               Assert.AreEqual(Convert.ToInt32(reader["Position"]), target.Position, "Position is not correct");
               Assert.AreEqual(Convert.ToInt32(reader["TimesInPosition"]), target.TimesInPosition, "TimesInPosition is not correct");
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
           Statistic target = new Statistic();

           string actual = null;

           Assert.AreEqual(actual, target.ToString(), "ClassLibrary.Statistic.ToString did not return the expected value.");

           actual = "Test Name";

           target.SongName = actual;

           Assert.AreEqual(actual, target.ToString(), "ClassLibrary.Statistic.ToString did not return the expected value.");
       }
    }

    /// <summary>
    ///This is a test class for ClassLibrary.ListCollection and is intended
    ///to contain all ClassLibrary.ListCollection Unit Tests
    ///</summary>
    [TestFixture]
    public class StatisticCollectionTest
    {
        /// <summary>
        ///A test for Sort (string)
        ///</summary>
        [Test]
        public void SortTest()
        {
            StatisticCollection target = new StatisticCollection();

            string strOrderBy = "SongName";

            target.Sort(strOrderBy);

            Assert.IsFalse(target.Count > 0, "StatisticCollection is greater than 0.");
        }

    }
    /// <summary>
    ///This is a test class for ClassLibrary.ListSorter and is intended
    ///to contain all ClassLibrary.ListSorter Unit Tests
    ///</summary>
    [TestFixture]
    public class StatisticSorterTest
    {
        private readonly String m_strConnectionStringName = "appDatabase";

        /// <summary>
        ///A test for Compare (List, List)
        ///</summary>
        [Test]
        public void CompareTest()
        {
            System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

            string strOrderBy = "Name";

            StatisticSorter target = new StatisticSorter(strOrderBy);
            Statistic x = new Statistic();
            Statistic y = new Statistic();
            int expected = 0;
            int actual;

            IDataReader reader = null;

            OleDbConnection connection = new OleDbConnection();

            connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
            connection.Open();

            String strSQL = "SELECT [Song].[Name] AS [SongName], [ListProp].[Position] AS [Position], COUNT([Song].[ID]) AS [TimesInPosition] FROM [Song] INNER JOIN ([List] INNER JOIN [ListProp] ON [List].[ID] = [ListProp].[List]) ON [Song].[ID] = [ListProp].[Song] WHERE ((([List].[WeekList])=True)) GROUP by [Song].[Name], [ListProp].[Position]";
            OleDbCommand command = new OleDbCommand(strSQL, connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                x.Load(reader);
                y.Load(reader);

                actual = target.Compare(x, y);

                Assert.AreEqual(expected, actual, "ClassLibrary.StatisticSorter.Compare did not return the expected value.");
            }

            connection.Dispose();
            command.Dispose();
            reader.Dispose();
        }
    }
}