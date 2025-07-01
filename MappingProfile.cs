using AutoMapper;
using BookLibraryApi.Models;
using BookLibraryApi.Models.DTOs;

namespace BookLibraryApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
            {
                CreateMap<Book, BookDto>();
                CreateMap<BookDto, Book>();
                CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
                CreateMap<AuthorDto, Author>();
                CreateMap<CreateAuthorDto, Author>();
                CreateMap<CreateUpdateBookDto, Book>();
            }
    }

}
