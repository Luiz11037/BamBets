using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bambets.Models;

namespace Bambets.Controllers;

[Route("[controller]")]
[ApiController]

public class ApostaController : ControllerBase
{
    private readonly ILogger<Aposta> _logger;
    public ApostaController(ILogger<Aposta> logger)
    {
        _logger = logger;
    }

    private int nextId = 1;

    [HttpGet(Name = "ApostaG")]

    public List<Aposta> GetAposta()
    {
        List<Aposta> ApostaList = new List<Aposta>();
        
        ApostaList.Add(new Aposta{
            Id = nextId++,
            Valor = 20,
            Time_apostado = "Flamengo",
        });

        ApostaList.Add(new Aposta{
            Id = nextId++,
            Valor = 10,
            Time_apostado = "Corinthians",
        });

        ApostaList.Add(new Aposta{
            Id = nextId++,
            Valor = 5,
            Time_apostado = "Santos",
        });

        return ApostaList;
    }

    [HttpPost(Name ="ApostaP")]

    public IActionResult CreateAposta([FromBody] Aposta aposta)
    {       {
                return Ok();
            }
    }
}