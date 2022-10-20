using AutoMapper;
using Taller.Data;
using Taller.DTOs;
using Taller.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
//using System.Text.RegularExpressions;

namespace Taller.Controllers
{



    [ApiController]
    [Route ("api/procedimientos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
    public class ProcedimientoController:Controller
    {
        private readonly ILogger<ProcedimientoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProcedimientoController(ILogger<ProcedimientoController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from Procedimientos
        [HttpGet]

        public async Task<ActionResult<List<Procedimiento>>> Get()
        {
           
            return await context.Procedimientos.ToListAsync();
            

        }

        // Búsqueda por parámetro
        [HttpGet("{Id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProcedimientoDTO>> Get(int Id)
        {

            var procedimiento = await context.Procedimientos.FirstOrDefaultAsync(x => x.Id == Id);


            if (procedimiento == null)
            {


                return NotFound();
            }


            
            return mapper.Map<ProcedimientoDTO>(procedimiento);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody]ProcedimientoCreacionDTO procedimientoCreacionDTO)
        {


            var procedimiento=mapper.Map<Procedimiento>(procedimientoCreacionDTO);
            context.Add(procedimiento);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{Id}")]

        public async Task<ActionResult> Put(Procedimiento procedimiento,int Id)
        {

            if(procedimiento.Id != Id)
            {
                return BadRequest("El procedimiento no existe");
}

            var existe =await context.Procedimientos.AnyAsync(x => x.Id == Id); 

            if(!existe)
            {

                return NotFound();



            }

            context.Update(procedimiento);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete( int Id)
        {

            
            var procedimiento= await context.Procedimientos.FirstOrDefaultAsync(x => x.Id == Id);

            if (procedimiento == null) 
            {

                return NotFound();
            }

            context.Remove(procedimiento);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }





    }

}