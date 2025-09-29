using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamburguesasAPI.Models;

public class Hamburguesa
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 999999)]
    public decimal Precio { get; set; }

    [Required, MaxLength(50)]
    public string Tamano { get; set; } = null!;
}