using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiBambets.Model;
using apiBambets.Context;
using Microsoft.AspNetCore.Authorization;

namespace apiBambets.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/{v:apiversion}/aposta")]
    [ApiVersion("2.0")]
    [ApiController]

    public class ApostaControllerv2 : ControllerBase
    {
        private readonly ILogger<ApostaControllerv2> _logger;
        private readonly apiBambetsContext _context;
 
        public ApostaControllerv2(ILogger<ApostaControllerv2> logger , apiBambetsContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
         public ActionResult<IEnumerable<Aposta>> Get()
        {
            var apostas = _context.Apostas?.ToList(); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.
                if (apostas is null)
                    return NotFound();

            return apostas;
        }

        [HttpGet("{id:int}", Name="GetAPosta")]
        public ActionResult<Aposta> Get(int id)
        {
            var aposta = _context.Apostas?.FirstOrDefault(p => p.Id == id); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.
            if(aposta is null)
                return NotFound("Não encontrado, parcero");
            return aposta;
        }

        [HttpPost]
        public ActionResult Post(Aposta aposta)
        {
            _context.Apostas?.Add(aposta); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetAposta",
            new{id = aposta.Id}, aposta);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Aposta aposta)
        {
            if(id != aposta.Id)
                return BadRequest();

            _context.Entry(aposta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(aposta);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var aposta = _context.Apostas?.FirstOrDefault(p => p.Id == id); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.

            if(aposta is null)
                return NotFound();

            _context.Apostas?.Remove(aposta); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.
            _context.SaveChanges();

            return Ok(aposta);
        }
    }
}
