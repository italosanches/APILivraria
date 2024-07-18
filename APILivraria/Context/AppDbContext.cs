using APILivraria.Models;
using Microsoft.EntityFrameworkCore;

namespace APILivraria.Context
{
	public class AppDbContext : DbContext
	{
		DbSet<Autor> Autores { get; set; }
		DbSet<Livro> Livros { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Autor>()
				.HasMany(a => a.Livros)
				.WithOne(b => b.Autor)
				.HasForeignKey(b => b.AutorId);

	

			base.OnModelCreating(modelBuilder);
		}
	}
}
