using GraphqlEntity.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphqlEntity.Core.EF.Context
{
    public class GraphqlEntityContext : DbContext
    {
        public GraphqlEntityContext(DbContextOptions<GraphqlEntityContext> options)
           : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<User> User { get; set; }
       public DbSet<Time> Time { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
