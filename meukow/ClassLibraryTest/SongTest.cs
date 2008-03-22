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
	///This is a test class for ClassLibrary.Song and is intended
	///to contain all ClassLibrary.Song Unit Tests
	///</summary>
	[TestFixture]
	public class SongTest
	{
		/// <summary>
		///A test for ArtistID
		///</summary>
		[Test]
		public void ArtistIDTest()
		{
			Song target = new Song();

			int val = 0; // TODO: Assign to an appropriate value for the property

			target.ArtistID = val;


			Assert.AreEqual(val, target.ArtistID, "ClassLibrary.Song.ArtistID was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Description
		///</summary>
		[Test]
		public void DescriptionTest()
		{
			Song target = new Song();

			string val = null; // TODO: Assign to an appropriate value for the property

			target.Description = val;


			Assert.AreEqual(val, target.Description, "ClassLibrary.Song.Description was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetTable ()
		///</summary>
		[Test]
		public void GetTableTest()
		{
			Song target = new Song();

			TableDescription expected = null;
			TableDescription actual;

			actual = target.GetTable();

			Assert.AreEqual(expected, actual, "ClassLibrary.Song.GetTable did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ID
		///</summary>
		[Test]
		public void IDTest()
		{
			Song target = new Song();

			int val = 0; // TODO: Assign to an appropriate value for the property

			target.ID = val;


			Assert.AreEqual(val, target.ID, "ClassLibrary.Song.ID was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Load (IDataReader)
		///</summary>
		[Test]
		public void LoadTest()
		{
			Song target = new Song();

			IDataReader reader = null; // TODO: Initialize to an appropriate value

			target.Load(reader);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for Name
		///</summary>
		[Test]
		public void NameTest()
		{
			Song target = new Song();

			string val = null; // TODO: Assign to an appropriate value for the property

			target.Name = val;


			Assert.AreEqual(val, target.Name, "ClassLibrary.Song.Name was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for Song ()
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			Song target = new Song();

			// TODO: Implement code to verify target
			Assert.Fail("TODO: Implement code to verify target");
		}

		/// <summary>
		///A test for SongPath
		///</summary>
		[Test]
		public void SongPathTest()
		{
			Song target = new Song();

			string val = null; // TODO: Assign to an appropriate value for the property

			target.SongPath = val;


			Assert.AreEqual(val, target.SongPath, "ClassLibrary.Song.SongPath was not set correctly.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for ToString ()
		///</summary>
		[Test]
		public void ToStringTest()
		{
			Song target = new Song();

			string expected = null;
			string actual;

			actual = target.ToString();

			Assert.AreEqual(expected, actual, "ClassLibrary.Song.ToString did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.SongCollection and is intended
	///to contain all ClassLibrary.SongCollection Unit Tests
	///</summary>
	[TestFixture]
	public class SongCollectionTest
	{
		/// <summary>
		///A test for Sort (string)
		///</summary>
		[Test]
		public void SortTest()
		{
			SongCollection target = new SongCollection();

			string strOrderBy = null; // TODO: Initialize to an appropriate value

			target.Sort(strOrderBy);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

	}
	/// <summary>
	///This is a test class for ClassLibrary.SongSorter and is intended
	///to contain all ClassLibrary.SongSorter Unit Tests
	///</summary>
	[TestFixture]
	public class SongSorterTest
	{
		/// <summary>
		///A test for Compare (Song, Song)
		///</summary>
		[Test]
		public void CompareTest()
		{
			string strOrderBy = null; // TODO: Initialize to an appropriate value

			SongSorter target = new SongSorter(strOrderBy);

			Song x = null; // TODO: Initialize to an appropriate value

			Song y = null; // TODO: Initialize to an appropriate value

			int expected = 0;
			int actual;

			actual = target.Compare(x, y);

			Assert.AreEqual(expected, actual, "ClassLibrary.SongSorter.Compare did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for SongSorter (string)
		///</summary>
		[Test]
		public void ConstructorTest()
		{
			string strOrderBy = null; // TODO: Initialize to an appropriate value

			SongSorter target = new SongSorter(strOrderBy);

			// TODO: Implement code to verify target
			Assert.Fail("TODO: Implement code to verify target");
		}

	}


}
