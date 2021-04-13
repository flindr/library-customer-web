using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using customer_web.Models;
using System.Net.Http;

namespace customer_web.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public async Task<IActionResult> Index()
        {
            IEnumerable<BookViewModel> books = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44334/api/");
              
                var result = await client.GetAsync("books");
                
                if (result.IsSuccessStatusCode)
                {
                    books = await result.Content.ReadAsAsync<IList<BookViewModel>>();
                }
                else //web api sent error response 
                {
                    //log response status here..

                    books = Enumerable.Empty<BookViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(books);
        }

        public async Task<IActionResult> Details(int? id)
        {
            BookViewModel book = null;

            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44334/api/");

                var result = await client.GetAsync("books/" + id);

                if (result.IsSuccessStatusCode)
                {
                    book = await result.Content.ReadAsAsync<BookViewModel>();
                    if (book == null)
                    {
                        return NotFound();
                    }
                }
                else //web api sent error response 
                {
                    //log response status here..
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(book);
        }
    }
}
