using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApp.Data
{
    public class Book : EntityBase
    {
        public string Name { get; set; } = "";
        public int PageCount { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Campaign")]
        public int? CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }

        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [Display(Name = "Translator")]
        public int? TranslatorId { get; set; }
        public virtual Translator Translator { get; set; }

        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Title { get; set; }


        //TODO: hata!!
        //public virtual List<Author> Authors{ get; set; }

    }
}
