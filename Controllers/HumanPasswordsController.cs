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
    public class HumanPasswordsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HumanPasswordsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/HumanPasswords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HumanPassword>>> GetHumanPasswords()
        {
            return await _context.HumanPasswords.ToListAsync();
        }

        // GET: api/HumanPasswords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HumanPassword>> GetHumanPassword(long id)
        {
            var humanPassword = await _context.HumanPasswords.FindAsync(id);

            if (humanPassword == null)
            {
                return NotFound();
            }

            return humanPassword;
        }

        // PUT: api/HumanPasswords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHumanPassword(long id, HumanPassword humanPassword)
        {
            if (id != humanPassword.Id)
            {
                return BadRequest();
            }

            _context.Entry(humanPassword).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumanPasswordExists(id))
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

        // POST: api/HumanPasswords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HumanPassword>> PostHumanPassword(HumanPassword humanPassword)
        {
            _context.HumanPasswords.Add(humanPassword);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHumanPassword", new { id = humanPassword.Id }, humanPassword);
        }

        // DELETE: api/HumanPasswords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HumanPassword>> DeleteHumanPassword(long id)
        {
            var humanPassword = await _context.HumanPasswords.FindAsync(id);
            if (humanPassword == null)
            {
                return NotFound();
            }

            _context.HumanPasswords.Remove(humanPassword);
            await _context.SaveChangesAsync();

            return humanPassword;
        }

        private bool HumanPasswordExists(long id)
        {
            return _context.HumanPasswords.Any(e => e.Id == id);
        }
    }
}
