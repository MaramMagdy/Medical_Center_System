namespace Medical_Center_System.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string DisplayName { get; set; }
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // navigation
    public virtual Doctor Doctor { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual AdminUser AdminUser { get; set; }
}
