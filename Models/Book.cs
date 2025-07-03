namespace BookLibraryApi.Models
{
    public class Book
    {
        public int Id {get;set;}
        [Required(ErrorMessage = "Title required")]
        [MaxLength(20 , ErrorMessage ="Cannot be more than 20 characters")]
        public string Title {get;set;}
        [Required(ErrorMessage = "Date of publish required")]
        public DateTime PublishedDate {get;set;}
        [Required(ErrorMessage = "Description required")]
        [MaxLength(50, ErrorMessage = "Description cannot have more than 0 characters")]
        public string Description {get;set;}
        public bool IsAvailable {get;set;} = true;

        public Author Author {get;set;} 
        public int AuthorId {get;set;} //foreign key
        
    }
}