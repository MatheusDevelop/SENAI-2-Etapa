using EntityFCore.Contexts;
using EntityFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Repositories
{
    public class PedidoItemRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoItemRepository()
        {
            _ctx = new PedidoContext();
        }

        #region Leitura

        /// <summary>
        /// Return a pedido list of database
        /// </summary>
        /// <returns></returns>
        public List<PedidoItem> Read()
        {
            try
            {
                return _ctx.PedidosItens.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public PedidoItem SearchForId(Guid id)
        {
            try
            {
                return _ctx.PedidosItens.Single(c => c.Id == id);
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
        public void Create(PedidoItem pedido)
        {
            try
            {
                _ctx.PedidosItens.Add(pedido);
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

        public void Delete(PedidoItem pedido)
        {
            try
            {
                _ctx.PedidosItens.Remove(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Update(PedidoItem newPedido)
        {
            try
            {
                _ctx.PedidosItens.Update(newPedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
