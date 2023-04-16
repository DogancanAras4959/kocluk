using kocluk.DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN
{
    public class koclukdb : DbContext
    {
        public koclukdb(DbContextOptions<koclukdb> options) : base(options)
        {

        }

        public virtual DbSet<Roles> roles { get; set; }
        public virtual DbSet<Users> users { get; set; }
        public virtual DbSet<Students> students { get; set; }
        public virtual DbSet<StudentUser> studentsUsers { get; set; }
        public virtual DbSet<Account> accounts { get; set; }
        public virtual DbSet<AccountRole> accountRoles { get; set; }
        public virtual DbSet<ImageFile> imagefile { get; set; }
        public virtual DbSet<ImageData> imagedatas { get; set; }
        public virtual DbSet<Studies> studies { get; set; }
        public virtual DbSet<Exams> exams { get; set; }
        public virtual DbSet<Booking> bookings { get; set; }
        public virtual DbSet<BookingRequest> bookingRequests { get; set; }
        public virtual DbSet<StudyTips> StudyTips { get; set; }
        public virtual DbSet<Place> place { get; set; }
    }
}
