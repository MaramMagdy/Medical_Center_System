using Medical_Center_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical_Center_System.Data.Configurations
{
    public class PaymentConfigure : IEntityTypeConfiguration<Payment> 
    {
        public void Configure(EntityTypeBuilder<Payment> b)
        {
            b.HasKey(p => p.Id);
            b.Property(p => p.Amount).HasColumnType("decimal(12,2)").IsRequired();
            b.Property(p => p.Provider).HasMaxLength(100);
            b.Property(p => p.ProviderReference).HasMaxLength(200);
            b.Property(p => p.Status).HasMaxLength(50).HasConversion<string>();
            b.Property(p => p.PaidAt).HasColumnType("datetime2");
            b.Property(p => p.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");

            b.HasOne(p => p.Appointment).WithMany().HasForeignKey(p => p.AppointmentId).OnDelete(DeleteBehavior.Restrict);
            b.HasOne(p => p.Patient).WithMany(pt => pt.Payments).HasForeignKey(p => p.PatientId).OnDelete(DeleteBehavior.Restrict);

            b.HasIndex(p => p.AppointmentId);
        }
    }
}
