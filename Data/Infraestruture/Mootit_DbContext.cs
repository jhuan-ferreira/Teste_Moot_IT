using System.Data.Entity;
using Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Data.Mapping;

namespace Data.Infraestruture
{
    public class Mootit_DbContext : DbContext
    {
        private const string stringConnection = @"Data Source=JHUAN\SQLEXPRESS;Initial Catalog=Teste_Moot;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Mootit_DbContext() : base(stringConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ClienteMapping());
            modelBuilder.Configurations.Add(new LogradouroMapping());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }
    }
}
