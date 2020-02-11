using Bookstore.Models;
using System.Collections.Generic;

namespace Bookstore.Models.ViewModels
{
	public class BookList
	{
		public IEnumerable<Book> Books { get; set; }
		public Paging PagingInfo { get; set; }
	}
}
