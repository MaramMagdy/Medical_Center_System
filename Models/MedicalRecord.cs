namespace Medical_Center_System.Models;

public class MedicalRecord
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int CreatedByDoctorId { get; set; }
    public int? AppointmentId { get; set; }

    public DateTime VisitDate { get; set; }
    public string Summary { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // nav
    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual Appointment Appointment { get; set; }
}