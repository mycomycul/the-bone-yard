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
    public class ConditionsController : ControllerBase
    {
        private readonly MyTrailsContext _context;

        public ConditionsController(MyTrailsContext context)
        {
            _context = context;
        }

        // GET: api/Conditions
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<String>>> GetConditions()
        //{
        //    return false; /*_context.Conditions.ToListAsync();*/
        //}


        //GET: api/Conditions/Trail/
        [HttpGet("/Trail/{id}")]
        public async Task<ActionResult<Conditions>> GetConditions(string id)
        {
            //By Name
            var conditions = await _context.Conditions.FirstOrDefaultAsync(t => t.Trail.TrailName == id);

            if (conditions == null)
            {
                conditions = await _context.Conditions.FirstOrDefaultAsync(t => t.Trail.Id == id);
            }
            if (conditions == null)
            {
                return NotFound();
            }

            return conditions;
        }


        // PUT: api/Conditions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConditions(string id, Conditions conditions)
        {
            if (id != conditions.Id)
            {
                return BadRequest();
            }

            _context.Entry(conditions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConditionsExists(id))
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

        // POST: api/Conditions
        [HttpPost]
        public async Task<ActionResult<Conditions>> PostConditions(Conditions conditions)
        {
            _context.Conditions.Add(conditions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConditionsExists(conditions.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConditions", new { id = conditions.Id }, conditions);
        }

        // DELETE: api/Conditions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Conditions>> DeleteConditions(string id)
        {
            var conditions = await _context.Conditions.FindAsync(id);
            if (conditions == null)
            {
                return NotFound();
            }

            _context.Conditions.Remove(conditions);
            await _context.SaveChangesAsync();

            return conditions;
        }

        private bool ConditionsExists(string id)
        {
            return _context.Conditions.Any(e => e.Id == id);
        }
    }
}
