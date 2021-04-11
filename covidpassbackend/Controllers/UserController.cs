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
        async public Task<ActionResult> Add(User user)
        {

            Console.WriteLine("Has request with: " + user.Email + ":" + user.Password);
            ICollection<User> users = await _context.Users.Where(u => u.Email == user.Email).ToListAsync();
            if (users.Count() > 0)
            {
                return NotFound();
            }

            Guid uid = Guid.NewGuid();
            user.Uid = uid.ToString();
            _context.Users.Add(user);
            _context.SaveChanges();
            return Accepted();
        }

        [HttpPut("{uid}")]
        public async Task<ActionResult> PutUser(User user)
        {
            if (user.Uid == "")
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("authenticate", Name = "Authenticate")]
        async public Task<ActionResult<User>> Authenticate([FromBody] UserAuthenticate data)
        {
            ICollection<User> users = await _context.Users.Where(u => u.Email.Equals(data.Email) && u.Password.Equals(data.Password)).ToListAsync();
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

            ICollection<Test> tests = await _context.Tests.Where(t => t.UserId == user.Uid).ToListAsync();
            user.Tests = tests;

            ICollection<Vaccine> vaccines = await _context.Vaccines.Where(t => t.UserId == user.Uid).ToListAsync();
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

            ICollection<Test> tests = await _context.Tests.Where(t => t.UserId == user.Uid).ToListAsync();
            user.Tests = tests;

            ICollection<Vaccine> vaccines = await _context.Vaccines.Where(t => t.UserId == user.Uid).ToListAsync();
            user.Vaccines = vaccines;

            return Ok(user);
        }

    }

}
