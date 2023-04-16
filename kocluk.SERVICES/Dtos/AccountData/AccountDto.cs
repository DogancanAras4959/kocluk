using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Dtos.AccountData
{
    public class AccountDto : BaseEntityDto
    {
        public string? AccountName { get; set; }
        public string? Password { get; set; }
        public string? RePassword { get; set; }
        public string? DisplayName { get; set; }
        public string? Image { get; set; }
        public bool IsActivation { get; set; }

        public int AccountRoleId { get; set; }
    }
}
