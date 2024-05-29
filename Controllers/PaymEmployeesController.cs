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
    public class PaymEmployeesController : ControllerBase
    {
        private readonly HrmsystemContext _context;

        public PaymEmployeesController(HrmsystemContext context)
        {
            _context = context;
        }

        // GET: api/PaymEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymEmployee>>> GetPaymEmployees()
        {
            return await _context.PaymEmployees.ToListAsync();
        }

        // GET: api/PaymEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymEmployee>> GetPaymEmployee(int id)
        {
            var paymEmployee = await _context.PaymEmployees.FindAsync(id);

            if (paymEmployee == null)
            {
                return NotFound();
            }

            return paymEmployee;
        }

        // PUT: api/PaymEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymEmployee(int id, PaymEmployee paymEmployee)
        {
            if (id != paymEmployee.PnCompanyId)
            {
                return BadRequest();
            }

            _context.Entry(paymEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymEmployeeExists(id))
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

        // POST: api/PaymEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public String  PostPaymEmployee(PaymEmployee paymEmployee)
        {

            String query =
$"Insert into Paym_Employee values ({paymEmployee.PnCompanyId}, {paymEmployee.PnBranchId}, '{paymEmployee.EmployeeCode}', '{paymEmployee.EmployeeFirstName}', '{paymEmployee.EmployeeMiddleName}','{paymEmployee.EmployeeFullName}', '{paymEmployee.DateofBirth}', '{paymEmployee.Password}', '{paymEmployee.Gender}', '{paymEmployee.Status}', '{paymEmployee.EmployeeFullName}', {paymEmployee.Readerid}, '{paymEmployee.OtEligible}', '{paymEmployee.Pfno}', '{paymEmployee.Esino}', {paymEmployee.OtCalc}, {paymEmployee.Ctc}, {paymEmployee.BasicSalary},'{paymEmployee.BankCode}', '{paymEmployee.BankName}', '{paymEmployee.BranchName}', '{paymEmployee.AccountType}', '{paymEmployee.MicrCode}', '{paymEmployee.IfscCode}', '{paymEmployee.Address}', '{paymEmployee.OtherInfo}', '{paymEmployee.ReportingPerson}', {paymEmployee.ReportingId}, '{paymEmployee.ReportingEmail}', '{paymEmployee.PanNo}', '{paymEmployee.CardNo}', '{paymEmployee.SalaryType}', '{paymEmployee.TdsApplicable}', '{paymEmployee.Flag}', {paymEmployee.Role})";



            var result = _context.Database.ExecuteSqlRaw(query);
            
            /*_context.PaymEmployees.Add(paymEmployee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymEmployeeExists(paymEmployee.PnCompanyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaymEmployee", new { id = paymEmployee.PnCompanyId }, paymEmployee);
        
             */
            return "Employee added successfully";
        
        }

        // DELETE: api/PaymEmployees/5
        [HttpDelete("{cid},{bid},{eid}")]
        public async Task<IActionResult> DeletePaymEmployee(int cid,int bid,int eid)
        {
            var paymEmployee = await _context.PaymEmployees.FindAsync(cid,bid,eid);
            if (paymEmployee == null)
            {
                return NotFound();
            }

            _context.PaymEmployees.Remove(paymEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymEmployeeExists(int id)
        {
            return _context.PaymEmployees.Any(e => e.PnCompanyId == id);
        }
    }
}
