using System.Data.Entity.ModelConfiguration;
using Data.Entity;

namespace Data.Mapping
{
    public class LogradouroMapping : EntityTypeConfiguration<Logradouro>
    {
        public LogradouroMapping()
        {
            ToTable("Logradouro.dbo");
            Property(x => x.LogradouroId).HasColumnName("LogradouroId").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).IsRequired();
            Property(x => x.LogradouroNome).HasColumnName("LogradouroNome").HasMaxLength(150).IsRequired();
            Property(x => x.ClienteId).HasColumnName("ClienteId").IsRequired();
        }
    }
}
