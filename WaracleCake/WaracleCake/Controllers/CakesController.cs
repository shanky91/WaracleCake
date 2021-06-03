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
using WaracleCake.Services;

namespace WaracleCake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
        private readonly ICakeService _cakeService;

        public CakesController(ICakeService cakeService)
        {
            _cakeService = cakeService;
        }

        // GET: api/Cakes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cake>>> GetCake()
        {
            return Ok(await _cakeService.GetCakeAsync());
        }

        // GET: api/Cakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cake>> GetCake(int id)
        {
            var cake = await _cakeService.GetCakeAsync(id);

            if (cake == null)
            {
                return NotFound();
            }

            return Ok(cake);
        }

        // PUT: api/Cakes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCake(int id, Cake cake)
        {
            if (id != cake.Id)
            {
                return BadRequest();
            }
            if (!_cakeService.CakeExists(id))
            {
                return NotFound();
            }

            await _cakeService.UpdateCakeAsync(cake);

            return NoContent();
        }

        // POST: api/Cakes
        [HttpPost]
        public async Task<ActionResult<Cake>> PostCake(CakeDto cakeDto)
        {

            if (_cakeService.CakeExists(cakeDto.Name))
            {
                return Conflict(new { message = $"An existing record with the name '{cakeDto.Name}' already exists." });
            }

            var cake = new Cake  // This could be achieved using a mapper or factory etc... but overkill for this task
            {
                Name = cakeDto.Name,
                Comment = cakeDto.Comment,
                YumFactor = cakeDto.YumFactor,
                ImageUrl = cakeDto.ImageUrl
            };

            await _cakeService.SaveCakeAsync(cake);

            return CreatedAtAction("GetCake", new { id = cake.Id }, cake);
        }

        // DELETE: api/Cakes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cake>> DeleteCake(int id)
        {
            var cake = await _cakeService.GetCakeAsync(id);
            if (cake == null)
            {
                return NotFound();
            }

            await _cakeService.DeleteCakeAsync(cake);
            return NoContent();
        }
    }
}
