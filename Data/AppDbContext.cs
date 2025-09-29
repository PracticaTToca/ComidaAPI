using Microsoft.EntityFrameworkCore;
using HamburguesasAPI.Models;

namespace HamburguesasAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Hamburguesa> Hamburguesas { get; set; }
}