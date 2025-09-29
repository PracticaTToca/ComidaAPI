using Microsoft.EntityFrameworkCore;
using ComidaAPI.Models;
namespace ComidaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Hamburguesa> Hamburguesas { get; set; } = null!;
        public DbSet<Taco> Tacos { get; set; } = null!;
    }
}