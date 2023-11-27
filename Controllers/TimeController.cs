using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiBambets.Model;
using apiBambets.Context;

namespace apiBambets.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class TimeController : ControllerBase
    {
        private readonly ILogger<TimeController> _logger;
        private readonly apiBambetsContext _context;
 
        public TimeController(ILogger<TimeController> logger , apiBambetsContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
         public ActionResult<IEnumerable<Time>> Get()
        {
            var times = _context.Times?.ToList(); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.
                if (times is null)
                    return NotFound();

            return times;
        }

        [HttpGet("{id:int}", Name="GetTime")]
        public ActionResult<Time> Get(int id)
        {
            var time = _context.Times?.FirstOrDefault(p => p.Id == id); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.
            if(time is null)
                return NotFound("Não encontrado, parcero");
            return time;
        }

        [HttpPost]
        public ActionResult Post(Time time)
        {
            _context.Times?.Add(time); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetTime",
            new{id = time.Id}, time);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Time time)
        {
            if(id != time.Id)
                return BadRequest();

            _context.Entry(time).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(time);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var time = _context.Times?.FirstOrDefault(p => p.Id == id); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.

            if(time is null)
                return NotFound();

            _context.Times?.Remove(time); // Após "Apostas" tem uma interrogação, pois essa variável pode ser nula, coloquei apenas para nao contar como erro, mais adequado, façam também.
            _context.SaveChanges();

            return Ok(time);
        }
    }
}
