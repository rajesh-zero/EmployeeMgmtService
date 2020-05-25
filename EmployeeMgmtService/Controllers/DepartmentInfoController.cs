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
    public class DepartmentInfoController : ControllerBase
    {
        private readonly EmployeeMgmtContext _context;

        public DepartmentInfoController(EmployeeMgmtContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentInfo>>> GetDepartmentInfo()
        {
            return await _context.DepartmentInfo.ToListAsync();
        }

        // GET: api/DepartmentInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentInfo>> GetDepartmentInfo(int id)
        {
            var departmentInfo = await _context.DepartmentInfo.FindAsync(id);

            if (departmentInfo == null)
            {
                return NotFound();
            }

            return departmentInfo;
        }

        // PUT: api/DepartmentInfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentInfo(int id, DepartmentInfo departmentInfo)
        {
            if (id != departmentInfo.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(departmentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentInfoExists(id))
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

        // POST: api/DepartmentInfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DepartmentInfo>> PostDepartmentInfo(DepartmentInfo departmentInfo)
        {
            _context.DepartmentInfo.Add(departmentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentInfo", new { id = departmentInfo.DepartmentId }, departmentInfo);
        }

        // DELETE: api/DepartmentInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DepartmentInfo>> DeleteDepartmentInfo(int id)
        {
            var departmentInfo = await _context.DepartmentInfo.FindAsync(id);
            if (departmentInfo == null)
            {
                return NotFound();
            }

            _context.DepartmentInfo.Remove(departmentInfo);
            await _context.SaveChangesAsync();

            return departmentInfo;
        }

        private bool DepartmentInfoExists(int id)
        {
            return _context.DepartmentInfo.Any(e => e.DepartmentId == id);
        }
    }
}
