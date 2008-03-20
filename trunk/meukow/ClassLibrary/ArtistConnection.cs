using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ClassLibrary
{
	class ArtistConnection : DBComm
	{
        #region Member variables

        private int m_nIDParent;
        private int m_nIDChild;


        #endregion

        #region Properties
        /// <summary>
        /// public int property for IDParent
        /// </summary>
        public int IDParent
        {
            get { return m_nIDParent; }
            set { m_nIDParent = value; }
        }
        /// <summary>
        /// public int property for IDChild
        /// </summary>
        public int IDChild
        {
            get { return m_nIDChild; }
            set { m_nIDChild = value; }
        }

        #endregion

        #region Constructors

		public ArtistConnection( )
		{
		}

		public ArtistConnection( DataRow row )
		{
            m_nIDParent = Convert.ToInt32(row["IDParent"]);
		    m_nIDChild = Convert.ToInt32(row["IDChild"]);
          
		}

		#endregion
    }
}
