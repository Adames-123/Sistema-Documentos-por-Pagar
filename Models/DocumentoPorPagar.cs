using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Documentos_por_Pagar.Models
{
    public class DocumentoPorPagar

    {
        [Key]
        public int IdDocumento { get; set; }
        public int IdProveedor { get; set; }

        [ForeignKey("IdProveedor")]
        public Proveedor ?Proveedor { get; set; }
        public int IdConcepto { get; set; }

        [ForeignKey("IdConcepto")]
        public Concepto? Concepto { get; set; }
        public decimal Monto { get; set; }
        public string ?NumeroDocumento { get; set; }
        public string? NumeroFactura { get; set; }

        public DateTime ?FechaDocumento { get; set; }
        public DateTime ?FechaRegistro { get; set; }

        public Boolean ? Estado { get; set; }
    }
}
