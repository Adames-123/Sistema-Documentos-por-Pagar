using System.ComponentModel.DataAnnotations;

namespace SistemaCuentasPorPagarAPI.Models
{
    public class Proveedor
    {
        [Key]
        public  int IdProveedor { get; set; }
        public string ?Nombre { get; set; }
        public string ?TipoPersona { get; set; }
        public string ?CedulaRNC { get; set; }
        public decimal ?Balance { get; set; }
        public Boolean ?Estado { get; set; }


    }
}
