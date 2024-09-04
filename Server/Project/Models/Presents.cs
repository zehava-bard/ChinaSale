using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Presents
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }  
        public int DonorsID { get; set; }
        public Donors Donors { get; set; }
        public int NumOfPurchasers { get; set; }
        public double TotalRevenue { get; set; }

    }
}
