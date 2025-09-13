namespace Medical_Center_System.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Doctor
{
    public int Id { get; set; }                     
    public int SpecialtyId { get; set; }
    public string ImageUrl { get; set; }
    public string Bio { get; set; }
    public string ClinicAddress { get; set; }
    public decimal ConsultationFee { get; set; }      
    public int YearsOfExperience { get; set; }
    public double AverageRating { get; set; } = 0.0;
    public int RatingCount { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; }
    public virtual Specialty Specialty { get; set; }
    public virtual ICollection<DoctorAvailability> Availabilities { get; set; } = new List<DoctorAvailability>();
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public virtual ICollection<DoctorReview> Reviews { get; set; }
    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

}
