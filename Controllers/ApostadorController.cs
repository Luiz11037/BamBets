using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bambets.Models;

namespace Bambets.Controllers;

[Route("[controller]")]
[ApiController]

public class ApostadorController : ControllerBase
{
    private readonly ILogger<Apostador> _logger;
    public ApostadorController(ILogger<Apostador> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Apostador")]  

    public List<Apostador> GetApostador()
    {
        List<Apostador> ApostadorList = new List<Apostador>();

        ApostadorList.Add(new Apostador{
                Nome = "Valderci",
                Numero = 999999999,
                Palpite = 1,
            });

            ApostadorList.Add(new Apostador{
                Nome = "Miltão",
                Numero = 999999999,
                Palpite = 2,
            });

            ApostadorList.Add(new Apostador{
                Nome = "Marquitos",
                Numero = 999999999,
                Palpite = 2,
            });

            return ApostadorList;       
    }

    [HttpPost(Name="ApostadorP")]
    public IActionResult CreateApostador([FromBody] Apostador apostador)
    {       {
                return Ok();
            }
    }
}