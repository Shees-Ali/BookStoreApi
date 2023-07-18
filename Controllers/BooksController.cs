using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;
// Controller for handling all routes related to /books 
[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService) =>
        _booksService = booksService;

    // Gets List of Books based on different filters
    [HttpGet]
    public async Task<List<Book>> GetList(string search = "", string sortBy = "", string order = "", int page = 1, int pageSize = 5)
    {
        var books = await _booksService.GetAsyncList(search, page, pageSize);
        List<Book> SortedList = books;
        if (sortBy == "name")
        {
            if (order == "ascending")
            {
                SortedList = books.OrderBy(o => o.BookName).ToList();

            }
            else if (order == "decending")
            {
                SortedList = books.OrderByDescending(o => o.BookName).ToList();
            }
        }

        if (sortBy == "author")
        {
            if (order == "ascending")
            {
                SortedList = books.OrderBy(o => o.Author).ToList();

            }
            else if (order == "decending")
            {
                SortedList = books.OrderByDescending(o => o.Author).ToList();
            }
        }

        if (sortBy == "category")
        {
            if (order == "ascending")
            {
                SortedList = books.OrderBy(o => o.Category).ToList();

            }
            else if (order == "decending")
            {
                SortedList = books.OrderByDescending(o => o.Category).ToList();
            }
        }

        if (sortBy == "status")
        {
            if (order == "ascending")
            {
                SortedList = books.OrderBy(o => o.Status).ToList();

            }
            else if (order == "decending")
            {
                SortedList = books.OrderByDescending(o => o.Status).ToList();
            }
        }

        if (sortBy == "completed_on")
        {
            if (order == "ascending")
            {
                SortedList = books.OrderBy(o => o.CompletedOn).ToList();

            }
            else if (order == "decending")
            {
                SortedList = books.OrderByDescending(o => o.CompletedOn).ToList();
            }
        }

        return SortedList;
    }

    // Gets a Single Book
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> Get(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    // Adds a new Book
    [HttpPost]
    public async Task<IActionResult> Post(Book newBook)
    {
        await _booksService.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    // Updates a existing Book by using ID
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Book updatedBook)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _booksService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    // Deletes a existing Book by using ID
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _booksService.RemoveAsync(id);

        return NoContent();
    }
}