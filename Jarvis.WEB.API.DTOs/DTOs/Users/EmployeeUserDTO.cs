using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.WEB.API.DTOs.DTOs.Users
{
    public class EmployeeUserDTO
    {
        [Required(ErrorMessage = "Names are required")]
        public string? Names { get; set; }
        [Required(ErrorMessage = "LasNames are required")]
        public string? LastNames { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Supervisor is required")]
        public Guid? SupervisorId { get; set; }

        public string? UserId { get; set; }
        [Required(ErrorMessage = "Academic Area is required")]
        public string? AcademicAreaId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string? DeletedBy { get; set; }
    }
}
