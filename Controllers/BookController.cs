using Microsoft.AspNetCore.Mvc;
using BookLibraryApi.Services;
using BookLibraryApi.Services.IService;
using BookLibraryApi.Models.DTOs;

namespace BookLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBookById(int bookId)
    {
        var book = await _bookService.GetBookByIdAsync(bookId);
        if(book == null) return NotFound($"Book with ID : {bookId} not found!");
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(CreateUpdateBookDto newBook)
    {
        await _bookService.AddBookAsync(newBook);
        return Ok(newBook);
    }

    [HttpPut("{bookId}")]
    public async Task<IActionResult> UpdateBook(int bookId, CreateUpdateBookDto updatedBook)
    {
        var existingBook = await _bookService.GetBookByIdAsync(bookId);
        if(existingBook == null) return NotFound($"Book with ID : {bookId} not found!");
        await _bookService.UpdateBookAsync(bookId, updatedBook);
        return Ok(updatedBook);
    }

    [HttpDelete("{bookId}")]
    public async Task<IActionResult> DeleteBook(int bookId)
    {
        var book = await _bookService.GetBookByIdAsync(bookId);
        if(book == null) return NotFound($"Book with ID : {bookId} not found!");
        await _bookService.DeleteBookAsync(bookId);
        return Ok($"Book with ID : {bookId} Deleted");
    }

    [HttpGet("by-author/{authorId}")]
    public async Task<IActionResult> GetBooksByAuthor(int authorId)
    {
        var authorBooks = _bookService.GetBooksByAuthorAsync(authorId);
        if(authorBooks == null) return NotFound();
        return Ok(authorBooks);
        
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableBooks()
    {
        var availableBooks = await _bookService.GetAvailableBooksAsync();
        return Ok(availableBooks);
    }

    


    
}