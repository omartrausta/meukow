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
	///This is a test class for ClassLibrary.ArtistConnectionDoc and is intended
	///to contain all ClassLibrary.ArtistConnectionDoc Unit Tests
	///</summary>
	[TestFixture]
	public class ArtistConnectionDocTest
	{
		/// <summary>
		///A test for AddArtistConnection (ArtistConnection)
		///</summary>
		[Test]
		public void AddArtistConnectionTest()
		{
			ArtistConnectionDoc target = new ArtistConnectionDoc();

			ArtistConnection artistConnection = null; // TODO: Initialize to an appropriate value

			target.AddArtistConnection(artistConnection);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for DeleteArtistConnection (ArtistConnection)
		///</summary>
		[Test]
		public void DeleteArtistConnectionTest()
		{
			ArtistConnectionDoc target = new ArtistConnectionDoc();

			ArtistConnection artistConnection = null; // TODO: Initialize to an appropriate value

			target.DeleteArtistConnection(artistConnection);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for GetAllArtistsConnection ()
		///</summary>
		[Test]
		public void GetAllArtistsConnectionTest()
		{
			ArtistConnectionDoc target = new ArtistConnectionDoc();

			ArtistConnectionCollection expected = null;
			ArtistConnectionCollection actual;

			actual = target.GetAllArtistsConnection();

			Assert.AreEqual(expected, actual,
			                "ClassLibrary.ArtistConnectionDoc.GetAllArtistsConnection did not return the expec" +
			                "ted value.");
		}

		/// <summary>
		///A test for GetArtistConnection (int)
		///</summary>
		[Test]
		public void GetArtistConnectionTest()
		{
			ArtistConnectionDoc target = new ArtistConnectionDoc();

			int nID = 0; // TODO: Initialize to an appropriate value

			ArtistConnection expected = null;
			ArtistConnection actual;

			actual = target.GetArtistConnection(nID);

			Assert.AreEqual(expected, actual, "ClassLibrary.ArtistConnectionDoc.GetArtistConnection did not return the expected " +
							"value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for UpdateArtistConnection (ArtistConnection)
		///</summary>
		[Test]
		public void UpdateArtistConnectionTest()
		{
			ArtistConnectionDoc target = new ArtistConnectionDoc();

			ArtistConnection artistConnection = null; // TODO: Initialize to an appropriate value

			target.UpdateArtistConnection(artistConnection);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

	}


}
