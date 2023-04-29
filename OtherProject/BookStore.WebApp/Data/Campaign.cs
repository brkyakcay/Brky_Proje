namespace BookStore.WebApp.Data
{
    public class Campaign : EntityBase
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

        public virtual List<Book> Books { get; set; }

        public DateTime CreatedDate { get; set; }
        //TODO: Hata!!!
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        


    }
}
