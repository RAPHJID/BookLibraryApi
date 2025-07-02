using AutoMapper;
using BookLibraryApi.Models;
using BookLibraryApi.Models.DTOs;

namespace BookLibraryApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
            {
                CreateMap<Book, BookDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));
                CreateMap<BookDto, Book>();
                CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
                CreateMap<AuthorDto, Author>();
                CreateMap<CreateAuthorDto, Author>();
                CreateMap<CreateUpdateBookDto, Book>();
            }
    }

}
