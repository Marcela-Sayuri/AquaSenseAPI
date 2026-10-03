using System.ComponentModel.DataAnnotations;

namespace AquaSenseAPI.Models
{
    public class Vazamento
    {
        public int Id { get; set; }

        public int SensorId { get; set; }

        public string NivelRisco { get; set; }

        public string Descricao { get; set; }

        public DateTime DataDeteccao { get; set; }
    }
}