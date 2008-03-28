using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;
using System.Data;

namespace ClassLibrary
{
	public class ChartDoc : BaseDocument
	{


		public DataSet ds;

		public DataSet GetChartList(int ID)
		{
			//String strSQL = string.Format("select Chart.List, [Position], [Song_Name], [Artist_Name] from Chart INNER JOIN Song ON Chart.List = Song.ArtistID");
			//String strSQL =("SELECT ListProp.List AS [List], ListProp.Position AS [Postition], Song.Name AS [Song_Name], Artist.Name AS [Artist_Name] FROM (((Artist INNER JOIN Song ON Artist.ID = Song.ArtistID) INNER JOIN ListProp ON Song.ID = ListProp.Song) INNER JOIN List ON ListProp.List = List.ID) GROUP BY ListProp.List, ListProp.Position, Song.Name, Artist.Name, ListProp.ID HAVING (((ListProp.List) Is Not Null And (ListProp.List)=60))");
			//String strSQL = string.Format("SELECT ListProp.List AS [List], ListProp.Position AS [Postition], Song.Name AS [Song_Name], Artist.Name AS [Artist_Name] FROM (((Artist INNER JOIN Song ON Artist.ID = Song.ArtistID) INNER JOIN ListProp ON Song.ID = ListProp.Song) INNER JOIN List ON ListProp.List = List.ID) WHERE (((ListProp.List) Is Not Null And (ListProp.List)=60))");
            String strSQL = string.Format("SELECT ListProp.[Position] AS Postition, Song.ID AS SongID, Song.Name AS SongName, Artist.ID AS ArtistID, Artist.Name AS ArtistName FROM ((Artist INNER JOIN Song ON Artist.ID = Song.ArtistID) INNER JOIN ListProp ON Song.ID = ListProp.Song) WHERE (ListProp.List = {0})", ID);
			
			//ds = base.LoadData(strSQL);
			//base.ExecuteSQL(strSQL);
			return base.LoadData(strSQL);
		}
	}
}