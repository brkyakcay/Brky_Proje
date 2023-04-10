namespace Obs_Proje.Models
{
    public class DersViewModel
    {
        public int Id { get; set; } 
        public string Adi { get; set; } 

        public virtual string BolumAdi { get; set; }    
        public virtual string OgretmenAdiSoyadi { get; set; }
    }
}
