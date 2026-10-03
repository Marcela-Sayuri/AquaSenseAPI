using AquaSenseAPI.Data;
using AquaSenseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AquaSenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConsumoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(Consumo consumo)
        {
            _context.Consumos.Add(consumo);
            _context.SaveChanges();

            return Ok(consumo);
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = 10)
        {
            var consumos = _context.Consumos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(consumos);
        }
    }
}