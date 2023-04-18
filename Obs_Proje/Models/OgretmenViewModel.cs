namespace Obs_Proje.Models
{
    public class OgretmenViewModel
    {
        public int Id { get; set; } 

        public string Adi { get; set; }
        public string Soyadi { get; set; }
        
        public int SicilNo { get; set; }    

        public virtual string BolumAdi { get; set; }
        public virtual string VerdigiDersler { get; set; }  


    }
}
