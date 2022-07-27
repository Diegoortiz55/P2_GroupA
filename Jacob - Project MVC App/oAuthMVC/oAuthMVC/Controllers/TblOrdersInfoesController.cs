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
    public class TblOrdersInfoesController : ControllerBase
    {
        private readonly RetroStoreDBContext _context;

        public TblOrdersInfoesController(RetroStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/TblOrdersInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblOrdersInfo>>> GetTblOrdersInfos()
        {
          if (_context.TblOrdersInfos == null)
          {
              return NotFound();
          }
            return await _context.TblOrdersInfos.ToListAsync();
        }

        // GET: api/TblOrdersInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblOrdersInfo>> GetTblOrdersInfo(int id)
        {
          if (_context.TblOrdersInfos == null)
          {
              return NotFound();
          }
            var tblOrdersInfo = await _context.TblOrdersInfos.FindAsync(id);

            if (tblOrdersInfo == null)
            {
                return NotFound();
            }

            return tblOrdersInfo;
        }

        // PUT: api/TblOrdersInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblOrdersInfo(int id, TblOrdersInfo tblOrdersInfo)
        {
            if (id != tblOrdersInfo.OrderNo)
            {
                return BadRequest();
            }

            _context.Entry(tblOrdersInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblOrdersInfoExists(id))
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

        // POST: api/TblOrdersInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblOrdersInfo>> PostTblOrdersInfo(TblOrdersInfo tblOrdersInfo)
        {
          if (_context.TblOrdersInfos == null)
          {
              return Problem("Entity set 'RetroStoreDBContext.TblOrdersInfos'  is null.");
          }
            _context.TblOrdersInfos.Add(tblOrdersInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblOrdersInfoExists(tblOrdersInfo.OrderNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblOrdersInfo", new { id = tblOrdersInfo.OrderNo }, tblOrdersInfo);
        }

        // DELETE: api/TblOrdersInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblOrdersInfo(int id)
        {
            if (_context.TblOrdersInfos == null)
            {
                return NotFound();
            }
            var tblOrdersInfo = await _context.TblOrdersInfos.FindAsync(id);
            if (tblOrdersInfo == null)
            {
                return NotFound();
            }

            _context.TblOrdersInfos.Remove(tblOrdersInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblOrdersInfoExists(int id)
        {
            return (_context.TblOrdersInfos?.Any(e => e.OrderNo == id)).GetValueOrDefault();
        }
    }
}
