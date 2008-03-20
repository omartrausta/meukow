using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ClassLibrary
{
	class ListProp : DBComm
	{

		#region Member variables

		private int m_nID;
		private int m_nSong;
		private int m_nList;
		private int m_nPostion;

		#endregion

		#region Properties

		public int ID
		{
			get { return m_nID; }
			set { m_nID = value; }
		}
		
		public int Song
		{
			get { return m_nSong; }
			set { m_nSong = value; }
		}
		
		public int List
		{
			get { return m_nList; }
			set { m_nList = value; }
		}	

		public int Position
		{
			get { return m_nPostion; }
			set { m_nPostion = value; }
		}

		#endregion

		#region Constructors

		public ListProp( )
		{
		}

		public ListProp( DataRow row )
		{
			m_nID = Convert.ToInt32(row["ID"]);
			m_nSong = Convert.ToInt32(row["Song"]);
			m_nList = Convert.ToInt32(row["List"]);
			m_nPostion = Convert.ToInt32(row["Position"]);

		}

		#endregion

		#region Overridden functions

		public override string ToString( )
		{
			return (m_nID + m_nList + m_nPostion + m_nSong).ToString();
		}

		#endregion


	}
}
