using Microsoft.AspNetCore.Mvc;
using MediSynth.Data;
using MediSynth.Models;
using System.Linq;

namespace MediSynth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Companies.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null) return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public IActionResult Post(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Company company)
        {
            var existingCompany = _context.Companies.Find(id);
            if (existingCompany == null) return NotFound();

            existingCompany.Name = company.Name;
            existingCompany.Address = company.Address;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null) return NotFound();

            _context.Companies.Remove(company);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
