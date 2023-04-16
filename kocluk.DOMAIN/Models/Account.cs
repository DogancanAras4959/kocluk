using kocluk.DOMAIN.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.DOMAIN.Models
{
    [Table("account")]
    public class Account : BaseEntity
    {
        public Account()
        {

        }

        public string AccountName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public bool IsActivation { get; set; }

        public AccountRole role { get; set; }

        [ForeignKey("role")]
        public int AccountRoleId { get; set; }
        
    }
}
