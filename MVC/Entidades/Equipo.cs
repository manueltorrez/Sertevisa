using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Entidades
{
    [Table("Equipo")]
    public class Equipo
    {
        [Key]
        public int EquipoId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar la {0}")]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Se requiere el {0}")]
        [Display(Name = "Modelo")]
        [MaxLength(25)]
        public string Modelo { get; set; }

        [ForeignKey("MarcaId")]
        public virtual Marca Marcas { get; set; }

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

        public virtual IEnumerable<OrdenEntrada> OrdenEntradas { get; set; }
    }
}