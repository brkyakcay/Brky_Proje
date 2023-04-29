using Obs_Proje.Data;

namespace Obs_Proje.Models
{
    public class OgrenciDersListeModel
    {
        public int Id { get; set; }
        public string TamAdi { get; set; }
        public List<Ders> Dersler { get; set; } = new List<Ders>();

    }
}
