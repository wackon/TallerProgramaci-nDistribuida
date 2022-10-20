using AutoMapper;
using Taller.Data;
using Taller.DTOs;
using Taller.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Taler.Controllers
{

     

    [ApiController]
    [Route ("api/vehiculos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]

    public class VehiculoController:Controller
    {
        private readonly ILogger<VehiculoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public VehiculoController(ILogger<VehiculoController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from Vehículo
        [HttpGet]
        
        public async Task<ActionResult<List<Vehiculo>>> Get()
        {
           
            return await context.Vehiculos.ToListAsync();
            
            
        }

        // Búsqueda por parámetro
        [HttpGet("{Id:int}")]
       
        public async Task<ActionResult<VehiculoDTO>> Get(int Id)
        {

            var vehiculo = await context.Vehiculos.FirstOrDefaultAsync(x => x.Id == Id);


            if (vehiculo == null)
            {


                return NotFound();
            }


            return mapper.Map<VehiculoDTO>(vehiculo);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] VehiculoCreacionDTO vehiculoCreacionDTO)
        {


            var vehiculo = mapper.Map<Vehiculo>(vehiculoCreacionDTO);
            context.Add(vehiculo);
            await context.SaveChangesAsync();
            return NoContent(); //204

        }
          

        [HttpPut("{Id}")]
        
        public async Task<ActionResult> Put(Vehiculo vehiculo, int Id)
        {

            if (vehiculo.Id != Id)
            {
                return BadRequest("la placa no existe");
            }

            var existe = await context.Vehiculos.AnyAsync(x => x.Id == Id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(vehiculo);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete( int Id)
        {

            
            var vehiculo= await context.Vehiculos.FirstOrDefaultAsync(x => x.Id == Id);

            if (vehiculo == null) 
            {

                return NotFound();
            }

            context.Remove(vehiculo);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }





    }

}