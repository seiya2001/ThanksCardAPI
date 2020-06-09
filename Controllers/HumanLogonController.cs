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
    public class HumanLogonController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public HumanLogonController(ApplicationContext context)
        {
            _context = context;

            if (_context.HumanPasswords.Count() == 0)
            {
                // Usersテーブルが空なら初期データを作成する。
                //_context.Users.Add(new User { Name = "admin", Password = "admin", IsAdmin = true });
                //_context.Users.Add(new User { Name = "user", Password = "user", IsAdmin = false });
                _context.SaveChanges();
            }
        }

        // POST api/humanlogon
        [HttpPost]
        public ActionResult<HumanPassword> Post([FromBody] HumanPassword humanPassword)
        {
            var authorizedHumanPassword = _context.HumanPasswords.SingleOrDefault(x =>  x.Password == humanPassword.Password);
            if (authorizedHumanPassword == null)
            {
                return NotFound();
            }
            return authorizedHumanPassword;
        }
    }
}
