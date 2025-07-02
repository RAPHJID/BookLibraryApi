using BookLibraryApi.Models;
using BookLibraryApi.Models.DTOs;

namespace BookLibraryApi.Services.IService
{
    public interface IAuthorService
    {
        Task <List<AuthorDto>> GetAllAuthorsAsync();
        Task <AuthorDto> GetAuthorByIdAsync(int authorId);
        Task AddAuthorAsync(CreateUpdatedAuthorDto newAuthor);
        Task UpdateAuthorAsync (int authorId, CreateUpdatedAuthorDto updatedAuthor);
        Task DeleteAuthorAsync(int authorId);

    }
}