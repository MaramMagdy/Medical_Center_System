namespace Medical_Center_System.Models;
public class DoctorReview
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public int AppointmentId { get; set; } 
    public int Stars { get; set; } // 1..5
    public string Comment { get; set; }
    public bool VerifiedPatient { get; set; } = true;
    // Indicates if the review is written by a patient who actually had an appointment with the doctor (to prevent fake reviews).

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // nav
    public virtual Doctor Doctor { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Appointment Appointment { get; set; }
}
