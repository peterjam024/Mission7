using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterProject.Infrastructure;
using Mission7.Models;

namespace Mission7.Pages
{
    public class PurchaseModel : PageModel
    {

        private IBooksRepository repo { get; set; }

        public PurchaseModel(IBooksRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnURL { get; set; }
        public void OnGet(string returnURL)
        {
            ReturnURL = returnURL ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookID, string returnURL)
        {
            Books p = repo.Books.FirstOrDefault(x => x.BookId == BookID);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            basket.AddItem(p, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnURL = returnURL });
        }
    }
}
