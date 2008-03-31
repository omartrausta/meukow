using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
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

		public Bitmap DrawGraph(String s, ArrayList aX, ArrayList aY)
		{
			int colWidth = 20;
			int colSpace = 5;
			int maxHeight = 400;
			int heightSpace = 15;
			int legendSpace = 120;
			int titleSpace = 50;
			int maxWidth = (colSpace + colWidth) * aX.Count + colSpace;
			int maxColHeight = 0;
			int totalHeight = maxHeight + legendSpace + titleSpace;

			Bitmap objBitmap = new Bitmap(maxWidth, totalHeight);
			Graphics objGraphics = Graphics.FromImage(objBitmap);

			objGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, maxWidth, maxWidth);

			objGraphics.FillRectangle(new SolidBrush(Color.Ivory), 0, 0, maxWidth, maxHeight);

			//find the maximum value

			//int value;

			foreach (int value in aY)
			{
				if (value > maxColHeight)
				{
					maxColHeight = value;
				}
			}

			int barX = colSpace;
			int currentHeight;

			SolidBrush objBrush = new SolidBrush(Color.FromArgb(70, 20, 20));
			Font fontLegend = new Font("Arial", 8);
			Font fontValue = new Font("Arial", 6);
			Font fontTitle = new Font("Arial", 24);

			//loop through and draw each bar

			for (int i = 0; i < aX.Count; i++)
			{
				currentHeight = Convert.ToInt32(Convert.ToDouble(aY[i]) / Convert.ToDouble(maxColHeight) * Convert.ToDouble(maxHeight - heightSpace));

				objGraphics.FillRectangle(objBrush, barX, maxHeight - currentHeight, colWidth, currentHeight);

				//objGraphics.DrawString(string.Format("{0:#,###}", aY[i]), fontValue, objBrush, barX, maxHeight - currentHeight - 15); 
				SizeF stringSize = objGraphics.MeasureString(Convert.ToString(aX[i]), fontValue);
				double startX = (double) barX-4;// +(double)colWidth;// / 2;// - (double)stringSize.Width / 2;
				int iStartX = Convert.ToInt32(Math.Round(startX));

				StringFormat drawFormat = new StringFormat();
				drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
 
				objGraphics.DrawString(Convert.ToString(aX[i]), fontLegend, objBrush, iStartX, maxHeight,drawFormat);

				objGraphics.DrawString(String.Format(aY[i].ToString(), "#,###"), fontValue, objBrush, barX, maxHeight - currentHeight - 15);
				barX += (colSpace + colWidth);
			}

			objGraphics.DrawString(s, fontTitle, objBrush, (maxWidth / 2) - s.Length * 6, maxHeight + legendSpace);

			objBitmap.Save("C:\\Documents and Settings\\omartr\\My Documents\\GluggMeukow\\meukow\\WebSite\\images\\graph.gif", ImageFormat.Gif);

			//objBitmap.Save(Response.OutputStream, ImageFormat.Gif);
			objGraphics.Dispose();

			return objBitmap;
		}

		#endregion
	}
}
