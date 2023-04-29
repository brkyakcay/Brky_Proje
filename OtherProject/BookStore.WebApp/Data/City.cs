using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.WebApp.Data
{
    public class City : EntityBase
    {
        public int CityCode { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public string DisplayName => CityCode + " - " + Name;
        //public string DisplayName
        //{
        //    get { return Name + " " + CityCode; }
        //}

        public virtual List<Address> Addresses { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
