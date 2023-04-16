using AutoMapper;
using kocluk.CORE.Repository;
using kocluk.DOMAIN.Core;
using kocluk.DOMAIN.Models;
using kocluk.SERVICES.Crud;
using kocluk.SERVICES.Dtos.UserData;
using kocluk.SERVICES.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace kocluk.SERVICES.Services
{
    public class UserService : CrudService<Users, UserDto>, IUserService
    {
        public UserService(IRepository<Users> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public override List<UserDto> GetAll()
        {
            var entities = _repository.Where(x=> x.Id > 0).ToList();
            var entityDtos = _mapper.Map<IList<Users>, List<UserDto>>(entities);
            return entityDtos;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var entities = await _repository.Where(x=> x.Id > 0).ToListAsync();
            var entityDtos = _mapper.Map<List<Users>, List<UserDto>>(entities);
            return entityDtos;
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var entities = await _repository.Where(x=> x.Id == id).SingleOrDefaultAsync();
            var entityDtos = _mapper.Map<Users, UserDto>(entities);
            return entityDtos;
        }

        public async Task<UserDto> GetUserAsyncUserName(string userName)
        {
            var entities = await _repository.Where(x => x.UserName == userName).SingleOrDefaultAsync();
            var entityDtos = _mapper.Map<Users, UserDto>(entities);
            return entityDtos;
        }

        public UserDto GetUserByDisplayName(string displayName)
        {
            var entities = _repository.Where(x => x.DisplayName == displayName).SingleOrDefault();
            var entityDto = _mapper.Map<Users, UserDto>(entities);
            return entityDto;
        }

        public UserDto GetUserByName(string userName)
        {
            var entities = _repository.Where(x => x.UserName == userName).SingleOrDefault();
            var entityDto = _mapper.Map<Users, UserDto>(entities);
            return entityDto;
        }

        public List<UserDto> GetUserByRole(int roleId)
        {
            var entities = _repository.Where(x => x.RoleId == roleId).Include("role").ToList();
            var entityDtos = _mapper.Map<List<Users>,List<UserDto>>(entities);
            return entityDtos;
        }

        public async Task<UserDto> InsertAsync(UserDto user)
        {
            var entity = _mapper.Map<UserDto, Users>(user);
            await _repository.Add(entity);
            _repository.Save();
            user.Id = entity.Id;
            return user;
        }

        public async Task<UserDto> UpdateAsync(UserDto user)
        {
            var entity = _mapper.Map<UserDto, Users>(user);
            _repository.Update(entity);
            _repository.Save();
            return user;
        }

        //public bool login(string username, string password)
        //{
        //    var entites = _repository.Where(x => x.Password == password && x.UserName == username).SingleOrDefault();
        //    var entityDto = _mapper.Map<Users, UserDto>(entites);

        //    if (entityDto != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
