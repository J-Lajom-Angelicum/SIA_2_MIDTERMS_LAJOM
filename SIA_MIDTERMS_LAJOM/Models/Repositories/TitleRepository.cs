using Microsoft.EntityFrameworkCore;

namespace SIA_MIDTERMS_LAJOM.Models.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly pubsContext _context;

        public TitleRepository(pubsContext context)
        {
            _context = context;
        }

        public async Task<Title> CreateAsync(Title Title)
        {
            _context.Titles.Add(Title);
            await _context.SaveChangesAsync();
            return Title;
        }

        public async Task<Title> UpdateAsync(Title Title)
        {
            _context.Titles.Update(Title);
            await _context.SaveChangesAsync();
            return Title;
        }

        public async Task<Title> GetByIdAsync(string id)
        {
            return await _context.Titles
                .FirstOrDefaultAsync(p => p.TitleId == id);
        }

        public async Task<IEnumerable<Title>> GetAllAsync()
        {
            return await _context.Titles.ToListAsync();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var Title = await _context.Titles.FindAsync(id);
            if (Title == null) return false;

            _context.Titles.Remove(Title);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
