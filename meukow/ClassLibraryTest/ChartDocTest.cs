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
			//System.IO.File.Copy("CopyOfVinsaeldalisti.mdb", "vinsaeldalisti.mdb", true);

			ChartDoc chartdoc = new ChartDoc();

			DataSet ds = chartdoc.GetSongTimesInPos();

			Assert.IsNotNull(ds,"DataSet is not null");

			//return ds;
		}

	}
}
