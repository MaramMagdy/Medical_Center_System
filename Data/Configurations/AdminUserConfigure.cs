using Medical_Center_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical_Center_System.Data.Configurations
{
    public class AdminUserConfigure : IEntityTypeConfiguration<AdminUser>
    {
        public void Configure(EntityTypeBuilder<AdminUser> b)
        {
            b.HasKey(a => a.Id);
            b.Property(a => a.Role).HasMaxLength(50);
            b.Property(a => a.CreatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
            b.HasOne(a => a.User).WithOne(u => u.AdminUser).HasForeignKey<AdminUser>(a => a.UserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
