using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiPrueba1.Entidades;

namespace WebApiPrueba1.Controllers
{
    [ApiController]
    [Route("encargados")]
    public class EncargadosController:ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EncargadosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Encargado>>> Get()
        {
            return await dbContext.Encargados.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Encargado encargado)
        {
            dbContext.Add(encargado);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("id{int}")]
        public async Task<ActionResult> Put(Encargado encargado, int id)
        {
            if (encargado.Id != id)
            {
                return BadRequest("El id del huevo no coincide con el establecido en la url.");
            }
            dbContext.Update(encargado);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
