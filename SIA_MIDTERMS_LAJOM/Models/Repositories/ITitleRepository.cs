using SIA_MIDTERMS_LAJOM.Models.DTO.TitleDTO;

namespace SIA_MIDTERMS_LAJOM.Models.Repositories
{
    public interface ITitleRepository
    {
        Task<Title> CreateAsync(Title Title);
        Task<Title> UpdateAsync(Title Title);
        Task<Title> GetByIdAsync(int id);
        Task<IEnumerable<Title>> GetAllAsync();
        Task<bool> DeleteAsync(int id); // optional if you want hard/soft delete
    }
}
