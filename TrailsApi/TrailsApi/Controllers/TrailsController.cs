using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailsApi.Models;

namespace TrailsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly MyTrailsContext _context;

        public TrailsController(MyTrailsContext context)
        {
            _context = context;
        }

        // GET: api/Trails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trails>>> GetTrails()
        {
            return await _context.Trails.ToListAsync();
        }

        // GET: api/Trails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trails>> GetTrails(string id)
        {
            var trails = await _context.Trails.FindAsync(id);

            if (trails == null)
            {
                return NotFound();
            }

            return trails;
        }

        // PUT: api/Trails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrails(string id, Trails trails)
        {
            if (id != trails.Id)
            {
                return BadRequest();
            }

            _context.Entry(trails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrailsExists(id))
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

        // POST: api/Trails
        [HttpPost]
        public async Task<ActionResult<Trails>> PostTrails(Trails trails)
        {
            _context.Trails.Add(trails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrailsExists(trails.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrails", new { id = trails.Id }, trails);
        }

        // DELETE: api/Trails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trails>> DeleteTrails(string id)
        {
            var trails = await _context.Trails.FindAsync(id);
            if (trails == null)
            {
                return NotFound();
            }

            _context.Trails.Remove(trails);
            await _context.SaveChangesAsync();

            return trails;
        }

        private bool TrailsExists(string id)
        {
            return _context.Trails.Any(e => e.Id == id);
        }
    }
}
