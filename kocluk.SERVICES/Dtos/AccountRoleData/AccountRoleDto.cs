using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Dtos.AccountData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.AccountRoleData
{
    public class AccountRoleDto : BaseEntityDto
    {
        public string RoleName { get; set; }

        public virtual ICollection<AccountDto>? accountList { get; set; }
    }
}
