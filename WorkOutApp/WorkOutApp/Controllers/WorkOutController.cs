using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkOutApp.Models;

namespace WorkOutApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOutController : ControllerBase
    {
        private readonly WorkOutContext _context;

        public WorkOutController(WorkOutContext context)
        {
            _context = context;
        }

        // GET: api/WorkOut
        [HttpGet]
        public IEnumerable<WorkOut> GetWorkOut()
        {
            return _context.WorkOut;
        }

        // GET: api/WorkOut/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkOut([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workOut = await _context.WorkOut.FindAsync(id);

            if (workOut == null)
            {
                return NotFound();
            }

            return Ok(workOut);
        }

        // PUT: api/WorkOut/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkOut([FromRoute] int id, [FromBody] WorkOut workOut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workOut.Id)
            {
                return BadRequest();
            }

            _context.Entry(workOut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkOutExists(id))
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

        // POST: api/WorkOut
        [HttpPost]
        public async Task<IActionResult> PostWorkOut([FromBody] WorkOut workOut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.WorkOut.Add(workOut);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkOut", new { id = workOut.Id }, workOut);
        }

        // DELETE: api/WorkOut/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkOut([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workOut = await _context.WorkOut.FindAsync(id);
            if (workOut == null)
            {
                return NotFound();
            }

            _context.WorkOut.Remove(workOut);
            await _context.SaveChangesAsync();

            return Ok(workOut);
        }

        private bool WorkOutExists(int id)
        {
            return _context.WorkOut.Any(e => e.Id == id);
        }
    }
}