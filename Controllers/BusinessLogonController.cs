using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessLogonController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BusinessLogonController(ApplicationContext context)
        {
            _context = context;
            if (_context.BusinessPasswords.Count() == 0)
            {
                // Usersテーブルが空なら初期データを作成する。
                //_context.Users.Add(new User { Name = "admin", Password = "admin", IsAdmin = true });
                //_context.Users.Add(new User { Name = "user", Password = "user", IsAdmin = false });
                _context.SaveChanges();
            }
        }

        // POST api/logon
        [HttpPost]
        public ActionResult<BusinessPassword> Post([FromBody] BusinessPassword businessPassword)
        {
            var authorizedBusinessPassword = _context.BusinessPasswords.SingleOrDefault(x => x.Password == businessPassword.Password);
            if (authorizedBusinessPassword == null)
            {
                return NotFound();
            }
            return authorizedBusinessPassword;
        }
    }
}