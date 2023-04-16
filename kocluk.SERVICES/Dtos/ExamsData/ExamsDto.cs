using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Dtos.StudyData;
using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.ExamsData
{
    public class ExamsDto : BaseEntityDto
    {
        public int StudyId { get; set; }
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public int Point { get; set; }
        public DateTime ExamDate { get; set; }
        public DateTime FinishTime { get; set; }
        public bool IsDoing { get; set; }

        public StudyDto? study { get; set; }
        public StudentsDto? student { get; set; }
        public UserDto? teacher { get; set; }
    }
}
