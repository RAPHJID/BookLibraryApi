using BookLibraryApi.Models;

namespace BookLibraryApi.Models.DTOs
{
    public class CreateUpdatedAuthorDto
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public DateTime BirthDate {get;set;}   
    }
}