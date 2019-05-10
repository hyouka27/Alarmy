using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlarmOS.Models;

namespace AlarmOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly AlarmOSContext _context;

        public APIController(AlarmOSContext context)
        {
            _context = context;
        }

        // GET: api/API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alarmy>>> GetAlarmy()
        {
            return await _context.Alarmy.ToListAsync();
        }

        // GET: api/API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alarmy>> GetAlarmy(int id)
        {
            var alarmy = await _context.Alarmy.FindAsync(id);

            if (alarmy == null)
            {
                return NotFound();
            }

            return alarmy;
        }

        // PUT: api/API/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlarmy(int id, Alarmy alarmy)
        {
            if (id != alarmy.Id)
            {
                return BadRequest();
            }

            _context.Entry(alarmy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlarmyExists(id))
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

        // POST: api/API
        [HttpPost]
        public async Task<ActionResult<Alarmy>> PostAlarmy(Alarmy alarmy)
        {
            _context.Alarmy.Add(alarmy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlarmy", new { id = alarmy.Id }, alarmy);
        }

        // DELETE: api/API/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Alarmy>> DeleteAlarmy(int id)
        {
            var alarmy = await _context.Alarmy.FindAsync(id);
            if (alarmy == null)
            {
                return NotFound();
            }

            _context.Alarmy.Remove(alarmy);
            await _context.SaveChangesAsync();

            return alarmy;
        }

        private bool AlarmyExists(int id)
        {
            return _context.Alarmy.Any(e => e.Id == id);
        }
    }
}
