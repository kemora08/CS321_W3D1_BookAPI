﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController (IBookService BookService)
        {
            _bookService = BookService;
        }
        public int Id { get; private set; }

        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.GetAll());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book myNewBook)
        {
            var book = _bookService.Add(myNewBook);
            if (book == null) return BadRequest();
            return CreatedAtAction("Get", new { Id = myNewBook.Id }, myNewBook);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book myUpdatedBook)
        {
            var Book = _bookService.Update(myUpdatedBook);
            if (Book == null) return NotFound();
            return Ok(Book);
        }

        // DELETE api/bookss/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Book = _bookService.Get(Id);
            if (Book == null) return NotFound();
            _bookService.Delete(Book);
            return NoContent();
        }
    }
}
