using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    [Table("OrdenEntrada")]
    public class OrdenEntrada
    {
        [Key]
        public int OrdenEntradaId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar el {0}")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar el {0} del equipo")]
        [Display(Name = "Número de Serie")]
        public int NumeroSerie { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar la {0}")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Descripcion Técnica")]
        public string DescripcionTecnica { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime FechaIngreso { get; set; }

        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public int FechaEgreso { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateCreation { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ScaffoldColumn(false)]
        public DateTime DateModification { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Clientes { get; set; }

        public virtual Marca Marcas { get; set; }

        [ForeignKey("AdelantoId")]
        public IEnumerable<Adelanto> Adelantos { get; set; }

        public virtual IEnumerable<FacturaDetalle> FacturaDetalles { get; set; }

        public virtual Estado Estado { get; set; }
    }
}
