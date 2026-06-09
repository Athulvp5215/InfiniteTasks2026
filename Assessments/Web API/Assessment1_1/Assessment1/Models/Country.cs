using System.ComponentModel.DataAnnotations;

namespace CountryAPI.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; }

        public string CountryName { get; set; }

        public string Capital { get; set; }
    }
}