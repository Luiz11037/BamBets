using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiBambets.Model;
using apiBambets.Context;

namespace apiBambets.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class JogoController : ControllerBase
    {
        private readonly ILogger<JogoController> _logger;
        private readonly apiBambetsContext _context;

        public JogoController(ILogger<JogoController> logger, apiBambetsContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Jogo>> Get()
        {
            var jogos = _context.Jogos?.ToList();
            if(jogos is null)
                return NotFound();
            return jogos;
        }

        [HttpGet("(id:int)", Name ="GetJogo")]
        public ActionResult<Jogo> Get(int id)
        {
            var jogo = _context.Jogos?.FirstOrDefault(p => p.Id == id);
            if(jogo is null)
                return NotFound("Jogo não encontrado");
            return jogo;
        }

        [HttpPost]
        public ActionResult Post(Jogo jogo)
        {
            _context.Jogos?.Add(jogo);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetJogo", new{id = jogo.Id}, jogo);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Jogo jogo){
            if(id != jogo.Id)
            return BadRequest();

            _context.Entry(jogo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(jogo);
        }
        
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id){
            var jogo = _context.Jogos?.FirstOrDefault(p => p.Id == id);
            if(jogo is null)
                return NotFound();
            _context.Jogos?.Remove(jogo);
            _context.SaveChanges();

            return Ok(jogo);
        }
    }
}