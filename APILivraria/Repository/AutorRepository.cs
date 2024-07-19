﻿using APILivraria.Context;
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

		public async Task<IEnumerable<Autor>> GetAutoresASync()
		{
            try
            {
                return await _context.Autores.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                //return Enumerable.Empty<Autor>();
                throw new Exception($"Erro interno do servidor: .{ex.Message}");

            }
        }
		

		public async Task<Autor> GetAutorById(int id)
		{
			try
			{
                var autor = await _context.Autores.AsNoTracking().FirstOrDefaultAsync(p => p.AutorId == id);
                return autor;
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Erro ao pesquisar o autor no banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro interno do servidor: .{ex.Message}");


            }
        }

        public async Task<int> CreateAsync(Autor autor)
        {
            try
            {
                if (autor != null)
                {
                   await _context.Autores.AddAsync(autor);
                   await _context.SaveChangesAsync();

                    return autor.AutorId;
                }
                return -1;
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException($"Erro ao criar o autor no banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro interno do servidor: {ex.Message}");

            }
        }


        public async Task<bool> UpdateAsync(Autor autor, int id)
		{
			try
			{
				if (id == autor.AutorId)
				{
					var autorVerificado = await _context.Autores.FirstOrDefaultAsync(x => x.AutorId.Equals(id));
                    if (autorVerificado !=null)
					{
                        _context.Entry(autorVerificado).CurrentValues.SetValues(autor);
                        await _context.SaveChangesAsync();
                        return true;
                    }
				}
				return false;
			}
			catch (DbUpdateException ex)
			{

				throw new DbUpdateException($"Erro ao atualizar o cadastro.{ex.Message}");
			}
			catch (Exception ex)
			{
                throw new Exception($"Erro interno do servidor: {ex.Message}");
            }
        }
		public async Task<bool> DeleteAsync(int id)
		{

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(x=> x.AutorId == id);
                if (autor == null)
                {
                    return false;
                }
                _context.Remove(autor);
                await _context.SaveChangesAsync();
                return true;
               
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Erro ao atualizar o cadastro.{ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro interno do servidor: {ex.Message}");
            }

        }

      
    }
}
