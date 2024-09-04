using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Purchases
    {
        [Key]
        public int ID { get; set; }  
        public User Buyer { get; set; }
        public int BuyerID { get; set; }
        public int NumberOfTicket { get; set; }
        public IEnumerable<Card> ListOfCard { get; set; }
        public bool status { get; set; }


        ///אולי למחוק
        //public Purchases(int BuyerID,int NumberOfTicket)
        //{
        //    this.BuyerID = BuyerID;
        //    this.NumberOfTicket = NumberOfTicket;
        //}
    }
}
