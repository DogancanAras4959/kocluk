using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.StudyData
{
    public class StudyDto : BaseEntityDto
    {
        [Required]
        public string? StudyName { get; set; }

        [Required]
        public string? Type { get; set; }

        public string? Color { get; set; }
    }
}
