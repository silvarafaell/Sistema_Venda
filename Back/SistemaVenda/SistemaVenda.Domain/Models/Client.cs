using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SistemaVenda.Domain.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? CPF { get; set; }

        public string? Email { get; set; }

        //[ForeignKey("ClienteId")]
        //public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
