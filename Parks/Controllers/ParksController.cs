using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parks.Controllers
{
    [Route("api/parks")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private ParkContext _db;

        public ParksController(ParkContext db)
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