using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorWithIdentity.Server.Data;
using BlazorWithIdentity.Shared;
using Microsoft.AspNetCore.Authorization;

namespace BlazorWithIdentity.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanRequest>>> GetWeightingPlans()
        {
            return await _context.WeightingPlans.ToListAsync();
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanRequest>> GetWeightingPlan(int id)
        {
            var weightingPlan = await _context.WeightingPlans.FindAsync(id);

            if (weightingPlan == null)
            {
                return NotFound();
            }

            return weightingPlan;
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<PlanRequest>>> GetWeightingPlanByDate(DateTime date)
        {
            return await _context.WeightingPlans.Where(s => s.Date == date).ToListAsync();
        }

        // PUT: api/Plans/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeightingPlan(int id, PlanRequest weightingPlan)
        {
            if (id != weightingPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(weightingPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeightingPlanExists(id))
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
        public async Task<ActionResult<PlanRequest>> PostWeightingPlan(PlanRequest weightingPlan)
        {
            _context.WeightingPlans.Add(weightingPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeightingPlan", new { id = weightingPlan.Id }, weightingPlan);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanRequest>> DeleteWeightingPlan(int id)
        {
            var weightingPlan = await _context.WeightingPlans.FindAsync(id);
            if (weightingPlan == null)
            {
                return NotFound();
            }

            _context.WeightingPlans.Remove(weightingPlan);
            await _context.SaveChangesAsync();

            return weightingPlan;
        }

        private bool WeightingPlanExists(int id)
        {
            return _context.WeightingPlans.Any(e => e.Id == id);
        }
    }
}
