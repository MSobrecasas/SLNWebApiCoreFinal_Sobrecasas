using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Sobrecasas.Data;
using SWProvincias_Sobrecasas.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Sobrecasas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly DBPaisFinalContext context;

        public CiudadController(DBPaisFinalContext context)
        {
            this.context = context;
        }

        //GET: api/ciudad
        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();
        }

        // POST : api/ciudad
        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();
        }

        //PUT: api/ciudad/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }
            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        //DELETE: api/ciudad/{id}
        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            Ciudad ciudad = (from c in context.Ciudades
                             where c.IdCiudad == id
                                   select c).SingleOrDefault();
            if (ciudad == null)
            {
                return NotFound();
            }
            context.Ciudades.Remove(ciudad);
            context.SaveChanges();
            return ciudad;
        }
    }
}
