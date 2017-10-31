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
        Estado()
        {
            Activo = false;
        }

        [Key]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar la {0}")]
        [Display(Name = "Descripción")]
        public string Descripción { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        public virtual IEnumerable<OrdenEntrada> OrdenEntrada { get; set; }
    }
}
