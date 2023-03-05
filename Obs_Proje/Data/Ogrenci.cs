using System.ComponentModel.DataAnnotations;

namespace Obs_Proje.Data
{
    public class Ogrenci:EntityBase
    {
        [Display(Name ="Adı")]
        public string Adi { get; set; }

        [Display(Name = "Soyadı")]
        public string Soyadi { get; set; }  

        [Display(Name = "Öğrenci Numarası")]
        public int OkulNo { get; set; } 


        public virtual List<Ders> Dersler { get; set; }

        public int? BolumId  { get; set; }
        public virtual Bolum Bolum { get; set; }

        public int? AdresId { get; set; }
        public virtual Adres Adres { get; set; }
    }

}
