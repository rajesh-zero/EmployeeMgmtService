using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeMgmtService.Models;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeMgmtService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInfoController : ControllerBase
    {
        private readonly EmployeeMgmtContext _context;

        public EmployeeInfoController(EmployeeMgmtContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeInfo>>> GetEmployeeInfo()
        {
            return await _context.EmployeeInfo.ToListAsync();
        }

        // GET: api/EmployeeInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeInfo>> GetEmployeeInfo(int id)
        {
            var employeeInfo = await _context.EmployeeInfo.FindAsync(id);

            if (employeeInfo == null)
            {
                return NotFound();
            }

            return employeeInfo;
        }

        // PUT: api/EmployeeInfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeInfo(int id, EmployeeInfo employeeInfo)
        {
            if (id != employeeInfo.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeInfoExists(id))
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

        // POST: api/EmployeeInfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeInfo>> PostEmployeeInfo(EmployeeInfo employeeInfo)
        {
            _context.EmployeeInfo.Add(employeeInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeInfo", new { id = employeeInfo.EmployeeId }, employeeInfo);
        }

        // DELETE: api/EmployeeInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeInfo>> DeleteEmployeeInfo(int id)
        {
            var employeeInfo = await _context.EmployeeInfo.FindAsync(id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            _context.EmployeeInfo.Remove(employeeInfo);
            await _context.SaveChangesAsync();

            return employeeInfo;
        }

        private bool EmployeeInfoExists(int id)
        {
            return _context.EmployeeInfo.Any(e => e.EmployeeId == id);
        }
    }
}
