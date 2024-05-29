using HRMSAPPLICATION.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMSAPPLICATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymousJwt]
    public class BranchLoginController : ControllerBase
    {
        HrmsystemContext _context;
      
        private Models.TokenHandler tokenHandler;
        public BranchLoginController(HrmsystemContext context,Models.TokenHandler tokenHandler )
        {
            _context = context;
            this.tokenHandler = tokenHandler;
        }
        [HttpPost]
        public ActionResult Authenticate([FromBody] BranchLoginModel login)
        {
            /* if (login.username == "admin" && login.password == "password")
             {
                 return Ok(new { message = "Login successful" });
             }
             else
             {
                 return Unauthorized(new { message = "Invalid username or password" });
             }*/

            var PaymBranch = from e in _context.PaymBranches
                             where e.BranchUserId == login.username && e.BranchPassword == login.password
                             select e;
            if (PaymBranch.Any())
            {

                return Ok(new { message = tokenHandler.GenerateJwtToken(login.username) });
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

        }
        
    }

}
