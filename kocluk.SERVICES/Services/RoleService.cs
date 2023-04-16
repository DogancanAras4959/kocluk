using AutoMapper;
using kocluk.CORE.Repository;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.RoleData;
using kocluk.SERVICES.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Services
{
    public class RoleService : CrudService<Roles, RoleDto>, IRoleService
    {
        public RoleService(IRepository<Roles> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
