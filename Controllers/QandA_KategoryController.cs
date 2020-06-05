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
    public class QandA_KategoryController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public QandA_KategoryController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/QandA_Kategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QandA_Kategory>>> GetQandA_Kategorys()
        {
            return await _context.QandA_Kategorys.ToListAsync();
        }

        // GET: api/QandA_Kategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QandA_Kategory>> GetQandA_Kategory(long id)
        {
            var qandA_Kategory = await _context.QandA_Kategorys.FindAsync(id);

            if (qandA_Kategory == null)
            {
                return NotFound();
            }

            return qandA_Kategory;
        }

        // PUT: api/QandA_Kategory/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQandA_Kategory(long id, QandA_Kategory qandA_Kategory)
        {
            if (id != qandA_Kategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(qandA_Kategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QandA_KategoryExists(id))
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

        // POST: api/QandA_Kategory
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QandA_Kategory>> PostQandA_Kategory(QandA_Kategory qandA_Kategory)
        {
            _context.QandA_Kategorys.Add(qandA_Kategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQandA_Kategory", new { id = qandA_Kategory.Id }, qandA_Kategory);
        }

        // DELETE: api/QandA_Kategory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QandA_Kategory>> DeleteQandA_Kategory(long id)
        {
            var qandA_Kategory = await _context.QandA_Kategorys.FindAsync(id);
            if (qandA_Kategory == null)
            {
                return NotFound();
            }

            _context.QandA_Kategorys.Remove(qandA_Kategory);
            await _context.SaveChangesAsync();

            return qandA_Kategory;
        }

        private bool QandA_KategoryExists(long id)
        {
            return _context.QandA_Kategorys.Any(e => e.Id == id);
        }
    }
}
