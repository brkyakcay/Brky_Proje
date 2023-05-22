namespace Obs_Proje.Models
{
    public class PersonelViewModel
    {

        public int Id { get; set; } 

        public string Adi { get; set; } 
        public string Soyadi { get; set; }

        public int SicilNo { get; set; }    

        public virtual string DepartmanAdi { get; set; }    

    }
}
