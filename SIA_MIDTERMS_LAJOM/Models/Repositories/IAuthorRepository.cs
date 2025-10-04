using SIA_MIDTERMS_LAJOM.Models.DTO.AuthorDTO;

namespace SIA_MIDTERMS_LAJOM.Models.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> CreateAsync(Author Author);
        Task<Author> UpdateAsync(Author Author);
        Task<Author> GetByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAsync();
        Task<bool> DeleteAsync(int id); // optional if you want hard/soft delete
    }
}
