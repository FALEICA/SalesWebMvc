using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller? seller { get; set; }


        public SalesRecord() { 
        
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller? seller)
        {
            this.id = id;
            Date = date;
            Amount = amount;
            Status = status;
            this.seller = seller;
        }
    }
}
