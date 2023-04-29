namespace BookStore.WebApp.Data
{
    public class Category: EntityBase
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public virtual List<Book> Books { get; set; }

    }
}
