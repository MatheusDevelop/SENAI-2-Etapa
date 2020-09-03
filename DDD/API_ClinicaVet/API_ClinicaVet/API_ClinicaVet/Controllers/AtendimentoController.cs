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
    public class AtendimentoController : ControllerBase
    {
        AtendimentoRepository rep = new AtendimentoRepository();





        // GET: api/<AtendimentoController>
        [HttpGet]
        public List<Atendimento> Get()
        {
            return rep.ReadAll() ;
        }

        // GET api/<AtendimentoController>/5
        [HttpGet("{id}")]
        public Atendimento Get(int id)
        {
            return rep.SearchForId(id);
        }

        // POST api/<AtendimentoController>
        [HttpPost]
        public List<Atendimento> Post(Atendimento a )
        {
            return rep.Create(a);
        }

        // PUT api/<AtendimentoController>/5
        [HttpPut("{id}")]
        public List<Atendimento> Put(int id, Atendimento a )
        {
            return rep.Update(id,a);
        }

        // DELETE api/<AtendimentoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)  
        {
            rep.Delete(id);
        }
    }
}
