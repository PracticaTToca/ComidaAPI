using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComidaAPI.Data;
using ComidaAPI.Models;

namespace ComidaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SushisController : ControllerBase
{
    private readonly AppDbContext _context;

    public SushisController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/sushis
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sushi>>> GetSushis()
        => await _context.Sushis.AsNoTracking().ToListAsync();

    // GET: api/sushis/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Sushi>> GetSushi(int id)
    {
        var sushi = await _context.Sushis.FindAsync(id);
        if (sushi == null) return NotFound();
        return sushi;
    }

    // POST: api/sushis
    [HttpPost]
    public async Task<ActionResult<Sushi>> PostSushi(Sushi sushi)
    {
        _context.Sushis.Add(sushi);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSushi), new { id = sushi.Id }, sushi);
    }

    // PUT: api/sushis/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutSushi(int id, Sushi sushi)
    {
        if (id != sushi.Id) return BadRequest();
        _context.Entry(sushi).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Sushis.Any(s => s.Id == id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/sushis/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSushi(int id)
    {
        var sushi = await _context.Sushis.FindAsync(id);
        if (sushi == null) return NotFound();

        _context.Sushis.Remove(sushi);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}