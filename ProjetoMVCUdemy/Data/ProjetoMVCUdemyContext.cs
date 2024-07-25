using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoMVCUdemy.Models;

namespace ProjetoMVCUdemy.Data
{
    public class ProjetoMVCUdemyContext : DbContext
    {
        public ProjetoMVCUdemyContext (DbContextOptions<ProjetoMVCUdemyContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
