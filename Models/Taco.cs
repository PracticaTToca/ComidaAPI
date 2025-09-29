using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComidaAPI.Models
{
    [Table("tacos")]
    public class Taco
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = null!;

        [Required]
        [Range(0.01, 1000.00)]
        public decimal Precio { get; set; }

        [Required, StringLength(50)]
        public string Tamaño { get; set; } = null!;
    }
}