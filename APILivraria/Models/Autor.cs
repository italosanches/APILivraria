using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILivraria.Models
{
	[Table("Autores")]
	public class Autor
	{
        [Key]
        public int AutorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string? AutorNome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
