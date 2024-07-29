using System.ComponentModel.DataAnnotations;

namespace ProjetoMVCUdemy.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Display (Name  = "Nome")]
        [Required(ErrorMessage = "o {0} é necessário.")]
        [StringLength (100, MinimumLength = 3, ErrorMessage = "Tamanho do {0} tem que ser entre {2} e {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name  = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Insira um e-mail válido")]
        [Required(ErrorMessage = "o {0} é necessário.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Tamanho do {0} tem que ser entre {2} e {1} caracteres.")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "o {0} é necessário.")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve ser de {1} a {2}")]
        [Required(ErrorMessage = "o {0} é necessário.")]
        public double SalarioBase { get; set; }

        public Department Department { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "o {0} é obrigatório.")]

        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Department department)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
        public double TotalSales(DateTime inicial, DateTime final)
        {
            return Sales.Where(sr => sr.Data >= inicial && sr.Data <= final).Sum(sr => sr.Quantia);
        }
    }
}
