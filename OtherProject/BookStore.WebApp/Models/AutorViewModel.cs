using BookStore.WebApp.Controllers;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApp.Models
{
    public class AutorViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Book Count")]
        public int BookCount { get; set; }
    }
}
