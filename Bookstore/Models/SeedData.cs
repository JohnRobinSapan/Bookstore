using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Bookstore.Models
{
	public class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
			if (!context.Books.Any())
			{
				context.Books.AddRange(
					new Book
					{
						Name = "How Computers Work",
						Description = "Overview of how everything in your computer works",
						Category = "General Computer Knowledge",
						Price = 45
					},
					new Book
					{
						Name = "Upgrading and Repairing PCs",
						Description = "In-depth overview of computers and computer hardware",
						Category = "General Computer Knowledge",
						Price = 50
					},
					new Book
					{
						Name = "CompTIA A+ Certification All-in-One Exam",
						Description = "Everything asked in the A+ Certification test",
						Category = "A+ Certification",
						Price = 70
					},
					new Book
					{
						Name = "Ghost in the Wires",
						Description = "One of the best-known hackers in history",
						Category = "Hacking and computer security",
						Price = 55
					},
					new Book
					{
						Name = "Hacking Exposed",
						Description = "Great series of books that covers all types of computer security related topics",
						Category = "Hacking and computer security",
						Price = 40
					},
					new Book
					{
						Name = "Design Patterns: Elements of Reusable Object-Oriented Software",
						Description = "A great source of information on object-oriented design theory",
						Category = "Computer Programming",
						Price = 110
					},
					new Book
					{
						Name = "Don't Make Me Think!",
						Description = "A beautiful and well designed book that covers all the basics of HTML and CSS used for web design",
						Category = "Web Design",
						Price = 35
					},
					new Book
					{
						Name = "Getting Started in Electronics",
						Description = "Beginner's electronics book containing hand-drawn diagrams of each of the circuits",
						Category = "Electronics",
						Price = 85
					});
				context.SaveChanges();

			}
		}
	}
}
