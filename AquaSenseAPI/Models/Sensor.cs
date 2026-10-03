using System.ComponentModel.DataAnnotations;

namespace AquaSenseAPI.Models
{
    public class Sensor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200)]
        public string Localizacao { get; set; }

        public bool Ativo { get; set; }
    }
}