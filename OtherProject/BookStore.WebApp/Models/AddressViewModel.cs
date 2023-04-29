using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApp.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }
        
        public string City { get; set; }

        public string Description { get; set; }
    }
}
