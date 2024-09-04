using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<Presents> presents { get; set; }
    }
}
