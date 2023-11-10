using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiBambets.Model;

namespace apiBambets.Controllers;

[Route("[controller]")]
[ApiController]
public class JogoController : ControllerBase
{
    private readonly ILogger<Jogo> _logger;
    public JogoController(ILogger<Jogo> logger)
    {
        _logger = logger;
    }
    // adicionando incrementador dos Ids.
    private int nextId = 1;


    [HttpGet(Name = "Jogo")]

    // Esse public precisa especificar o tipo que será retornado, nesse caso o tipo é uma List<Jogo>
    public List<Jogo> GetJogo()
    {

        //Criando uma lista de jogadores
        List<Apostador> apostadores1 = new List<Apostador>();
        apostadores1.Add(new Apostador{
            Nome = "Sivirino",
            Numero = 999999999,
            Palpite = "Fogão",
        });

        apostadores1.Add(new Apostador{
            Nome = "Vitinho",
            Numero = 999999999,
            Palpite = "Porco",
        });

        apostadores1.Add(new Apostador{
            Nome = "Carlos",
            Numero = 999999999,
            Palpite = "Mengão",
        });


        //Criando a lista de jogos
        List<Jogo> JogoList = new List<Jogo>();
        //Adicionando objetos em JogoList
        JogoList.Add(new Jogo{
        Id = nextId++,
        Time1="Flamengo",
        Time2="Fluminense",
        apostadores_jogo = apostadores1,
        });

        JogoList.Add(new Jogo{
        Id = nextId++,
        Time1="Corinthians",
        Time2="Palmeiras",
        apostadores_jogo = apostadores1
        });

        JogoList.Add(new Jogo{
        Id = nextId++,
        Time1="Santos",
        Time2="São Paulo",
        apostadores_jogo = apostadores1,
        });

        return JogoList;
    }
    
    [HttpPost(Name ="JogoP")]
    public IActionResult CreateJogo( Jogo jogo)
    {       {
                return Ok();
            }
    }
}