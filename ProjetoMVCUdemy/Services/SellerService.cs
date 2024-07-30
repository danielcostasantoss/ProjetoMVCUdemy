using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjetoMVCUdemy.Data;
using ProjetoMVCUdemy.Models;
using ProjetoMVCUdemy.Services.Exceptions;

namespace ProjetoMVCUdemy.Services
{
    public class SellerService
    {
        private readonly ProjetoMVCUdemyContext _context;
        public SellerService(ProjetoMVCUdemyContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller
                .Include(obj => obj.Department)
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var seller = await _context.Seller.Include(s => s.Sales).FirstOrDefaultAsync(s => s.Id == id);

            if (seller == null)
            {
                throw new NotFoundException("Seller not found");
            }

            if (seller.Sales.Any())
            {
                throw new IntegrityException("Can't delete seller because they have sales");
            }

            _context.Seller.Remove(seller);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new KeyNotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
