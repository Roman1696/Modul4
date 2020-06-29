using BusinessLayer;
using BusinessLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Modul_4.Controllers
{
    public class BookStoreController : Controller
    {
        private readonly BookStoreManager _bookStoreManager;

        public BookStoreController()
        {
            _bookStoreManager = new BookStoreManager();
        }

        // GET: BookStore
        public ActionResult Index()
        {

            var books = _bookStoreManager.GetAllBooks();

            return View(books);
            
        }
        public ActionResult BookDetails(int id)
        {
            var books = _bookStoreManager.GetBookById(id);

            return View(books);
        }
        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(BookDTO book)
        {
            _bookStoreManager.AddBook(book);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditBook(int id)
        {
            var books = _bookStoreManager.GetBookById(id);

            return View(books);
        }

        [HttpGet]
        public ActionResult RemoveBook(int id)
        {
            _bookStoreManager.RemoveById(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditBook(BookDTO book)
        {
            _bookStoreManager.UpdateBook(book);

            return RedirectToAction("Index");
        }

        
    }
}

