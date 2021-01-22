using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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