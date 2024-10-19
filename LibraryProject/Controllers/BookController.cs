using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace LibraryProject.Controllers
{
	public class BookController : Controller
	{
		 ApplicationDBContext context = new ApplicationDBContext();
      
        public IActionResult AllBooks()
		{

            List<Book> books = context.Books.ToList();
			ViewData["books"] = books;
            return View("BookView", books);
		}
		public IActionResult Add()
		{
			return View("AddView");
		}

		public IActionResult SaveAdd(Book Newbook)
		{
			if (Newbook.Title != null)
			{
			context.Books.Add(Newbook);
			context.SaveChanges();
            return RedirectToAction("AllBooks");
			}
			else
			{
				return View("AddView" , Newbook);
			}
		;
		}
	
		public IActionResult Edit(int id)
		{
			Book book = context.Books.FirstOrDefault(i => i.Id == id);
			return View("EditView" ,book);
		}

		[HttpPost]
	public IActionResult SaveEdit(Book EditedBook , int id)
		{
			if (EditedBook.Title != null)
			{
				Book bookEdit = context.Books.FirstOrDefault(i => i.Id == id);
				bookEdit.Title = EditedBook.Title;
				bookEdit.Author = EditedBook.Author;
				bookEdit.StatusId = EditedBook.StatusId;
				context.SaveChanges();
				return RedirectToAction("AllBooks");

			}

			else
			{
				return View("EditView", EditedBook);
			}

		}


		public IActionResult Delete(Book book, int id)
		{
			Book deletedBook = context.Books.FirstOrDefault(i => i.Id == id);
			context.Books.Remove(deletedBook);
			context.SaveChanges();
			return RedirectToAction("AllBooks");
		}




		public IActionResult Search(string author)
		{

            List<Book> bookAuthor = context.Books.Where(b => b.Author == author).ToList();
            if (bookAuthor.Any())
            {
				ViewData["AuthorName"] = $"{author}";
                ViewBag.Books = bookAuthor;
				return View("SearchView",bookAuthor);
            }
            else
            {
                ViewBag.Message = $"No books found by this author {author}";
                return View("SearchView", ViewBag.Message);

            }
            return View();

        }

	}

}
