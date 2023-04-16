using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.StudentsData
{
    public class StudentsDto : BaseEntityDto
    {
        [Required]
        public string? StudentName { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Image { get; set; }

        [Required]
        public string? ClassLevel { get; set; }
       
        [Required]
        public string? CountryId { get; set; }
       
        public string? Branch { get; set; }
     
        [Required]
        public string? Area { get; set; }
     
        [Required]
        public string? Phone { get; set; }
      
        [Required]
        public string? School { get; set; }
      
        [Required]
        public string? ParentName { get; set; }
     
        [Required]
        public string? ParentPhone { get; set; }
     
        [Required]
        public string? ParentAddress { get; set; }

        public int? UserId { get; set; }
        public UserDto? user { get; set; }
    }
}
