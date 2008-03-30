using System;
using ClassLibrary.Common.Data;
using System.Data;

namespace ClassLibrary
{
	/// <summary>
	/// ChartDoc that inherits BaseDocument
	/// </summary>
	public class ChartDoc : BaseDocument
	{
		/// <summary>
		/// Function that returns dataset with chart list for a single list.
		/// </summary>
		/// <returns>Dataset with chart list.</returns>
		public DataSet GetChartList(int ID)
		{
			String strSQL = string.Format("SELECT [ListProp].[List], [ListProp].[Position] AS [Position], [Song].[ID] AS [SongID], [Song].[Name] AS [SongName], [Artist].[ID] AS [ArtistID], [Artist].[Name] AS [ArtistName] FROM (([Artist] INNER JOIN [Song] ON [Artist].[ID] = [Song].[ArtistID]) INNER JOIN [ListProp] ON [Song].[ID] = [ListProp].[Song]) WHERE ([ListProp].[List] = {0})", ID);
			return base.LoadData(strSQL);
		}

		/// <summary>
		/// Function that returns collection of a chart for a single list.
		/// </summary>
		/// <returns>Collection of chart.</returns>
		public ChartCollection GetChartCollection(int ID)
		{
			String strSQL = string.Format("SELECT [ListProp].[List], [ListProp].[Position] AS [Position], [Song].[ID] AS [SongID], [Song].[Name] AS [SongName], [Artist].[ID] AS [ArtistID], [Artist].[Name] AS [ArtistName] FROM (([Artist] INNER JOIN [Song] ON [Artist].[ID] = [Song].[ArtistID]) INNER JOIN [ListProp] ON [Song].[ID] = [ListProp].[Song]) WHERE ([ListProp].[List] = {0})", ID);
			return base.LoadCollection<ChartCollection, Chart>(strSQL);
		}

		/// <summary>
		/// Delete an instance of ListProp.
		/// </summary>
		/// <param name="chart">Instance of Chart.</param>
		public void DeleteChart(Chart chart)
		{
			ListPropDoc doc = new ListPropDoc();
			ListPropCollection collection = doc.GetListPropByList(chart.ListID);
			foreach (ListProp prop in collection)
			{
				if (prop.Position.Equals(chart.Position))
				{
					doc.DeleteListProp(prop);
				}
			}
		}
	}
}