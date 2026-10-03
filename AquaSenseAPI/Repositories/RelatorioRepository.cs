using AquaSenseAPI.Data;
using AquaSenseAPI.ViewModels;

namespace AquaSenseAPI.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ApplicationDbContext _context;

        public RelatorioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RelatorioViewModel ObterDashboard()
        {
            return new RelatorioViewModel
            {
                ConsumoTotal = _context.Consumos.Sum(c => c.QuantidadeLitros),
                SensoresAtivos = _context.Sensores.Count(s => s.Ativo)
            };
        }
    }
}