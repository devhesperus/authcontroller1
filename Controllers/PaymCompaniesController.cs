using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMSAPPLICATION.Models;

namespace HRMSAPPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymCompaniesController : ControllerBase
    {
        private readonly HrmsystemContext _context;

        public PaymCompaniesController(HrmsystemContext context)
        {
            _context = context;
        }

        // GET: api/PaymCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymCompany>>> GetPaymCompanies()
        {
            return await _context.PaymCompanies.ToListAsync();
        }

        // GET: api/PaymCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymCompany>> GetPaymCompany(int id)
        {
            var paymCompany = await _context.PaymCompanies.FindAsync(id);

            if (paymCompany == null)
            {
                return NotFound();
            }

            return paymCompany;
        }

        // PUT: api/PaymCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymCompany(int id, PaymCompany paymCompany)
        {
            if (id != paymCompany.PnCompanyId)
            {
                return BadRequest();
            }

            _context.Entry(paymCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymCompanyExists(id))
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

        // POST: api/PaymCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymCompany>> PostPaymCompany(PaymCompany paymCompany)
        {
            _context.PaymCompanies.Add(paymCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymCompany", new { id = paymCompany.PnCompanyId }, paymCompany);
        }

        // DELETE: api/PaymCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymCompany(int id)
        {
            var paymCompany = await _context.PaymCompanies.FindAsync(id);
            if (paymCompany == null)
            {
                return NotFound();
            }

            _context.PaymCompanies.Remove(paymCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymCompanyExists(int id)
        {
            return _context.PaymCompanies.Any(e => e.PnCompanyId == id);
        }
    }
}
