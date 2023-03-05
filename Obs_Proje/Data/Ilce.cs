using System.ComponentModel.DataAnnotations;

namespace Obs_Proje.Data
{
    public class Ilce : EntityBase
    {
        
        public int SehirId { get; set; }

        [Display(Name = "Adı")]
        public string Adi { get; set; } 

        public virtual Sehir Sehir { get; set; }
        public virtual List<Adres> Adresler { get; set; }
    }

}
