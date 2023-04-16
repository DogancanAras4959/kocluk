using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.RoleData
{
    public class RoleDto : BaseEntityDto
    {
        public string? RoleName { get; set; }
        public ICollection<UserDto>? userList { get; set; }
    }
}
