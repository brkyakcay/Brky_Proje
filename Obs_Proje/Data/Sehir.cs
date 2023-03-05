using System.ComponentModel.DataAnnotations;

namespace Obs_Proje.Data
{
    public class Sehir : EntityBase
    {
        [Display(Name = "Adı")]
        public string Adi { get; set; } 

        public virtual List<Ilce> Ilceler { get; set; }
    }

}
