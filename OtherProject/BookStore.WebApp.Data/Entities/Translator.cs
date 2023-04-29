namespace BookStore.WebApp.Data.Entities
{
    public class Translator:PersonBase
    {
        public string? EMail { get; set; }

        public virtual List<Book> Books { get; set; }

        public virtual List<Lang> Langs { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
