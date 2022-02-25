using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IMission7ProjectRepository repo { get; set; }

        public TypesViewComponent(IMission7ProjectRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var Category = repo.Books
                .Select(x => x.bookCategory)
                .Distinct()
                .OrderBy(x => x);

            return View(Category);
        }
    }

}
