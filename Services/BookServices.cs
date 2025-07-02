using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Services
{
    public class BookServices : IBookService
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public BookServices(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _context.Books.Include(b => b.Author).AsNoTracking().ToListAsync();
            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookDto> GetBookByIdAsync(int bookId)
        {
            var book = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == bookId);
            if(book == null) return null;
            return _mapper.Map<BookDto>(book);
        }

        public async Task AddBookAsync(CreateUpdateBookDto newBook)
        {
            var book = _mapper.Map<Book>(newBook);
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateBookAsync(int bookId, CreateUpdateBookDto updatedBook)
        {
            var existingBook = await _context.Books.FindAsync(bookId);
            if(existingBook == null)  return;
            _mapper.Map(updatedBook, existingBook);
            await _context.SaveChangesAsync();            
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book == null) return;
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

        }

        public async Task<List<BookDto>> GetBooksByAuthorAsync(int authorId)
        {
            var books = await _context.Books.Include(b => b.Author).Where(a => a.AuthorId == authorId).ToListAsync();
            return _mapper.Map<List<BookDto>>(books);

        }

        public async Task<List<BookDto>> GetAvailableBooksAsync()
        {
            var availableBooks = await _context.Books.Include(b => b.Author).Where(b => b.IsAvailable).ToListAsync();
            return _mapper.Map<List<BookDto>>(availableBooks);


        }






        
    }
}