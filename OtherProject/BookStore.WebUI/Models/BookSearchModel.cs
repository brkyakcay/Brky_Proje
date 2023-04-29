namespace BookStore.WebUI.Models
{
    public class BookSearchModel
    {
        public string? Name{ get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        public int? CategoryId { get; set; }
    }
}
