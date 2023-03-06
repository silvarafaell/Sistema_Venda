using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Domain.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? CPF { get; set; }

        public string? Email { get; set; }
    }
}
