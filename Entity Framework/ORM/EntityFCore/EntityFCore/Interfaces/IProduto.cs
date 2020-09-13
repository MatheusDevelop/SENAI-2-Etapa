using EntityFCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Interfaces
{
    interface IProduto
    {
        public void Create(Produto product);
        public List<Produto> Read();
        public Produto SearchForId(Guid id);
        public List<Produto> SearchForName(string name);
        public void Update(Produto newProduct);
        public void Delete(Produto product);


    }
}
