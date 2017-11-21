using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    [Table("Estado")]
    public class Estado
    {

        //Estado()
        //{
        //    Activo = true;
        //}

        public int ID { get; set; }
        
        [Index("Index_Estado_Descripcion", IsUnique = true)]
        [Required(ErrorMessage = "Se requiere seleccionar la {0}")]
        [Display(Name = "Descripción")]
        [MaxLength(35)]
        public string Descripcion { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

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

        public virtual IEnumerable<OrdenEntrada> OrdenEntrada { get; set; }
    }
}
