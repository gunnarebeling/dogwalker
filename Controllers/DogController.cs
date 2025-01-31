using DogWalker.Data;
using DogWalker.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace DogWalker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogController : ControllerBase
    {
        // Mock data for demonstration purposes
        private DogWalkerDbContext _context;
        public DogController(DogWalkerDbContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public IActionResult GetAllDogs()
        {
            List<Dog> dogs = _context.Dogs.ToList();
            
            return Ok(_context.Dogs);
        }

        [HttpPost]
        public IActionResult AddDog(Dog dog)
        {
            _context.Dogs.Add(dog);
            _context.SaveChanges();
            return Ok(dog);
        }
    }
}