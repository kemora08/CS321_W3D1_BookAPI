using CS321_W3D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Services
{
    public interface IAuthorService
    {
        // Get all authors
        IEnumerable<Author> GetAll();

        // Get a author by id
        Author Get(int id);

        // Add a new author
        Author Add(Author newAuthor);

        // Update a author
        Author Update(Author updateAuthor);

        // Delete a author
        void Delete(Author deleteauthor);
    }
}
