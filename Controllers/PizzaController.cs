using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComidaAPI.Data;
using ComidaAPI.Models;

namespace PizzasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private readonly AppDbContext _context;

    public PizzasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/pizzas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas()
    {
        return await _context.Pizzas.AsNoTracking().ToListAsync();
    }

    // GET: api/pizzas/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Pizza>> GetPizza(int id)
    {
        var p = await _context.Pizzas.FindAsync(id);
        return p is null ? NotFound() : p;
    }

    // POST: api/pizzas
    [HttpPost]
    public async Task<ActionResult<Pizza>> PostPizza(Pizza p)
    {
        _context.Pizzas.Add(p);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPizza), new { id = p.Id }, p);
    }

    // PUT: api/pizzas/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutPizza(int id, Pizza p)
    {
        if (id != p.Id) return BadRequest("El id de la ruta no coincide con el cuerpo.");

        _context.Entry(p).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var exists = await _context.Pizzas.AnyAsync(e => e.Id == id);
            if (!exists) return NotFound();
            throw; // si fue otra causa de concurrencia
        }

        return NoContent();
    }

    // DELETE: api/pizzas/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePizza(int id)
    {
        var p = await _context.Pizzas.FindAsync(id);
        if (p is null) return NotFound();

        _context.Pizzas.Remove(p);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}