using Medical_Center_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical_Center_System.Data.Configurations
{
    public class DoctorAvailabilityConfigure : IEntityTypeConfiguration<DoctorAvailability>
    {
        public void Configure (EntityTypeBuilder<DoctorAvailability> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartTs).HasColumnType("datetime2");
            builder.Property(x => x.EndTs).HasColumnType("datetime2");
            builder.Property(x => x.SlotDurationMinutes).HasDefaultValue(15);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.UpdatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            builder.HasOne(x => x.Doctor).WithMany(d => d.Availabilities).HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.Cascade);
            builder.HasIndex(x => new { x.DoctorId, x.StartTs, x.EndTs });
        }
    }
}
