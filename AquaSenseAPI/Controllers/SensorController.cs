using AquaSenseAPI.Data;
using AquaSenseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AquaSenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SensorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = 10)
        {
            var sensores = _context.Sensores
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(sensores);
        }

        [HttpPost]
        public IActionResult Post(Sensor sensor)
        {
            _context.Sensores.Add(sensor);
            _context.SaveChanges();

            return Ok(sensor);
        }
    }
}