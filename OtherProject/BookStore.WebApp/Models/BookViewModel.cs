namespace BookStore.WebApp.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Publisher{ get; set; }
        public string Translator { get; set; }
    }
}
