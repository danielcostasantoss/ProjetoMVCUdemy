using Microsoft.EntityFrameworkCore;
using ProjetoMVCUdemy.Data;
using ProjetoMVCUdemy.Models;

namespace ProjetoMVCUdemy.Services
{
    public class DepartmentService
    {
        private readonly ProjetoMVCUdemyContext _context;

        public DepartmentService(ProjetoMVCUdemyContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
