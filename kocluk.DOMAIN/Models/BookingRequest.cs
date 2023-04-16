using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("bookingRequest")]
    public class BookingRequest : BaseEntity
    {
        public BookingRequest()
        {

        }

        public string TeacherName { get; set; }
        public string StudyName { get; set; }
        public string StudentName { get; set; }
        public string Tip { get; set; }
        public string Place { get; set; }
        public string Content { get; set; }
        public DateTime BookingTime { get; set; }
        public bool BookingStatus { get; set; }
        public string BookingProcess { get; set; }

    }
}
