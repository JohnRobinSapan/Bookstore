using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
	public class FakeBookRepository : IBookRepository
	{
		public IQueryable<Book> Books => new List<Book>
		{
			new Book{ Name = "Introduction to ASP.Net Core", Price = 100},
			new Book{ Name = "Introduction to Java", Price = 150},
			new Book{ Name = "Introduction to ASP.Net Core Features", Price = 210}

		}.AsQueryable();
	}
}
