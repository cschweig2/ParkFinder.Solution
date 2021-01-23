using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkFinder.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/parks")]
    [ApiController]
    public class ParksV1Controller : ControllerBase
    {
        private ParkFinderContext _db;

        public ParksV1Controller(ParkFinderContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Park>> Get(string parkType, string parkName, string city, string state, string status)
        {
            var query = _db.Parks.AsQueryable();
            if (parkType != null)
            {
                query = query.Where(entry => entry.ParkType == parkType);
            }
            if (parkName != null)
            {
                query = query.Where(entry => entry.ParkName == parkName);
            }
            if (city != null)
            {
                query = query.Where(entry => entry.City == city);
            }
            if (state != null)
            {
                query = query.Where(entry => entry.State == state);
            }
            if (status != null)
            {
                query = query.Where(entry => entry.Status == status);
            }
            return query.ToList();
        }

        [HttpPost]
        public void Post([FromBody] Park park)
        {
            _db.Parks.Add(park);
            _db.SaveChanges();
        }

        [HttpGet("{id}")]
        public ActionResult<Park> Get(int id)
        {
            return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Park park)
        {
            park.ParkId = id;
            _db.Entry(park).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
            _db.Parks.Remove(parkToDelete);
            _db.SaveChanges();
        }
    }

    [ApiVersion("2.0")]
    [Route("api/{v:ApiVersion}/parks")]
    [ApiController]
    public class ParksV2Controller : ControllerBase
    {
        private ParkFinderContext _db;

        public ParksV2Controller(ParkFinderContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Park>> Get(string parkType, string parkName, string city, string state, string status)
        {
            var query = _db.Parks.AsQueryable();
            if (parkType != null)
            {
                query = query.Where(entry => entry.ParkType == parkType);
            }
            if (parkName != null)
            {
                query = query.Where(entry => entry.ParkName == parkName);
            }
            if (city != null)
            {
                query = query.Where(entry => entry.City == city);
            }
            if (state != null)
            {
                query = query.Where(entry => entry.State == state);
            }
            if (status != null)
            {
                query = query.Where(entry => entry.Status == status);
            }
            return query.ToList();
        }

        [HttpPost]
        public void Post([FromBody] Park park)
        {
            _db.Parks.Add(park);
            _db.SaveChanges();
        }

        [HttpGet("{id}")]
        public ActionResult<Park> Get(int id)
        {
            return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Park park)
        {
            park.ParkId = id;
            _db.Entry(park).State = EntityState.Modified;
            _db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
            _db.Parks.Remove(parkToDelete);
            _db.SaveChanges();
        }

        [HttpGet("random")]
        public ActionResult<Park> Get()
        {
            var rand = new Random();
            var random = rand.Next(1, _db.Parks.Count());
            return _db.Parks.FirstOrDefault(entry => entry.ParkId == random);
        }
    }
}