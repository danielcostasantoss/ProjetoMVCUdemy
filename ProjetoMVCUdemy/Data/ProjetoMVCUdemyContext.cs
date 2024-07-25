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

        public DbSet<ProjetoMVCUdemy.Models.Department> Department { get; set; } = default!;
    }
}
