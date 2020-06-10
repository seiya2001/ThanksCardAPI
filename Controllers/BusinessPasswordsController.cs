using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPasswordsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BusinessPasswordsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/BusinessPasswords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessPassword>>> GetBusinessPasswords()
        {
            return await _context.BusinessPasswords.ToListAsync();
        }

        // GET: api/BusinessPasswords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessPassword>> GetBusinessPassword(long id)
        {
            var businessPassword = await _context.BusinessPasswords.FindAsync(id);

            if (businessPassword == null)
            {
                return NotFound();
            }

            return businessPassword;
        }

        // PUT: api/BusinessPasswords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessPassword(long id, BusinessPassword businessPassword)
        {
            if (id != businessPassword.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessPassword).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessPasswordExists(id))
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

        // POST: api/BusinessPasswords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessPassword>> PostBusinessPassword(BusinessPassword businessPassword)
        {
            _context.BusinessPasswords.Add(businessPassword);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessPassword", new { id = businessPassword.Id }, businessPassword);
        }

        // DELETE: api/BusinessPasswords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessPassword>> DeleteBusinessPassword(long id)
        {
            var businessPassword = await _context.BusinessPasswords.FindAsync(id);
            if (businessPassword == null)
            {
                return NotFound();
            }

            _context.BusinessPasswords.Remove(businessPassword);
            await _context.SaveChangesAsync();

            return businessPassword;
        }

        private bool BusinessPasswordExists(long id)
        {
            return _context.BusinessPasswords.Any(e => e.Id == id);
        }
    }
}
