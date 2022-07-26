using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetroStoreAPI.Models;

namespace RetroStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblProductsPurchasedsController : ControllerBase
    {
        private readonly RetroStoreDBContext _context;

        public TblProductsPurchasedsController(RetroStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/TblProductsPurchaseds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProductsPurchased>>> GetTblProductsPurchaseds()
        {
          if (_context.TblProductsPurchaseds == null)
          {
              return NotFound();
          }
            return await _context.TblProductsPurchaseds.ToListAsync();
        }

        // GET: api/TblProductsPurchaseds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProductsPurchased>> GetTblProductsPurchased(int id)
        {
          if (_context.TblProductsPurchaseds == null)
          {
              return NotFound();
          }
            var tblProductsPurchased = await _context.TblProductsPurchaseds.FindAsync(id);

            if (tblProductsPurchased == null)
            {
                return NotFound();
            }

            return tblProductsPurchased;
        }

        // PUT: api/TblProductsPurchaseds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProductsPurchased(int id, TblProductsPurchased tblProductsPurchased)
        {
            if (id != tblProductsPurchased.OrderNo)
            {
                return BadRequest();
            }

            _context.Entry(tblProductsPurchased).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductsPurchasedExists(id))
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

        // POST: api/TblProductsPurchaseds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProductsPurchased>> PostTblProductsPurchased(TblProductsPurchased tblProductsPurchased)
        {
          if (_context.TblProductsPurchaseds == null)
          {
              return Problem("Entity set 'RetroStoreDBContext.TblProductsPurchaseds'  is null.");
          }
            _context.TblProductsPurchaseds.Add(tblProductsPurchased);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblProductsPurchasedExists(tblProductsPurchased.OrderNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblProductsPurchased", new { id = tblProductsPurchased.OrderNo }, tblProductsPurchased);
        }

        // DELETE: api/TblProductsPurchaseds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProductsPurchased(int id)
        {
            if (_context.TblProductsPurchaseds == null)
            {
                return NotFound();
            }
            var tblProductsPurchased = await _context.TblProductsPurchaseds.FindAsync(id);
            if (tblProductsPurchased == null)
            {
                return NotFound();
            }

            _context.TblProductsPurchaseds.Remove(tblProductsPurchased);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProductsPurchasedExists(int id)
        {
            return (_context.TblProductsPurchaseds?.Any(e => e.OrderNo == id)).GetValueOrDefault();
        }
    }
}
