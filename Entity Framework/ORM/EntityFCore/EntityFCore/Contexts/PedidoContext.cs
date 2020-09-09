﻿using EntityFCore.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFCore.Contexts
{
    public class PedidoContext:DbContext
    {
        //Domains
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)   
            {
                optionsBuilder.UseSqlServer(@"DataSrc=.\Sqlexpress;Initial Catalog = EntityFCore ;user id = sa;password = sa132");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
