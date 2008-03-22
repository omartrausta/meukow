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
	///This is a test class for ClassLibrary.ListProp and is intended
	///to contain all ClassLibrary.ListProp Unit Tests
	///</summary>
	[TestFixture]
	public class ListPropTest
	{
		/// <summary>
		///A test for GetTable ()
		///</summary>
		[Test]
		public void GetTableTest()
		{
			ListProp target = new ListProp();

			TableDescription expected = null;
			TableDescription actual;

			actual = target.GetTable();

			Assert.AreEqual(expected, actual, "ClassLibrary.ListProp.GetTable did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ID
		///</summary>
		[Test]
		public void IDTest()
		{
			ListProp target = new ListProp();

			int val = 0; // TODO: Assign to an appropriate value for the property

			target.ID = val;


			Assert.AreEqual(val, target.ID, "ClassLibrary.ListProp.ID was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for List
		///</summary>
		[Test]
		public void ListTest()
		{
			ListProp target = new ListProp();

			int val = 0; // TODO: Assign to an appropriate value for the property

			target.List = val;


			Assert.AreEqual(val, target.List, "ClassLibrary.ListProp.List was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ListProp ()
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			ListProp target = new ListProp();

			// TODO: Implement code to verify target
			Assert.Fail("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for Load (IDataReader)
		///</summary>
		[Test]
		public void LoadTest()
		{
			ListProp target = new ListProp();

			IDataReader reader = null; // TODO: Initialize to an appropriate value

			target.Load(reader);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for Position
		///</summary>
		[Test]
		public void PositionTest()
		{
			ListProp target = new ListProp();

			int val = 0; // TODO: Assign to an appropriate value for the property

			target.Position = val;


			Assert.AreEqual(val, target.Position, "ClassLibrary.ListProp.Position was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Song
		///</summary>
		[Test]
		public void SongTest()
		{
			ListProp target = new ListProp();

			int val = 0; // TODO: Assign to an appropriate value for the property

			target.Song = val;


			Assert.AreEqual(val, target.Song, "ClassLibrary.ListProp.Song was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ToString ()
		///</summary>
		[Test]
		public void ToStringTest()
		{
			ListProp target = new ListProp();

			string expected = null;
			string actual;

			actual = target.ToString();

			Assert.AreEqual(expected, actual, "ClassLibrary.ListProp.ToString did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.ListPropCollection and is intended
	///to contain all ClassLibrary.ListPropCollection Unit Tests
	///</summary>
	[TestFixture]
	public class ListPropCollectionTest
	{
		/// <summary>
		///A test for Sort (string)
		///</summary>
		[Test]
		public void SortTest()
		{
			ListPropCollection target = new ListPropCollection();

			string strOrderBy = null; // TODO: Initialize to an appropriate value

			target.Sort(strOrderBy);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.ListPropSorter and is intended
	///to contain all ClassLibrary.ListPropSorter Unit Tests
	///</summary>
	[TestFixture]
	public class ListPropSorterTest
	{
		/// <summary>
		///A test for Compare (ListProp, ListProp)
		///</summary>
		[Test]
		public void CompareTest()
		{
			string strOrderBy = null; // TODO: Initialize to an appropriate value

			ListPropSorter target = new ListPropSorter(strOrderBy);

			ListProp x = null; // TODO: Initialize to an appropriate value

			ListProp y = null; // TODO: Initialize to an appropriate value

			int expected = 0;
			int actual;

			actual = target.Compare(x, y);

			Assert.AreEqual(expected, actual, "ClassLibrary.ListPropSorter.Compare did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ListPropSorter (string)
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			string strOrderBy = null; // TODO: Initialize to an appropriate value

			ListPropSorter target = new ListPropSorter(strOrderBy);

			// TODO: Implement code to verify target
			Assert.Fail("TODO: Implement code to verify target");
		}

	}


}
