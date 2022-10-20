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
    [Route ("api/tipovehiculo")]

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class TipoVehiculoController:Controller
    {
        private readonly ILogger<TipoVehiculoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoVehiculoController(ILogger<TipoVehiculoController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from tipos de vehículos
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<TipoVehiculo>>> Get()
        {
           
            return await context.TipoVehiculos.ToListAsync();
            

        }

        // Búsqueda por parámetro
        [HttpGet("{Id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<TipoVehiculoDTO>> Get(int Id)
        {

            var tipovehiculo = await context.TipoVehiculos.FirstOrDefaultAsync(x => x.Id == Id);


            if (tipovehiculo == null)
            {


                return NotFound();
            }


            return mapper.Map<TipoVehiculoDTO>(tipovehiculo);

        }


        [HttpPost]
        
        public async Task<ActionResult> Post([FromBody]TipoVehiculoCreacionDTO tipoVehiculoCreacionDTO)
        {


            var tipovehiculo=mapper.Map<TipoVehiculo>(tipoVehiculoCreacionDTO);
            context.Add(tipovehiculo);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{Id}")]
        
        public async Task<ActionResult> Put(TipoVehiculo tipoVehiculo, int Id)
        {

            if(tipoVehiculo.Id != Id)
            {
                return BadRequest("El tipo de vehículo no existe");
}

            var existe =await context.TipoVehiculos.AnyAsync(x => x.Id == Id); 

            if(!existe)
            {

                return NotFound();



            }

            context.Update(tipoVehiculo);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{Id}")]
        
        public async Task<ActionResult> Delete( int Id)
        {

            
            var tipovehiculo= await context.TipoVehiculos.FirstOrDefaultAsync(x => x.Id == Id);

            if (tipovehiculo == null) 
            {

                return NotFound();
            }

            context.Remove(tipovehiculo);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }





    }

}