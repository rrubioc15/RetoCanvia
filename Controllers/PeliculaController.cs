using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiCanvia.Data;
using WebApiCanvia.Models;

namespace WebApiCanvia.Controllers
{
    public class PeliculaController : ApiController
    {
        public List<Pelicula> Get()
        {
            return PeliculaData.Listar();
        }


        [Route("api/pelicula/{id}/{id2}")]
        public List<Pelicula> Get(int id, int id2)
        {
            return PeliculaData.Paginar(id, id2);
        }


        // GET api/<controller>/5
        public Pelicula Get(int id)
        {
            return PeliculaData.Obtener(id);
        }


        // POST api/<controller>
        public bool Post([FromBody] Pelicula oPelicula)
        {
            return PeliculaData.Registrar(oPelicula);
        }


        // PUT api/<controller>/5
        public bool Put([FromBody] Pelicula oPelicula)
        {
            return PeliculaData.Modificar(oPelicula);
        }


        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return PeliculaData.Eliminar(id);
        }


        //PATCH api/<controller>
        public bool Patch(int id)
        {
            return PeliculaData.Desactivar(id);
        }


        //POST
        [Route("api/pelicula/activar/{id}")]
        public bool Activar(int id)
        {
            return PeliculaData.Activar(id);
        }
    }
}