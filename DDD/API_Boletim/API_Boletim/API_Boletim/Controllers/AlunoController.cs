using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Boletim.Domains;
using API_Boletim.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Boletim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        //Chamar o Repository para manipular 
        AlunoRepository repositorio = new AlunoRepository();
        
        
        // GET: api/<AlunoController>
        [HttpGet]
        public List<Aluno> Get()
        {

            return repositorio.ReadAll();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return repositorio.SearchForId(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public void Post(Aluno a)
        {
            repositorio.Create(a);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public Aluno Put(int id, Aluno a)
        {
            return repositorio.Update(id,a);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repositorio.Delete(id);
        }
    }
}
