using System.ComponentModel.DataAnnotations;

namespace Medical_Center_System.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }

}
