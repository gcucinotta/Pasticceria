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
    public class UtentiController : ControllerBase
    {
        private readonly Context _dbContext;

        public UtentiController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<Data.Entity.Utente>> Get()
        {
            return await _dbContext.Utenti.ToListAsync();
        }

        [HttpGet]
        [Route("IsExists/{eMail}")]
        public async Task<Data.Entity.Utente> IsExists(string eMail)
        {
            return await _dbContext.Utenti.Where(x => x.eMail == eMail.ToLower()).FirstOrDefaultAsync();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] Data.Entity.Utente utente)
        {
            if (ModelState.IsValid)
            {
                utente.ID = 1;
                _dbContext.Add(utente);
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
        public async Task<Data.Entity.Utente> Details(string id)
        {
            return await _dbContext.Utenti.FindAsync(id);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(int id, [FromBody] Data.Entity.Utente utente)
        {
            if (id != utente.ID)
            {
                return false;
            }

            _dbContext.Entry(utente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> DeleteConfirmed(int id)
        {
            var utente = await _dbContext.Utenti.FindAsync(id);
            if (utente == null)
            {
                return false;
            }

            _dbContext.Utenti.Remove(utente);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
