using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using food_records.Data;
using food_records.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace food_records.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FoodRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FoodRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<FoodRecord>>> Get()
        {
            return await _context.FoodRecords.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodRecord>> Get(string id)
        {
            return await _context.FoodRecords.FindAsync(id);
        }

        [HttpPost]
        public async Task Post(FoodRecord record)
        {
            Guid g = Guid.NewGuid();
            record.Id = g.ToString();
            await _context.AddAsync(record);

            await _context.SaveChangesAsync();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(string id, FoodRecord record)
        {
            var exists = await _context.FoodRecords.AnyAsync(r => r.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            _context.FoodRecords.Update(record);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var record = await _context.FoodRecords.FindAsync(id);

            _context.FoodRecords.Remove(record);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}