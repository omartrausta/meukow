using System;
using System.Collections.Generic;
using System.Text;

using ClassLibrary.Common.Data;

namespace ClassLibrary
{
	public class BlogDoc : BaseDocument
	{
		public BlogCollection GetAllBlogs()
		{
			String strSQL = "SELECT * FROM Blogs"; 
			//order by Dagsetning desc";
			return base.LoadCollection<BlogCollection, Blog>(strSQL);
		}
	}
}
