using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Pasticceria.Data.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitaMisuraController : ControllerBase
    {
        private readonly Context _dbContext;

        public UnitaMisuraController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<Data.Entity.UnitaMisura>> Get()
        {
            return await _dbContext.UnitaMisura.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] Data.Entity.UnitaMisura unitaMisura)
        {
            if (ModelState.IsValid)
            {
                unitaMisura.ID = 1;
                _dbContext.Add(unitaMisura);
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<Data.Entity.UnitaMisura> Details(string id)
        {
            return await _dbContext.UnitaMisura.FindAsync(id);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(int id, [FromBody] Data.Entity.UnitaMisura unitaMisura)
        {
            if (id != unitaMisura.ID)
            {
                return false;
            }

            _dbContext.Entry(unitaMisura).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> DeleteConfirmed(int id)
        {
            var unitaMisura = await _dbContext.UnitaMisura.FindAsync(id);
            if (unitaMisura == null)
            {
                return false;
            }

            _dbContext.UnitaMisura.Remove(unitaMisura);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
