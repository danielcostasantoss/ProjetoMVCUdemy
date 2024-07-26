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

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Nome).ToList();
        }
    }
}
