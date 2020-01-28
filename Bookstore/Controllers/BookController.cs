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

		public BookController (IBookRepository repo)
		{
			this.repo = repo;
		}

		public ViewResult List()
		{
			return View(repo.Books);
		}
	}
}