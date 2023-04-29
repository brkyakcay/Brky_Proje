namespace BookStore.WebApp.Data.Entities
{
    public class Campaign : EntityBase
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public DateTime CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual List<Book> Books { get; set; }
    }
}
