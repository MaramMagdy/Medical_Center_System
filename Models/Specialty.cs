namespace Medical_Center_System.Models;
public class Specialty
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // nav
    public virtual ICollection<Doctor> Doctors { get; set; }
}