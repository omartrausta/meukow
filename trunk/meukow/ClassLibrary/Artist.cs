using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ClassLibrary
{
	public class Artist : DBComm
	{
		#region Member variables

		private int m_nID;
		private String m_strName;
		private String m_strDescription;
		private String m_strPicture;
		private String m_strURL;

		#endregion


		#region Properties

		public int ID
		{
			get { return m_nID; }
			set { m_nID = value; }
		}

		public String Nafn
		{
			get { return m_strName; }
			set { m_strName = value; }
		}

		public String Description
		{
			get { return m_strDescription; }
			set { m_strDescription = value; }
		}		

		public String Picture
		{
			get { return m_strPicture; }
			set { m_strPicture = value; }
		}

		public String URL
		{
			get { return m_strURL; }
			set { m_strURL = value; }
		}

		#endregion

		public Artist( )
		{
		}

		public Artist( DataRow row )
		{
			m_nID = Convert.ToInt32(row["ID"]);
			m_strName = row[ "Name" ].ToString( );
			m_strDescription = row["Description"].ToString();
			m_strPicture = row["Picture"].ToString();
			m_strURL = row["URL"].ToString();
		}


	}
}
