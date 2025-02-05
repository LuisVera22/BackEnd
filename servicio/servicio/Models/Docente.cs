﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicio.Models
{
    public class Docente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [Required]
        [MaxLength(20)]
        public string Dni { get; set; }

        [Required]
        [MaxLength(100)]
        public string Especialidad { get; set; }

        public bool Estado { get; set; } 

        // Relación con AsignaciónDocente
        public ICollection<AsignacionDocente> Asignaciones { get; set; } = new List<AsignacionDocente>();
      }
    }