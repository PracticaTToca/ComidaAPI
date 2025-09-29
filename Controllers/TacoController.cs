using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComidaAPI.Data;
using ComidaAPI.Models;

namespace ComidaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TacoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Taco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taco>>> GetTacos()
        {
            return await _context.Tacos.ToListAsync();
        }

        // GET: api/Taco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taco>> GetTaco(int id)
        {
            var taco = await _context.Tacos.FindAsync(id);

            if (taco == null)
            {
                return NotFound();
            }

            return taco;
        }

        // POST: api/Taco
        [HttpPost]
        public async Task<ActionResult<Taco>> PostTaco(Taco taco)
        {
            _context.Tacos.Add(taco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaco), new { id = taco.Id }, taco);
        }

        // PUT: api/Taco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaco(int id, Taco taco)
        {
            if (id != taco.Id)
            {
                return BadRequest();
            }

            _context.Entry(taco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TacoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Taco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaco(int id)
        {
            var taco = await _context.Tacos.FindAsync(id);
            if (taco == null)
            {
                return NotFound();
            }

            _context.Tacos.Remove(taco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TacoExists(int id)
        {
            return _context.Tacos.Any(e => e.Id == id);
        }
    }
}