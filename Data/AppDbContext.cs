using Microsoft.EntityFrameworkCore;
using ComidaAPI.Models;

namespace ComidaAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Hamburguesa> Hamburguesas { get; set; }
    public DbSet<Sushi> Sushis { get; set; }  
}