using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("roles")]
    public class Roles : BaseEntity
    {
        public Roles()
        {
            userList = new List<Users>();
        }

        public string RoleName { get; set; }
        public virtual ICollection<Users> userList { get; set; }
    }
}
