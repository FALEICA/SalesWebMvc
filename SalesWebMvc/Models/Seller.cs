using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é requerido")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e 60 caracteres {1}")]
        public string? name { get; set; }

        [Display(Name = "e-Mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} é requerido")]
        [EmailAddress(ErrorMessage ="O email não é válido")]
        public string? email { get; set; }

        [Display(Name = "Data Aniversario")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} é requerido")]
        public DateTime birthDate { get; set; }

        [Display(Name = "Salario Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} é requerido")]
        [Range(100.00, 50000.00, ErrorMessage ="{0} O salario base nao pode ser menor que {1} e maior que {2}")]
        public double baseSalary { get; set; }

        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> sales { get; set; } = new List<SalesRecord>();


        public Seller() { }

        public Seller(int id, string? name, string? email, DateTime birthDate, double baseSalary, Department? Department)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.birthDate = birthDate;
            this.baseSalary = baseSalary;
            this.Department = Department;
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
