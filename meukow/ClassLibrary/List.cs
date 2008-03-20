using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ClassLibrary
{
	class List : DBComm
	{
		#region Member variables
		private int m_nID;
		private String m_strName;
		private DateTime m_dtStarts;
		private DateTime m_dtEnds;
		private bool m_bWeekList;
		#endregion

		#region Properties
		/// <summary>
		/// public int property for ID
		/// </summary>
		public int ID
		{
			get { return m_nID; }
			set { m_nID = value; }
		}

		/// <summary>
		/// public string property for Name
		/// </summary>
		public String Name
		{
			get { return m_strName; }
			set { m_strName = value; }
		}

		/// <summary>
		/// public date time property for Starts
		/// </summary>
		public DateTime Starts
		{
			get { return m_dtStarts; }
			set { m_dtStarts = value; }
		}

		/// <summary>
		/// public date time property for Ends
		/// </summary>
		public DateTime Ends
		{
			get { return m_dtEnds; }
			set { m_dtEnds = value; }
		}

		/// <summary>
		/// public bool property for WeekList
		/// </summary>
		public bool WeekList
		{
			get { return m_bWeekList; }
			set { m_bWeekList = value; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor for List
		/// </summary>
		public List( )
		{
		}

		/// <summary>
		/// Constructor for List
		/// </summary>
		/// <param name="row">DataRow</param>
		public List(DataRow row)
		{
			m_nID = Convert.ToInt32(row["ID"]);
			m_strName = row[ "Name" ].ToString();
			m_dtStarts = Convert.ToDateTime(row["Starts"]);
			m_dtEnds = Convert.ToDateTime(row["Ends"]);
			m_bWeekList = Convert.ToBoolean(row["WeekList"]);
		}

		#endregion

		#region Overridden functions

		/// <summary>
		/// Overridden function for ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return m_strName;
		}
		#endregion
	}
}
