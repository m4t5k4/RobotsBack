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
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly RobotsContext _context;

        public CategoryController(RobotsContext context)
        {
            _context = context;
        }

        // GET api/categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _context.Categories.OrderBy(m => m.Name);
            return categories.ToList();
        }

        private Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(a => a.CategoryID == id);
        }

        // GET api/categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            return GetCategory(id);
        }

        // POST api/categories
        [HttpPost]
        public ActionResult<Category> Post([FromBody] Category value)
        {
            _context.Categories.Add(value);
            _context.SaveChanges();
            return GetCategory(value.CategoryID);
        }

        // PUT api/categories/5
        [HttpPut("{id}")]
        public ActionResult<Category> Put(int id, [FromBody] Category value)
        {
            var category = _context.Categories.SingleOrDefault(a => a.CategoryID == id);
            category.Name = value.Name;
            category.Comment = value.Comment;
            _context.SaveChanges();
            return GetCategory(category.CategoryID);
        }

        // DELETE api/categories/5
        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(a => a.CategoryID == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }
    }
}


