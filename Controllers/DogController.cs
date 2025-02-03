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
        [HttpDelete("{id}")]
        public IActionResult DeleteDog(int id)
        {
            Dog dog = _context.Dogs.FirstOrDefault(d => d.Id == id);
            if (dog == null)
            {

                return NotFound("cant find dog");
            }
            _context.Dogs.Remove(dog);
            _context.SaveChanges();
            return Ok();
        }
        
        [HttpPost]
        public IActionResult AddDog(Dog dog)
        {
            _context.Dogs.Add(dog);
            _context.SaveChanges();
            return Ok(dog);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDog(int id, Dog dog)
        {
            Dog dogToUpdate = _context.Dogs.FirstOrDefault(d => d.Id == id);
            if (dogToUpdate == null)
            {
                return NotFound("cant find dog");
            }
            dogToUpdate.Name = dog.Name;
            dogToUpdate.Breed = dog.Breed;
            dogToUpdate.Age = dog.Age;
            dogToUpdate.OwnerName = dog.OwnerName;
            _context.SaveChanges();
            return Ok(dogToUpdate);
        }
    }
}