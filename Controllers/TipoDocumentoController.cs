using AutoMapper;
using Taller.Data;
using Taller.DTOs;
using Taller.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Taller.Controllers
{



    [ApiController]
    [Route("api/tipodocumento")]
    public class TipoDocumentoController : Controller
    {
        private readonly ILogger<TipoDocumentoController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoDocumentoController(ILogger<TipoDocumentoController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        //Select * from Tipo Documento
        [HttpGet]
        public async Task<ActionResult<List<TipoDocumento>>> Get()
        {

            return await context.TipoDocumentos.ToListAsync();


        }

        // Búsqueda por parámetro
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<TipoDocumentoDTO>> Get(int Id)
        {

            var tipodocumento = await context.TipoDocumentos.FirstOrDefaultAsync(x => x.Id == Id);


            if (tipodocumento == null)
            {


                return NotFound();
            }


            return mapper.Map<TipoDocumentoDTO>(tipodocumento);

        }


        [HttpPost]

        public async Task<ActionResult> Post([FromBody] TipoDocumentoCreacionDTO tipoDocumentoCreacionDTO)
        {


            var tipodocumento = mapper.Map<TipoDocumento>(tipoDocumentoCreacionDTO);
            context.Add(tipodocumento);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }



        [HttpPut("{Id}")]

        public async Task<ActionResult> Put(TipoDocumento TipoDocumento, int Id)
        {

            if (TipoDocumento.Id != Id)
            {
                return BadRequest("El tipo de documento no existe");
            }

            var existe = await context.TipoDocumentos.AnyAsync(x => x.Id == Id);

            if (!existe)
            {

                return NotFound();



            }

            context.Update(TipoDocumento);
            await context.SaveChangesAsync();
            return Ok(); //200


        }


        [HttpDelete("{Id}")]

        public async Task<ActionResult> Delete(int Id)
        {


            var tipodocumento = await context.TipoDocumentos.FirstOrDefaultAsync(x => x.Id == Id);

            if (tipodocumento == null)
            {

                return NotFound();
            }

            context.Remove(tipodocumento);
            await context.SaveChangesAsync();
            return NoContent(); //204


        }





    }

}