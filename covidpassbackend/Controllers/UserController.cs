using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using covidpassbackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace covidpassbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CovidPassContext _context = new CovidPassContext();

        [HttpPost]
        public ActionResult Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Accepted();
        }

        [HttpPost("authenticate", Name = "Authenticate")]
        async public Task<ActionResult<User>> Authenticate([FromBody] UserAuthenticate data)
        {
            Console.WriteLine("looking for: " + data.Email + ":" + data.Password);
            ICollection<User> users = await _context.Users.Where(u => u.Email == data.Email && u.Password == data.Password).ToListAsync();
            Console.WriteLine(users.Count());
            if (users.Count() == 0)
            {
                return NotFound();
            }
            return Ok(users.First());
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}", Name = "GetUser")]
        async public Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ICollection<Test> tests = await _context.Tests.Where(t => t.UserId == user.Id).ToListAsync();
            user.Tests = tests;

            ICollection<Vaccine> vaccines = await _context.Vaccines.Where(t => t.UserId == user.Id).ToListAsync();
            user.Vaccines = vaccines;

            return Ok(user);
        }

        [HttpGet("GetByUid/{uid}", Name = "GetUserByUid")]
        public async Task<ActionResult<User>> GetByUid(string uid)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Uid == uid);
            if (user == null)
            {
                return NotFound();
            }

            ICollection<Test> tests = await _context.Tests.Where(t => t.UserId == user.Id).ToListAsync();
            user.Tests = tests;

            ICollection<Vaccine> vaccines = await _context.Vaccines.Where(t => t.UserId == user.Id).ToListAsync();
            user.Vaccines = vaccines;

            return Ok(user);
        }

    }

}
