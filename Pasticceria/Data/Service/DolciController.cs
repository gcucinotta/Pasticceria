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
    public class DolciController : ControllerBase
    {
        private readonly Context _dbContext;

        public DolciController(Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<List<Data.Entity.Dolce>> Get()
        {
            return await _dbContext.Dolci.ToListAsync();
        }

        [HttpGet]
        [Route("GetByVetrina")]
        public async Task<List<Data.Entity.Dolce>> GetByVetrina()
        {
            DateTime dStart = DateTime.Now.Date.AddDays(-2);
            DateTime dStop = DateTime.Now.Date;
            List<Data.Entity.Dolce> list = await _dbContext.Dolci.Where(x => x.IsVetrina == true && x.DataVendita >= dStart && x.DataVendita <= dStop).ToListAsync();

            // Modifico il prezzo secondo questa logica ...
            // 1 ... Se il dolce è di oggi => prezzo pieno;
            // 2 ... Se il dolce è di ieri => sconto 20%;
            // 3 ... se il dolce è di 2gg fa => sconto 80%;

            DateTime dGiornoMeno1 = DateTime.Now.Date.AddDays(-1);
            DateTime dGiornoMeno2 = DateTime.Now.Date.AddDays(-2);

            foreach (Data.Entity.Dolce d in list) {
                if (d.DataVendita == dGiornoMeno1)
                    d.Prezzo = d.Prezzo * Convert.ToDecimal(0.8);
                else if (d.DataVendita == dGiornoMeno2)
                    d.Prezzo = d.Prezzo * Convert.ToDecimal(0.2);
            }

            return list;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<int> Create([FromBody] Data.Entity.Dolce dolce)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(dolce);
                try
                {
                    await _dbContext.SaveChangesAsync();
                    return dolce.ID;
                }
                catch (DbUpdateException ex)
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<Data.Entity.Dolce> Details(int id)
        {
            return await _dbContext.Dolci.FindAsync(id);
        }

        [HttpGet]
        [Route("FindByName/{name}")]
        public async Task<Data.Entity.Dolce> FindByName(string name)
        {
            return await _dbContext.Dolci.Where(x => x.Nome.ToLower() == name.ToLower()).FirstOrDefaultAsync();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<bool> Edit(int id, [FromBody] Data.Entity.Dolce dolce)
        {
            if (id != dolce.ID)
            {
                return false;
            }

            _dbContext.Entry(dolce).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<bool> DeleteConfirmed(int id)
        {
            var dolce = await _dbContext.Dolci.FindAsync(id);
            if (dolce == null)
            {
                return false;
            }

            _dbContext.Dolci.Remove(dolce);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
