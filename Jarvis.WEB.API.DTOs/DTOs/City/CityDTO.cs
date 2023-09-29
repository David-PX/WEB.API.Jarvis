using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.WEB.API.DTOs.DTOs.City
{
    public class CityDTO
    {
        [Required]
        public Guid CityId { get; set; }
        [Required]
        public string? CityName { get; set; }
        [Required]
        public Guid? CountryId { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        [Required]
        public string? CreatedBy { get; set; }
        [Required]
        public DateTime? UpdatedDate { get; set; }
        [Required]
        public string? UpdatedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public string? DeletedBy { get; set; }

    }
}
