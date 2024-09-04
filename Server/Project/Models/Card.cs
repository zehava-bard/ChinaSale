using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        public Presents Presents { get; set; }
        public int PresentsID { get; set; }
        public Purchases Purchases { get; set; }
        public int PurchasesId { get; set; }
    }
}
