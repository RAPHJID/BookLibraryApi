using AutoMapper;
using BookLibraryApi.Data;
using BookLibraryApi.Models;
using BookLibraryApi.Models.DTOs;
using BookLibraryApi.Services.IService;
using Microsoft.EntityFrameworkCore;


namespace BookLibraryApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly LibraryContext _context;

        public AuthorService(IMapper mapper, LibraryContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _context.Authors.Include(a => a.Books).AsNoTracking().ToListAsync();
            return _mapper.Map<List<AuthorDto>>(authors);
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int authorId)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == authorId);
            if(author == null) return null;
            return _mapper.Map<AuthorDto>(author);
        }

        public async Task AddAuthorAsync(CreateUpdatedAuthorDto newAuthor)
        {
            var author = _mapper.Map<Author>(newAuthor);
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(int authorId, CreateUpdatedAuthorDto updatedAuthor)
        {
            var existingAuthor = await _context.Authors.FindAsync(authorId);
            if(existingAuthor == null) return;
            _mapper.Map(updatedAuthor, existingAuthor);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAuthorAsync(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);
            if(author == null) return;
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
        
    }
}