using EntityFCore.Contexts;
using EntityFCore.Domains;
using EntityFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Repositories
{
    public class ProdutoRepository : IProduto
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        #region Leitura

        /// <summary>
        /// Return a product list of database
        /// </summary>
        /// <returns></returns>
        public List<Produto> Read()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Produto SearchForId(Guid id)
        {
            try
            {
                return _ctx.Produtos.Single(c=> c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Produto> SearchForName(string name)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome == name).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação

        /// <summary>
        /// Throw new product to database
        /// </summary>
        /// <param name="product">Produto object</param>
        public void Create(Produto product)
        {
            try
            {
                _ctx.Produtos.Add(product);
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delete product in database
        /// </summary>
        /// <param name="product">Produto object</param>

        public void Delete(Produto product)
        {
            try
            {
                _ctx.Produtos.Remove(product);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Update(Produto newProduct)
        {
            try
            {
                _ctx.Produtos.Update(newProduct);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
