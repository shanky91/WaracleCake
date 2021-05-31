using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaracleCake.Data;
using WaracleCake.Models;
using WaracleCake.Models.RequestDto;

namespace WaracleCake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
        private readonly WaracleCakeContext _context;

        public CakesController(WaracleCakeContext context)
        {
            _context = context;
        }

        // GET: api/Cakes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cake>>> GetCake()
        {
            return await _context.Cake.ToListAsync();
        }

        // GET: api/Cakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cake>> GetCake(int id)
        {
            var cake = await _context.Cake.FindAsync(id);

            if (cake == null)
            {
                return NotFound();
            }

            return cake;
        }

        // PUT: api/Cakes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCake(int id, Cake cake)
        {
            if (id != cake.Id)
            {
                return BadRequest();
            }

            _context.Entry(cake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CakeExists(id))
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

        // POST: api/Cakes
        [HttpPost]
        public async Task<ActionResult<Cake>> PostCake(CakeDto cakeDto)
        {

            if (_context.Cake.Any(x => x.Name.ToUpper() == cakeDto.Name.ToUpper()))
            {
                return Conflict(new { message = $"An existing record with the name '{cakeDto.Name}' already exists." });
            }

            var cake = new Cake
            {
                Name = cakeDto.Name,
                Comment = cakeDto.Comment,
                YumFactor = cakeDto.YumFactor,
                ImageUrl = cakeDto.ImageUrl
            };
            _context.Cake.Add(cake);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCake", new { id = cake.Id }, cake);
        }

        // DELETE: api/Cakes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cake>> DeleteCake(int id)
        {
            var cake = await _context.Cake.FindAsync(id);
            if (cake == null)
            {
                return NotFound();
            }

            _context.Cake.Remove(cake);
            await _context.SaveChangesAsync();

            return cake;
        }

        private bool CakeExists(int id)
        {
            return _context.Cake.Any(e => e.Id == id);
        }
    }
}
