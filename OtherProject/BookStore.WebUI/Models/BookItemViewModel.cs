namespace BookStore.WebUI.Models
{
    public class BookItemViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? PageCount { get; set; }
        public string? PublisherName { get; set; }
        public string? Category{ get; set; }
        public string? AuthorName { get; set; }
        public string? TranslatorName { get; set; }        
    }
}
