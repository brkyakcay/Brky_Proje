using System.ComponentModel.DataAnnotations;

namespace Obs_Proje.Data
{
    public class Ders : EntityBase
    {
        [Display(Name = "Adı")]
        public string Adi { get; set; } 

        public int? BolumId { get; set; }
        public virtual Bolum Bolum { get; set; }

        public virtual List<Ogrenci> Ogrenciler { get; set; }
    }

}
