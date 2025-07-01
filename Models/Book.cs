namespace BookLibraryApi.Models
{
    public class Book
    {
        public int Id {get;set;}
        public string Title {get;set;}
        public DateTime PublishedDate {get;set;}
        public string Description {get;set;}
        public bool IsAvailable {get;set;} = true;

        public Author Author {get;set;} 
        public int AuthorId {get;set;} //foreign key
        
    }
}