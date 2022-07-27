using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingASPAPI.Models.EF;

namespace ShoppingASPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContactController : ControllerBase
    {
        private readonly retroStoreDBContext _context = new retroStoreDBContext();

        //public CustomerContactController(retroStoreDBContext context)
        //{
        //    _context = context;
        //}

        // GET: api/CustomerContact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomerContact>>> GetTblCustomerContacts()
        {
          if (_context.TblCustomerContacts == null)
          {
              return NotFound();
          }
            return await _context.TblCustomerContacts.ToListAsync();
        }

        // GET: api/CustomerContact/5
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

        // PUT: api/CustomerContact/5
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

        // POST: api/CustomerContact
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCustomerContact>> PostTblCustomerContact(TblCustomerContact tblCustomerContact)
        {
          if (_context.TblCustomerContacts == null)
          {
              return Problem("Entity set 'retroStoreDBContext.TblCustomerContacts'  is null.");
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

        // DELETE: api/CustomerContact/5
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
