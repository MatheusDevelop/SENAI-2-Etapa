using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ClinicaVet.Domains;
using API_ClinicaVet.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ClinicaVet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {

        TipoRepository rep = new TipoRepository();



        // GET: api/<TipoController>
        [HttpGet]
        public List<Tipo> Get()
        {
            return rep.ReadAll();
        }

        // GET api/<TipoController>/5
        [HttpGet("{id}")]
        public Tipo Get(int id)
        {
            return rep.SearchForId(id);
        }

        // POST api/<TipoController>
        [HttpPost]
        public List<Tipo> Post(Tipo t)
        {
            return rep.Create(t);
        }

        // PUT api/<TipoController>/5
        [HttpPut("{id}")]
        public List<Tipo> Put(int id, Tipo t )
        {
            return rep.Update(id, t);
        }

        // DELETE api/<TipoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rep.Delete(id);

        }
    }
}
