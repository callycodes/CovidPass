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
        private readonly UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
            if (_context.users.Count() == 0)
            {
                _context.users.Add(new User
                    {
                        uid = "uyctuyuioibh",
                        firstName = "Cal",
                        lastName = "Bass",
                        dateOfBirth = new DateTime()
                    }
                ); _context.SaveChanges();
            }
        }
    }
}
