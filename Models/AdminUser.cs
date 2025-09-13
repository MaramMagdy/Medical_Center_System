namespace Medical_Center_System.Models;
public class AdminUser
{
    public int Id { get; set; } 
    public string UserId { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // nav
    public virtual ApplicationUser User { get; set; }
}
