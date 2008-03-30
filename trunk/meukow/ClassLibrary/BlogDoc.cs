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

		public BlogCollection GetBlogSong(int nID)
			{
				String strSQL =String.Format("SELECT Blogs.ID, Blogs.Title, Blogs.BlogDate, Blogs.Content FROM (Blogs INNER JOIN Song ON Blogs.SongID = Song.ID) WHERE (Blogs.SongID ={0})",
						nID);
				return base.LoadCollection<BlogCollection, Blog>(strSQL);
			}
		
		public Blog GetBlog(int nID)
		{
			String strSQL = String.Format("SELECT Blogs.ID, Blogs.Title, Blogs.BlogDate, Blogs.Content FROM (Blogs INNER JOIN Song ON Blogs.SongID = Song.ID) WHERE (Blogs.ID ={0})",
					nID);
			return base.LoadItem<Blog>(strSQL);
		}

		public void AddBlog(Blog blog)
		{
			int newID = base.AddData(blog.GetTable());
			blog.ID = newID;
		}
	}
}
