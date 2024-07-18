using APILivraria.Models;

namespace APILivraria.Repository
{
	public interface IAutorRepository
	{
		IEnumerable<Autor> Autores { get; }
		public Task<Autor> GetAutorById(int id);

		public int Create(Autor autor);
		public bool Update(Autor autor, int id);
		public bool Delete(int id);

	}
}
