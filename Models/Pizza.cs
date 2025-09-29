namespace ComidaAPI.Models;

public class Pizza
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    // Precio en la moneda que uses (mejor decimal para dinero)
    public decimal Precio { get; set; }

    public string? Descripcion { get; set; }

    public bool EsVegetariana { get; set; }
}