using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPrueba1.Entidades;

namespace WebApiPrueba1.Controllers
{
    [ApiController]
    [Route("huevos")]
    public class HuevosController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public HuevosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Huevo>>> Get()
        {
            return await dbContext.Huevos.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Huevo huevo)
        {
            dbContext.Add(huevo);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Huevo huevo, int id)
        {
            if (huevo.Id != id)
            {
                return BadRequest("El id del huevo no coincide con el establecido en la url.");
            }
            dbContext.Update(huevo);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
