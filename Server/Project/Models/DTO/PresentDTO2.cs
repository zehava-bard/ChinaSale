using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project.Models.DTO
{
    public class PresentDTO2
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public Donors Donors { get; set; }      


    }
}
