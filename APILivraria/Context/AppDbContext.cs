using APILivraria.Models;
using Microsoft.EntityFrameworkCore;

namespace APILivraria.Context
{
	public class AppDbContext : DbContext
	{
		
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		public DbSet<Autor> Autores { get; set; }
		public DbSet<Livro> Livros { get; set; }
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
