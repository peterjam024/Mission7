using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {
        private BookstoreContext BookContext { get; set; }

        public HomeController(BookstoreContext x)
        {
            BookContext = x;
        }

        public IActionResult Index()
        {

            var applications = BookContext.Books.ToList();

            return View(applications);
        }

    }
}
