using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiBambets.Model;
using apiBambets.Context;
using Microsoft.AspNetCore.Authorization;

namespace apiBambets.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    [ApiVersion("2.0")]
    [ApiController]

    public class ApostadorControllerv2 : ControllerBase
    {
        private readonly ILogger<ApostadorControllerv2> _logger;
        private readonly apiBambetsContext _context;

        public ApostadorControllerv2(ILogger<ApostadorControllerv2> logger, apiBambetsContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "Apostador")]  
        public ActionResult<IEnumerable<Apostador>> Get()
        {
            var apostadores = _context.Apostadores?.ToList();
                if (apostadores is null)
                    return NotFound();
            return apostadores;
        }

        [HttpGet("{id:int}", Name="GetApostador")]  
        public ActionResult<Apostador> Get(int id)
        {
            var apostador = _context.Apostadores?.FirstOrDefault(p => p.Id == id);
            if (apostador is null)
                return NotFound();
            return apostador;
        }

        [HttpPost]
        public ActionResult Post(Apostador apostador)
        {
            _context.Apostadores?.Add(apostador);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetApostador", new{id = apostador.Id}, apostador);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Apostador apostador)
        {
            if(id != apostador.Id)
                return BadRequest();

            _context.Entry(apostador).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(apostador);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var apostador = _context.Apostadores?.FirstOrDefault(p => p.Id == id);

            if(apostador is null)
                return NotFound();

            _context.Apostadores?.Remove(apostador);
            _context.SaveChanges();

            return Ok(apostador);
        }
    }
}