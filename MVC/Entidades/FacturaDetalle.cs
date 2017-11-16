    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    [Table("FacturaDetalle")]
    public class FacturaDetalle
    {
        [Key]
        public int FacturaDetalleId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar el {0}")]
        [Display(Name = "Factura")]
        public int FacturaId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar la {0}")]
        [Display(Name = "Orden de Entrada")]
        public int OrdenEntradaId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar la {0}")]
        [Display(Name = "Descripción")]
        [MaxLength(70)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar el {0}")]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateCreation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateModification { get; set; }

        [ForeignKey("FacturaId")]
        public virtual Factura Facturas { get; set; }

        [ScaffoldColumn(false)]
        [Timestamp]
        public byte[] Control { get; set; }

        [ForeignKey("OrdenEntradaId")]
        public virtual OrdenEntrada OrdenEntradas { get; set; }
    }
}
