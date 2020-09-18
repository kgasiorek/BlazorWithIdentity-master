using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithIdentity.Server.Data;
using BlazorWithIdentity.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWithIdentity.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatesEpcController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlatesEpcController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlateEpcRequest>>> GetPlateEpc()
        {
            return await _context.PlateEpc.ToListAsync();
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlateEpcRequest>> GetPlateEpc(int id)
        {
            var plateEpc = await _context.PlateEpc.FindAsync(id);

            if (plateEpc == null)
            {
                return NotFound();
            }

            return plateEpc;
        }

        // PUT: api/Plans/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlateEpc(int id, PlateEpcRequest plateEpc)
        {
            if (id != plateEpc.Id)
            {
                return BadRequest();
            }

            _context.Entry(plateEpc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlateEpc(id))
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

        // POST: api/Plans
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PlateEpcRequest>> PostPlateEpc(PlateEpcRequest plateEpc)
        {
            _context.PlateEpc.Add(plateEpc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlateEpc", new { id = plateEpc.Id }, plateEpc);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlateEpcRequest>> DeletePlateEpc(int id)
        {
            var plateEpc = await _context.PlateEpc.FindAsync(id);
            if (plateEpc == null)
            {
                return NotFound();
            }

            _context.PlateEpc.Remove(plateEpc);
            await _context.SaveChangesAsync();

            return plateEpc;
        }

        private bool PlateEpc(int id)
        {
            return _context.PlateEpc.Any(e => e.Id == id);
        }
    }
}
