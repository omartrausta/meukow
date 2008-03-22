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
	///This is a test class for ClassLibrary.ArtistConnection and is intended
	///to contain all ClassLibrary.ArtistConnection Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistConnectionTest
	{
		/// <summary>
		///A test for ArtistConnection ()
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			ArtistConnection target = new ArtistConnection();

			// TODO: Implement code to verify target
			Assert.Fail("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for ArtistConnection (DataRow)
		///</summary>
		[Test]
		public void ConstructorTest1()
		{
			DataRow row = null; // TODO: Initialize to an appropriate value

			ArtistConnection target = new ArtistConnection(row);

			// TODO: Implement code to verify target
			Assert.Fail("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for GetTable ()
		///</summary>
		[Test]
		public void GetTableTest()
		{
			ArtistConnection target = new ArtistConnection();

			TableDescription expected = null;
			TableDescription actual;

			actual = target.GetTable();

			Assert.AreEqual(expected, actual, "ClassLibrary.ArtistConnection.GetTable did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IDChild
		///</summary>
		[Test]
		public void IDChildTest()
		{
			ArtistConnection target = new ArtistConnection();

			int val = 0; // TODO: Assign to an appropriate value for the property

			target.IDChild = val;


			Assert.AreEqual(val, target.IDChild, "ClassLibrary.ArtistConnection.IDChild was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for IDParent
		///</summary>
		[Test]
		public void IDParentTest()
		{
			ArtistConnection target = new ArtistConnection();

			int val = 0; // TODO: Assign to an appropriate value for the property

			target.IDParent = val;


			Assert.AreEqual(val, target.IDParent, "ClassLibrary.ArtistConnection.IDParent was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Load (IDataReader)
		///</summary>
		[Test]
		public void LoadTest()
		{
			ArtistConnection target = new ArtistConnection();

			IDataReader reader = null; // TODO: Initialize to an appropriate value

			target.Load(reader);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for ToString ()
		///</summary>
		[Test]
		public void ToStringTest()
		{
			ArtistConnection target = new ArtistConnection();

			string expected = null;
			string actual;

			actual = target.ToString();

			Assert.AreEqual(expected, actual, "ClassLibrary.ArtistConnection.ToString did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.ArtistConnectionCollection and is intended
	///to contain all ClassLibrary.ArtistConnectionCollection Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistConnectionCollectionTest
	{
		/// <summary>
		///A test for Sort (string)
		///</summary>
		[Test]
		public void SortTest()
		{
			ArtistConnectionCollection target = new ArtistConnectionCollection();

			string strOrderBy = null; // TODO: Initialize to an appropriate value

			target.Sort(strOrderBy);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.ArtistConnectionSorter and is intended
	///to contain all ClassLibrary.ArtistConnectionSorter Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistConnectionSorterTest
	{
		/// <summary>
		///A test for ArtistConnectionSorter (string)
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			string strOrderBy = null; // TODO: Initialize to an appropriate value

			ArtistConnectionSorter target = new ArtistConnectionSorter(strOrderBy);

			// TODO: Implement code to verify target
			Assert.Fail("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for Compare (ArtistConnection, ArtistConnection)
		///</summary>
		[Test]
		public void CompareTest()
		{
			string strOrderBy = null; // TODO: Initialize to an appropriate value

			ArtistConnectionSorter target = new ArtistConnectionSorter(strOrderBy);

			ArtistConnection x = null; // TODO: Initialize to an appropriate value

			ArtistConnection y = null; // TODO: Initialize to an appropriate value

			int expected = 0;
			int actual;

			actual = target.Compare(x, y);

			Assert.AreEqual(expected, actual, "ClassLibrary.ArtistConnectionSorter.Compare did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

	}


}
