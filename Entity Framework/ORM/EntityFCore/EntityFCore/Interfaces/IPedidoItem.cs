using EntityFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Interfaces
{
    interface IPedidoItem
    {
        public void Create(PedidoItem PedidoItem);
        public List<PedidoItem> Read();
        public PedidoItem SearchForId(Guid id);
        public List<PedidoItem> SearchForName(string name);
        public void Pedido(PedidoItem newPedidoItem);
        public void Delete(PedidoItem PedidoItem);
    }
}
