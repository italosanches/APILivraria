using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APILivraria.Models
{
	[Table("Autores")]
	public class Autor
	{
        [Key]
		[JsonPropertyName("ID")]
		public int AutorId { get; set; }

        [Required]
        [MaxLength(100)]
		[JsonPropertyName("Nome")]
		public string? AutorNome { get; set; }

		[JsonIgnore]
		public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
