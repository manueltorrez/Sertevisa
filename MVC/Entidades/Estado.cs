using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    
    public class Estado
    {

        public int ID { get; set; }
        //Estado()
        //{
        //    Activo = false;
        //}
        [Required(ErrorMessage = "Se requiere seleccionar la {0}")]
        [Display(Name = "Descripción")]
        [MaxLength(35)]
        public string Descripcion { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        public byte Control { get; set; }

        public virtual IEnumerable<OrdenEntrada> OrdenEntrada { get; set; }
    }
}
