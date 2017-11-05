using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    
    public class Marca
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage = "Se requiere el {0}")]
        [Display(Name = "Nombre")]
        [MaxLength(20)]
        public string Nombre { get; set; }

        public virtual IEnumerable<Equipo> Equipos { get; set; }
    }
}
