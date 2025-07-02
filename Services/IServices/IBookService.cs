using BookLibraryApi.Models;
using BookLibraryApi.Models.DTOs;

namespace BookLibraryApi.Services.IService
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooksAsync();
        Task <BookDto?> GetBookByIdAsync(int bookId);
        Task AddBookAsync(CreateUpdateBookDto newBook);
        Task UpdateBookAsync(int bookId, CreateUpdateBookDto updatedBook);
        Task DeleteBookAsync(int bookId);
        Task<List<BookDto>> GetBooksByAuthorAsync(int authorId);
        Task<List<BookDto>> GetAvailableBooksAsync();
    }
}
