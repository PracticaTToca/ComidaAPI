using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HamburguesasAPI.Data;
using HamburguesasAPI.Models;

namespace HamburguesasAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HamburguesasController : ControllerBase
{
    private readonly AppDbContext _context;

    public HamburguesasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/hamburguesas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Hamburguesa>>> GetHamburguesas()
    {
        return await _context.Hamburguesas.AsNoTracking().ToListAsync();
    }

    // GET: api/hamburguesas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Hamburguesa>> GetHamburguesa(int id)
    {
        var h = await _context.Hamburguesas.FindAsync(id);
        return h == null ? NotFound() : h;
    }

    // POST: api/hamburguesas
    [HttpPost]
    public async Task<ActionResult<Hamburguesa>> PostHamburguesa(Hamburguesa h)
    {
        _context.Hamburguesas.Add(h);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetHamburguesa), new { id = h.Id }, h);
    }

    // PUT: api/hamburguesas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHamburguesa(int id, Hamburguesa h)
    {
        if (id != h.Id) return BadRequest();

        _context.Entry(h).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Hamburguesas.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // DELETE: api/hamburguesas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHamburguesa(int id)
    {
        var h = await _context.Hamburguesas.FindAsync(id);
        if (h == null) return NotFound();

        _context.Hamburguesas.Remove(h);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
