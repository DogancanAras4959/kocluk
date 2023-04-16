using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.BookingData
{
    public class BookingRequestDto : BaseEntityDto
    {
        public string? TeacherName { get; set; }
        public string? StudyName { get; set; }
        public string? StudentName { get; set; }
        public string? Content { get; set; }
        public DateTime BookingTime { get; set; }
        public bool BookingStatus { get; set; }
        public string? BookingProcess { get; set; }

    }
}
