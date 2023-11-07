using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiBambets.Model;
using apiBambets.Context;

namespace apiBambets.Controllers;

[Route("[controller]")]
[ApiController]

public class ApostaController : ControllerBase
{
    private readonly ILogger<ApostaController> _logger;
        private readonly apiBambetsContext _context;
 
    public ApostaController(ILogger<ApostaController> logger , apiBambetsContext context)
       {
        _logger = logger;
        _context = context;
       }

    [HttpGet]
        public ActionResult<IEnumerable<Aposta>> Get()
        {
            var apostas = _context.Apostas.ToList();
                if (apostas is null)
                    return NotFound();

            return apostas;
        }

        [HttpGet("{id:int}", Name="GetAPosta")]
        public ActionResult<Aposta> Get(int id)
        {
            var aposta = _context.Apostas.FirstOrDefault(p => p.Id == id);
            if(aposta is null)
                return NotFound("Não encontrado, parcero");
            return aposta;
        }
}