using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFCore.Domains;
using EntityFCore.Interfaces;
using EntityFCore.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedido _pedidoRepository;
        public PedidoController()
        {
            _pedidoRepository = new PedidoRepository();
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public List<Pedido>Get()
        {
            return _pedidoRepository.Read();
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public Pedido Get(Guid id)
        {
            return _pedidoRepository.SearchForId(id);
        }

        // POST api/<PedidoController>
        [HttpPost]
        public void Post(Pedido p)
        {
            _pedidoRepository.Create(p);
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public void Put(Guid id,Pedido p)
        {
            
            _pedidoRepository.AtualizarPedido(id,p);
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _pedidoRepository.Delete(id);
        }
    }
}
