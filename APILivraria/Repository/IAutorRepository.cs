using APILivraria.Models;

namespace APILivraria.Repository
{
	public interface IAutorRepository
	{
		//IEnumerable<Autor> Autores { get; }
		public Task<IEnumerable<Autor>> GetAutoresASync();

        public Task<Autor> GetAutorById(int id);

		public Task<int> CreateAsync(Autor autor);
		public Task<bool> UpdateAsync(Autor autor, int id);


		public Task<bool> DeleteAsync(int id);

	}
}
