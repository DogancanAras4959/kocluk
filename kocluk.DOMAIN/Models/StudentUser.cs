using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("studentsUser")]
    public class StudentUser : BaseEntity
    {
        [ForeignKey("students")]
        public int UserId { get; set; }

        [ForeignKey("users")]
        public int StudentId { get; set; }
        
        
        public Students students { get; set; }
        public Users users { get; set; }
    }
}
