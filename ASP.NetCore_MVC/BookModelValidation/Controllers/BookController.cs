using Microsoft.AspNetCore.Mvc;
using BookModelValidation.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookModelValidation.Controllers
{
    [Route("Book")]
    public class BookController : Controller
    {
        public static List<Book> books = new List<Book>();

        [Route("/")]
        [Route("List")]
        public IActionResult List()
        {
            return View(books);
        }

        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                var exists = books.Any(b => b.Isbn == book.Isbn);
                if (!exists)
                {
                    books.Add(book);
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError("Isbn", "ISBN already exists.");
                }
            }

            return View(book);
        }
    }
}
