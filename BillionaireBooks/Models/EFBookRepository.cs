﻿namespace BillionaireBooks.Models
{
    public class EFBookRepository : IBookstoreRepository
    {
        private BookstoreContext _context;
        public EFBookRepository(BookstoreContext temp)
        {
            _context = temp;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
