using System;
using foodTrackerApi.Db;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using foodTrackerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace foodTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FoodRecordsController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public FoodRecordsController(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<FoodRecord>>> Get()
        {
                return await _dbContext.FoodRecords.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodRecord>> Get(string id)
        {
            return await _dbContext.FoodRecords.FindAsync(id);            
        }

        [HttpPost]
        public async Task<ActionResult> Post(FoodRecord record)
        {
            _dbContext.FoodRecords.Add(record);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,FoodRecord record)
        {
            var exists = await _dbContext.FoodRecords.AnyAsync(x=>x.Id==id);
            if(!exists) return NotFound();

            _dbContext.FoodRecords.Update(record);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _dbContext.FoodRecords.AnyAsync(x=>x.Id==id);
            if(!exists) return NotFound();
            var record = await _dbContext.FoodRecords.FirstOrDefaultAsync(x=>x.Id==id);
            _dbContext.FoodRecords.Remove(record);
            _ = await _dbContext.SaveChangesAsync();
            return Ok();
        }


    }
}