using Medical_Center_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical_Center_System.Data.Configurations
{
    public class AppointmentConfigure : IEntityTypeConfiguration<Appointment>
    {
        public void Configure (EntityTypeBuilder<Appointment> b)
        {
            b.HasKey(a => a.Id);

            b.Property(a => a.ScheduledStart).HasColumnType("datetime2");
            b.Property(a => a.ScheduledEnd).HasColumnType("datetime2");
            b.Property(a => a.Reason).HasMaxLength(1000);
            b.Property(a => a.Status).HasMaxLength(50).HasConversion<string>();
            b.Property(a => a.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");

            b.HasOne(a => a.Doctor).WithMany(d => d.Appointments).HasForeignKey(a => a.DoctorId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(a => a.Patient).WithMany(p => p.Appointments).HasForeignKey(a => a.PatientId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne<ApplicationUser>().WithMany().HasForeignKey(a => a.CreatedByUserId).OnDelete(DeleteBehavior.NoAction);

            b.HasOne(a => a.ParentAppointment).WithMany(a => a.RescheduledAppointments).HasForeignKey(a => a.ParentAppointmentId).OnDelete(DeleteBehavior.Restrict);


            b.HasIndex(a => new { a.DoctorId, a.ScheduledStart });

        }
    }
}
