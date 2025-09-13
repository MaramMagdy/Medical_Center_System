namespace Medical_Center_System.Models;

public class DoctorAvailability
{
    public int Id { get; set; } 
    public int DoctorId { get; set; }
    public DateTime StartTs { get; set; }
    public DateTime EndTs { get; set; }
    public int SlotDurationMinutes { get; set; } = 15;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // nav
    public virtual Doctor Doctor { get; set; }
}