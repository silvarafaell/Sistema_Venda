using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Domain.Models
{
    [Table("Produto")]
    public class Produto : BaseEntity
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        public string? Name { get; set; }

        [Column]
        public string? Description { get; set; }

        [Required]
        [Column]
        public decimal Price { get; set; }

        [Required]
        [Column]
        public int Stock { get; set; }

        [Column]
        public bool? Reserved { get; set; }

    }
}
