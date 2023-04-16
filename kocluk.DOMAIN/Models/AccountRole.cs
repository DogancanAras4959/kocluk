using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("accountRole")]
    public class AccountRole : BaseEntity
    {
        public AccountRole()
        {
            accountList = new List<Account>();
        }
        public string RoleName { get; set; }

        public virtual ICollection<Account> accountList { get; set; }
    }
}
