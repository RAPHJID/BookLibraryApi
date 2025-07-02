using Microsoft.AspNetCore.Mvc;
using BookLibraryApi.Services;
using BookLibraryApi.Services.IService;
using BookLibraryApi.Models.DTOs;

namespace BookLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await _authorService.GetAllAuthorsAsync();
        return Ok(authors);

    }

    [HttpGet("{authorId}")]
    public async Task<IActionResult> GetAuthorById(int authorId)
    {
        var author = await _authorService.GetAuthorByIdAsync(authorId);
        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor(CreateUpdatedAuthorDto newAuthor)
    {
        await _authorService.AddAuthorAsync(newAuthor);
        return Ok(newAuthor);
    }

    [HttpPut("{authorId}")]
    public async Task<IActionResult> UpdateAuthor(int authorId, CreateUpdatedAuthorDto updatedAuthor)
    {
        var existingAuthor = await _authorService.GetAuthorByIdAsync(authorId);
        if(existingAuthor == null) return NotFound($"Author with ID: {authorId} NOT FOUND!!");
        await _authorService.UpdateAuthorAsync(authorId, updatedAuthor);
        return Ok(updatedAuthor);
    }

    [HttpDelete("{authorId}")]
    public async Task<IActionResult> DeleteAuthor(int authorId)
    {
        var author = await _authorService.GetAuthorByIdAsync(authorId);
        if(author == null) return NotFound($"Author with ID : {authorId} Not Found!");
        await _authorService.DeleteAuthorAsync(authorId);
        return Ok($"Author with ID {authorId} Deleted");
    }


    
    
}