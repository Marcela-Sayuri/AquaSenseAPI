using AquaSenseAPI.Data;
using AquaSenseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AquaSenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VazamentoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VazamentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(Vazamento vazamento)
        {
            _context.Vazamentos.Add(vazamento);
            _context.SaveChanges();

            return Ok(vazamento);
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = 10)
        {
            var vazamentos = _context.Vazamentos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(vazamentos);
        }

        [HttpPost("analisar")]
        public IActionResult Analisar(decimal consumoAtual)
        {
            if (consumoAtual > 500)
            {
                return Ok(new
                {
                    risco = "ALTO",
                    mensagem = "Possível vazamento detectado."
                });
            }

            return Ok(new
            {
                risco = "BAIXO",
                mensagem = "Consumo dentro do esperado."
            });
        }
    }
}
