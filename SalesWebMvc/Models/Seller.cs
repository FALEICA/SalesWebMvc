namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public DateTime birthDate { get; set; }
        public double baseSalary { get; set; }
        public Department? department { get; set; }
        public ICollection<SalesRecord> sales { get; set; } = new List<SalesRecord>();


        public Seller() { }

        public Seller(int id, string? name, string? email, DateTime birthDate, double baseSalary, Department? department)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.birthDate = birthDate;
            this.baseSalary = baseSalary;
            this.department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr) { 
            sales.Remove(sr);   
        }

        public double TotalSales(DateTime initial, DateTime final) {
            return sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);

        }

     


    
    }
}
