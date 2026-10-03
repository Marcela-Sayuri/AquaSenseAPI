using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AquaSenseAPI.Models
{
    public class Consumo
    {
        public int Id { get; set; }

        [Required]
        public int SensorId { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal QuantidadeLitros { get; set; }

        public DateTime DataRegistro { get; set; }
    }
}