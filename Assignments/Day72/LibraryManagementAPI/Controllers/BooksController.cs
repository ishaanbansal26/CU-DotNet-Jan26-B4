using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.DTOs;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        private readonly ILogger _logger;

        public BooksController(MyAppDbContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            try
            {
                _logger.LogInformation("GET api/Books");
                var books = await _context.Books.Include(s => s.Author).Select(s => new 
                {
                    s.BookId,
                    s.BookName,
                    s.Price,
                    Author = new
                    {
                        s.Author.AuthorId,
                        s.Author.AuthorName,
                        s.Author.Age
                    }
                }).ToListAsync();

                return Ok(books);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                _logger.LogInformation($"GET api/Books/{id}");
                var book = await _context.Books.Include(x => x.Author).Where(x => x.BookId == id)
                    .Select(s => new
                    {
                        s.BookId,
                        s.BookName,
                        s.Price,
                        Author = new
                        {
                            s.Author.AuthorId,
                            s.Author.AuthorName,
                            s.Author.Age
                        }
                    }).FirstOrDefaultAsync();



                if (book == null)
                {
                    return NotFound();
                }

                return Ok(book);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            _logger.LogInformation($"PUT api/Books/{id}");
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(CreateBookDTO dto)
        {
            try
            {
                _logger.LogInformation("POST api/Books");
                var book = new Book
                {
                    BookName = dto.BookName,
                    Price = dto.Price,
                    AuthorId = dto.AuthorId
                };
                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBook", new { id = book.BookId }, book);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }

        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                _logger.LogInformation($"DELETE api/Books/{id}");
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }

        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
