using AquaSenseAPI.Repositories;
using AquaSenseAPI.ViewModels;

namespace AquaSenseAPI.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _repository;

        public RelatorioService(IRelatorioRepository repository)
        {
            _repository = repository;
        }

        public RelatorioViewModel ObterDashboard()
        {
            return _repository.ObterDashboard();
        }
    }
}