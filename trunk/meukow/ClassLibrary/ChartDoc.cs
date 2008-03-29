using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Common.Data;
using System.Data;

namespace ClassLibrary
{
	public class ChartDoc : BaseDocument
	{
		public DataSet GetChartList(int ID)
		{
            String strSQL = string.Format("SELECT ListProp.[Position] AS Position, Song.ID AS SongID, Song.Name AS SongName, Artist.ID AS ArtistID, Artist.Name AS ArtistName FROM ((Artist INNER JOIN Song ON Artist.ID = Song.ArtistID) INNER JOIN ListProp ON Song.ID = ListProp.Song) WHERE (ListProp.List = {0})", ID);
			return base.LoadData(strSQL);
		}

        public ChartCollection GetChartCollection(int ID)
        {
            String strSQL = string.Format("SELECT [ListProp].[List], [ListProp].[Position] AS [Position], [Song].[ID] AS [SongID], [Song].[Name] AS [SongName], [Artist].[ID] AS [ArtistID], [Artist].[Name] AS [ArtistName] FROM (([Artist] INNER JOIN [Song] ON [Artist].[ID] = [Song].[ArtistID]) INNER JOIN [ListProp] ON [Song].[ID] = [ListProp].[Song]) WHERE ([ListProp].[List] = {0})", ID);
            return base.LoadCollection<ChartCollection, Chart>(strSQL);
        }

		public DataSet GetSongTimesInPos()
		{
            String strSQL = "SELECT [Song].[Name] AS [SongName], [ListProp].[Position] AS [Position], COUNT([Song].[ID]) AS [TimesInPosition] FROM [Song] INNER JOIN ([List] INNER JOIN [ListProp] ON [List].[ID] = [ListProp].[List]) ON [Song].[ID] = [ListProp].[Song] WHERE ((([List].[WeekList])=True)) GROUP by [Song].[Name], [ListProp].[Position]";
		
			return base.LoadData(strSQL);
		}

	}
}