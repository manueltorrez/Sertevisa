using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Entidades
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar el {0}")]
        [Display(Name = "Primer Nombre")]
        public string Nombre1 { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string Nombre2 { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar el {0}")]
        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }

        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        [Display(Name = "Celular")]
        public int Celular { get; set; }

        public virtual IEnumerable<Factura> Facturas { get; set; }

        public virtual IEnumerable<OrdenEntrada> OrdenEntradas { get; set; }
    }
}
