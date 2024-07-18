using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILivraria.Models
{
	[Table("Livros")]
	public class Livro
	{
		[Key]
        public int		 LivroId      { get; set; }

		[Required]
		[MaxLength(100)]
        public string? LivroNome      { get; set; }

		[MaxLength(500)]
        public string? LivroDescricao { get; set; }
		[Range(0,999)]
		public int LivroQtdPaginas {  get; set; }

		[ForeignKey(nameof(Autor.AutorId))]
		public int AutorId            { get; set; }
        public virtual Autor? Autor   { get; set; }
    }
}
