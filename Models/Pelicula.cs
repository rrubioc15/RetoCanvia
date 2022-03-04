using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCanvia.Models
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public string Director { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Byte Estado { get; set; }
    }
}