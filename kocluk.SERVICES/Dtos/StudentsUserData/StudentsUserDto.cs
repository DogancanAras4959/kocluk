using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.StudentsUserData
{
    public class StudentsUserDto : BaseEntityDto
    {
        public int StudentId { get; set; }
        public int UserId { get; set; }

        public UserDto user { get; set; }
        public StudentsDto student { get; set; }
    }
}
