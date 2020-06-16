﻿using CS321_W3D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Services
{
    public interface IBookService
    {
        // Get all books
        IEnumerable<Book> GetAll();

        // Get a book by id
        Book Get(int id);

        // Add a new book
        Book Add(Book newBook);

        // Update a book
        Book Update(Book updateBook);

        // Delete a book
        void Delete(Book deletebook);
    }
}
