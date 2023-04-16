using AutoMapper;
using kocluk.CORE.Repository;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.AccountData;
using kocluk.SERVICES.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Services
{
    public class AccountService : CrudService<Account, AccountDto>, IAccountService
    {
        public AccountService(IRepository<Account> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public AccountDto getUserByName(string userName)
        {
            var entity = _repository.Where(x => x.AccountName == userName).Include("role").SingleOrDefault();
            var entityDto = _mapper.Map<Account, AccountDto>(entity);
            return entityDto;
        }

        public bool login(string username, string password)
        {
            var entity = _repository.Where(x => x.Password == password && x.AccountName == username).SingleOrDefault();
            var entityDto = _mapper.Map<Account, AccountDto>(entity);
            return entityDto != null ? true : false;         
        }
    }
}
