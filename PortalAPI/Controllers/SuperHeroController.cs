using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalAPI.Data;
using PortalAPI.Entities;
using PortalAPI.Entities.HeroesDTO;

namespace PortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        //GET the list of all heroes
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            
            var heroes = await _context.SuperHeroes.ToListAsync();


            return Ok(heroes);
        }


        //GET a single hero
        [HttpGet("{Id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int Id)
        {

            var hero = await _context.SuperHeroes.FindAsync(Id);

            if(hero == null)
                return NotFound("Hero not found"); 
             
            else
                return Ok(hero);
        }

        //ADD a new superhero
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        //Edit a Superhero
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedhero)
        {
           var dbHero = await _context.SuperHeroes.FindAsync(updatedhero.Id);
            if(dbHero == null)
            {
                return NotFound("Hero not found");
            } 
            dbHero.Name = updatedhero.Name;
            dbHero.FirstName = updatedhero.FirstName;
            dbHero.LastName = updatedhero.LastName;
            dbHero.Place = updatedhero.Place;
            dbHero.DateCreated = updatedhero.DateCreated;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        //Delete Superhero

        [HttpDelete]

        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int Id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(Id);
            if (dbHero is null)
                return NotFound("Hero not found");
            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

    }
}
