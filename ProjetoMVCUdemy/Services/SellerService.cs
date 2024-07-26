using ProjetoMVCUdemy.Data;
using ProjetoMVCUdemy.Models;

namespace ProjetoMVCUdemy.Services
{
    public class SellerService
    {
        private readonly ProjetoMVCUdemyContext _context;
        public SellerService(ProjetoMVCUdemyContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();  
        }
    }
}
