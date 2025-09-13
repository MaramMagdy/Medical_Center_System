using Medical_Center_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medical_Center_System.Data.Configurations
{
    public class ApplicationUserConfigure : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {            
            builder.Property(u => u.DisplayName).HasMaxLength(150);
            builder.Property(u => u.IsActive).HasDefaultValue(true);
        }

    }
}
