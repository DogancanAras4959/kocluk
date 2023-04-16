using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("users")]
    public class Users : BaseEntity
    {
        public Users()
        {
            bookingList = new List<Booking>();
            examList = new List<Exams>();
            studentUserList = new List<StudentUser>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }

        [ForeignKey("role")]
        public int RoleId { get; set; }
        public string Image { get; set; }


        public Roles role { get; set; }

        public virtual ICollection<Booking> bookingList { get; set; }
        public virtual ICollection<Exams> examList { get; set; }
        public virtual ICollection<StudentUser> studentUserList { get; set; }
    }
}
