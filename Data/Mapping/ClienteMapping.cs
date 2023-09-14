using System.Data.Entity.ModelConfiguration;
using Data.Entity;

namespace Data.Mapping
{
    public class ClienteMapping : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapping()
        {
            ToTable("Cliente.dbo");
            Property(x => x.ClienteId).HasColumnName("ClienteId").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).IsRequired();
            Property(X => X.Nome).HasColumnName("Nome").IsRequired().HasMaxLength(150);
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(150);
            Property(x => x.Logotipo).HasColumnName("Logotipo").IsRequired().HasMaxLength(150);
        }
    }
}
