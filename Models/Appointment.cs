namespace Medical_Center_System.Models;
using Medical_Center_System.Enums;

public class Appointment
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public string CreatedByUserId { get; set; } // ApplicationUser that created it (patient or admin)
    public int? ParentAppointmentId { get; set; } // for reschedule/follow-up

    public DateTime ScheduledStart { get; set; }
    public DateTime ScheduledEnd { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Scheduled;

    public string Reason { get; set; } // optional short reason/comment

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // navigation
    public virtual Doctor Doctor { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual ApplicationUser CreatedByUser { get; set; }
    public virtual Appointment ParentAppointment { get; set; }
    public virtual ICollection<Appointment> RescheduledAppointments { get; set; }

}
