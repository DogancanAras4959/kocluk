using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("place")]
    public class Place : BaseEntity
    {
        public Place()
        {
            students = new List<Students>();
            booking = new List<Booking>();
        }

        public string PlaceName { get; set; }

        public virtual ICollection<Students> students { get; set; }
        public virtual ICollection<Booking> booking { get; set; }
    }
}
