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
	public class ChartDocTest
	{
		[Test]	
		public void GetSongTimesInPosTest()
		{
			System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			ChartDoc chartdoc = new ChartDoc();

			DataSet ds = chartdoc.GetSongTimesInPos();

			Assert.IsNotNull(ds,"DataSet is not null");
		}

        [Test]
        public void GetChartListTest()
        {
            System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

            ChartDoc chartdoc = new ChartDoc();

            DataSet ds = chartdoc.GetChartList(1);

            Assert.IsNotNull(ds, "DataSet is not null");
        }

        [Test]
        public void GetChartCollectionTest()
        {
            System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

            ChartDoc chartdoc = new ChartDoc();
            ChartCollection collection = new ChartCollection();

            collection = chartdoc.GetChartCollection(1);

            Assert.IsTrue(collection.Count > 0, "ChartCollection is not greater than 0." );
        }
	}
}
