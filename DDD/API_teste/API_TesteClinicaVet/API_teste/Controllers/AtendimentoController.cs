using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoController : ControllerBase
    {
        // GET: api/<AtendimentoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "primeiro json", "value2" };
        }

        // GET api/<AtendimentoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/<AtendimentoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AtendimentoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AtendimentoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
