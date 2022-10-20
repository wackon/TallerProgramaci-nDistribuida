using AutoMapper;
using Taller.Data;
using Taller.DTOs;
using Taller.Entidades;
using Taller.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Taller.Controllers
{



    [ApiController]
    [Route ("api/imagenvehiculo")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class ImagenVehiculoController:Controller
    {
        private readonly ILogger<ImagenVehiculoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "Files";

        public ImagenVehiculoController(ILogger<ImagenVehiculoController> logger, ApplicationDbContext context, IMapper mapper,
             IAlmacenadorArchivos almacenadorArchivos)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }


        //Select * from Imagen Vehículo
        [HttpGet]
        public async Task<ActionResult<List<ImagenVehiculoDTO>>> Get()
        {
            var entidades  = await context.ImagenVehiculos.ToListAsync();
           
            return  mapper.Map<List<ImagenVehiculoDTO>>(entidades);


            

        }

        // Búsqueda por parámetro
        [HttpGet("{Id:Int}")]
        public async Task<ActionResult<ImagenVehiculoDTO>> Get(int Id)
        {

            var imagen = await context.ImagenVehiculos.FirstOrDefaultAsync(x => x.Id == Id);


            if (imagen == null)
            {


                return NotFound();
            }


            return mapper.Map<ImagenVehiculoDTO>(imagen);

        }


        [HttpPost]//401
        
        
        public async Task<ActionResult> Post([FromForm] ImagenVehiculoCreacionDTO imagenVehiculoCreacionDTO)
        {

            var archivos = mapper.Map<ImagenVehiculo>(imagenVehiculoCreacionDTO);

            if (imagenVehiculoCreacionDTO.Foto != null)
            {

                archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, imagenVehiculoCreacionDTO.Foto);

            }


            context.Add(archivos);
            await context.SaveChangesAsync();

            return NoContent();




        }



        [HttpPut("{id}")]

        public async Task<ActionResult> Put(ImagenVehiculo imagenVehiculo, int id)
        {

            if (imagenVehiculo.Id != id)
            {
                return BadRequest("La imagen no existe");
            }

            var existe = await context.ImagenVehiculos.AnyAsync(x => x.Id == id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(imagenVehiculo);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete( int Id)
        {

            
            var imagen= await context.ImagenVehiculos.FirstOrDefaultAsync(x => x.Id == Id);

            if (imagen == null) 
            {

                return NotFound();
            }

            context.Remove(imagen);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }





    }

}