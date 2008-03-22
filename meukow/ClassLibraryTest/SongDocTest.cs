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
	///This is a test class for ClassLibrary.SongDoc and is intended
	///to contain all ClassLibrary.SongDoc Unit Tests
	///</summary>
	[TestFixture]
	public class SongDocTest
	{
		/// <summary>
		///A test for AddList (Song)
		///</summary>
		[Test]
		public void AddListTest()
		{
			SongDoc target = new SongDoc();

			Song song = null; // TODO: Initialize to an appropriate value

			target.AddList(song);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for DeleteListt (Song)
		///</summary>
		[Test]
		public void DeleteListtTest()
		{
			SongDoc target = new SongDoc();

			Song song = null; // TODO: Initialize to an appropriate value

			target.DeleteListt(song);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for GetAllSongs ()
		///</summary>
		[Test]
		public void GetAllSongsTest()
		{
			SongDoc target = new SongDoc();

			SongCollection expected = null;
			SongCollection actual;

			actual = target.GetAllSongs();

			Assert.AreEqual(expected, actual, "ClassLibrary.SongDoc.GetAllSongs did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetSong (int)
		///</summary>
		[Test]
		public void GetSongTest()
		{
			SongDoc target = new SongDoc();

			int nID = 0; // TODO: Initialize to an appropriate value

			List expected = null;
			List actual;

			actual = target.GetSong(nID);

			Assert.AreEqual(expected, actual, "ClassLibrary.SongDoc.GetSong did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for UpdateSong (Song)
		///</summary>
		[Test]
		public void UpdateSongTest()
		{
			SongDoc target = new SongDoc();

			Song song = null; // TODO: Initialize to an appropriate value

			target.UpdateSong(song);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}
	}
}
