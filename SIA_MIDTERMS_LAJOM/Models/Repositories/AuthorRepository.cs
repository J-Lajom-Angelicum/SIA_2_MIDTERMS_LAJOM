using SIA_MIDTERMS_LAJOM.Models.DTO.AuthorDTO;
using Microsoft.EntityFrameworkCore;

namespace SIA_MIDTERMS_LAJOM.Models.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly pubsContext _context;

        public AuthorRepository(pubsContext context)
        {
            _context = context;
        }

        public async Task<Author> CreateAsync(Author Author)
        {
            _context.Authors.Add(Author);
            await _context.SaveChangesAsync();
            return Author;
        }

        public async Task<Author> UpdateAsync(Author Author)
        {
            _context.Authors.Update(Author);
            await _context.SaveChangesAsync();
            return Author;
        }

        public async Task<Author> GetByIdAsync(string id)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(p => p.AuId == id);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
