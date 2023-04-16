using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Dtos.PlaceData;
using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Dtos.StudyData;
using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.BookingData
{
    public class BookingDto : BaseEntityDto
    {
        public string? BookingName { get; set; }

        public int StudentId { get; set; }

        public int UserId { get; set; }

        public int StudyId { get; set; }

        public int PlaceId { get; set; }

        public DateTime BookingTime { get; set; }
        public bool BookingStatus { get; set; }
        public string Tip { get; set; }

        public string? TextColor { get; set; }
        public string? Color { get; set; }
        public string? BookingCode { get; set; }

        public string? UserName { get; set; }
        public string? StudyName { get; set; }
        public string? StudentName { get; set; }

        public UserDto? user { get; set; }
        public StudentsDto? student { get; set; }  
        public StudyDto? study { get; set; }
        public PlaceDto? place { get; set; }
    }
}
