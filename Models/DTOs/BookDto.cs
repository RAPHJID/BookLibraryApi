using BookLibraryApi.Models;

namespace BookLibraryApi.Models.DTOs
{
    public class BookDto
    {
        public int Id {get;set;}
        public string Title {get;set;}
        public DateTime PublishedDate {get;set;}
        public string Description {get;set;}
        public bool IsAvailable {get;set;}
        public string AuthorName {get;set;} 
        public int AuthorId {get;set;} 

        
    }
}