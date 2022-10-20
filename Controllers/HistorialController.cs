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
    [Route ("api/historial")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class HistorialController:Controller
    {
        private readonly ILogger<HistorialController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HistorialController(ILogger<HistorialController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from Historial
        [HttpGet]
        public async Task<ActionResult<List<Historial>>> Get()
        {
           
            return await context.Historiales.ToListAsync();
            

        }

        // Búsqueda por parámetro
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<HistorialDTO>> Get(int Id)
        {

            var historial = await context.Historiales.FirstOrDefaultAsync(x => x.Id == Id);


            if (historial == null)
            {


                return NotFound();
            }


            return mapper.Map<HistorialDTO>(historial);

        }


        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> Post([FromBody]HistorialCreacionDTO historialCreacionDTO)
        {


            var historial=mapper.Map<Historial>(historialCreacionDTO);
            context.Add(historial);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{Id}")]

        public async Task<ActionResult> Put(Historial historial ,int Id)
        {

            if(historial.Id != Id)
            {
                return BadRequest("El historial no existe");
}

            var existe =await context.Historiales.AnyAsync(x => x.Id == Id); 

            if(!existe)
            {

                return NotFound();



            }

            context.Update(historial);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete( int Id)
        {

            
            var historial= await context.Historiales.FirstOrDefaultAsync(x => x.Id == Id);

            if (historial == null) 
            {

                return NotFound();
            }

            context.Remove(historial);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }





    }

}