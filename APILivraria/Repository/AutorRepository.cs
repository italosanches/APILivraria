using APILivraria.Context;
using APILivraria.Models;
using Microsoft.EntityFrameworkCore;

namespace APILivraria.Repository
{
	public class AutorRepository : IAutorRepository
	{
		private readonly AppDbContext _context;

		public AutorRepository(AppDbContext context)
		{
			_context = context;

		}
		public IEnumerable<Autor> Autores => _context.Autores.AsNoTracking().ToList();
		public int Create(Autor autor)
		{
			try
			{
				if (autor != null)
				{
					_context.Autores.Add(autor);
					_context.SaveChanges();

					return autor.AutorId;
				}
				return -1;
			}
			catch (DbUpdateException ex)
			{

				throw new DbUpdateException("Erro ao criar o autor no banco" + ex.Message);
			}
			catch (Exception ex)
			{
				throw new Exception("Erro interno no servidor. " + ex.Message);
			}
		}



		public async Task<Autor> GetAutorById(int id)
		{
			var list = await _context.Autores.AsNoTracking().FirstOrDefaultAsync(p => p.AutorId == id);
			return list;
		}


		public bool Update(Autor autor, int id)
		{
			try
			{
				if (id == autor.AutorId)
				{
					_context.Entry(autor).State = EntityState.Modified;
					_context.SaveChanges();
					return true;
				}
				return false;
			}
			catch (DbUpdateException ex)
			{

				throw new DbUpdateException("Erro ao atualizar o cadastro." + ex);
			}
			catch (Exception ex)
			{

				throw new Exception("Erro interno do servidor"+ ex);
			}
		}
		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
