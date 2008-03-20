using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	class ListProp : DBComm
	{
		private int myVar;

		public int MyProperty
		{
			get { return myVar; }
			set { myVar = value; }
		}
	
	}
}
