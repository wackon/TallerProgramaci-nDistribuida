using AutoMapper;
using Taller.Data;
using Taller.DTOs;
using Taller.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Taller.Controllers
{



    [ApiController]
    [Route("api/detalles")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class DetalleController : Controller
    {
        private readonly ILogger<DetalleController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DetalleController(ILogger<DetalleController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from Detalle
        [HttpGet]
        public async Task<ActionResult<List<Detalle>>> Get()
        {

            return await context.Detalles.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<DetalleDTO>> Get(int Id)
        {

            var detalle = await context.Detalles.FirstOrDefaultAsync(x => x.Id == Id);


            if (detalle == null)
            {


                return NotFound();
            }


            return mapper.Map<DetalleDTO>(detalle);

        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> Post([FromBody] DetalleCreacionDTO detalleCreacionDTO)
        {


            var detalle = mapper.Map<Detalle>(detalleCreacionDTO);
            context.Add(detalle);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{Id}")]
       
        public async Task<ActionResult> Put(Detalle detalle, int Id)
        {

            if (detalle.Id != Id)
            {
                return BadRequest("El detalle no existe");
            }

            var existe = await context.Detalles.AnyAsync(x => x.Id == Id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(detalle);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete(int Id)
        {


            var detalle = await context.Detalles.FirstOrDefaultAsync(x => x.Id == Id);

            if (detalle == null)
            {

                return NotFound();
            }

            context.Remove(detalle);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }





    }

}