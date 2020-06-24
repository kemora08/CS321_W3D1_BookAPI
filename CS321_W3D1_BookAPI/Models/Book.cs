using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W3D1_BookAPI.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        // Book has an Author
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        // Book has an Publisher
        public Publisher Publisher { get; set; }

    }
}
