using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    [Table("Marcas")]
    public class Marca
    {
        
        public int ID { get; set; }

        [Index("Index_Marca_Nombre", IsUnique =true)]
        [Required(ErrorMessage = "Se requiere el {0}")]
        [Display(Name = "Nombre")]
        [MaxLength(20)]
        public string Nombre { get; set; }

        //Campos de control
        [Display(Name = "Activo")]
        public bool Active { get; set; }

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

        public virtual IEnumerable<Equipo> Equipos { get; set; }
    }
}
