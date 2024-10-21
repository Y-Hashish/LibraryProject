using LibraryProject.Migrations;
using LibraryProject.Models;
using LibraryProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace LibraryProject.Controllers
{
    [Authorize(Roles = "admin")]
    public class BorrowController : Controller
    {
        IBorrowRepo borrowRepository;
        IBookRepo bookRepository;
        public BorrowController(IBorrowRepo _borrowcontext, IBookRepo _bookRepository)
        {
            borrowRepository = _borrowcontext;
            bookRepository = _bookRepository;
        }
        // /Borrow/AllBorrowings
        public IActionResult AllBorrowings()
        {
            List<Borrowing> borrowings = borrowRepository.GetAll();
            ViewData["borrowings"] = borrowings;
            ViewData["User"] = borrowRepository.GetAllUsers();
            return View("AllBorrowings", borrowings);
        }
        // /Borrow/CreateBorrow
        [HttpGet]
        public IActionResult CreateBorrow()
        {
            //Borrowing borrowing = new Borrowing();
            //borrowing.ActualReturnDate = borrowing.DueDate;

            ViewBag.Books = bookRepository.GetAll();
            ViewBag.Users = borrowRepository.GetAllUsers();


            return View("CreateBorrow");
        }
        [HttpPost]
        public IActionResult SaveNewBorrow(Borrowing BorrowFromRequest)
        {
            if (ModelState.IsValid == true)
            {
                //BorrowFromRequest.ActualReturnDate=BorrowFromRequest.DueDate;

                // Save

                borrowRepository.AddBorrowing(BorrowFromRequest); 
                BorrowFromRequest.ActualReturnDate=BorrowFromRequest.DueDate;
                //Add();
                borrowRepository.Save();
                return RedirectToAction("AllBorrowings");
            }
            ViewBag.Books = bookRepository.GetAll();
            ViewBag.Users = borrowRepository.GetAllUsers();
            return View("CreateBorrow", BorrowFromRequest);

    }
        public double CalcPenality(DateTime dayD, DateTime dayAct) {
            Borrowing br = new Borrowing();
            var numDays = (dayAct - dayD).Days;

            return 5 * numDays;
        }
   
        public IActionResult EditBorrow(int id) 
        {
            ViewBag.Books = bookRepository.GetAll();
            ViewBag.Users = borrowRepository.GetAllUsers();
            Borrowing _borrowing=borrowRepository.GetById(id);
            List<Book> books = bookRepository.GetAll();
            _borrowing.Id = id;
            
            //_borrowing.PenalityAmount = CalcPenality(_borrowing.DueDate, _borrowing.ActualReturnDate);
            return View("EditBorrow",_borrowing);
            
        }
        [HttpPost]
        public IActionResult SaveEdit(int id,Borrowing borrowFromRequest)
        {
            //ViewData["BookList"] = bookRepository.GetAll();
            //ViewData["UsersList"] = borrowRepository.GetAllUsers();
            if (borrowRepository.GetById(id) != null)
            {
                Borrowing borrowFromDB=borrowRepository.GetById(id);
                borrowFromDB.BookId = borrowFromRequest.BookId;
                borrowFromDB.ApplicationUserId = borrowFromRequest.ApplicationUserId;
                borrowFromDB.BorrowingDate = borrowFromRequest.BorrowingDate;
                borrowFromDB.DueDate = borrowFromRequest.DueDate;
                borrowFromDB.ActualReturnDate = borrowFromRequest.ActualReturnDate;
                borrowFromDB.PenalityAmount = borrowFromRequest.PenalityAmount;
                borrowFromDB.PenalityAmount = CalcPenality(borrowFromDB.DueDate, borrowFromDB.ActualReturnDate);


                borrowRepository.UpdateBorrowing(borrowFromDB);
                borrowRepository.Save();
                return RedirectToAction("AllBorrowings");
            }
            //borrowRepository.Save();

            return View("EditBorrow", borrowFromRequest);

        }

        public async Task<IActionResult> DeleteBorrow(Borrowing _borrow, int id)
        {
            borrowRepository.DeleteBorrowing(id);
            borrowRepository.Save();
            return RedirectToAction("AllBorrowings");
        }
        public ActionResult BorrowForEachBook(int id,Book _book) {
            //bookRepository.AddBook(id);
			//borrowRepository.UpdateBorrowing();
            ViewBag.BookID=bookRepository.GetById(id);
			borrowRepository.Save();
			return RedirectToAction("CreateBorrow");
        }



    }
}
