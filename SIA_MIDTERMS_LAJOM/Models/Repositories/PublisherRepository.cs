using Microsoft.EntityFrameworkCore;

namespace SIA_MIDTERMS_LAJOM.Models.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly pubsContext _context;

        public PublisherRepository(pubsContext context)
        {
            _context = context;
        }

        public async Task<Publisher> CreateAsync(Publisher Publisher)
        {
            _context.Publishers.Add(Publisher);
            await _context.SaveChangesAsync();
            return Publisher;
        }

        public async Task<Publisher> UpdateAsync(Publisher Publisher)
        {
            _context.Publishers.Update(Publisher);
            await _context.SaveChangesAsync();
            return Publisher;
        }

        public async Task<Publisher> GetByIdAsync(string id)
        {
            return await _context.Publishers
                .FirstOrDefaultAsync(p => p.PubId == id);
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var Publisher = await _context.Publishers.FindAsync(id);
            if (Publisher == null) return false;

            _context.Publishers.Remove(Publisher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
