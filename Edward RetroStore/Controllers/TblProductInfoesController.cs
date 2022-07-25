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
    public class TblProductInfoesController : ControllerBase
    {
        private readonly RetroStoreDBContext _context;

        public TblProductInfoesController(RetroStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/TblProductInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProductInfo>>> GetTblProductInfos()
        {
          if (_context.TblProductInfos == null)
          {
              return NotFound();
          }
            return await _context.TblProductInfos.ToListAsync();
        }

        // GET: api/TblProductInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProductInfo>> GetTblProductInfo(int id)
        {
          if (_context.TblProductInfos == null)
          {
              return NotFound();
          }
            var tblProductInfo = await _context.TblProductInfos.FindAsync(id);

            if (tblProductInfo == null)
            {
                return NotFound();
            }

            return tblProductInfo;
        }

        // PUT: api/TblProductInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProductInfo(int id, TblProductInfo tblProductInfo)
        {
            if (id != tblProductInfo.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(tblProductInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductInfoExists(id))
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

        // POST: api/TblProductInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProductInfo>> PostTblProductInfo(TblProductInfo tblProductInfo)
        {
          if (_context.TblProductInfos == null)
          {
              return Problem("Entity set 'RetroStoreDBContext.TblProductInfos'  is null.");
          }
            _context.TblProductInfos.Add(tblProductInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblProductInfo", new { id = tblProductInfo.ProductId }, tblProductInfo);
        }

        // DELETE: api/TblProductInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProductInfo(int id)
        {
            if (_context.TblProductInfos == null)
            {
                return NotFound();
            }
            var tblProductInfo = await _context.TblProductInfos.FindAsync(id);
            if (tblProductInfo == null)
            {
                return NotFound();
            }

            _context.TblProductInfos.Remove(tblProductInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblProductInfoExists(int id)
        {
            return (_context.TblProductInfos?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
