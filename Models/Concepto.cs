using System.ComponentModel.DataAnnotations;

namespace SistemaCuentasPorPagarAPI.Models
{
    public class Concepto
    {
        [Key]
        public int IdConcepto { get; set; }
        public string? Descripcion { get; set; }
        public Boolean ? Estado { get; set; }
    }
}
