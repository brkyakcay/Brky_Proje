namespace Obs_Proje.Data
{
    public class Adres : EntityBase
    {
        
        public string Satir1 { get; set; }
        public string Satir2 { get; set; }
        public int IlceId { get; set; }

        public virtual List<Ogrenci> Ogrenciler { get; set; }
        public virtual Ilce Ilce { get; set; }
    }

}
