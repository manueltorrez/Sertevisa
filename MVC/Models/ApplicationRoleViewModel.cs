using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class ApplicationRoleViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar el nombre del Rol")]
        [StringLength(30, ErrorMessage = "El nombre del rol debe ser de 30 caracteres o menos")]
        [Display(Name = "Nombre del rol")]
        public string Name { get; set; }

    }
}