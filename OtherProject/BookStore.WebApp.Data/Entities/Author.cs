namespace BookStore.WebApp.Data.Entities
{
    public class Author : PersonBase
    {
        public string? EMail { get; set; }

        public virtual List<Book> Books { get; set; }

        public DateTime CreatedDate { get; set; }
    }
    
  
}
