using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using covidpassbackend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace covidpassbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : Controller
    {
        private readonly CovidPassContext _context = new CovidPassContext();

        [HttpPost]
        public ActionResult Add(Vaccine vaccine)
        {
            _context.Vaccines.Add(vaccine);
            _context.SaveChanges();
            return Accepted();
        }

    }
}
