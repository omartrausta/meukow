using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
	internal class Artist : DBComm
	{
		#region Member variables

		private int m_iD;
		private String m_name;
		private String m_description;
		private String m_picture;
		private String m_url;

		#endregion



		public int ID
		{
			get { return m_iD; }
			set { m_iD = value; }
		}

		public String Nafn
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public String Description
		{
			get { return m_description; }
			set { m_description = value; }
		}		

		public String Picture
		{
			get { return m_picture; }
			set { m_picture = value; }
		}

		public String URL
		{
			get { return m_url; }
			set { m_url = value; }
		}	






	}
}
