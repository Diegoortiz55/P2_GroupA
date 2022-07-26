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
    public class TblRegisterInfoesController : ControllerBase
    {
        private readonly RetroStoreDBContext _context;

        public TblRegisterInfoesController(RetroStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/TblRegisterInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRegisterInfo>>> GetTblRegisterInfos()
        {
          if (_context.TblRegisterInfos == null)
          {
              return NotFound();
          }
            return await _context.TblRegisterInfos.ToListAsync();
        }

        // GET: api/TblRegisterInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblRegisterInfo>> GetTblRegisterInfo(string id)
        {
          if (_context.TblRegisterInfos == null)
          {
              return NotFound();
          }
            var tblRegisterInfo = await _context.TblRegisterInfos.FindAsync(id);

            if (tblRegisterInfo == null)
            {
                return NotFound();
            }

            return tblRegisterInfo;
        }

        // PUT: api/TblRegisterInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRegisterInfo(string id, TblRegisterInfo tblRegisterInfo)
        {
            if (id != tblRegisterInfo.UserName)
            {
                return BadRequest();
            }

            _context.Entry(tblRegisterInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRegisterInfoExists(id))
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

        // POST: api/TblRegisterInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblRegisterInfo>> PostTblRegisterInfo(TblRegisterInfo tblRegisterInfo)
        {
          if (_context.TblRegisterInfos == null)
          {
              return Problem("Entity set 'RetroStoreDBContext.TblRegisterInfos'  is null.");
          }
            _context.TblRegisterInfos.Add(tblRegisterInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblRegisterInfoExists(tblRegisterInfo.UserName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblRegisterInfo", new { id = tblRegisterInfo.UserName }, tblRegisterInfo);
        }

        // DELETE: api/TblRegisterInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblRegisterInfo(string id)
        {
            if (_context.TblRegisterInfos == null)
            {
                return NotFound();
            }
            var tblRegisterInfo = await _context.TblRegisterInfos.FindAsync(id);
            if (tblRegisterInfo == null)
            {
                return NotFound();
            }

            _context.TblRegisterInfos.Remove(tblRegisterInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblRegisterInfoExists(string id)
        {
            return (_context.TblRegisterInfos?.Any(e => e.UserName == id)).GetValueOrDefault();
        }
    }
}
