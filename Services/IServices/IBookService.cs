namespace BookLibraryApi.Services.IService
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task <Book> GetBookById(int bookId);
        Task AddBookAsync(Book newBook);
        Task UpdateBookAsync(int bookId, Book updatedBook);
        Task DeleteBookAsync(int bookId);
    }
}