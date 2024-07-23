using APILivraria.Models;

namespace APILivraria.Services.Interfaces
{
    public interface IAutorService
    {
        Task<IEnumerable<Autor>> GetAutoresAsync();
        Task<Autor> GetAutorByIdAsync(int id);
        Task<int> CreateAsync(Autor autor);
        Task<bool> UpdateAsync(Autor autor, int id);
        Task<bool> DeleteAsync(int id);
    }
}
