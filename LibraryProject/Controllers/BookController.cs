using LibraryProject.Models;
using LibraryProject.Repositories;
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


        //public IActionResult Delete(Book book, int id)
        public async Task<IActionResult> Delete(Book book, int id)
        {
			bookRepository.Delete(id);
			bookRepository.Save();
			return RedirectToAction("AllBooks");
		}




        //public IActionResult Search(string name)
        //{

        //          List<Book> bookAuthor = bookRepository.Search(name);
        //	List<Book> booktitle = bookRepository.Search(name);
        //	if (bookAuthor.Any())
        //	{
        //		ViewData["AuthorName"] = $"{name}";
        //		ViewBag.Books = bookAuthor;
        //		return View("SearchView", bookAuthor);
        //	}
        //	else if (booktitle.Any()) 
        //	{
        //		ViewData["TitleName"] = $"{name}";
        //		ViewBag.BooksTitle = booktitle;
        //		return View("SearchView",booktitle);
        //	}



        //              ViewBag.Message = $"No books found by this author {name}";
        //              return View("SearchView", ViewBag.Message);


        //          //return View();

        //      }

        public IActionResult Search(string input)
        {

            List<Book> bookAuthor = context.Books.Where(b => b.Author.Contains(input)).Include(b => b.Kind).ToList();
            List<Book> booktitle = context.Books.Where(b => b.Title.Contains(input)).Include(b => b.Kind).ToList();

            if (bookAuthor.Any())
            {
                ViewData["AuthorName"] = $"{input}";
                ViewBag.BooksAuthor = bookAuthor;
                return View("SearchView", bookAuthor);
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
