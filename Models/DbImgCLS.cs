using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Desafio_2_DAS_2021.Models
{
    public class DbImgCLS
    {
        public DbSet<pelicula> imagen { get; set; }
    }
}