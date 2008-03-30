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
		/// Function that returns collection of statistics.
		/// </summary>
		/// <returns>Collection of statistics.</returns>
		public StatisticCollection GetStatistics()
		{
			String strSQL = "SELECT [Song].[Name] AS [SongName], [ListProp].[Position] AS [Position], COUNT([Song].[ID]) AS [TimesInPosition] FROM [Song] INNER JOIN ([List] INNER JOIN [ListProp] ON [List].[ID] = [ListProp].[List]) ON [Song].[ID] = [ListProp].[Song] WHERE ((([List].[WeekList])=True)) GROUP by [Song].[Name], [ListProp].[Position]";
			return base.LoadCollection<StatisticCollection, Statistic>(strSQL);
		}
		#endregion
	}
}
