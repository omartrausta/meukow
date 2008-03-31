using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using ClassLibrary.Common.Data;
using System.IO;

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

		/// <summary>
		/// Function for drawing bar chart, takes in list of items for each column (X axis) and a 
		/// corresponding value for each column (Y axis) a chart name can also be added by a string
		/// </summary>
		/// <param name="s">chart name</param>
		/// <param name="aX">name or value for column corresponding X axis</param>
		/// <param name="aY">value for each column corresponding Y axis</param>
		/// <returns>Gif image of barchart</returns>
		public Bitmap DrawGraph(String path, String s, ArrayList aX, ArrayList aY)
		{
			int colWidth = 20;
			int colSpace = 5;
			int maxHeight = 300;
			int legendSpace = 175;
			int titleSpace = 25;
			int maxWidth = (colSpace + colWidth) * aX.Count + colSpace;
			int totalHeight = maxHeight + legendSpace + titleSpace;
			int maxValueY = 0;

			Bitmap objBitmap = new Bitmap(maxWidth, totalHeight);
			Graphics objGraphics = Graphics.FromImage(objBitmap);

			objGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, maxWidth, maxWidth);

			objGraphics.FillRectangle(new SolidBrush(Color.Ivory), 0, 0, maxWidth, maxHeight);

			// find max value in collection
			foreach (int value in aY)
			{
				if (value > maxValueY)
				{
					maxValueY = value;
				}
			}

			int barX = colSpace;

			SolidBrush objBrush = new SolidBrush(Color.FromArgb(70, 20, 20));
			Font fontLegend = new Font("Arial", 9);
			Font fontValue = new Font("Arial", 7);
			Font fontTitle = new Font("Arial", 12);

			//loop through and draw each bar

			for (int i = 0; i < aX.Count; i++)
			{
				int currentHeight = Convert.ToInt32((Convert.ToDouble(aY[i])/Convert.ToDouble(maxValueY))*Convert.ToDouble(maxHeight));

				objGraphics.FillRectangle(objBrush, barX, maxHeight - currentHeight, colWidth, currentHeight);

				double startX = (double) barX-2;
				int iStartX = Convert.ToInt32(Math.Round(startX));

				// turn string vertical on image
				StringFormat drawFormat = new StringFormat();
				drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
 
				objGraphics.DrawString(Convert.ToString(aX[i]), fontLegend, objBrush, iStartX, maxHeight,drawFormat);

				objGraphics.DrawString(String.Format(aY[i].ToString(), "#,###"), fontValue, objBrush, barX, maxHeight - currentHeight - 10);
				
				barX += (colSpace + colWidth);
			}

			objGraphics.DrawString(s, fontTitle, objBrush, (maxWidth / 2) - s.Length * 6, maxHeight + legendSpace);

			objBitmap.Save(path);

			objGraphics.Dispose();

			return objBitmap;
		}
		#endregion
	}
}
