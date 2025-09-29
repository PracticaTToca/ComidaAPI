using System.ComponentModel.DataAnnotations;

namespace ComidaAPI.Models;

public class Sushi
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = null!;

    [Range(0, double.MaxValue)]
    public decimal Precio { get; set; }

    [Required]
    public string Tamano { get; set; } = null!; // Pequeño | Mediano | Grande
}