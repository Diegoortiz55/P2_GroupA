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
    public class TblProductCostListsController : ControllerBase
    {
        private readonly RetroStoreDBContext _context;

        public TblProductCostListsController(RetroStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/TblProductCostLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProductCostList>>> GetTblProductCostLists()
        {
          if (_context.TblProductCostLists == null)
          {
              return NotFound();
          }
            return await _context.TblProductCostLists.ToListAsync();
        }

        // GET: api/TblProductCostLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProductCostList>> GetTblProductCostList(string id)
        {
          if (_context.TblProductCostLists == null)
          {
              return NotFound();
          }
            var tblProductCostList = await _context.TblProductCostLists.FindAsync(id);

            if (tblProductCostList == null)
            {
                return NotFound();
            }

            return tblProductCostList;
        }

        // PUT: api/TblProductCostLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProductCostList(string id, TblProductCostList tblProductCostList)
        {
            if (id != tblProductCostList.ProductName)
            {
                return BadRequest();
            }

            _context.Entry(tblProductCostList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductCostListExists(id))
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

        // POST: api/TblProductCostLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProductCostList>> PostTblProductCostList(TblProductCostList tblProductCostList)
        {
          if (_context.TblProductCostLists == null)
          {
              return Problem("Entity set 'RetroStoreDBContext.TblProductCostLists'  is null.");
          }
            _context.TblProductCostLists.Add(tblProductCostList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblProductCostListExists(tblProductCostList.ProductName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblProductCostList", new { id = tblProductCostList.ProductName }, tblProductCostList);
        }

        // DELETE: api/TblProductCostLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProductCostList(string id)
        {
            if (_context.TblProductCostLists == null)
            {
                return NotFound();
            }
            var tblProductCostList = await _context.TblProductCostLists.FindAsync(id);
            if (tblProductCostList == null)
            {
                return NotFound();
            }

            _context.TblProductCostLists.Remove(tblProductCostList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProductCostListExists(string id)
        {
            return (_context.TblProductCostLists?.Any(e => e.ProductName == id)).GetValueOrDefault();
        }
    }
}
