using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class EFBooksRepository
    {
        private BookstoreContext context { get; set; }
        public EFBooksRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Books> Projects => context.Books;
    }
}
