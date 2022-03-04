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
    public class UsuarioController : ApiController
    {
        // GET api/<controller>
        public List<Usuario> Get()
        {
            return UsuarioData.Listar();
        }


        [Route("api/usuario/{id}/{id2}")]
        public List<Usuario> Get(int id, int id2)
        {
            return UsuarioData.Paginar(id,id2);
        }


        // GET api/<controller>/5
        public Usuario Get(int id)
        {
            return UsuarioData.Obtener(id);
        }


        // POST api/<controller>
        public bool Post([FromBody] Usuario oUsuario)
        {
            return UsuarioData.Registrar(oUsuario);
        }


        // PUT api/<controller>/5
        public bool Put([FromBody] Usuario oUsuario)
        {
            return UsuarioData.Modificar(oUsuario);
        }
       

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return UsuarioData.Eliminar(id);
        }


        //PATCH api/<controller>
        public bool Patch(int id)
        {
            return UsuarioData.Desactivar(id);
        }


        //POST
        [Route("api/usuario/activar/{id}")]
        public bool Activar(int id)
        {
            return UsuarioData.Activar(id);
        }

    }
}