using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Entities;

namespace API.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x=> x.Id);

            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasMaxLength(80).HasColumnName("Nome").HasColumnType("NVARCHAR").IsRequired();
            builder.Property(x => x.Sobrenome).HasMaxLength(128).HasColumnName("Sobrenome").HasColumnType("NVARCHAR").IsRequired();
            builder.Property(x => x.Cpf).HasMaxLength(11).HasColumnName("CPF").HasColumnType("VARCHAR").IsRequired();

            builder.HasIndex(x => x.Cpf, "IX_User_CPF");
        }
    }
}
