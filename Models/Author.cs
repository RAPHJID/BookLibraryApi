namespace BookLibraryApi.Models
{
    public class Author
    {

        public int Id {get;set;}
        [Required(ErrorMessage = "FirstName required")]
        [MaxLength(50, ErrorMessage="Can't be more than 50 characters")]
        public string FirstName {get;set;}
        [Required(ErrorMessage = "LastName required")]
        [MaxLength(50, ErrorMessage="Can't be more than 50 characters")]
        public string LastName {get;set;}
        [Required(ErrorMessage ="Birth date required")]
        public DateTime BirthDate {get;set;}
        public ICollection<Book> Books {get;set;} = new List<Book>();
        
    }
}