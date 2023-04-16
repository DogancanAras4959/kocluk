using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.AccountData;
using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Interface
{
    public interface IAccountService : ICrudService<Account, AccountDto>
    {
        bool login(string username, string password);
        AccountDto getUserByName(string userName);
    }
}
