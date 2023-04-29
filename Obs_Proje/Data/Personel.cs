namespace Obs_Proje.Data
{
    public class Personel:EntityBase
    {
        public string Adi { get; set; }

        public string Soyadi { get; set; }  

        public int SicilNo { get; set; } 

        public int DepartmanId { get; set; }    
        public virtual Departman Departman { get; set; }


    }
}
