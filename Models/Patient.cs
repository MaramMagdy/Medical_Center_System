namespace Medical_Center_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Patient
{
    public int Id { get; set; } 
    public DateTime? DateOfBirth { get; set; }
    public string Gender { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // nav
    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<Appointment> Appointments { get; set; }
    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
    public virtual ICollection<DoctorReview> Reviews { get; set; }
}
