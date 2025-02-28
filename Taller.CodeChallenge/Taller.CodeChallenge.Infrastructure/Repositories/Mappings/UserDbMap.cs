using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taller.CodeChallenge.Domain.Entities;

namespace Taller.CodeChallenge.Infrastructure.Repositories.Mappings
{    
    public class UserDbMap : IEntityTypeConfiguration<Users>
    {
        const string tableName = "users";

        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable(tableName);

            builder.HasKey(c => c.Id)
                .HasName($"pk_{tableName}");

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName($"id_{tableName}");

            builder.Property(c => c.UserName)
                .HasColumnName("desc_username");
        }
    }
}
