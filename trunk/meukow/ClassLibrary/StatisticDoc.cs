using System;
using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	/// <summary>
	/// StatisticDoc that inherits BaseDocument
	/// </summary>
	public class StatisticDoc : BaseDocument
	{
		#region Public functions
		/// <summary>
		/// Function that returns collection of statistics. All songs that have been on charts
		/// and how many times each song has been in a each position. All lists not weeklists
		/// are excuded.
		/// </summary>
		/// <returns>Collection of statistics.</returns>
		public StatisticCollection GetStatistics()
		{
			String strSQL = "SELECT [Song].[Name] AS [SongName], [ListProp].[Position] AS [Position], COUNT([Song].[ID]) AS [TimesInPosition] FROM [Song] INNER JOIN ([List] INNER JOIN [ListProp] ON [List].[ID] = [ListProp].[List]) ON [Song].[ID] = [ListProp].[Song] WHERE ((([List].[WeekList])=True) AND [ListProp].[Position] = 1) GROUP by [Song].[Name], [ListProp].[Position]";
			return base.LoadCollection<StatisticCollection, Statistic>(strSQL);
		}
		/// <summary>
		/// Function that returns collection of statistics for how many times each song has been
		/// in a given position, position is provided as parameter. All lists not weeklists are 
		/// excluded.
		/// </summary>
		/// <param name="pos"></param>
		/// <returns>Collection of statistics</returns>
		public StatisticCollection GetStatisticsByPos(int pos)
		{
			String strSQL = string.Format("SELECT [Song].[Name] AS [SongName], [ListProp].[Position] AS [Position], COUNT([Song].[ID]) AS [TimesInPosition] FROM [Song] INNER JOIN ([List] INNER JOIN [ListProp] ON [List].[ID] = [ListProp].[List]) ON [Song].[ID] = [ListProp].[Song] WHERE ((([List].[WeekList])=True) and (([Position]) = {0})) GROUP by [Song].[Name], [ListProp].[Position]", pos );
			return base.LoadCollection<StatisticCollection, Statistic>(strSQL);
		}

		#endregion
	}
}
