using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApp.Models
{
    public class PublisherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Book Count")]
        public int BookCount { get; set; }

        [Display(Name = "Address Count")]
        public int AddressCount { get; set; }
    }
}
