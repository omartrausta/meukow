using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Media;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using ClassLibrary;
using ClassLibrary.Common.Data;
using System.ComponentModel;
using System.Xml.Serialization;
using Image=System.Drawing.Image;

public partial class DisplayViewStatistics : System.Web.UI.Page
{
	public Bitmap bm;
	public int pos = 1;

	protected void Page_Load(object sender, EventArgs e)
	{

		if(ddl_selectPos.Items.Count < 1)
		{
		for (int i = 1; i < 31; i++)
		{
			ddl_selectPos.Items.Add(i.ToString());
		}
	}	
		StatisticDoc statDoc = new StatisticDoc();

		StatisticCollection statColl = statDoc.GetStatisticsByPos(pos);

		ArrayList axisX = new ArrayList();
		ArrayList axisY = new ArrayList();

		foreach (Statistic stats in statColl)
		{
			axisX.Add(stats.SongName);
			axisY.Add(stats.TimesInPosition);
		}

		String str = "";
		
		bm = statDoc.DrawGraph(str, axisX, axisY);

	}

	protected void OnLoadPicture(object sender, EventArgs e)
	{
		m_statImage.Height = bm.Height;
		m_statImage.Width = bm.Width;
		m_statPanel.Height = bm.Height+30;
		m_statImage.ImageUrl = "http://localhost:1462/WebSite/images/graph.gif";
	}
	protected void OnDrawGraph(object sender, EventArgs e)
	{
		pos = Convert.ToInt32( ddl_selectPos.SelectedItem.Text );
		Page_Load(sender,e);
	}
}
















	//  // Since we are outputting a Jpeg, set the ContentType appropriately
	//  Response.ContentType = "image/jpeg";

	//  // Create a Bitmap instance that's 468x60, and a
	//  Graphics instance;

	//  const int width = 300, height = 300;

	//  Bitmap objBitmap = new Bitmap(width, height);
	//  Graphics objGraphics = Graphics.FromImage(objBitmap);

	//  // Create a black background for the border
	//  objGraphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);

	//  Draw3DPieChart(ref objGraphics);

	//  // Save the image to a file
	//  objBitmap.Save(Response.OutputStream, ImageFormat.Jpeg);

	//  // clean up...
	//  objGraphics.Dispose();
	//  objBitmap.Dispose();
	//}

	//// Draws a 3D pie chart where ever slice is 45 degrees in value
	//void Draw3DPieChart(ref Graphics objGraphics)
	//{
	//  int iLoop, iLoop2;

	//  // Create location and size  of ellipse.
	//  int x = 50;
	//  int y = 20;
	//  int width = 200;
	//  int height = 100;

	//  // Create start and sweep angles.
	//  int startAngle = 0;
	//  int sweepAngle = 45;
	//  SolidBrush objBrush = new SolidBrush(Color.Aqua);

	//  Random rand = new Random();
	//  objGraphics.SmoothingMode = SmoothingMode.AntiAlias;

	//  //Loop through 180 back around to 135 degress so it gets drawn    // correctly.
	//  for (iLoop = 0; iLoop <= 315; iLoop += 45)
	//  {
	//    startAngle = (iLoop + 180) % 360;
	//    objBrush.Color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));

	//    // On degrees from 0 to 180 draw 10 Hatched brush slices to show            // depth
	//    if ((startAngle < 135) || (startAngle == 180))
	//    {
	//      for (iLoop2 = 0; iLoop2 < 10; iLoop2++)
	//        objGraphics.FillPie(new HatchBrush(HatchStyle.Percent50,
	//            objBrush.Color), x,
	//            y + iLoop2, width, height, startAngle, sweepAngle);
	//    }

	//    // Displace this pie slice from pie.
	//    if (startAngle == 135)
	//    {
	//      // Show Depth
	//      for (iLoop2 = 0; iLoop2 < 10; iLoop2++)
	//        objGraphics.FillPie(new HatchBrush(HatchStyle.Percent50,
	//            objBrush.Color), x - 30,
	//            y + iLoop2 + 15, width, height, startAngle, sweepAngle);

	//      objGraphics.FillPie(objBrush, x - 30, y + 15,
	//          width, height, startAngle, sweepAngle);
	//    }
	//    else // Draw normally
	//      objGraphics.FillPie(objBrush, x, y, width,
	//          height, startAngle, sweepAngle);
	//  }




	//  //    Statistic stat = new Statistic();
	//  //    StatisticDoc statdoc = new StatisticDoc();

	//  //    const int width = 300, height = 300;

	//  //    Bitmap objBitmap = new Bitmap(width, height);
	//  //    Graphics objGraphics = Graphics.FromImage(objBitmap);


	//  //    DrawChart(ref objGraphics);

	//  //    objGraphics.Dispose();

	//  //  }

	//  //public void DrawChart(ref Graphics objGraphics)
	//  //  {
	//  //    int x, y, iMax;

	//  //    x = 20;
	//  //    y = 60;
	//  //    SolidBrush objBrush = new SolidBrush(Color.Red);
	//  //    Random rand = new Random();

	//  //    for (int iCount = 0; iCount < 10; iCount++)
	//  //    {
	//  //      iMax = rand.Next() % 400;
	//  //      for (int iLoop = 0; iLoop < iMax; iLoop += 25)
	//  //      {
	//  //        objGraphics.FillRectangle(objBrush, x + iLoop, y + (iCount * 30), 20, 20);
	//  //      }
	//  //    }
	//  //  }


