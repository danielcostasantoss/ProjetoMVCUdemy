﻿namespace ProjetoMVCUdemy.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; } = new Seller();
        public ICollection<Department> Departments { get; set; }
    }
}
