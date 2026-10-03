using AquaSenseAPI.ViewModels;

namespace AquaSenseAPI.Repositories
{
    public interface IRelatorioRepository
    {
        RelatorioViewModel ObterDashboard();
    }
}