
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVenda.Domain.Models
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string? Email { get; set; }

        [Column]
        public string Password { get; set; }
    }
}
