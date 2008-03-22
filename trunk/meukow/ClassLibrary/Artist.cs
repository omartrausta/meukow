using System;
using System.Collections.Generic;
using System.Data;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	public class Artist : IDataItem
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

		public String Name
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

		#region Constructors

		public Artist( )
		{
		}


		#endregion

		#region Overridden functions

		public override string ToString()
		{
			return m_strName;
		}
		#endregion

        #region IDataList implementation
        public void Load(IDataReader reader)
        {
            m_nID = Convert.ToInt32(reader["ID"]);
            m_strName = reader["Name"].ToString();
            m_strDescription = reader["Description"].ToString();
            m_strPicture = reader["Picture"].ToString();
            m_strURL = reader["Url"].ToString();
        }

        /// <summary>
        /// Fall sem skilar TableDescription hlut, en �ennan hlut m� svo
        /// nota �egar tilvik af klasanum er uppf�rt e�a n�skr��.
        /// Athugi� a� �etta fall �arf ekki endilega a� v�sa � s�mu d�lka
        /// og Load falli�, h�r �tti a�eins a� v�sa � d�lkan�fn � t�flunni
        /// sem �essi klasi tengist, en Load falli� g�ti t.d. s�tt g�gn
        /// �r ��rum d�lkum sem v�ri skila� me� INNER JOIN skipun.
        /// </summary>
        /// <returns></returns>
        public TableDescription GetTable()
        {
            ColumnDescription[] columns = 
			{
				new ColumnDescription( "ID", this.ID, DbType.Int32, true ),
				new ColumnDescription( "Name", this.Name, DbType.String ),
				new ColumnDescription( "Description", this.Description, DbType.String ),
				new ColumnDescription( "Picture", this.Picture, DbType.String ),
        new ColumnDescription("Url", this.URL, DbType.String), 
			};
            return new TableDescription("Artist	", columns);
        }

        #endregion
    }
    /// <summary>
    /// StudentSorter s�r um a� ra�a tilvikum af Student.
    /// </summary>

    public class ArtistSorter : IComparer<Artist>
    {
        #region Member variables
        private String m_strOrderBy;
        #endregion

        #region Constructors
        public ArtistSorter(String strOrderBy)
        {
            m_strOrderBy = strOrderBy;
        }
        #endregion

        #region IComparer implementation
        public int Compare(Artist x, Artist y)
        {
            switch (m_strOrderBy)
            {
                case "ID":
                    return x.ID.CompareTo(y.ID);
                case "Name":
                    return x.Name.CompareTo(y.Name);
                case "Description":
                    return x.Description.CompareTo(y.Description);
                
            }

            return 0;
        }
        #endregion
    }

    public class ArtistCollection : DataList<Artist>
    {
        #region Public functions
        public void Sort(String strOrderBy)
        {
            ArtistSorter sorter = new ArtistSorter(strOrderBy);
            base.Sort(sorter);
        }
        #endregion
    }

}
