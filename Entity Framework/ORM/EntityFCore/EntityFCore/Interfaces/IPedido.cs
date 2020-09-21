using EntityFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Interfaces
{
    interface IPedido
    {
        public void Create(Pedido pedido);
        public List<Pedido> Read();
        public Pedido SearchForId(Guid id);
        public List<Pedido> SearchForName(string name);
        public void AtualizarPedido(Guid id, Pedido newPedido);
        public void Delete(Guid id);
    }
}
