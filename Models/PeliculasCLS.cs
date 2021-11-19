using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Desafio_2_DAS_2021.Models
{
    [Table("pelicula")]
    public class PeliculasCLS
    {
        [Key]
        [Display(Name = "ID Pelicula")]
        public int iid_pelicula { get; set; }
        [Display(Name = "Titulo")]
        public string titulo { get; set; }
        [Display(Name = "Sinopsis")]
        public string sinopsis { get; set; }
        [Display(Name = "Director")]
        public string director { get; set; }
        [Display(Name = "Puntuacion")]
        public int puntuacion { get; set; }
        [Display(Name = "Nombre poster")]
        public string poster_name { get; set; }
        [Display(Name = "Poster")]
        public byte[] poster { get; set; }

        public String posterRecuperarImagen { get; set; }
    }
}