using Medical_Center_System.Enums;

namespace Medical_Center_System.Models;

public class Payment
{
    public int Id { get; set; }
    public int? AppointmentId { get; set; }
    public int? PatientId { get; set; }

    public decimal Amount { get; set; } 
    public string Provider { get; set; }           
    public string ProviderReference { get; set; } // gateway transaction id
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public DateTime? PaidAt { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // nav
    public virtual Appointment Appointment { get; set; }
    public virtual Patient Patient { get; set; }
}
