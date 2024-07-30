using Microsoft.EntityFrameworkCore;
using ProjetoMVCUdemy.Data;
using ProjetoMVCUdemy.Models;

namespace ProjetoMVCUdemy.Services
{
    public class SalesRecordService 
    {
        private readonly ProjetoMVCUdemyContext _context;

        public SalesRecordService(ProjetoMVCUdemyContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }
    }
}
