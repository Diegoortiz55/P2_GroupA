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
    public class TblCustomerContactsController : ControllerBase
    {
        private readonly RetroStoreDBContext _context;

        public TblCustomerContactsController(RetroStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/TblCustomerContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomerContact>>> GetTblCustomerContacts()
        {
          if (_context.TblCustomerContacts == null)
          {
              return NotFound();
          }
            return await _context.TblCustomerContacts.ToListAsync();
        }

        // GET: api/TblCustomerContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomerContact>> GetTblCustomerContact(string id)
        {
          if (_context.TblCustomerContacts == null)
          {
              return NotFound();
          }
            var tblCustomerContact = await _context.TblCustomerContacts.FindAsync(id);

            if (tblCustomerContact == null)
            {
                return NotFound();
            }

            return tblCustomerContact;
        }

        // PUT: api/TblCustomerContacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCustomerContact(string id, TblCustomerContact tblCustomerContact)
        {
            if (id != tblCustomerContact.UserName)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomerContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerContactExists(id))
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

        // POST: api/TblCustomerContacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCustomerContact>> PostTblCustomerContact(TblCustomerContact tblCustomerContact)
        {
          if (_context.TblCustomerContacts == null)
          {
              return Problem("Entity set 'RetroStoreDBContext.TblCustomerContacts'  is null.");
          }
            _context.TblCustomerContacts.Add(tblCustomerContact);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblCustomerContactExists(tblCustomerContact.UserName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblCustomerContact", new { id = tblCustomerContact.UserName }, tblCustomerContact);
        }

        // DELETE: api/TblCustomerContacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCustomerContact(string id)
        {
            if (_context.TblCustomerContacts == null)
            {
                return NotFound();
            }
            var tblCustomerContact = await _context.TblCustomerContacts.FindAsync(id);
            if (tblCustomerContact == null)
            {
                return NotFound();
            }

            _context.TblCustomerContacts.Remove(tblCustomerContact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCustomerContactExists(string id)
        {
            return (_context.TblCustomerContacts?.Any(e => e.UserName == id)).GetValueOrDefault();
        }
    }
}
