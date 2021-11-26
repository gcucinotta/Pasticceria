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
    public class IngredientiController : ControllerBase
    {
        private readonly Context _dbContext;

        public IngredientiController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<Data.Entity.Ingrediente>> Get()
        {
            return await _dbContext.Ingredienti.ToListAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] Data.Entity.Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(ingrediente);
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    string m = ex.Message;
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
        public async Task<Data.Entity.Ingrediente> Details(int id)
        {
            return await _dbContext.Ingredienti.FindAsync(id);
        }

        [HttpGet]
        [Route("FindByIDDolce/{idDolce}")]
        public async Task<List<Data.Entity.Ingrediente>> FindByIDDolce(int idDolce)
        {
            return await _dbContext.Ingredienti.Where(x => x.IDDolce == idDolce).ToListAsync();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(int id, [FromBody] Data.Entity.Ingrediente ingrediente)
        {
            if (id != ingrediente.ID)
            {
                return false;
            }

            _dbContext.Entry(ingrediente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> DeleteConfirmed(int id)
        {
            var ingrediente = await _dbContext.Ingredienti.FindAsync(id);
            if (ingrediente == null)
            {
                return false;
            }

            _dbContext.Ingredienti.Remove(ingrediente);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("DeleteByDolce/{idDolce}")]
        public async Task<bool> DeleteByDolce(int idDolce)
        {
            List<Data.Entity.Ingrediente> ingredienti = await _dbContext.Ingredienti.Where(x => x.IDDolce == idDolce).ToListAsync();
            foreach (Data.Entity.Ingrediente ing in ingredienti) {
                _dbContext.Ingredienti.Remove(ing);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
