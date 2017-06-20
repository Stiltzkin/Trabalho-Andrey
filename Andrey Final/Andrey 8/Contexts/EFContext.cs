using Andrey_8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Andrey_8.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
            new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Cobertura> Coberturas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cadastro> Cadastros { get; set; }
    }
}
