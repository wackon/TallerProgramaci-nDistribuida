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
    [Route ("api/marcas")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]

    public class MarcaController:Controller
    {
        private readonly ILogger<MarcaController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MarcaController(ILogger<MarcaController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from marcas
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Marca>>> Get()
        {
           
            return await context.Marcas.ToListAsync();
            

        }

        // Búsqueda por parámetro
        [HttpGet("{Id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<MarcaDTO>> Get(int Id)
        {

            var marca = await context.Marcas.FirstOrDefaultAsync(x => x.Id == Id);


            if (marca == null)
            {


                return NotFound();
            }


            return mapper.Map<MarcaDTO>(marca);

        }


        [HttpPost]
        

        public async Task<ActionResult> Post([FromBody]MarcaCreacionDTO marcaCreacionDTO)
        {


            var marca=mapper.Map<Marca>(marcaCreacionDTO);
            context.Add(marca);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }

        

        [HttpPut("{Id}")]
        

        public async Task<ActionResult> Put(Marca marca,int Id)
        {

            if(marca.Id != Id)
            {
                return BadRequest("la marca no existe");
}

            var existe =await context.Marcas.AnyAsync(x => x.Id == Id); 

            if(!existe)
            {

                return NotFound();



            }

            context.Update(marca);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{Id}")]
       
        public async Task<ActionResult> Delete( int Id)
        {

            
            var marca= await context.Marcas.FirstOrDefaultAsync(x => x.Id == Id);

            if (marca == null) 
            {

                return NotFound();
            }

            context.Remove(marca);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }





    }

}