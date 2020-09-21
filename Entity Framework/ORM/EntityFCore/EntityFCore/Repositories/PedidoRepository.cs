using EntityFCore.Contexts;
using EntityFCore.Domains;
using EntityFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Repositories
{
    public class PedidoRepository:IPedido
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
        /// Update pedido in database
        /// </summary>
        /// <param name="id">id of product</param>
        /// <param name="newPedido">new product for updtate</param>
       

        public void AtualizarPedido(Guid id, Pedido newPedido)
        {
            try
            {
                Pedido pedidoTemp = SearchForId(id);
                if (pedidoTemp == null)
                {
                    throw new Exception("Produto não encontrado");
                }
                else
                {
                    pedidoTemp.OrderDate    = newPedido.OrderDate;
                    pedidoTemp.status       = newPedido.status;

                    
                    _ctx.Pedidos.Update(pedidoTemp);
                    _ctx.SaveChanges();
                }



                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Delete pedido in database
        /// 
        /// </summary>
        /// <param name="id">id of product</param>
        public void Delete(Guid id)
        {
            try
            {
                Pedido pedidoTemp = SearchForId(id);
                if (pedidoTemp == null)
                {
                    throw new Exception("Produto não encontrado");
                }
                else
                {
                    _ctx.Pedidos.Remove(pedidoTemp);
                    _ctx.SaveChanges();
                }




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion
    }
}
