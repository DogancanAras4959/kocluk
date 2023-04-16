using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("studies")]
    public class Studies : BaseEntity
    {
        public Studies()
        {
            examsStudies = new List<Exams>();
            booking = new List<Booking>();
        }

        public string StudyName { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Exams> examsStudies { get; set; }
        public virtual ICollection<Booking> booking { get; set; }
    }
}
