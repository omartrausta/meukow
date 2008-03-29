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
        ///A test for SongName
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
        ///A test for GetTable ()
        ///</summary>
        [Test]
        public void GetTableTest()
        {
            List target = new List();

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

            Assert.AreEqual("Starts", actual.Columns[2].Name, "Name is not the same for Starts");
            Assert.AreEqual(DateTime.MinValue, actual.Columns[2].Value, "Value is not the same for Starts");
            Assert.AreEqual(DbType.DateTime, actual.Columns[2].Type, "Type is not the same for Starts");
            Assert.AreEqual(false, actual.Columns[2].IsPrimaryKey, "IsPrimaryKey is not the same for Starts");

            Assert.AreEqual("Ends", actual.Columns[3].Name, "Name is not the same for Ends");
            Assert.AreEqual(DateTime.MinValue, actual.Columns[3].Value, "Value is not the same for Ends");
            Assert.AreEqual(DbType.DateTime, actual.Columns[3].Type, "Type is not the same for Ends");
            Assert.AreEqual(false, actual.Columns[3].IsPrimaryKey, "IsPrimaryKey is not the same for Ends");

            Assert.AreEqual("WeekList", actual.Columns[4].Name, "Name is not the same for WeekList");
            Assert.AreEqual(false, actual.Columns[4].Value, "Value is not the same for WeekList");
            Assert.AreEqual(DbType.Boolean, actual.Columns[4].Type, "Type is not the same for WeekList");
            Assert.AreEqual(false, actual.Columns[4].IsPrimaryKey, "IsPrimaryKey is not the same for WeekList");
        }

        /// <summary>
        ///A test for List ()
        ///</summary>
        [Test]
        public void ConstructorTest()
        {
            List target = new List();

            Assert.AreEqual(0, target.ID, "ID is not 0.");
            Assert.IsNull(target.Name, "Name is not null.");
            Assert.AreEqual(DateTime.MinValue, target.Starts, "Starts is not DateTime.MinValue.");
            Assert.AreEqual(DateTime.MinValue, target.Ends, "Ends is not DateTime.MinValue.");
            Assert.IsFalse(target.WeekList, "WeekList is true.");
        }

        /// <summary>
        ///A test for Load
        ///</summary>
        [Test]
        public void LoadTest()
        {
            System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

            List target = new List();

            IDataReader reader = null;

            OleDbConnection connection = new OleDbConnection();

            connection.ConnectionString = ConfigurationManager.AppSettings[m_strConnectionStringName].ToString();
            connection.Open();

            String strSQL = "select * from List";
            OleDbCommand command = new OleDbCommand(strSQL, connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                target.Load(reader);

                Assert.AreEqual(Convert.ToInt32(reader["ID"]), target.ID, "ID is not correct");
                Assert.AreEqual(reader["Name"].ToString(), target.Name, "Name is not correct");
                Assert.AreEqual(Convert.ToDateTime(reader["Starts"]), target.Starts, "Starts is not correct");
                Assert.AreEqual(Convert.ToDateTime(reader["Ends"]), target.Ends, "Ends is not correct");
                Assert.AreEqual(Convert.ToBoolean(reader["WeekList"]), target.WeekList, "WeekList is not correct");

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
            List target = new List();

            string actual = null;

            Assert.AreEqual(actual, target.ToString(), "ClassLibrary.List.ToString did not return the expected value.");

            actual = "Test Name";

            target.Name = actual;

            Assert.AreEqual(actual, target.ToString(), "ClassLibrary.List.ToString did not return the expected value.");
        }

    }
}
