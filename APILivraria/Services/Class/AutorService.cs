using APILivraria.Models;
using APILivraria.Repository;
using APILivraria.Services.Interfaces;

namespace APILivraria.Services.Class
{
	public class AutorService : IAutorService
	{
		private readonly IAutorRepository _repository;

		public AutorService(IAutorRepository repository)
		{
			_repository = repository;
		}

		public Task<int> CreateAsync(Autor autor)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Autor> GetAutorByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Autor>> GetAutoresAsync()
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAsync(Autor autor, int id)
		{
			throw new NotImplementedException();
		}
	}
}
