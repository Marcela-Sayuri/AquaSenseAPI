using AquaSenseAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaSenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _service;

        public RelatorioController(IRelatorioService service)
        {
            _service = service;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            var dashboard = _service.ObterDashboard();

            return Ok(dashboard);
        }
    }
}