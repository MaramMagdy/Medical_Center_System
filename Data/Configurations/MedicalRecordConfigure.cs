using Medical_Center_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical_Center_System.Data.Configurations
{
    public class MedicalRecordConfigure : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure (EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.VisitDate).HasColumnType("datetime2");
            builder.Property(m => m.Summary).HasColumnType("nvarchar(max)");
            builder.Property(m => m.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.Property(m => m.UpdatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.HasOne(m => m.Patient).WithMany(p => p.MedicalRecords).HasForeignKey(m => m.PatientId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(m => m.Appointment).WithMany().HasForeignKey(m => m.AppointmentId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(m => m.Doctor).WithMany(d => d.MedicalRecords).HasForeignKey(m => m.CreatedByDoctorId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
