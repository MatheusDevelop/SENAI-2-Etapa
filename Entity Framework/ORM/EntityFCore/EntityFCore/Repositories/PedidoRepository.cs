using EntityFCore.Contexts;
using EntityFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Repositories
{
    public class PedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        #region Leitura

        /// <summary>
        /// Return a pedido list of database
        /// </summary>
        /// <returns></returns>
        public List<Pedido> Read()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Pedido SearchForId(Guid id)
        {
            try
            {
                return _ctx.Pedidos.Single(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Pedido> SearchForName(string name)
        {
            try
            {
                return _ctx.Pedidos.Where(c => c.status == name).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação

        /// <summary>
        /// Throw new pedido to database
        /// </summary>
        /// <param name="pedido">Pedido object</param>
        public void Create(Pedido pedido)
        {
            try
            {
                _ctx.Pedidos.Add(pedido);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete pedido in database
        /// </summary>
        /// <param name="pedido">pedido object</param>

        public void Delete(Pedido pedido)
        {
            try
            {
                _ctx.Pedidos.Remove(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Update(Pedido newPedido)
        {
            try
            {
                _ctx.Pedidos.Update(newPedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
