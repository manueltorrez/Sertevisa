﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.Entidades
{
    public class Equipo
    {
        [Key]
        public int EquipoId { get; set; }

        [Required(ErrorMessage = "Se requiere seleccionar la {0}")]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Se requiere el {0}")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [ForeignKey("MarcaId")]
        public virtual Marca Marcas { get; set; }
    }
}