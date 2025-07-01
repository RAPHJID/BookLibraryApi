using BookLibraryApi.Models;

namespace BookLibraryApi.Models.DTOs
{
    public class CreateUpdateBookDto
    {
        public string Title {get;set;}
        public DateTime PublishedDate {get;set;}
        public string Description {get;set;} 
        public int AuthorId {get;set;} 
        
    }

}