using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
	public class BookController : Controller
	{

		private IBookRepository repo;
		private int PageSize = 4;
		public BookController(IBookRepository repo)
		{
			this.repo = repo;
		}

		//public ViewResult List()
		//{
		//	return View(repo.Books);
		//}

		public ViewResult List(int page = 1)
		{
			return View(repo.Books
				.OrderBy(p => p.BookID)
				.Skip((page - 1) * PageSize)
				.Take(PageSize));
		}
	}
}