using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;
       

        public BookService(BookContext myContext)
        {
            _bookContext = myContext;    
        }
        public Book Add(Book newBook)
        {
            _bookContext.Add(newBook);
            _bookContext.SaveChanges();
            return newBook;
        }

        public void Delete(Book deletebook)
        {
            // make sure the book exists
            var currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == deletebook.Id);
            if(currentBook != null)
            {
                _bookContext.Remove(deletebook);
                _bookContext.SaveChanges();
            }
         
        }

        public Book Get(int id)
        {
           return _bookContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book Update(Book updateBook)
        {
            var currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == updateBook.Id);
            if (currentBook != null)
            {
                _bookContext.Entry(currentBook).CurrentValues.SetValues(updateBook);
                _bookContext.Books.Update(currentBook);
                _bookContext.SaveChanges();
                return currentBook;
            }
            return null;
        }
    }
}
