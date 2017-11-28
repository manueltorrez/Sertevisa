using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    [Table("Desglose")]
    public class Desglose
    {
        [Key]
        public int DesgloseId { get; set; }

        [Required(ErrorMessage = "Se requiere la {0}")]
        [Display(Name = "Factura")]
        public int FacturaId { get; set; }

        [Required(ErrorMessage = "Se requiere la {0}")]
        [Display(Name = "Moneda")]
        [MaxLength(4), MinLength(3)]
        public string Moneda { get; set; }

        [Required(ErrorMessage = "Se requiere la {0}")]
        [Display(Name = "Valor")]
        public int Valor { get; set; }

        [Required(ErrorMessage = "Se requiere la {0}")]
        [Display(Name = "Tasa de Cambio")]
        public int TasaCambio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateCreation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateModification { get; set; }

        [ScaffoldColumn(false)]
        [Timestamp]
        public byte[] Control { get; set; }

        [ForeignKey("FacturaId")]
        public virtual Factura Facturas { get; set; }

    }
}
