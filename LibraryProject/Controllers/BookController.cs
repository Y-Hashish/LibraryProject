using LibraryProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace LibraryProject.Controllers
{
	public class BookController : Controller
	{
		 ApplicationDBContext context ;
        public BookController(ApplicationDBContext _context)
        {
			context = _context;
        }

        public IActionResult AllBooks()
		{
		
			List<Book> books = context.Books
            .Include(b => b.Kind).ToList();	
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




		public IActionResult Search(string input)
		{

            List<Book> bookAuthor = context.Books.Where(b => b.Author.Contains(input)).Include(b => b.Kind).ToList();
			List<Book> booktitle = context.Books.Where(b => b.Title.Contains(input)).Include(b => b.Kind).ToList();

            if (bookAuthor.Any())
            {
				ViewData["AuthorName"] = $"{input}";
                ViewBag.BooksAuthor = bookAuthor;
				return View("SearchView",bookAuthor);
            }
			else if (booktitle.Any())
			{
				ViewData["TitleName"] = $"{input}";
				ViewBag.Bookstitle = booktitle;
				return View("SearchView", booktitle);
			}
            else
            {
                ViewBag.Message = $"No books found by this author {input}";
                return View("SearchView", ViewBag.Message);

            }
            return View();

        }

	}

}
