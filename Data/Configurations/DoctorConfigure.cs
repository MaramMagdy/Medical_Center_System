using Medical_Center_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Medical_Center_System.Data.Configurations
{
    public class DoctorConfigure : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Bio).HasMaxLength(2000);
            builder.Property(d => d.ClinicAddress).HasMaxLength(500);
            builder.Property(d => d.ConsultationFee).HasColumnType("decimal(12,2)").HasDefaultValue(0m);
            builder.Property(d => d.YearsOfExperience).HasDefaultValue(0);
            builder.Property(d => d.AverageRating).HasColumnType("float").HasDefaultValue(0.0);
            builder.Property(d => d.RatingCount).HasDefaultValue(0);
            builder.Property(d => d.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.HasOne(d => d.User)
                 .WithOne(u => u.Doctor)
                 .HasForeignKey<Doctor>(d => d.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Specialty)
                 .WithMany(s => s.Doctors)
                 .HasForeignKey(d => d.SpecialtyId)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(d => d.SpecialtyId);
            builder.HasIndex(d => new { d.AverageRating, d.RatingCount });
        }
    }
}
