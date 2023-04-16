using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Dtos.BookingData;
using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.PlaceData
{
    public class PlaceDto
    {
        public string? PlaceName { get; set; }

        public virtual ICollection<UserDto>? users { get; set; }
        public virtual ICollection<StudentsDto>? students { get; set; }
        public virtual ICollection<BookingDto>? booking { get; set; }
    }
}
