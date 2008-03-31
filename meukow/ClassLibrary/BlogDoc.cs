using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

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
				String strSQL =String.Format("SELECT Blogs.ID, Song.ID AS SongID, Blogs.Title, Blogs.BlogDate, Blogs.Content FROM (Blogs INNER JOIN Song ON Blogs.SongID = Song.ID) WHERE (Blogs.SongID ={0})", nID);
				return base.LoadCollection<BlogCollection, Blog>(strSQL);
			}
		
		public DataSet GetBlog(int nID)
		{
			String strSQL = String.Format("SELECT Blogs.ID, Song.ID AS SongID, Blogs.Title, Blogs.BlogDate, Blogs.Content FROM (Blogs INNER JOIN Song ON Blogs.SongID = Song.ID) WHERE (Blogs.ID ={0})", nID);
			return base.LoadData(strSQL);
		}

		public void AddBlog(Blog blog)
		{
			int newID = base.AddData(blog.GetTable());
			blog.ID = newID;
		}
	}
}
