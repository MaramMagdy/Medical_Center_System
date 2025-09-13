using Medical_Center_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical_Center_System.Data.Configurations
{
    public class PatientConfigure : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DateOfBirth).HasColumnType("date");
            builder.Property(p => p.Gender).HasMaxLength(20);
            builder.Property(p => p.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.HasOne<ApplicationUser>().WithOne(u => u.Patient).HasForeignKey<Patient>(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
