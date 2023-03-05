using System.ComponentModel.DataAnnotations;

namespace Obs_Proje.Data
{
    public class Bolum : EntityBase
    {
        [Display(Name = "Adı")]
        public string Adi { get; set; } 

        public virtual List<Ogrenci> Ogrenciler { get; set; }
        public virtual List<Ders> Dersler { get; set; }

    }

}
