using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("booking")]
    public class Booking : BaseEntity
    {
        public Booking()
        {

        }

        public string BookingName { get; set; }

       
        [ForeignKey("student")]
        public int StudentId { get; set; }


        [ForeignKey("user")]
        public int UserId { get; set; }


        [ForeignKey("study")]
        public int StudyId { get; set; }

        [ForeignKey("place")]
        public int PlaceId { get; set; }

        public DateTime BookingTime { get; set; }
        
        public bool BookingStatus { get; set; }

        public string BookingCode { get; set; }

        public string Tip { get; set; }
        public string UserName { get; set; }
        public string StudyName { get; set; }
        public string StudentName { get; set; }

        public Users user { get; set; }
        public Students student { get; set; }
        public Studies study { get; set; }
        public Place place { get; set; }
    }
}
