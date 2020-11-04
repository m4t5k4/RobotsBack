using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RobotsAPI.Data;
using RobotsAPI.Models;

namespace RobotsAPI.Controllers
{
    [Route("api/manufacturers")]
    [ApiController]
    public class ManufacturerController : Controller
    {
        private readonly RobotsContext _context;

        public ManufacturerController(RobotsContext context)
        {
            _context = context;
        }

        // GET api/manufacturers
        [HttpGet]
        public ActionResult<IEnumerable<Manufacturer>> Get()
        {
            var manufacturers = _context.Manufacturers.OrderBy(m => m.Name);
            return manufacturers.ToList();
        }

        private Manufacturer GetManufacturer(int id)
        {
            return _context.Manufacturers.FirstOrDefault(a => a.ManufacturerID == id);
        }

        // GET api/manufacturers/5
        [HttpGet("{id}")]
        public ActionResult<Manufacturer> Get(int id)
        {
            return GetManufacturer(id);
        }

        // POST api/manufacturers
        [HttpPost]
        public ActionResult<Manufacturer> Post([FromBody] Manufacturer value)
        {
            _context.Manufacturers.Add(value);
            _context.SaveChanges();
            return GetManufacturer(value.ManufacturerID);
        }

        // PUT api/manufacturers/5
        [HttpPut("{id}")]
        public ActionResult<Manufacturer> Put(int id, [FromBody] Manufacturer value)
        {
            var manufacturer = _context.Manufacturers.SingleOrDefault(a => a.ManufacturerID == id);
            manufacturer.Name = value.Name;
            manufacturer.Location = value.Location;
            _context.SaveChanges();
            return GetManufacturer(manufacturer.ManufacturerID);
        }

        // DELETE api/manufacturers/5
        [HttpDelete("{id}")]
        public ActionResult<Manufacturer> Delete(int id)
        {
            var manufacturer = _context.Manufacturers.SingleOrDefault(a => a.ManufacturerID == id);
            _context.Manufacturers.Remove(manufacturer);
            _context.SaveChanges();
            return manufacturer;
        }
    }
}

