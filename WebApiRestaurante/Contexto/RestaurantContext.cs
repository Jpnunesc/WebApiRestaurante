using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApiRestaurante.Models;

namespace WebApiRestaurante.Content
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base("RestaurantContexto")
        { }

        public IDbSet<Restaurante> Restaurantes { get; set; }
        public IDbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
    

    
}