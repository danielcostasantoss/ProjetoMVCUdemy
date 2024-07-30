using ProjetoMVCUdemy.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVCUdemy.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}} ")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}" )]
        public double Quantia { get; set; }

        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord() { }

        public SalesRecord(int id, DateTime data, double quantia, SaleStatus status, Seller seller)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            Seller = seller;
        }
    }
}
