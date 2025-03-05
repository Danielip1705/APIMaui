using ENT;
using DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public List<Personas> Get()
        {

            return ManejadoraPersonas.ListarPersonas();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public Personas Get(int id)
        {
            return ManejadoraPersonas.BuscarPersonaPorId(id);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] Personas per)
        {
            ManejadoraPersonas.CrearPersona(per.Id, per.Nombre, per.Direccion);
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Personas per)
        {
            ManejadoraPersonas.ActualizarPersona(id, per.Nombre, per.Direccion);
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ManejadoraPersonas.EliminarPersona(id);
        }
    }
}
