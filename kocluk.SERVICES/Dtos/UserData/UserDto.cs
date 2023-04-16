using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Dtos.RoleData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.UserData
{
    public class UserDto : BaseEntityDto
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        public string? DisplayName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? RePassword { get; set; }
        public int? RoleId { get; set; }
        public string? Image { get; set; }
        public RoleDto? role { get; set; }
    }
}
