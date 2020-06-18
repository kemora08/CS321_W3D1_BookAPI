using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookContext _bookContext;


        public AuthorService(BookContext myContext)
        {
            _bookContext = myContext;
        }
        public Author Add(Author newAuthor)
        {
            _bookContext.Add(newAuthor);
            _bookContext.SaveChanges();
            return newAuthor;
        }

        public void Delete(Author deleteauthor)
        {
            // make sure the Author exists
            var currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == deleteauthor.Id);
            if (currentBook != null)
            {
                _bookContext.Remove(deleteauthor);
                _bookContext.SaveChanges();
            }

        }

        public Author Get(int id)
        {
            return _bookContext.Authors.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookContext.Authors.ToList();
        }

        public Author Update(Author updateAuthor)
        {
            var currentAuthor = _bookContext.Authors.FirstOrDefault(b => b.Id == updateAuthor.Id);
            if (currentAuthor != null)
            {
                _bookContext.Entry(currentAuthor).CurrentValues.SetValues(updateAuthor);
                _bookContext.Authors.Update(currentAuthor);
                _bookContext.SaveChanges();
                return currentAuthor;
            }
            return null;
        }
    }
}
