using SIA_MIDTERMS_LAJOM.Models.DTO.PublisherDTO;

namespace SIA_MIDTERMS_LAJOM.Models.Repositories
{
    public interface IPublisherRepository
    {
        Task<Publisher> CreateAsync(Publisher Publisher);
        Task<Publisher> UpdateAsync(Publisher Publisher);
        Task<Publisher> GetByIdAsync(int id);
        Task<IEnumerable<Publisher>> GetAllAsync();
        Task<bool> DeleteAsync(int id); // optional if you want hard/soft delete
    }
}
