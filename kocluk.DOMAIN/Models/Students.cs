using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("students")]
    public class Students : BaseEntity 
    {
        public Students()
        {
            examsStutends = new List<Exams>();
            bookingList = new List<Booking>(); 
            studentUserList = new List<StudentUser>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string StudentName { get; set; }
        public string Image { get; set; }
        public string ClassLevel { get; set; }
        public string CountryId { get; set; }
        public string Branch { get; set; }
        public string Area { get; set; }
        public string Phone { get; set; }
        public string School { get; set; }
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public string ParentAddress { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }
        public Users user { get; set; }

        [ForeignKey("place")]
        public int PlaceId { get; set; }
        public Place place { get; set; }
        public virtual ICollection<Exams> examsStutends { get; set; }
        public virtual ICollection<Booking> bookingList { get; set; }
        public virtual ICollection<StudentUser> studentUserList { get; set; }


    }
}
