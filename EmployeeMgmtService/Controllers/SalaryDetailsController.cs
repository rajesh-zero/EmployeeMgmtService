using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeMgmtService.Models;

namespace EmployeeMgmtService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryDetailsController : ControllerBase
    {
        private readonly EmployeeMgmtContext _context;

        public SalaryDetailsController(EmployeeMgmtContext context)
        {
            _context = context;
        }

        // GET: api/SalaryDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryDetails>>> GetSalaryDetails()
        {
            return await _context.SalaryDetails.ToListAsync();
        }

        // GET: api/SalaryDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryDetails>> GetSalaryDetails(int id)
        {
            var salaryDetails = await _context.SalaryDetails.FindAsync(id);

            if (salaryDetails == null)
            {
                return NotFound();
            }

            return salaryDetails;
        }

        // PUT: api/SalaryDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryDetails(int id, SalaryDetails salaryDetails)
        {
            if (id != salaryDetails.SalaryId)
            {
                return BadRequest();
            }

            _context.Entry(salaryDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryDetailsExists(id))
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

        // POST: api/SalaryDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SalaryDetails>> PostSalaryDetails(SalaryDetails salaryDetails)
        {
            _context.SalaryDetails.Add(salaryDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalaryDetails", new { id = salaryDetails.SalaryId }, salaryDetails);
        }

        // DELETE: api/SalaryDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalaryDetails>> DeleteSalaryDetails(int id)
        {
            var salaryDetails = await _context.SalaryDetails.FindAsync(id);
            if (salaryDetails == null)
            {
                return NotFound();
            }

            _context.SalaryDetails.Remove(salaryDetails);
            await _context.SaveChangesAsync();

            return salaryDetails;
        }

        private bool SalaryDetailsExists(int id)
        {
            return _context.SalaryDetails.Any(e => e.SalaryId == id);
        }
    }
}
