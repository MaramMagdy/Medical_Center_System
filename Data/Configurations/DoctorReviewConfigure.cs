using Medical_Center_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical_Center_System.Data.Configurations
{
    public class DoctorReviewConfigure : IEntityTypeConfiguration<DoctorReview>
    {
        public void Configure (EntityTypeBuilder<DoctorReview> builder)
        {
           builder.HasKey(r => r.Id);
           builder.Property(r => r.Stars).IsRequired();
           builder.Property(r => r.Comment).HasColumnType("nvarchar(1000)");
           builder.Property(r => r.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
           builder.HasOne(r => r.Doctor).WithMany(d => d.Reviews).HasForeignKey(r => r.DoctorId).OnDelete(DeleteBehavior.Cascade);
           builder.HasOne(r => r.Patient).WithMany(p => p.Reviews).HasForeignKey(r => r.PatientId).OnDelete(DeleteBehavior.NoAction);
           builder.HasOne(r => r.Appointment).WithMany().HasForeignKey(r => r.AppointmentId).OnDelete(DeleteBehavior.NoAction);
           builder.HasIndex(r => new { r.DoctorId, r.CreatedAt });

        }
    }
}
