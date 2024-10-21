using LibraryProject.Models;
using LibraryProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace LibraryProject.Controllers
{
	public class BookController : Controller
	{
		IBookRepo bookRepository;
        public BookController(IBookRepo _context)
        {
			bookRepository = _context;
        }

        public IActionResult AllBooks()
		{
		
			List<Book> books = bookRepository.GetAll();
			ViewData["books"] = books;
			return View("BookView", books);
		}
        [Authorize(Roles = "admin")]
        public IActionResult Add()
		{
			return View("AddView");
		}

		public IActionResult SaveAdd(Book Newbook)
		{
			if (Newbook.Title != null)
			{
			bookRepository.Add(Newbook);
			bookRepository.Save();
            return RedirectToAction("AllBooks");
			}
			
		    return View("AddView" , Newbook);
			
		;
		}
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
		{
			Book book = bookRepository.GetById(id);
			return View("EditView" ,book);
		}

		[HttpPost]
	public IActionResult SaveEdit(Book EditedBook , int id)
		{
			if (EditedBook.Title != null)
			{
				Book bookEdit = bookRepository.GetById(id);
				bookEdit.Title = EditedBook.Title;
				bookEdit.Author = EditedBook.Author;
				bookEdit.StatusId = EditedBook.StatusId;
			    bookRepository.Save();
				return RedirectToAction("AllBooks");

			}

				return View("EditView", EditedBook);
			

		}

        [Authorize(Roles = "admin")]
        //public IActionResult Delete(Book book, int id)
        public async Task<IActionResult> Delete(Book book, int id)
        {
			bookRepository.Delete(id);
			bookRepository.Save();
			return RedirectToAction("AllBooks");
		}




        public IActionResult Search(string author)
        {

            List<Book> bookAuthor = bookRepository.Search(author);
            if (bookAuthor.Any())
            {
                ViewData["AuthorName"] = $"{author}";
                ViewBag.BookAuthor = bookAuthor;
                return View("SearchView", bookAuthor);
            }


            ViewBag.Message = $"No books found by this author {author}";
            return View("SearchView", ViewBag.Message);


            //return View();

        }

    }

}
