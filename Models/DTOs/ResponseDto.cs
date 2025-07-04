using BookLibraryApi.Models;

namespace BookLibraryApi.Models.DTOs
{
    public class ResponseDto
    {
        public bool Success {get;set;} = true;
        public string Message {get;set;} = string.Empty;  
    }
}