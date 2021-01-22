using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkFinder.Controllers
{
    [Route("api/parks")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private ParkFinderContext _db;

        public ParksController(ParkFinderContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Park>> Get()
        {
            return _db.Parks.ToList();
        }

    }
}