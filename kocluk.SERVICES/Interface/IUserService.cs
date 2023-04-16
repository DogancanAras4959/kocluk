using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Interface
{
    public interface IUserService : ICrudService<Users, UserDto>
    {
        //bool login(string username, string password);
        UserDto GetUserByName(string userName);
        UserDto GetUserByDisplayName(string displayName);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetUserAsync(int id);
        List<UserDto> GetUserByRole(int roleId);
        Task<UserDto> GetUserAsyncUserName(string userName);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<UserDto> InsertAsync(UserDto user);

    }
}
