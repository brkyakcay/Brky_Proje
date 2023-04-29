using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.WebApp.Data.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
     
    }

    public class PersonBase:EntityBase
    {
        public string Name { get; set; } = "";
        public string? MiddleName { get; set; } = null;
        public string Surname { get; set; } = "";

        //public string FullName => Name + " " + MiddleName + " " + Surname;
        
        //[NotMapped]
        public string FullName => $"{Name} {MiddleName} {Surname}";
    }
}
