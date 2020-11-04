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
    [Route("api/robots")]
    [ApiController]
    public class RobotController : Controller
    {
        private readonly RobotsContext _context;

        public RobotController(RobotsContext context)
        {
            _context = context;
        }

        // GET api/robots
        [HttpGet]
        public ActionResult<IEnumerable<Robot>> Get()
        {
            var robots = _context.Robots.Include(r => r.Manufacturer).
                Include(r => r.Category).OrderBy(r => r.Name);
            return robots.ToList();
        }

        private Robot GetRobot(int id)
        {
            return _context.Robots.Include(r => r.Manufacturer).
                Include(r => r.Category).FirstOrDefault(a => a.RobotID == id);
        }

        // GET api/robots/5
        [HttpGet("{id}")]
        public ActionResult<Robot> Get(int id)
        {
            return GetRobot(id);
        }

        // POST api/robots
        [HttpPost]
        public ActionResult<Robot> Post([FromBody] Robot value)
        {
            _context.Robots.Add(value);
            _context.SaveChanges();
            return GetRobot(value.RobotID);
        }

        // PUT api/robots/5
        [HttpPut("{id}")]
        public ActionResult<Robot> Put(int id, [FromBody] Robot value)
        {
            var robot = _context.Robots.SingleOrDefault(a => a.RobotID == id);
            robot.Name = value.Name;
            robot.Serialnumber = value.Serialnumber;
            robot.Image = value.Image;
            robot.ManufacturerID = value.ManufacturerID;
            robot.CategoryID = value.CategoryID;
            _context.SaveChanges();
            return GetRobot(robot.RobotID);
        }

        // DELETE api/robots/5
        [HttpDelete("{id}")]
        public ActionResult<Robot> Delete(int id)
        {
            var robot = _context.Robots.SingleOrDefault(a => a.RobotID == id);
            _context.Robots.Remove(robot);
            _context.SaveChanges();
            return robot;
        }

    }
}

