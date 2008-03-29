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
    public class ChartTest
    {
        private readonly String m_strConnectionStringName = "appDatabase";

        /// <summary>
        ///A test for Position
        ///</summary>
        [Test]
        public void PositionTest()
        {
            Chart target = new Chart();

            int val = 0;

            target.Position = val;

            Assert.AreEqual(val, target.Position, "ClassLibrary.Chart.Position was not set correctly.");

            val = 5;

            target.Position = val;

            Assert.AreEqual(val, target.Position, "ClassLibrary.Chart.Position was not set correctly with a value.");
        }

        /// <summary>
        ///A test for SongID
        ///</summary>
        [Test]
        public void SongIDTest()
        {
            Chart target = new Chart();

            int val = 0;

            target.SongID = val;

            Assert.AreEqual(val, target.SongID, "ClassLibrary.Chart.SongID was not set correctly.");

            val = 5;

            target.SongID = val;

            Assert.AreEqual(val, target.SongID, "ClassLibrary.Chart.SongID was not set correctly with a value.");
        }

        /// <summary>
        ///A test for SongName
        ///</summary>
        [Test]
        public void SongNameTest()
        {
            Chart target = new Chart();

            String val = "";

            target.SongName = val;

            Assert.AreEqual(val, target.SongName, "ClassLibrary.Chart.SongName was not set correctly.");

            val = "SongName";

            target.SongName = val;

            Assert.AreEqual(val, target.SongName, "ClassLibrary.Chart.SongName was not set correctly with a value.");
        }
        
        /// <summary>
        ///A test for ArtistID
        ///</summary>
        [Test]
        public void ArtistIDTest()
        {
            Chart target = new Chart();

            int val = 0;

            target.ArtistID = val;

            Assert.AreEqual(val, target.ArtistID, "ClassLibrary.Chart.ArtistID was not set correctly.");

            val = 5;

            target.ArtistID = val;

            Assert.AreEqual(val, target.ArtistID, "ClassLibrary.Chart.ArtistID was not set correctly with a value.");
        }

        /// <summary>
        ///A test for ArtistName
        ///</summary>
        [Test]
        public void ArtistNameTest()
        {
            Chart target = new Chart();

            String val = "";

            target.ArtistName = val;

            Assert.AreEqual(val, target.ArtistName, "ClassLibrary.Chart.ArtistName was not set correctly.");

            val = "ArtistName";

            target.ArtistName = val;

            Assert.AreEqual(val, target.ArtistName, "ClassLibrary.Chart.ArtistName was not set correctly with a value.");
        }

        /// <summary>
        ///A test for ArtistID
        ///</summary>
        [Test]
        public void ListIDTest()
        {
            Chart target = new Chart();

            int val = 0;

            target.ListID = val;

            Assert.AreEqual(val, target.ListID, "ClassLibrary.Chart.ListID was not set correctly.");

            val = 5;

            target.ListID = val;

            Assert.AreEqual(val, target.ListID, "ClassLibrary.Chart.ListID was not set correctly with a value.");
        }
        
        /// <summary>
        ///A test for GetTable ()
        ///</summary>
        [Test]
        public void GetTableTest()
        {
            Chart target = new Chart();

            TableDescription actual;

            actual = target.GetTable();


            Assert.AreEqual("List", actual.Columns[0].Name, "Name is not the same for List");
            Assert.AreEqual(0, actual.Columns[0].Value, "Value is not the same for List");
            Assert.AreEqual(DbType.Int32, actual.Columns[0].Type, "Type is not the same for List");
            Assert.AreEqual(true, actual.Columns[0].IsPrimaryKey, "IsPrimaryKey is not the same for List");

            Assert.AreEqual("Position", actual.Columns[1].Name, "Name is not the same for Position");
            Assert.AreEqual(0, actual.Columns[1].Value, "Value is not the same for Position");
            Assert.AreEqual(DbType.Int32, actual.Columns[1].Type, "Type is not the same for Position");
            Assert.AreEqual(false, actual.Columns[1].IsPrimaryKey, "IsPrimaryKey is not the same for Position");

            Assert.AreEqual("SongID", actual.Columns[2].Name, "Name is not the same for SongID");
            Assert.AreEqual(0, actual.Columns[2].Value, "Value is not the same for SongID");
            Assert.AreEqual(DbType.Int32, actual.Columns[2].Type, "Type is not the same for SongID");
            Assert.AreEqual(false, actual.Columns[2].IsPrimaryKey, "IsPrimaryKey is not the same for SongID");

            Assert.AreEqual("SongName", actual.Columns[3].Name, "Name is not the same for SongName");
            Assert.AreEqual(null, actual.Columns[3].Value, "Value is not the same for SongName");
            Assert.AreEqual(DbType.String, actual.Columns[3].Type, "Type is not the same for SongName");
            Assert.AreEqual(false, actual.Columns[3].IsPrimaryKey, "IsPrimaryKey is not the same for SongName");

            Assert.AreEqual("ArtistID", actual.Columns[4].Name, "Name is not the same for ArtistID");
            Assert.AreEqual(0, actual.Columns[4].Value, "Value is not the same for ArtistID");
            Assert.AreEqual(DbType.Int32, actual.Columns[4].Type, "Type is not the same for ArtistID");
            Assert.AreEqual(false, actual.Columns[4].IsPrimaryKey, "IsPrimaryKey is not the same for ArtistID");

            Assert.AreEqual("ArtistName", actual.Columns[5].Name, "Name is not the same for ArtistName");
            Assert.AreEqual(null, actual.Columns[5].Value, "Value is not the same for ArtistName");
            Assert.AreEqual(DbType.String, actual.Columns[5].Type, "Type is not the same for ArtistName");
            Assert.AreEqual(false, actual.Columns[5].IsPrimaryKey, "IsPrimaryKey is not the same for ArtistName");
        }

        /// <summary>
        ///A test for List ()
        ///</summary>
        [Test]
        public void ConstructorTest()
        {
            Chart target = new Chart();

            Assert.AreEqual(0, target.Position, "Position is not 0.");
            Assert.AreEqual(0, target.SongID, "SongID is not 0.");
            Assert.IsNull(target.SongName, "SongName is not null.");
            Assert.AreEqual(0, target.ArtistID, "ArtistID is not 0.");
            Assert.IsNull(target.ArtistName, "ArtistName is not null.");
            Assert.AreEqual(0, target.ListID, "ListID is not 0.");
        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [Test]
        public void LoadTest()
        {
            System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

            Chart target = new Chart();

            IDataReader reader = null;

            OleDbConnection connection = new OleDbConnection();

            connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
            connection.Open();

            String strSQL = string.Format("SELECT [ListProp].[List], [ListProp].[Position] AS [Position], [Song].[ID] AS [SongID], [Song].[Name] AS [SongName], [Artist].[ID] AS [ArtistID], [Artist].[Name] AS [ArtistName] FROM (([Artist] INNER JOIN [Song] ON [Artist].[ID] = [Song].[ArtistID]) INNER JOIN [ListProp] ON [Song].[ID] = [ListProp].[Song])");
            OleDbCommand command = new OleDbCommand(strSQL, connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                target.Load(reader);

                Assert.AreEqual(Convert.ToInt32(reader["Position"]), target.Position, "Position is not correct");
                Assert.AreEqual(Convert.ToInt32(reader["SongID"]), target.SongID, "SongID is not correct");
                Assert.AreEqual(reader["SongName"].ToString(), target.SongName, "SongName is not correct");
                Assert.AreEqual(Convert.ToInt32(reader["ArtistID"]), target.ArtistID, "ArtistID is not correct");
                Assert.AreEqual(reader["ArtistName"].ToString(), target.ArtistName, "ArtistName is not correct");
                Assert.AreEqual(Convert.ToInt32(reader["List"]), target.ListID, "ListID is not correct");
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
            Chart target = new Chart();

            string actual = null;

            Assert.AreEqual(actual, target.ToString(), "ClassLibrary.Chart.ToString did not return the expected value.");

            actual = "Test Name";

            target.SongName = actual;

            Assert.AreEqual(actual, target.ToString(), "ClassLibrary.Chart.ToString did not return the expected value.");
        }

    }
}
