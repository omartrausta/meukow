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
	///This is a test class for ClassLibrary.ListPropDoc and is intended
	///to contain all ClassLibrary.ListPropDoc Unit Tests
	///</summary>
	[TestFixture]
	public class ListPropDocTest
	{
		/// <summary>
		///A test for AddListProp (ListProp)
		///</summary>
		[Test]
		public void AddListPropTest()
		{
			ListPropDoc target = new ListPropDoc();

			ListProp listProp = null; // TODO: Initialize to an appropriate value

			target.AddListProp(listProp);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for DeleteList (ListProp)
		///</summary>
		[Test]
		public void DeleteListtTest()
		{
			ListPropDoc target = new ListPropDoc();

			ListProp listProp = null; // TODO: Initialize to an appropriate value

			target.DeleteListt(listProp);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

		/// <summary>
		///A test for GetAllListProp ()
		///</summary>
		[Test]
		public void GetAllListPropTest()
		{
			ListPropDoc target = new ListPropDoc();

			ListPropCollection expected = null;
			ListPropCollection actual;

			actual = target.GetAllListProp();

			Assert.AreEqual(expected, actual, "ClassLibrary.ListPropDoc.GetAllListProp did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for GetListProp (int)
		///</summary>
		[Test]
		public void GetListPropTest()
		{
			ListPropDoc target = new ListPropDoc();

			int nID = 0; // TODO: Initialize to an appropriate value

			ListProp expected = null;
			ListProp actual;

			actual = target.GetListProp(nID);

			Assert.AreEqual(expected, actual, "ClassLibrary.ListPropDoc.GetListProp did not return the expected value.");
			Assert.Fail("Verify the correctness of this test method.");
		}

		/// <summary>
		///A test for UpdateListProp (ListProp)
		///</summary>
		[Test]
		public void UpdateListPropTest()
		{
			ListPropDoc target = new ListPropDoc();

			ListProp listProp = null; // TODO: Initialize to an appropriate value

			target.UpdateListProp(listProp);

			Assert.Fail("A method that does not return a value cannot be verified.");
		}

	}


}
